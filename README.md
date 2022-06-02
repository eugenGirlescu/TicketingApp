# TicketingApp

### Prerequisites

#### In order to run the project you must have Visual Studio, MS SQL Server Management Studio installed.

#### Open SQL Server Management Studio Express and connect to the SQL server.
Expand Databases.
Right-click on the database you want to back up, then select Tasks > Back up. (This is not available for version 2018/2019)
On the Back Up Database window, make sure the Database field contains the name of the database you want to back up.
Select the Backup Type. By default, it is Full - leave it set to that.
Click Remove to remove the default/last backup file name.
Click Add to open the Select Backup Destination window.
Click [...] next to the File Name field.
On the Locate Database Files window, select the folder where you want the backup file to go. By default, it is ..\Microsoft SQL Server\MSSQL.1\MSSQL\Backup.
In the File Name field, type the name for this backup, with a .bak extension. For example, xyz_20080221.bak for a backup of the XYZ database created on 21 February 2008.
Click OK to close the Locate Database Files window.
Click OK to close the Select Backup Destination window.
Click OK to start the backup. The progress icon displays in the lower-left corner, and a ‘completed successfully’ message displays when it's done.
