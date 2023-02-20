# .NET/React.JS with Vertical Slice Architecture
Boilerplate code for fullstack development with .NET and React that implements
Vertical Slice Architecture. Each slice (or feature) runs through 
both backend and frontend code so that both code is side by side. 

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
        | - Backend                 # Backend code of todo feature.
        | - Frontend                # Frontend code of todo feature.
    |- Backend                      # Backend common code.
    |- Frontend                     # Frontend common code.
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

## Unit Testing
Test files for frontend Javascript or TypeScript code is put side by side in the same directory 
as is standard when creating a CRA (create react app) project.

For C# backend code test-files is also put side by side in 
the same directory. This is not convention in .NET but to strictly following the principles 
behind vertical slice architecture which is greater code cohesion. 
<br />We avoid shipping test code to production by using a custom .csproj files 
so that when files with match the pattern *.Tests.cs will be removed when building the project 
in Release-mode, also test library packages are only included when the project 
is NOT in Release-mode.

## Running Project For Local Development
To start the development server run the following command in your shell:

```shell
dotnet watch --project DotnetReactVerticalSlice
# this will build and run your project on a local development server.
# Also class-files will be watched and on a change will trigger hot-reload, but
# in some cases a complete reload of the processes is needed.
```

## Build & Run the project with Docker

```shell
cd DotnetReactVerticalSlice
# run following to create a docker container image named dotnet-react-vertical-slice (the name is defined in .csproj-file)
dotnet publish --os linux --arch x64 /t:PublishContainer -c Release
# run following to start a container with the just created image:
docker run --name dotnet-react-vertical-slice -p 8080:80 -d dotnet-react-vertical-slice:1.0.0
# browse to localhost:8080
```

## Generate Frontend Client Code For API
Some glue frontend code for calling Backend APIs is generated using a npm-package 
called openapi-typescript-codegen. 
 If you need to regenerate the code because an API-contract have changed run following command while 
local development server is running:

```shell
cd DotnetReactVerticalSlice
npm run generate
```

## Issues and Limitations
* This project does not follow the regular namespace-naming convention as most regular .NET-projects as
we divide some code up in Frontend and Backend directories which we don't want to show up as .NET-namespaces
as it's clear all C# code is backend code in this project. In Rider (IDE) I've decided to 
disregard these specific directories as namespace-providers.

## Deployment to Production
Currently there's no preference for how to create a deliverable artifact into production. 
This depends of course specific target environment and if you want to ship frontend and 
backend together. 