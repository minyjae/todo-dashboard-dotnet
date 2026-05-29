# Todo Dashboard .NET

REST API สำหรับ Todo Dashboard สร้างด้วย ASP.NET Core 10, Entity Framework Core และ PostgreSQL

## Tech Stack

- **Runtime**: .NET 10
- **Database**: PostgreSQL 17
- **ORM**: Entity Framework Core + Npgsql
- **Auth**: JWT Bearer
- **Dev Tools**: Docker, pgAdmin 4

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- [Docker Desktop](https://www.docker.com/products/docker-desktop)
- [dotnet-ef CLI](https://learn.microsoft.com/en-us/ef/core/cli/dotnet)

## Setup

### 1. ติดตั้ง EF Core CLI (ครั้งแรกครั้งเดียว)

```bash
dotnet tool install --global dotnet-ef
```

### 2. สร้างไฟล์ `.env`

สร้างไฟล์ `.env` ที่ root ของโปรเจกต์

```env
DB_HOST=localhost
DB_PORT=5432
DB_NAME=todo-dashboard
DB_USER=admin
DB_PASSWORD=your-password

PGADMIN_EMAIL=admin@admin.com
PGADMIN_PASSWORD=admin
PGADMIN_PORT=5050

JWT_SECRET=your-super-secret-key-change-this-in-production
```

### 3. รัน Database

```bash
docker-compose up -d
```

| Service  | URL                    |
|----------|------------------------|
| PostgreSQL | `localhost:5432`     |
| pgAdmin  | http://localhost:5050  |

> เชื่อมต่อ PostgreSQL ใน pgAdmin ให้ใช้ host เป็น `db` (ชื่อ Docker service) ไม่ใช่ `localhost`

### 4. สร้างและ Apply Migration

```bash
# สร้าง migration ครั้งแรก
dotnet ef migrations add InitialCreate

# Apply migration เข้า database
dotnet ef database update
```

### 5. รัน API

```bash
dotnet run
```

API พร้อมใช้งานที่ `http://localhost:5080`

---

## Database Commands

| Command | ใช้เมื่อ |
|---------|---------|
| `dotnet ef migrations add <Name>` | เพิ่มหรือแก้ไข Entity แล้วต้องการ sync กับ DB |
| `dotnet ef database update` | Apply migration ที่ยังไม่ได้รันเข้า DB |
| `dotnet ef migrations remove` | ลบ migration ล่าสุด (ยังไม่ได้ apply) |
| `dotnet ef database update 0` | Roll back migration ทั้งหมด |

---

## API Endpoints

### Users

| Method | Path | Description | Auth |
|--------|------|-------------|------|
| `POST` | `/api/users/register` | สมัครสมาชิก | - |
| `POST` | `/api/users/login` | เข้าสู่ระบบ → รับ JWT token | - |
| `GET`  | `/api/users/{id}` | ดึงข้อมูล user | - |

### Lists

| Method | Path | Description | Auth |
|--------|------|-------------|------|
| `GET`    | `/api/lists/user/{userId}` | ดึง lists ของ user | JWT |
| `POST`   | `/api/lists` | สร้าง list | JWT |
| `PUT`    | `/api/lists/{id}` | แก้ไข list | JWT |
| `DELETE` | `/api/lists/{id}` | ลบ list | JWT |

### การใช้ JWT Token

หลัง login ให้นำ token ที่ได้ใส่ใน Header:

```
Authorization: Bearer <token>
```

---

## Project Structure

```
Domain/           Entity + Repository/Service interfaces
Application/      Service implementations + DTOs
Infrastructure/   AppDbContext + Repository implementations
Controllers/      API endpoints
Utils/            PasswordHelper, JwtHelper
docs/             เอกสารอธิบาย concept ต่างๆ
```
