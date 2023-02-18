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
* Frontend and Backend code are kept separated in subdirectories, 
but not from the top level instead from common code level and each feature.
This caused some minor problems in my IDE (Rider) which had code inspection-rules for .NET code that expects
a perfect match between directory path of a class-file and it's namespaces, which I didn't want for
the Backend and Frontend folders. Luckily Rider have a setting to disable these directories as namespace-providers.

## Deployment to Production
Currently there's no preference for how to create a deliverable artifact into production. 
This depends of course specific target environment and if you want to ship frontend and 
backend together. 