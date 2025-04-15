# Ryanair TravelLabs - ROCS Hiring Test - Tycoon Factory

# Developer: Elizabeth Romero
# Project Architecture Overview: Rocs

The project Rocs is structured following Domain-Driven Design (DDD) and SOLID principles, with a clear separation of concerns across different layers.

# Projects and Layers

1. Domain Layer (Rocs.Domain)
This is the core of your application and contains:

- Entities:
* Worker
* Activity
* ActivityType

Each entity uses private constructors and static factory methods like Create() to enforce business rules during instantiation. This pattern aligns with the Factory Method and encapsulates domain logic.

- Domain Services:
* ReviewConflictsService: contains domain logic to detect scheduling conflicts including overlapping activities and insufficient rest periods before and after existing activities. It returns a list of conflict messages as strings.

This layer is fully decoupled from infrastructure and application logic, applying the Single Responsibility and Open/Closed principles.

##

2. Application Layer (Rocs.Application)
Acts as a bridge between the Web API and the domain. It contains:

- Interfaces:
* IActivityAppService
* IActivityTypeAppService
* IWorkerAppService

- Implementations:
* ActivityAppService: orchestrates the creation and updating of activities, validating input, loading domain entities, invoking conflict checks, and delegating persistence to repositories.

This layer serves as a Facade and applies the Dependency Inversion Principle by relying on abstractions rather than concrete implementations.

##

3. Infrastructure Layer (Rocs.Infrastructure)
Handles database access and configuration using Entity Framework Core. Includes:

- RocsContext: implementation of DbContext
- Data seeding with HasData()
- Repository implementations

This layer follows the Repository Pattern, isolating database logic and maintaining clean architecture boundaries.

##

4. WebAPI Project (Rocs.Api)
The presentation layer of the application:. Includes:

- Controllers to handle HTTP requests
- Dependency injection of application services

Controllers delegate all business logic to the application layer, adhering to the Controller-Service pattern and maintaining Separation of Concerns.

##

5.  DTO Layer (Rocs.DTOs)
This layer defines Data Transfer Objects (DTOs) used by the API to communicate between layers. Includes:

- NewActivity: Used to create a new Activity via the API
- UpdateActivity: Used to update an existing activity 
(These classes act as Form Objects or API Contracts, separating the shape of incoming/outgoing data from domain models.)

- WorkerActivity: Represents the result of a raw SQL query, used on the GetTop10Workers use case.

**
6. Testing Projects

- Rocs.Domain.Test: This project focuses on testing your Domain Layer in isolation.
Tests included: 
* Entity creation rules for: Worker, Activit and ActivityType
* Validation rules for service ReviewConflictsService: To confirm when there are overlaps and required rest periods.

- Rocs.Application.Test: This project tests the Application Layer in isolation from the Web API and infrastructure.
Tests included:
Full lifecycle tests for:
* AddActivity
* UpdateActivity
(Use of Moq to mock repositories and domain services)



