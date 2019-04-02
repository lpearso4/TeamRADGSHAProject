# TeamRADGSHAProject
Prerequisites:
  Visual Studio (2017).
  Microsoft SQL Server Management Studio.
  A decent computer/mouse/keyboard(lol).
  
Cloning Repository:
  1. Open Visual Studio
  2. Open Team Explorer and click clone.
  3. Go to "https://github.com/lpearso4/TeamRADGSHAProject", and click the green "clone/download" button
  4. Copy the URL that appears after clicking the "clone/download" button.
  5. Paste the URL in Visual Studio's Team Explorer URL input field.
  6. Click Clone.
  7. "Ta-Da"!
  
Installing Database:
  1. Open Microsoft SQL Server Managemen Studio.
  2. Create the User "teamRADGSHAUser" manually.
  3. verify the file paths "D:\SQL server\MSSQL14.MSSQLSERVER\MSSQL\DATA\RADGSHADatabase.mdf" and
    "D:\SQL server\MSSQL14.MSSQLSERVER\MSSQL\DATA\RADGSHADatabase_log.ldf" are open.
  4. Open new Query by inputting ctrl+N with the keyboard
  5. Paste in the Create Database script under repository directory "lpearso4/TeamRADGSHAProject/CreateDatabaseQuery/createDatabaseQuery"
  6. run the query (It should take under a minute, usually only a few seconds).
