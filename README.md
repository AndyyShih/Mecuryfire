# Mecuryfire

## 測驗說明
架構採用3+1層結構，ORM採用Dapper，因時間有限，僅完成新增使用者的API，以下為各層說明：

* Mecuryfire 
程式進入點、Controller(API)、DI註冊

* BusinessRule
商業邏輯、動態方法

* Commom
共同方法、Enum、靜態方法

* DataAccess
資料庫相關操作、Response Model

## 尚未解決的Bug
1. 新增使用者的T-SQL是成功的，但紀錄Log的預存程序寫入有問題，還沒改好
