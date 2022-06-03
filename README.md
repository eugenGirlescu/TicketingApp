# TicketingApp

### Prerequisites

#### In order to run the project you must have Visual Studio, MS SQL Server Management Studio installed.

#### Open SQL Server Management Studio Express and connect to the SQL server.
#### CREATE a database with name "ticketing".
#### CREATE DATABASE ticketing;

#### Refresh, right-click on database name and select New Query
#### COPY-PASTE this query to create "register" table:
# CREATE TABLE [dbo].[register2](
	#[id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	#[firstName] [varchar](50) NOT NULL,
	#[lastName] [varchar](50) NOT NULL,
	#[email] [varchar](50) NOT NULL UNIQUE,
	#[password] [varchar](50) NOT NULL,)

# Open the project in Visual Studio and connect with MS SQL Server
### Go to Tools menu > Click "Connect to Database"
### By default, the data source is selected as Microsoft SQL Server (SQL Client)
### Provide "Server name" to server name from MS SQL connection and Select our database in the dropdown as "ticketing"
### We need to verify the database connection by clicking the "Test Connection" button , Once the connection is verified you will see the "Test connection succeeded" message box.
### Once the database connection is created, then you will see the connection details in Visual Studio Server Explorer
### How do I know the connection string?

Right Click database connection > Properties > Copy "Connection string" for your reference. Also, in App.config you should add this: add name="connString".
Also, there should be the connectionString with your details, e.g: connectionString="Data Source=LAPTOP-SQ90480J\SQLEXPRESS;Initial Catalog=ticketing;Integrated Security=True"

# After all the above steps, you can run the app.


