# TicketingApp

### Prerequisites

#### In order to run the project you must have Visual Studio, MS SQL Server Management Studio installed.

#### Open SQL Server Management Studio Express and connect to the SQL server.
### Expand Databases.
### Right-click on the database you want to back up, then select Tasks > Back up. (This is not available for version 2018/2019)
### On the Back Up Database window, make sure the Database field contains the name of the database you want to back up.
### Select the Backup Type. By default, it is Full - leave it set to that.
### Click Remove to remove the default/last backup file name.
### Click Add to open the Select Backup Destination window.
### Click [...] next to the File Name field.
### On the Locate Database Files window, select the folder where you want the backup file to go. By default, it is ..\Microsoft SQL Server\MSSQL.1\MSSQL\Backup.
### In the File Name field, type the name for this backup, with a .bak extension. For example, xyz_20080221.bak for a backup of the XYZ database created on 21 February 2008.
### Click OK to close the Locate Database Files window.
### Click OK to close the Select Backup Destination window.
### Click OK to start the backup. The progress icon displays in the lower-left corner, and a ‘completed successfully’ message displays when it's done.


# Importing SQL Server Database :
### Step 1: Right Click on the Database folder and select “Import Data-Tier Application” and click “Next.
### Step 2: Select the file which you have exported and change the name of the database in "ticketing"
### Click next until you finish.

# Open the project in Visual Studio and connect with MS SQL Server
### Go to Tools menu > Click "Connect to Database"
### By default, the data source is selected as Microsoft SQL Server (SQL Client)
### Provide "Server name" to server name from MS SQL connection and Select our database in the dropdown as "ticketing"
### We need to verify the database connection by clicking the "Test Connection" button as shown below, Once the connection is verified you will see the "Test connection succeeded" message box.
### Once the database connection is created, then you will see the connection details in Visual Studio Server Explorer
### How do I know the connection string?

Right Click database connection > Properties > Copy "Connection string" for our reference. Also, in App.config you should add this: add name="connString".
###


