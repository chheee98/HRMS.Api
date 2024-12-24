# HRMS.Api .NET 8 Web API
This repository contains a scalable and maintainable .NET 8 Web API.

## Features
- Clean and modular project structure
- Integration with EF Core for database persistence
- Dependency Injection with built-in .NET Core DI
- Centralized error handling
- Extensible for additional modules and services
- Unit and integration tests (Not Started)

## Project Structure
```plaintext
src/
├── Contracts/              // DTOs for data exchange
├── Controllers/            // Handle API requests and responses
├── Data/                   // Manage dabase and data access
├── ── Entities/            // Database models
├── ── Migrations/          // Migrations files
├── ── Repositories/        // Data access logic(e.g., cache)
├── ── ── Interfaces/       // Repository Interfaces
├── Extensions/             // Extensions for Program.cs configurations
├── Helper/                 // For those Helper suchas Attrubute..
├── Mappings/               // AutoMapper configurations
├── Middlewares/            // Custom Middleware Components
├── Models/                 // Simple, shared models like config and responses
├── Services/               // Business logic implementation
├── ── Interfaces/          // Service Interfaces
