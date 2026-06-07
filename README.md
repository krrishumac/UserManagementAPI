# User Management API

A RESTful API built with ASP.NET Core Web API (.NET 10) for managing user information. The application provides user management functionality through CRUD operations and demonstrates API validation, middleware implementation, authentication, logging, and exception handling.

---

## Features

### User Management

* Create new users
* Retrieve all users
* Retrieve a user by ID
* Update user information
* Delete users

### Validation

* Required field validation
* Email format validation
* Input validation using Data Annotations

### Middleware

* Request and response logging
* Global exception handling
* Token-based authentication

### API Documentation

* Swagger UI integration
* OpenAPI support

---

## Technology Stack

* ASP.NET Core Web API (.NET 10)
* C#
* Swagger / OpenAPI
* Middleware Architecture
* Git & GitHub

---

## Project Structure

```text
UserManagementAPI
│
├── Controllers
│   └── UsersController.cs
│
├── Models
│   └── User.cs
│
├── Middleware
│   ├── LoggingMiddleware.cs
│   ├── ErrorHandlingMiddleware.cs
│   └── AuthenticationMiddleware.cs
│
├── Program.cs
├── appsettings.json
└── UserManagementAPI.csproj
```

---

## API Endpoints

| Method | Endpoint          | Description             |
| ------ | ----------------- | ----------------------- |
| GET    | `/api/users`      | Retrieve all users      |
| GET    | `/api/users/{id}` | Retrieve a user by ID   |
| POST   | `/api/users`      | Create a new user       |
| PUT    | `/api/users/{id}` | Update an existing user |
| DELETE | `/api/users/{id}` | Delete a user           |

---

## Sample Request

### Create User

```json
{
  "name": "John Doe",
  "email": "john@example.com",
  "department": "IT"
}
```

### Sample Response

```json
{
  "id": 1,
  "name": "John Doe",
  "email": "john@example.com",
  "department": "IT"
}
```

---

## Middleware Pipeline

The application uses a custom middleware pipeline configured in the following order:

1. Error Handling Middleware
2. Authentication Middleware
3. Logging Middleware

This configuration ensures that exceptions are handled consistently, requests are authenticated before reaching endpoints, and request/response activity is logged for auditing purposes.

---

## Authentication

Protected endpoints require a valid authorization token.

Example:

```http
Authorization: Bearer my-secret-token
```

Requests without a valid token receive a **401 Unauthorized** response.

---

## Error Handling

Unhandled exceptions are intercepted by the global error-handling middleware and returned in a standardized JSON format.

Example:

```json
{
  "error": "Internal server error."
}
```

---

## Testing

The API can be tested using Swagger UI after running the application.

Swagger endpoint:

```text
https://localhost:{port}/swagger
```

---

## Getting Started

### Prerequisites

* .NET 10 SDK
* Visual Studio 2022 or later

### Run the Application

1. Clone the repository
2. Open the solution in Visual Studio
3. Build the solution
4. Run the project
5. Navigate to:

```text
https://localhost:{port}/swagger
```

to access the Swagger UI.

---

## Author

**Krish Macwan**
