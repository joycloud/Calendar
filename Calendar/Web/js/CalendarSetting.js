$(document).ready(function () {
    //Read Json
    getData();

    var total_no = 1;

    //定義 getData Function
    function getData() {
        $.getJSON('./data.json', function (data) {
            //取得 json 取得所有的 dataset
            var jsonData = data.items;
            if (jsonData.length > 0) {
                $(jsonData).each(function () {
                    let row = $(this);

                    //建立tr
                    //Json資料
                    let no = row[0].no;
                    let title = row[0].title;
                    let remark = row[0].remark;
                    let sdate = row[0].sdate;
                    let edate = row[0].edate;
                    let customSwitch = 'customSwitch-' + total_no;
                    let open = row[0].open;

                    //判斷Switch
                    let switch_string = '';
                    if (open) {
                        switch_string = '<input type="checkbox" class="custom-control-input" id= ' + customSwitch + '" checked>'
                    }
                    else {
                        switch_string = '<input type="checkbox" class="custom-control-input" id= ' + customSwitch + '">'
                    }

                    // new tr 插入tbody，在建立底下td
                    let trv =
                        $(document.createElement('tr')).attr(
                            {
                                "id": 'tr-' + total_no
                            });

                    let htmlString = getHtmlString(no, title, remark, sdate, edate, switch_string, customSwitch);
                    trv.appendTo('#tb-items');
                    trv.after().html(
                        htmlString
                    );
                    //套用日期選擇棄
                    var options = {};
                    $('#sdate-' + total_no).datepicker(options);
                    $('#edate-' + total_no).datepicker(options);
                    total_no++;
                });
            }
        });
    };

    //串List String
    function getHtmlString(no, title, remark, sdate, edate, switch_string, customSwitch) {
        let request = '<td>' + no + '</td>' +
            '<td><input type="text" class="form-control" value = ' + title + '></td>' +
            '<td><input type="text" class="form-control" value = ' + remark + '></td>' +
            //sdate
            '<td><input id=sdate-' + total_no + ' value=' + sdate + '></td>' +
            //edate
            '<td><input id=edate-' + total_no + ' value=' + edate + '></td>' +
            //checkbox
            '<td><div class="custom-control custom-switch">' + switch_string +
            '<label class="custom-control-label" for=' + customSwitch + '"></label></div></td>' +
            //delete
            '<td><input type="button" class="btn btn-warning" value="Delete" onclick="deleteItem(this)" /></td>';
        return request;
    }

    $("body").on("click", "#btnAdd", function () {
        let count = $('tr').length - 1; //總列數
        let no = (count + 1);
        let customSwitch = 'customSwitch-' + total_no;
        // new tr 插入tbody，在建立底下td
        let trv =
            $(document.createElement('tr')).attr(
                {
                    "id": 'tr-' + total_no
                });

        let switch_string = '<input type="checkbox" class="custom-control-input" id= ' + customSwitch + '" checked>';
        let htmlString = getHtmlString(no, '', '', '', '', switch_string, customSwitch);
        trv.appendTo('#tb-items');
        trv.after().html(
            htmlString
        );
        //套用日期選擇棄
        var options = {};
        $('#sdate-' + total_no).datepicker(options);
        $('#edate-' + total_no).datepicker(options);
        total_no++;
    });

    //Save
    $("body").on("click", "#btnSave", function () {
        //整理成Json格式
        let data = { items: [] };
        let no_num = 1;
        let err_msg = '';


        var validateArray = [];
        //檢核
        $("#tb-items > tr").each(function () {
            let err_string = '';
            //取得資料
            let row = $(this);
            let no = row.find("td")[0].innerHTML;
            let title = row.find("td").find("input")[0].value;
            let remark = row.find("td").find("input")[1].value;
            let sdate = row.find("td").find("input")[2].value;
            let edate = row.find("td").find("input")[3].value;
            let open = row.find("td").find("input")[4].checked;
            //判斷如果有開啟，需輸入title、sdate、edate
            if (open) {
                if (title.trim() == "") {
                    err_string += 'Title、';
                }
                if (sdate.trim() == "") {
                    err_string += 'Start Date、';
                }
                if (edate.trim() == "") {
                    err_string += 'End Date、';
                }
                if (err_string.length > 0) {
                    err_string = '編號' + no + '的' + err_string.substring(0, err_string.length - 1) + '必填\n';
                    err_msg += err_string;
                }
                //暫存Array，拿來判斷時間是否重複
                validateArray.push({
                    no: no,
                    sdate: sdate,
                    edate: edate
                });
            }
        });

        //必填提示
        if (err_msg.length > 0) {
            sweetAlert(err_msg, "error");
            return;
        }

        err_msg = '';
        //檢核有開啟的項目是否時間重疊
        $("#tb-items > tr").each(function () {
            let err_string = '';
            //取得資料
            let row = $(this);
            let no = row.find("td")[0].innerHTML;
            let sdate = row.find("td").find("input")[2].value;
            let edate = row.find("td").find("input")[3].value;
            let open = row.find("td").find("input")[4].checked;

            if (open) {
                validateArray.forEach(function (value) {
                    if (no != value.no &&
                        (edate >= value.sdate && edate <= value.edate ||
                            sdate >= value.sdate && sdate <= value.edate ||
                            sdate >= value.sdate && edate <= value.edate)) {
                        err_msg += '編號' + no + '的時間重疊\n';
                    }
                });
            }
        });

        //必填提示
        if (err_msg.length > 0) {
            sweetAlert(err_msg, "error");
            return;
        }

        $("#tb-items > tr").each(function () {
            let err_string = '';
            //取得資料
            let row = $(this);
            //let no = row.find("td")[0].innerHTML;
            let no = no_num;
            let title = row.find("td").find("input")[0].value;
            let remark = row.find("td").find("input")[1].value;
            let sdate = row.find("td").find("input")[2].value;
            let edate = row.find("td").find("input")[3].value;
            let open = row.find("td").find("input")[4].checked;

            //Json Push
            data.items.push({
                no: no,
                title: title,
                remark: remark,
                sdate: sdate,
                edate: edate,
                open: open
            });
            no_num++;
        });

        //另存成Json檔
        var content = JSON.stringify(data);
        var blob = new Blob([content], { type: "text/plain;charset=utf-8" });
        saveAs(blob, "data.json");
    });
});

//sweetAlert
function sweetAlert(msg, type) {
    var showString = '';
    if (type == 'error') {
        showString = "儲存失敗!";
    }
    else if (type == 'success') {
        showString = "儲存成功!";
    }
    setTimeout(() => {
        swal("儲存失敗!", msg, type);
    }, 500);
};


//移除列表
function deleteItem(button) {
    var row = $(button).closest("tr");  //取目前tr
    var name = row.find("td").find("input")[0].value;   //Title
    if (confirm("Do you want to delete: " + name + " ?")) {
        row.remove();   //移除

        //重新計算No
        let no_num = 1;
        $("#tb-items > tr").each(function () {
            $(this).find("td")[0].innerHTML = no_num;
            no_num++;
        });
    }
};


