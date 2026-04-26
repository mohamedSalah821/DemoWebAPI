# Demo API - 3 Layer Architecture 🧱

This project is a demo ASP.NET Core Web API built using **3-Layer Architecture** with implementation of **Unit of Work, Dependency Injection, and SOLID principles** to achieve clean, maintainable, and scalable backend design.

---

## 🚀 Project Overview

This project demonstrates how to structure a backend application using layered architecture to separate concerns and improve maintainability. It follows enterprise-style backend design principles commonly used in real-world applications.

---

## 🧱 Architecture Layers

### 1️⃣ Presentation Layer (API)
Handles HTTP requests and responses, contains Controllers, and acts as the entry point of the system.

### 2️⃣ Business Logic Layer (BLL)
Contains business logic and rules, processes data before sending it to DAL, and acts as a bridge between API and DAL.

### 3️⃣ Data Access Layer (DAL)
Handles database operations using Entity Framework Core and implements repositories and Unit of Work.

---

## 📁 Project Structure

Demo-Api-3layer-architecture  
├── API (Presentation Layer)  
├── BLL (Business Logic Layer)  
├── DAL (Data Access Layer)

---

## ⚙️ Technologies Used

- ASP.NET Core Web API  
- Entity Framework Core  
- SQL Server  
- C#

---

## 🔧 Design Patterns & Principles

### Unit of Work Pattern
Used to manage database transactions and coordinate multiple repositories as a single unit to ensure data consistency.

### Dependency Injection (DI)
Used to inject services and repositories into classes to achieve loose coupling and improve testability.

### SOLID Principles
Applied throughout the project to ensure clean architecture:
- Single Responsibility Principle (SRP)
- Open/Closed Principle (OCP)
- Liskov Substitution Principle (LSP)
- Interface Segregation Principle (ISP)
- Dependency Inversion Principle (DIP)

---

## 🔄 Application Flow

Client Request → API Controller → Business Logic Layer (BLL) → Unit of Work (DAL) → Database  
Response ← API Controller ← BLL ← DAL ← Database

---

## 🎯 Key Features

- Clean separation of concerns  
- Scalable and maintainable structure  
- Unit of Work implementation  
- Dependency Injection usage  
- SOLID principles applied  
- Organized backend architecture  

---

## 🧠 Purpose of the Project

This project was built for learning and practicing:
- 3-Layer Architecture design  
- Backend system structuring  
- Unit of Work pattern  
- Dependency Injection in ASP.NET Core  
- SOLID principles in real applications  

---

## 📌 Notes

- This is a learning/demo project  
- Can be upgraded into Clean Architecture  
- Can be extended with DTOs and AutoMapper  
- Can support authentication (JWT) in future  

---

## 👨‍💻 Author

Mohamed Salah
