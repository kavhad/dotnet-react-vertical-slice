# .NET/React.JS with Vertical Slice Architecture
An opinionated boilerplace code for Fullstack development of 
web applications for fullstack developers who use .NET and React. 
The project implements a Vertical Slice Architecture for both backend and
frontend meaning no separate ClientApp folder.

### Build status
[![.NET](https://github.com/kavhad/dotnet-project-templates/actions/workflows/dotnet.yml/badge.svg)](https://github.com/kavhad/dotnet-project-templates/actions/workflows/dotnet.yml)


## Vertical Slice Architecture
Vertical slice architecture is a software design approach that involves creating small, 
self-contained modules for individual features of an application. This allows for parallel development, 
reduced dependencies, and improved agility in large and complex applications. The benefits 
include improved maintainability, scalability, and flexibility, as well as faster time-to-market 
and greater developer productivity.


### Folder structure

Here's a folder structure for the MinimalAPI project:

```
DotnetReactVerticalSlice/src        # Project Template source root directory.
  |- src
    |- Features/                    # A vertical slice is defined as a subfolder in this folder.
       | - Todo                     # Todo-feature sample vertical slice.  
       | - Swagger                  # Swagger-feature, automatically generates Open API definition for all REST APIs in the project.           
    |- IApiBuilder.cs               # Interface that enable each vertical slice to define it's own routing rules.
    |- IModelBuilder.cs             # Interface that enable each vertical slice to define it's own models within the database, although all models are in one shared database.
    |- AppDbContext.cs              # The application db context which is an abstraction over a shared database for all vertical slices. 
    |- appsettings.json             # Global application configuration.
    |- Program.cs                   # Main entry of application
    |- FeatureRegistrator           # Scans assembly for classes that register features
    |- GlobalErrorHandler.cs        # API error handling
    |- index.tsx                    # React main
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
