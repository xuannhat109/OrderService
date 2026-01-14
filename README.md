Orders Microservice

This project is a .NET 8 Orders Microservice built using Hexagonal Architecture (Ports & Adapters).
It provides a simple REST API to manage orders with SQLite as the database.

📌 Architecture

The project follows Hexagonal Architecture to keep business logic independent from frameworks and infrastructure.

OrdersService
│
├── Orders.Domain         (Core business)
│   └── Entities
│       └── Order.cs
│
├── Orders.Application    (Use cases)
│   ├── Ports
│   │   ├── IOrderRepository.cs
│   │   └── IOrderService.cs
│   └── Services
│       └── OrderService.cs
│
├── Orders.Infrastructure (Adapters - Database)
│   ├── Data
│   │   └── OrdersDbContext.cs
│   └── Repositories
│       └── OrderRepository.cs
│
├── Orders.API            (REST API)
│   ├── Controllers
│   │   └── OrdersController.cs
│   └── Program.cs
│
└── Orders.Tests          (Unit Tests)

⚙️ Tech Stack

.NET 8

ASP.NET Core Web API

Entity Framework Core

SQLite

Swagger (Swashbuckle)

xUnit & Moq (Unit Testing)
