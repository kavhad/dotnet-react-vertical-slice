# .NET/React.JS with Vertical Slice Architecture
An opinionated boiler plate code for Fullstack developer with .NET and React. 

The project implements a Vertical Slice Architecture that runs through 
backend and frontend (meaning no separate ClientApp folder for frontend parts). 
Further we reduce the need to write client API glue code by using SwaggerGen and
the excellent npm package openapi-typescript-codegen
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

Here's a folder structure for the MinimalAPI project:

```
DotnetReactVerticalSlice/src        # Project Template source root directory.
  |- src
    |- Features/                    # A vertical slice is defined as a subfolder in this folder.
      | - Todo                      # Todo-feature sample vertical slice.  
        | - Backend                 # .Net/C# backend code
        | - Frontend                # React/TypeScript frontend code
    |- Backend
      |- Swagger                    # contains SwaggerGen registration files, automatically generates Open API definition for all REST APIs in the project.           
      |- IApiBuilder.cs             # Interface that enable each vertical slice to define it's own routing rules.
      |- IModelBuilder.cs            # Interface that enable each vertical slice to define it's own models within the database, although all models are in one shared database.
      |- AppDbContext.cs             # The application db context which is an abstraction over a shared database for all vertical slices. 
      |- appsettings.json            # Global application configuration.
      |- Program.cs                  # Main entry of application
      |- FeatureRegistrator.cs       # Scans assembly for classes that register features
      |- GlobalErrorHandler.cs       # API error handling
    |- Frontend
      |- index.tsx                    # React main entry
      |- router.tsx                   # Setup url routing for React app
DotnetReactVerticalSlice.Tests/     # Unit tests project
```


## Running Project From Command Line

Change current directory to project path __DotnetReactVerticalSlice__ 
and run:
```shell
dotnet watch
```

## Publish project to folder
Change current directory to project path __DotnetReactVerticalSlice__
and run:

```shell
dotnet publish
```
The resulting artifact-folder will be in /bin/&lt; Debug | Release &gt;/net7.0/publish
with the React-build in the wwwroot folder of that folder.

## Generate frontend API Client Code 
To automatically generate typescript client code for calling
the API, change directory to __DotnetReactVerticalSlice__ and 
run following in your shell:

```shell
npm run generate
```

This command uses the openapi-typescript-codegen npm package 
(https://github.com/ferdikoomen/openapi-typescript-codegen)

## Docker How To
TODO
