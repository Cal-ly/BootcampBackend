# CoffeeBean Solution

This repository contains a solution for managing coffee beans, including an API, a library, and unit tests. The solution is structured into three main projects: CoffeeBeanAPI, CoffeeBeanLib, and CoffeeBeanTest.

## Project Structure

The solution is organized into the following projects:

1. **CoffeeBeanAPI**: A web API for managing coffee beans.
2. **CoffeeBeanLib**: A library containing the core business logic and models.
3. **CoffeeBeanTest**: A project for unit testing the CoffeeBeanLib and CoffeeBeanAPI projects.

## Projects

### CoffeeBeanAPI

**Description**: This project is a web API built using ASP.NET Core. It provides endpoints for managing coffee beans, including creating, reading, updating, and deleting coffee bean records.

**Files**:
- `CoffeeBeanAPI.csproj`: Project file containing dependencies and build configurations.
- `Program.cs`: Entry point of the application.
- `Controllers/`: Contains API controllers for handling HTTP requests.

**Dependencies**:
- `Swashbuckle.AspNetCore`: For generating Swagger documentation.

---

### CoffeeBeanLib

**Description**: This project contains the core business logic and models for the coffee bean application. It includes classes and methods for validating and managing coffee bean data.

**Files**:
- `CoffeeBeanLib.csproj`: Project file containing dependencies and build configurations.
- `CoffeeBean.cs`: Model class representing a coffee bean.
- `CoffeeBeanAlt.cs`: Alternative implementation of the CoffeeBean class with property validation.

---

### CoffeeBeanTest

**Description**: This project contains unit tests for the CoffeeBeanLib and CoffeeBeanAPI projects. It uses MSTest as the testing framework to ensure the correctness of the business logic and API endpoints.

**Files**:
- `CoffeeBeanTest.csproj`: Project file containing dependencies and build configurations.
- `Tests/`: Contains test classes and methods.

**Dependencies**:
- `Microsoft.NET.Test.Sdk`: Required for running tests.
- `MSTest.TestAdapter`: Adapter for running MSTest tests.
- `MSTest.TestFramework`: MSTest framework for writing tests.
- `Microsoft.Testing.Extensions.TrxReport`: For generating test reports.
