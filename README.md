# RetroRides — Retro Vehicle Museum Management System

A Windows Forms desktop application built with **.NET 8** and **Entity Framework Core** for managing a retro car & motorcycle museum. Visitors can browse the vehicle catalog, book museum visits, and purchase souvenirs — while administrators manage exhibits, products, users, and orders.

---

## Overview

RetroRides provides a complete museum management experience with role-based access:

- **Visitors** can register, log in, browse the vehicle collection, book visits, shop for souvenirs, and manage their profile.
- **Administrators** have full control over exhibits, souvenirs, orders, reservations, and user management.

---

## Features

### Visitor Features
- **Authentication** — Register and log in with username, password, email, age, and avatar
- **Vehicle Catalog** — Browse retro cars and motorcycles with images, make, model, year, and type
- **Book a Visit** — Reserve a date to visit the museum with optional notes
- **Souvenir Shop** — Purchase museum souvenirs with stock tracking
- **Checkout & Invoices** — Complete orders with delivery address and phone, and receive generated invoices
- **My Orders** — View personal reservation and order history
- **Profile Management** — Edit profile details, upload avatar, change password, or delete account
- **Responsive Design** — Login and Register forms toggle between desktop and mobile layouts

### Admin Features
- **User Management** — View all users, assign/remove admin roles, edit or delete accounts
- **Manage Exhibits** — Add, edit, and delete vehicles (cars/motorcycles) with image uploads
- **Manage Souvenirs** — Add, edit, and delete shop products with pricing and stock
- **View All Orders & Reservations** — Full visibility across all users

---

## Tech Stack

| Component | Technology |
|---|---|
| **Framework** | .NET 8 (Windows Forms) |
| **Language** | C# 12 |
| **ORM** | Entity Framework Core 8.0 |
| **Database** | SQL Server (LocalDB / SQL Express) |
| **Architecture** | Service Layer + ServiceLocator Pattern |
| **UI** | Windows Forms with custom styling |

---

## Database Schema

| Entity | Description |
|---|---|
| **User** | Username, password, email, age, avatar URL |
| **Role** | Role name (e.g. "Admin") |
| **UserRole** | Many-to-many join between User and Role |
| **Exhibit** | Vehicle with make, model, type (Car/Motorcycle), year, description, image |
| **Souvenir** | Shop product with name, price, stock quantity, image |
| **Reservation** | Museum visit booking with date, status, and notes |
| **Order** | Purchase order with delivery address, phone, and total amount |
| **OrderItem** | Line item linking an order to a souvenir with quantity and unit price |

---

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (LocalDB or SQL Express)
- Visual Studio 2022 (17.8+) with the **.NET desktop development** workload

### Setup

1. **Clone the repository**
   ```bash
   git clone https://github.com/DimitarTashkov/RetroRides.git
   cd RetroRides
   ```

2. **Configure the database connection**

   Open `RetroRides/Models/DbConfiguration/Configuration.cs` and update the connection string to match your SQL Server instance:
   ```csharp
   public static string ConnectionString = "Data Source=YOUR_SERVER;Initial Catalog=RetroRides;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;";
   ```

3. **Apply database migrations**
   ```bash
   cd RetroRides
   dotnet ef database update
   ```

4. **Run the application**
   ```bash
   dotnet run
   ```
   Or open `RetroRides.sln` in Visual Studio and press **F5**.

### Default Admin Account

An admin user is automatically seeded on first launch. Check `SeedAdmin.cs` for the default credentials.

---

## 📸 Gallery

<details>
<summary>Click to view screenshots</summary>

### Home & Navigation
![Home Form](images/home%20form.png)
![About Us](images/about%20us%20form.png)
![Contact Us](images/Contact%20us%20form.png)

### Authentication
![Login Form](images/Login%20form.png)
![Login Responsive](images/Login%20responsive.png)
![Register Form](images/Register%20form.png)
![Register Responsive](images/Register%20responsive.png)

### Museum & Shop
![Catalog Form](images/catalog%20form.png)
![Book Visit Form](images/book%20visit%20form.png)
![Store Form](images/store%20form.png)
![Checkout Form](images/checkout%20form.png)

### User Dashboard
![Profile Form](images/profile%20form.png)
![Orders & Reservations](images/orders%20form-%20reservations.png)
![Orders Generated Invoice](images/orders%20form%20invoice.png)

### Admin Panel
![Users Form](images/users%20form.png)
![Manage Vehicles](images/manage%20vehicles%20form.png)
![Manage Store](images/manage%20store%20form.png)
![Add/Edit Vehicle](images/add%26edit%20vehicle%20form.png)

### Architecture & DB
![DB Diagram](images/db%20diagram.png)

</details>

---

