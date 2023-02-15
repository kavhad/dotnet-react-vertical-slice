# MinimalAPI project template
An opinionated .Net project template for .NET Minimal APIs and Vertical Slice Architecture.

### Build status
[![.NET](https://github.com/kavhad/dotnet-project-templates/actions/workflows/dotnet.yml/badge.svg)](https://github.com/kavhad/dotnet-project-templates/actions/workflows/dotnet.yml)


## Vertical Slice Architecture
Vertical slice architecture is a software design approach that involves creating small, self-contained modules for individual features of an application. This allows for parallel development, reduced dependencies, and improved agility in large and complex applications. The benefits include improved maintainability, scalability, and flexibility, as well as faster time-to-market and greater developer productivity.

## .NET Minimal Api
.NET Minimal API is a new feature introduced in .NET 6 that simplifies the development of lightweight web APIs by allowing developers to define routes and request/response handling directly in the code using concise syntax. It provides a simplified hosting model and is ideal for building simple APIs, microservices, or backend services. The benefits of .NET Minimal API include faster development, reduced complexity, and improved performance.


### Folder structure

Here's a folder structure for the MinimalAPI project:

```
MinimalAPI/                 # Project template root directory.
|- Features/                # A vertical slice is defined as a subfolder in this folder.
   | - Todo                 # Todo-feature, a starting implementation of a todo-app api.  
   | - Swagger              # Swagger-feature, automatically generates Open API definition for all REST APIs in the project.           
|- IApiBuilder.cs           # Interface that enable each vertical slice to define it's own routing rules.
|- IModelBuilder.cs         # Interface that enable each vertical slice to define it's own models within the database, although all models are in one shared database.
|- AppDbContext.cs          # The application db context which is an abstraction over a shared database for all vertical slices. 
|- appsettings.json         # Global application configuration.
|- Program.cs               # Main entry of application
|- FeatureRegistrator       # Scans assembly for classes that register features
|- GlobalErrorHandler.cs    # API error handling
MinimalAPI.Tests/           # Unit tests project

