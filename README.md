# .NET/React.JS with Vertical Slice Architecture
Boilerplate code for fullstack development with .NET and React that implements
Vertical Slice Architecture. Each slice runs through 
both backend and frontend so that frontend and backend code for features live side by side. 

Further we reduce the need to write client API glue code by using SwaggerGen and
the npm package openapi-typescript-codegen
(https://github.com/ferdikoomen/openapi-typescript-codegen).

### Build status
[![.NET](https://github.com/kavhad/dotnet-project-templates/actions/workflows/dotnet.yml/badge.svg)](https://github.com/kavhad/dotnet-project-templates/actions/workflows/dotnet.yml)


## Benifits of Vertical Slice Architecture
Vertical slice architecture is a software design approach that involves creating small, 
self-contained modules for individual features of an application. This allows for parallel development, 
reduced dependencies, and improved agility in large and complex applications. The benefits 
include improved maintainability, scalability, and flexibility, as well as faster time-to-market 
and greater developer productivity.

### Directory structure
The project source code is under the __src__-directory where both frontend and backend code
is side by side firs

```
DotnetReactVerticalSlice            # Project directory
  |- src
    |- Features/                    # All features are defined here
      | - Todo                      # Todo-feature 
        | - Backend                 # Backend part of feature.
        | - Frontend                # Frontend part of code.
    |- Backend                      # Backend Main and "infrastructure" code.
      |- Swagger                    # contains SwaggerGen registration files, automatically generates Open API definition for all REST APIs in the project.           
      |- IApiBuilder.cs             # Interface that enable each vertical slice to define it's own routing rules.
      |- IModelBuilder.cs           # Interface that enable each vertical slice to define it's own models within the database, although all models are in one shared database.
      |- AppDbContext.cs            # The application db context which is an abstraction over a shared database for all vertical slices. 
      |- appsettings.json           # Global application configuration.
      |- Program.cs                 # Main entry of application
      |- FeatureRegistrator.cs      # Scans assembly for classes and register feature backend-part.
      |- GlobalErrorHandler.cs      # API error handling.
    |- Frontend                     # Frontend Main and "infrastructure" code.
      |- index.tsx                  # Composition Root for the forntend.
      |- router.tsx                 # Setup url routing for React app (Composition Root)
DotnetReactVerticalSlice.Tests/     # Unit tests project
```


## Feature Registration
The backend part of a feature can be registered without any change to the main entry-method. Instead 
registration is done by assembly scanning classes and methods that adopt following specific convention:

A static class with a name that ends with __Startup__ and
a static method called __Register__ that takes a single parameter of type __IServiceCollection__.
Here's an example with some explanation of what is being registered and why.
```csharp
public static class TodoStartup
{
    public static void Register(this IServiceCollection services)
    {
        //Features that requires data-model for persistence using EF Core can 
        //implement and register a IModelBuilder dependency. The models 
        //will be added to AppDbContext.
        services.AddSingleton<IModelBuilder, TodoModelBuilder>(); 
        //Features that exposes new api endpoints can implement and register a
        //IApiBuilder to be automatically wired during app startup.
        services.AddSingleton<IApiBuilder, TodoApiBuilder>();
    }
}
```

Frontend registration has to be done centrally in the main part of the frontend.

## Running Project From Command Line
To start the development backend and frontend server run the following command in your shell:

```shell
dotnet watch --project DotnetReactVerticalSlice
```
This will start the development server and a watch process that will hot reload any
classes whose source has been changed. In cases where classes have indirect dependencies 
a hot reloaded might not occur and so a manual restart of the processes might be needed. 


## Publish project to directory


```shell
dotnet publish
```
The resulting artifact-directory will be in __/bin/&lt; Debug | Release &gt;/net7.0/publish__
and the React build artifact will be in the subdirectory __wwwroot__.

## Generate Frontend Client Code For API 
To automatically generate typescript client code from OpenAPI (swagger) definition run the following
and make sure backend development server is running.

```shell
cd DotnetReactVerticalSlice
npm run generate
```

Note that the backend must be running and expose Swagger (OpenApi) definitions.

## Issues and Limitations
* I've choosen to keep frontend and backend code files in separate subdirectories, both for main and each feature.
This can cause an issue with Namespace Code Inspection-rule in IDEs as the .Net code convention is
that namespace match directory-paths of a class. I've choosen to disable this in my IDE (Rider by JetBrains)
for specific directories.
* Currently a .Net Test Project is still needed for unit testing backend and code. 
It would be ideal to have code files and test code files side by side if we want to strictly adopt
vertical slice architecture.

## Deployment to Production
TODO