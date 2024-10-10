# My .NET Core and Angular Solution

This is a complete solution that uses **.NET Core** for the back-end (API) and **Angular** for the front-end. The project is designed as an example of clean architecture, layer separation, and development best practices.

## Project Structure

### Backend (API)

The backend project is developed in **.NET Core 8.0**. It provides a series of RESTful endpoints to interact with the database (in this case, an API "https://hub.dummyapis.com/employee") and serve the necessary data to the front-end.

### Frontend (Angular)

The frontend application is built with **Angular 16**. It is a Single Page Application (SPA) using the MVC framework that consumes the REST services provided by the backend.

## Prerequisites

Before starting, make sure you have the following installed:

- [.NET Core SDK 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Node.js (v14 or higher)](https://nodejs.org/)
- [Angular CLI](https://angular.io/cli)

## Project Setup

Follow these steps to set up and run the project on your local environment.

### Clone the Repository

```bash
git clone https://github.com/EdisonRuiz/Thales_DotNet_Developer_Test
cd my-repository
```

#### Backend: .NET Core API
1. Navigate to the backend directory:

```bash
cd Thales_DotNet_Developer_Test.Server
```

2. Restore the NuGet packages (From Visual Studio, 'Restore NuGet Packages') or use the following command:

```bash
dotnet restore
```
3. Run the project:

```bash
dotnet run
```
#### Frontend: Angular App
1. Navigate to the frontend directory:
```bash
cd ../thales_dotnet_developer_test.client
```

2. Install the Node.js dependencies:
```bash
npm install
```

3. Run the Angular application:
```bash
ng serve
```

### The application will be available at http://localhost:4200.


This version maintains the structure and instructions from the original while providing a clear guide for English-speaking users.


![image](https://github.com/user-attachments/assets/8289f986-f41b-41c9-987d-4bda28e67739)

![image](https://github.com/user-attachments/assets/5978cc6f-dff6-4f0a-b8a2-bc485fc8e56a)

