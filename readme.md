# Movies API

A RESTful API built with ASP.NET Core 9.0 for managing movies and categories. This project follows a clean architecture pattern with Repository and Service layers.

## 🚀 Features

- **CRUD operations** for Movies and Categories
- **One-to-Many relationship** (Category → Movies)
- **Entity Framework Core** with SQL Server
- **AutoMapper** for DTO mappings
- **Swagger/OpenAPI** documentation
- **Data validation** with custom error messages
- **Async/await** pattern throughout

## 📋 Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/sql-server) (LocalDB, Express, or Full)
- [Git](https://git-scm.com/)

## 🛠️ Installation

### 1. Clone the repository

```bash
git clone https://github.com/JaiderValencia/moviesapi.git
cd moviesapi
```

### 2. Configure the database connection

Update the connection string in `moviesapi/appsettings.json`:

```json
{
  "ConnectionStrings": {
    "SqlConnection": "Server=localhost;Database=MoviesDB;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

### 3. Restore dependencies

```bash
dotnet restore
```

### 4. Restore local tools (EF Core CLI)

```bash
dotnet tool restore
```

## 🗄️ Database Setup

### Run migrations

Navigate to the project directory and execute:

```bash
cd moviesapi
dotnet ef database update
```

This will create the database and apply all migrations:
- `create_categories_table`
- `set_nullable_field_UpdatedAt`
- `CreateMoviesTable`

### Create a new migration (if needed)

```bash
dotnet ef migrations add MigrationName
```

### Revert migrations

```bash
dotnet ef database update PreviousMigrationName
```

## ▶️ Running the Application

### Development mode

```bash
cd moviesapi
dotnet run
```

Or use the HTTP profile (no HTTPS):

```bash
dotnet run --launch-profile http
```

The API will be available at:
- HTTP: `http://localhost:5099`
- Swagger UI: `http://localhost:5099/swagger`

### Build for production

```bash
dotnet build --configuration Release
```

## 📁 Project Structure

```
moviesApi/
├── moviesapi/
│   ├── Controllers/              # API endpoints
│   │   ├── CategoriesController.cs
│   │   └── MoviesController.cs
│   ├── DAL/                      # Data Access Layer
│   │   ├── Models/               # Entity models
│   │   │   ├── AuditBase.cs     # Base class with Id, CreatedAt, UpdatedAt
│   │   │   ├── Category.cs
│   │   │   └── Movie.cs
│   │   ├── Dtos/                 # Data Transfer Objects
│   │   │   ├── Category/
│   │   │   │   ├── CategoryDto.cs
│   │   │   │   └── CategoryUpdateCreateDto.cs
│   │   │   └── Movie/
│   │   │       ├── MovieDto.cs
│   │   │       └── MovieUpdateCreateDto.cs
│   │   └── ApplicationDbContext.cs
│   ├── Repository/               # Data access layer
│   │   ├── IRepository/
│   │   │   ├── ICategoryRepository.cs
│   │   │   └── IMovieRepository.cs
│   │   ├── CategoryRepository.cs
│   │   └── MovieRepository.cs
│   ├── Services/                 # Business logic layer
│   │   ├── IServices/
│   │   │   ├── IcategoryService.cs
│   │   │   └── IMovieService.cs
│   │   ├── CategoryService.cs
│   │   └── MovieService.cs
│   ├── MoviesMapper/             # AutoMapper profiles
│   │   └── Mapper.cs
│   ├── Migrations/               # EF Core migrations
│   ├── Program.cs                # Application entry point
│   └── appsettings.json          # Configuration
└── moviesapi.sln                 # Solution file
```

## 🔌 API Endpoints

### Categories

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/categories` | Get all categories |
| GET | `/api/categories/id/{id}` | Get category by ID |
| GET | `/api/categories/name/{name}` | Get category by name |
| POST | `/api/categories` | Create a new category |
| PUT | `/api/categories/{id}` | Update a category |
| DELETE | `/api/categories/{id}` | Delete a category |

### Movies

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/movies` | Get all movies |
| GET | `/api/movies/{id}` | Get movie by ID |
| GET | `/api/movies/name/{name}` | Get movie by name |
| POST | `/api/movies` | Create a new movie |
| PUT | `/api/movies/{id}` | Update a movie |
| DELETE | `/api/movies/{id}` | Delete a movie |

## 📝 Request/Response Examples

### Create a Category

**Request:**
```bash
POST /api/categories
Content-Type: application/json

{
  "name": "Action"
}
```

**Response:**
```json
{
  "id": 1,
  "name": "Action",
  "createdAt": "2024-11-24T10:00:00Z",
  "updatedAt": null
}
```

### Create a Movie

**Request:**
```bash
POST /api/movies
Content-Type: application/json

{
  "name": "The Matrix",
  "releaseYear": 1999,
  "duration": 136,
  "categoryId": 1
}
```

**Response:**
```json
{
  "id": 1,
  "name": "The Matrix",
  "releaseYear": 1999,
  "duration": 136,
  "categoryId": 1,
  "categoryName": "Action",
  "createdAt": "2024-11-24T10:30:00Z",
  "updatedAt": null
}
```

## 🔐 Validations

### Category Validations
- Name is required
- Name cannot exceed 100 characters
- Name must be unique

### Movie Validations
- Name is required (max 200 characters)
- Release year must be between 1900-2100
- Duration must be between 1-1000 minutes
- Category ID is required and must exist
- Movie name must be unique

## 🏗️ Architecture

This project follows a **layered architecture**:

1. **Controllers**: Handle HTTP requests/responses
2. **Services**: Business logic and validations
3. **Repository**: Data access abstraction
4. **Models**: Entity Framework entities
5. **DTOs**: Data transfer objects for API contracts

### Key Patterns Used
- **Repository Pattern**: Abstracts data access
- **Service Pattern**: Encapsulates business logic
- **Dependency Injection**: Managed via ASP.NET Core DI container
- **DTO Pattern**: Separates internal models from API contracts
- **Unit of Work**: Implemented through DbContext

## 🧰 Technologies

- **ASP.NET Core 9.0** - Web framework
- **Entity Framework Core 9.0** - ORM
- **SQL Server** - Database
- **AutoMapper 12.0** - Object mapping
- **Swashbuckle.AspNetCore** - Swagger/OpenAPI
- **C# 12** - Programming language

## 📦 NuGet Packages

```xml
<PackageReference Include="AutoMapper" Version="12.0.1" />
<PackageReference Include="AutoMapper.Extensions.Microsoft.DependencyInjection" Version="12.0.1" />
<PackageReference Include="Microsoft.AspNetCore.OpenApi" Version="9.0.11" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="9.0.0" />
<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="9.0.0" />
<PackageReference Include="Swashbuckle.AspNetCore" Version="10.0.1" />
```

## 🧪 Testing

Access the Swagger UI at `http://localhost:5099/swagger` to test all endpoints interactively.

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 📄 License

This project is open source and available under the [MIT License](LICENSE).

## 👤 Author

**Jaider Valencia**
- GitHub: [@JaiderValencia](https://github.com/JaiderValencia)

## 📞 Support

For issues or questions, please open an issue on the GitHub repository.
