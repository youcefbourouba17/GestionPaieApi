# Getting Started

## Prerequisites
Ensure you have the following installed:
- .NET 6.0 or higher
- SQL Server
- Entity Framework Core tools

## Setup Instructions
Follow these steps to get the project running:

### 1. Clone the Repository
```bash
git clone <repository-url>
cd <project-folder>
```

### 2. Update the Database Connection
Modify the connection string in the `appsettings.json` file to point to your SQL Server instance:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=<your-server>;Database=<your-database>;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```

### 3. Apply Migrations and Seed the Database
The application will automatically migrate and seed the database during startup. If you encounter issues or need to re-run migrations, use the following commands:
```bash
dotnet ef database update
```

### 4. Run the Application
Start the application using:
```bash
dotnet run
```

### 5. Access Swagger Documentation
Swagger UI will be available at:
```
https://localhost:<port>/swagger
```

### Troubleshooting
- If database seeding fails, check the error logs in the console.
- Ensure that the database server is running and accessible.

### DATA BASE
![Class Diagram0](https://github.com/user-attachments/assets/bc7d2102-42fd-4a89-ae64-cb940a5506b0)




