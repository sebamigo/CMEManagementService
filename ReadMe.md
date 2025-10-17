# CME Management Service

> **Continuing Medical Education (CME) Management System** - A modern .NET 9.0 Web API for managing medical education courses, personnel participation, and compliance reporting.

## 🎯 Project Overview

This project demonstrates Entity Framework Core techniques and modern .NET development practices in the context of a medical education management system. The application manages doctors, nurses, education courses, and tracks participation for compliance reporting.

## 🚀 Technologies & Frameworks

- **.NET 9.0** - Latest framework version
- **Entity Framework Core 9.0** - ORM with advanced features
- **SQLite** - Lightweight database for development
- **AutoMapper 12.0** - Object mapping
- **xUnit** - Unit testing framework
- **In-Memory Database** - Fast, lightweight testing database
- **FluentAssertions** - Expressive test assertions
- **Swagger** - OpenAPI/Swagger documentation

### Migration Management
- **Code-First Migrations** with version control
- **SQL Scripts** for deployment
- **Migration History** tracking schema evolution

## 🏥 Domain Model

### Core Entities
- **Personnel** (Abstract base class)
  - **Doctor** - Medical professionals with specialties
  - **Nurse** - Nursing staff
- **EducationCourse** - CME courses with credit hours
- **PersonnelParticipation** - Junction entity with completion tracking

## 🚀 Getting Started

### Prerequisites
- .NET 9.0 SDK
- SQLite (included)

### Setup & Run
```bash
git clone [repository-url]
cd CMEManagementService
dotnet restore
dotnet run
```

### Testing
```bash
dotnet test
```

## 📋 Entity Framework Migration Commands

```bash
# Add new migration
dotnet ef migrations add __name__

# Update database
dotnet ef database update

# Generate deployment scripts
dotnet ef migrations script --output ../Ressources/DB/SQL/init_db.sql --idempotent

# Create incremental migration script
dotnet ef migrations script InitialCreate AddEmailToDoctor --output ./deploy/v2__name__.sql --idempotent
```
