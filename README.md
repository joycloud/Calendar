# **Calendar(行事曆時間倒數程式)**

**技術：Html、Jquery、Sass、C#(WinForm)**

**1. 設定行程_Web畫面**
* 功能：新增、修改、刪除
* 欄位：No、Title、Remark、Start Date、End Date、Open、Delete
* 儲存檔案格式：Json

![](https://github.com/joycloud/Calendar/blob/main/Calendar/img/01.PNG)


**2. 日期選擇器**

![](https://github.com/joycloud/Calendar/blob/main/Calendar/img/02.PNG)

**3. 存檔規則**

![](https://github.com/joycloud/Calendar/blob/main/Calendar/img/03.PNG)

**4. 開機執行畫面_WinForm**

將exe檔丟置開機資料夾就會開機時啟動，程式已設定Timer因此每秒會讀取已儲存的Json檔，並計算時間的自動倒數，若之後有在Web頁面修改行程資料，則倒數畫面也會自動更新。

![](https://github.com/joycloud/Calendar/blob/main/Calendar/img/04.PNG)

**5. 執行程式icon**

因為不想再工具列佔一個位置，所以最小化後不會出現在工具列上，但右下角有產生icon，雙擊兩下程式就可以叫出來。

![](https://github.com/joycloud/Calendar/blob/main/Calendar/img/05.PNG)
