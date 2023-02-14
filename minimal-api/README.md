# MinimalAPI project template
An project template for APIs or microservices which avoids
defining APIs using classes and attributes.

The template also implements the Vertical Slice Architecture
(Here's a explainer youtube video by Derek Comartin https://www.youtube.com/watch?v=lsddiYwWaOQ).

### Build status
[![.NET](https://github.com/kavhad/dotnet-project-templates/actions/workflows/dotnet.yml/badge.svg)](https://github.com/kavhad/dotnet-project-templates/actions/workflows/dotnet.yml)

### Folder structure

Here's a folder structure for the MinimalAPI project:

```
MinimalAPI/     # Project template root directory.
|- bin/        # Folder used to store builded (output) files.
|- obj/        # Folder used to store files used for build and debugging.
|- Features/   # Each vertical slice has all code in it's Feature-folder in this folder.
   | - Todo    # Todo-feature which is an example of a vertical slice  
   | - Swagger # Swagger-feature to enable api documentation generation          
|- IApiBuilder.cs # interface which supports vertical slicing of Minimal API
|- IModelBuilder.cs # interface which supports vertical slicing of DbContext.
|- AppDbContext.cs # Application EF Core DbContext 
|- appsettings.json # application configuration.
|- Program.cs # Main entry of application
MinimalAPI.Tests/ # Unit tests for project