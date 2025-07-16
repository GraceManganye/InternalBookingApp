# Internal Resource Booking System

A simple web-based app to manage and book internal resources (e.g., meeting rooms), built using **ASP.NET Core 8 (Razor Pages)** and **SQL Server**.

-----------------------------------------------------------------------------------------------------------------------

## Features

- Add, edit, and delete resources
- Book resources with Start/End time validation
- Prevent overlapping/double bookings
- View bookings for each resource
- Form validation (server-side & client-side)



##Technologies Used

- ASP.NET Core 8 (Razor Pages)
- Entity Framework Core 8
- SQL Server (LocalDB)
- Visual Studio 2022
- SQL Server Management Studio (SSMS 21)



##Setup Instructions

### 1. Open the Solution

- Open the project in **Visual Studio 2022**
- Restore NuGet packages if prompted

### 2. Configure Connection String

Make sure `appsettings.json` contains:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=BookingAppDb;Trusted_Connection=True;"
}


##Additional Instructions 
-Click "Run or Debug" to open the application in the internet browser
-Navigate to home page and click on "Resource" to add new Reource"
-See the attached InternalBookingApp Demo pdf to view the screenshot of the working application
-See the BookingAppDB.bak to restore backup for the Internal Booking Application