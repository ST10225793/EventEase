EventEase - Venue & Event Management System
🌐 Live Application
The application is fully deployed and accessible at:
eventease-koketso-afb0d8fad9eqh0dm.southafricanorth-01.azurewebsites.net
📖 Project Overview
EventEase is a web-based solution built with ASP.NET Core MVC designed to streamline venue management and event scheduling. The project demonstrates a full migration from a local development environment to a Platform-as-a-Service (PaaS) cloud architecture on Microsoft Azure.
Key Features
Venue Management: Full CRUD functionality for venue details, capacity, and location.
Event Scheduling: Relational mapping of events to specific venues.
Cloud Integration: Real-time data storage using Azure SQL Database.
Advanced Security: Implementation of Microsoft Entra Passwordless Authentication via Managed Identities.
🛠️ Technical Stack
Framework: .NET 8 (ASP.NET Core MVC)
Database: Azure SQL Database (PaaS)
ORM: Entity Framework Core
Hosting: Azure App Service (Basic B1 Plan)
Identity: Microsoft Entra ID (Managed Identity)
🚀 Local Setup Instructions
To run this project on your local machine for marking purposes:
Clone the Repository:
Bash
git clone https://github.com/ST10225793/EventEase
Database Configuration: The project is pre-configured to use LocalDB for ease of marking.
Open appsettings.json.
Ensure the DefaultConnection points to (localdb)\\mssqllocaldb.
Apply Migrations: Open the Package Manager Console in Visual Studio and run:
PowerShell
Update-Database
Run the Application: Press F5 or click Start in Visual Studio.
🗄️ Database Schema
The database consists of three primary tables:
Venues: Stores location and capacity data.
Events: Stores event descriptions and dates (Foreign Key to Venues).
Bookings: Manages user reservations (Foreign Key to Events).
The full SQL deployment script is available in the root directory: EventEase_DatabaseScript.sql.
🛡️ Cloud Security Note
This project avoids hardcoded credentials. It utilizes System-Assigned Managed Identities to authorize the Web App to communicate with the SQL Database, ensuring that no passwords are stored in the source code or configuration files.
