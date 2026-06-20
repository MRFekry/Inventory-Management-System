# 📦 Inventory Management System (IMS)

[![Framework](https://img.shields.io/badge/.NET-10.0-blueviolet?style=flat-square&logo=dotnet)](https://dotnet.microsoft.com/)
[![UI Architecture](https://img.shields.io/badge/Blazor-Static%20%26%20Interactive%20SSR-blue?style=flat-square&logo=blazor)](https://learn.microsoft.com/en-us/aspnet/core/blazor/)
[![Design Pattern](https://img.shields.io/badge/Architecture-Clean%20%2F%20DDD-success?style=flat-square)]()

A robust, enterprise-grade **Inventory Management System** built using modern **C#** and **Blazor (.NET 10)**. This project follows clean engineering principles, decoupling core business logic from UI frameworks and data persistence mechanics.

*Developed as part of advanced professional training in modern Blazor architectural design patterns.*

---

## 🏗️ Architectural Blueprint

The application leverages a strict **Clean Architecture / Domain-Driven Design (DDD)** breakdown to ensure high testability, maintenance isolation, and scalability:

```text
├── 📂 IMS.CoreBusiness       # Pure Domain Model Layer (Products, Inventories)
├── 📂 IMS.UseCases          # Orchestration Layer (Application Logic, Interactors)
├── 📂 IMS.Plugins           # Data Drivers & Adapters (EF Core, SQL Server Infrastructure)
└── 📂 IMS.WebApp            # Presentation Layer (Blazor Web UI Architecture)
