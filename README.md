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

The disadvantage of this architecture in this specific project type is 
that we don't get clean separation of horizontal layers e.g if a team have coders that
work exclusively on backend and frontend they still see and can access files for both parts of the system.

### Folder structure

The project source code is under the __src__-folder where both frontend and backend code
is side by side firs

```
DotnetReactVerticalSlice/src        # Project Template source root directory.
  |- src
    |- Features/                    # A vertical slice is defined as a subfolder in this folder.
      | - Todo                      # Todo-feature sample vertical slice.  
        | - Backend                 # .Net/C# backend code.
        | - Frontend                # React/TypeScript frontend code.
    |- Backend                      # Backend Main.
      |- Swagger                    # contains SwaggerGen registration files, automatically generates Open API definition for all REST APIs in the project.           
      |- IApiBuilder.cs             # Interface that enable each vertical slice to define it's own routing rules.
      |- IModelBuilder.cs           # Interface that enable each vertical slice to define it's own models within the database, although all models are in one shared database.
      |- AppDbContext.cs            # The application db context which is an abstraction over a shared database for all vertical slices. 
      |- appsettings.json           # Global application configuration.
      |- Program.cs                 # Main entry of application
      |- FeatureRegistrator.cs      # Scans assembly for classes and register feature backend-part.
      |- GlobalErrorHandler.cs      # API error handling.
    |- Frontend                     # Frontend Main.
      |- index.tsx                  # Composition Root for the forntend.
      |- router.tsx                 # Setup url routing for React app (Composition Root)
DotnetReactVerticalSlice.Tests/     # Unit tests project
```

## Feature (Vertical Slice ) Registration
The backend of a feature can be registered without any change to the main entry-method. Instead 
registration can be done indirectly defining a static class with a name that ends with __Startup__ and
a static method called __Register__ that takes a single parameter of type __IServiceCollection__ and define certain dependencies.
During startup these classes will be scanned from the assembly and invoked so that 
their services can be registered and bootstrapped, e.g:
```csharp
public static class TodoStartup
{
    public static void Register(this IServiceCollection services)
    {
        //Features that define new data-model for persistence can 
        //define and register an IModelBuilder dependency which models 
        //will be added to AppDbContext.
        services.AddSingleton<IModelBuilder, TodoModelBuilder>(); 
        //Features that exposes new api endpoints can define and register this
        //dependency to be automatically wired during hosting app startup.
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


## Publish project to folder


```shell
dotnet publish
```
The resulting artifact-folder will be in __/bin/&lt; Debug | Release &gt;/net7.0/publish__
and the React build artifact will be in the subfolder __wwwroot__.

## Generate Frontend Client Code For API 
To automatically generate typescript client code from OpenAPI (swagger) definition run the following
and make sure backend development server is running.

```shell
cd DotnetReactVerticalSlice
npm run generate
```

Note that the backend must be running and expose Swagger (OpenApi) definitions.

## Deployment to Production
TODO