# Equipment Management API

Backend API for an equipment and calibration management dashboard.
The system tracks equipment, calibration schedules, calibration costs, and analytics over time.

This API provides data for a React dashboard that visualizes calibration activity and costs using charts and aggregated metrics.

---

## Tech Stack

* .NET 8
* ASP.NET Core Web API
* Entity Framework Core
* SQL Server
* xUnit (unit testing)
* Moq (mocking for tests)

---

## Architecture

This project follows a **Clean Architecture** approach with clear separation between domain logic, infrastructure, and API layers.

```
EquipmentManagement.Api
│
├── Core
│   ├── Entities
│   └── Interfaces
│
├── Application
│   ├── Services
│   └── Result<T> pattern
│
├── Infrastructure
│   ├── Repositories
│   └── Database Context (EF Core)
│
└── Api
    └── Controllers
```

### Core

The Core layer contains:

* Domain entities
* Repository interfaces

The domain is completely independent and does **not depend on EF Core or any infrastructure libraries**.

---

### Infrastructure

The Infrastructure layer implements the repository interfaces defined in Core.

It contains:

* Entity Framework DbContext
* Repository implementations
* Database configuration

Entity configuration is performed using **Fluent API in `OnModelCreating`** rather than attributes to keep the Core layer independent of EF.

---

### Application Layer

The Application layer contains business logic and service classes.

Responsibilities include:

* Processing domain operations
* Aggregating dashboard analytics
* Coordinating repository calls

All services return a **`Result<T>` pattern**, allowing consistent handling of success and error responses between layers.

Example:

```
Result<T>
    Success -> Value returned
    Failure -> Error information
```

---

### API Layer

Controllers consume the Application services and translate the `Result<T>` responses into appropriate HTTP responses.

Example flow:

```
Controller
    ↓
Application Service
    ↓
Repository Interface
    ↓
Infrastructure Implementation
```

Using `[ApiController]` enables automatic request validation and consistent API responses.

---

## Features

Current functionality:

* Equipment CRUD operations
* Server-side pagination
* Column sorting
* Category filtering
* Dashboard analytics endpoints
* Calibration cost aggregation
* Calibration counts by date range

Pagination is performed **server-side using LINQ** for efficient database queries.

---

## Dashboard Analytics

The API provides aggregated data used by the frontend dashboard including:

* Calibration cost totals
* Cost breakdown by category
* Calibration counts
* Vendor statistics

Categories include:

* Electrical
* Hydraulic
* Mechanical
* Pneumatic

---

## Authentication (Planned)

Upcoming implementation:

* JWT authentication
* Role-based authorization
* Protected endpoints

Example roles:

* Admin
* User

These roles will restrict access to certain CRUD operations.

---

## Testing

Unit testing will be implemented using:

* xUnit
* Moq

Tests will focus on:

* Service layer logic
* Business calculations
* Repository interactions

A dedicated test database will be used for integration testing scenarios.

---

## Roadmap

Upcoming work:

* Implement JWT authentication
* Add role-based authorization
* Add unit tests for services
* Add integration tests
* CI/CD pipeline with GitHub Actions
* Deploy API to Azure App Service
* Deploy database to Azure SQL

---

## Running the API

```
dotnet restore
dotnet run
```

Configure the connection string in:

```
appsettings.json
```

---

## Project Purpose

This project was built as a portfolio application to demonstrate:

* Clean Architecture in .NET
* REST API design
* Server-side data processing
* Data analytics endpoints
* Unit testing strategies
* Cloud deployment practices
