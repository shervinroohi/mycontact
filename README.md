# MyContact - Phone Book Application

A simple Phone Book application built with C# Windows Forms and SQL Server.

## Features

* Add new contacts
* Edit existing contacts
* Delete contacts
* Search contacts by name or family name
* Store and manage data using SQL Server
* Input validation for phone numbers and email addresses

## Technologies Used

* C#
* .NET Framework 4.7.2
* Windows Forms
* SQL Server
* Entity Framework 6

## Screenshots

### Main Window
![Main Window](mycontact/screenshots/main-form.png)

### Add / Edit Contact
![Add Contact](mycontact/screenshots/add-contact.png)

## Database Setup

Entity Framework will automatically create the database and tables
on the first run. Just make sure your connection string in `App.config`
is correctly configured.

## Prerequisites

* Visual Studio 2019 or later
* SQL Server 2017 or later
* .NET Framework 4.7.2

## Configuration

Update the connection string in `App.config` with your SQL Server instance name:

```xml
<connectionStrings>
  <add name="MyContactDB"
       connectionString="Data Source=YOUR_SERVER_NAME;Initial Catalog=mycontact_DB;Integrated Security=True"
       providerName="System.Data.SqlClient" />
</connectionStrings>
```

## How to Run

1. Clone the repository.
2. Configure the connection string in `App.config`.
3. Open `mycontact.sln` in Visual Studio.
4. Build and run the project.

## License

This project is licensed under the MIT License.

## Author

Developed by **Shervin Rouhi**

[![LinkedIn](https://img.shields.io/badge/LinkedIn-Connect-blue?logo=linkedin)](http://www.linkedin.com/in/shervin-rouhi-661143404)
