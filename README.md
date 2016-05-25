# MvcApp
A ready to build on MVC template
Built with MVC5, EF6 code-first, Bootstrap 4, SASS, AutoMapper, StructureMap and Moq for unit testing.

##Features

**DRY**
An effort has been made to keep this project as DRY (don't repeat yourself) as possible. Using base classes for models in the repository and default properties, so that logic doesn't have to be repeated.

Generic repository methods for CRUD (create, read, update delete), so that when a new entity/table is added, these methods don't need to be recreated.

AutoMapper, because writing mappings between database models and view models is unnecessarily time consuming and prone to human error.

Using StructureMap to automatically create the configurations for AutoMapper profiles.

SASS to make maintaining and writing CSS more like OOP.


**Modular and pluggable**
Some core components have been implemented using interfaces.

For example the DbContext is encapsulated in wrapper and the interface of that wrapper is dependency injected into the controllers as a service using StructureMap. This is to enable easy passing of a fake context for testing purposes without the need to touch the database.


**Testable**
Quickly testable and created in a way to ensure unit tests are quick and painless to write.

Moq is utilised for creation of dummy data. The entities themselves do not need to be duplicated and the data can be injected directly into the test context.


**Authentication**
Lightweight custom authentication code was opted for. The built in is just too bloated and not flexible enough. Additionally ASP.NET Identity uses GUIDs by default and this can affect DB performance massively when you need to scale.

Passwords are stored securely, they are hashed and salted using PBKDF2.

A password reset feature based on sending a unique link via e-mail is included.


**Other notes**
Other than the jQuery and Bootstrap stuff, a front end JavaScript framework has not been included in this template for flexibility of choosing your own / including the latest and greatest.
