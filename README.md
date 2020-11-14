# EFCore.LazyRepository

If you're too lazy to write down every time the same old repository layer, or if you need the basic CRUD operation, this library can help you.

This is a working in progress, with probably **very bad code**, but whatever. It's a start. 

Also, is probably a pretty useless library.

## Usage

### Startup

In the `startup.cs` file call `service.RegisterRepositories(func)` where func is a delegate used to define the assemblies from which retrieve the following implementations.

### Define a new Entity

Creare a new entity and implement `IRepositoryEntity`. You just need to define a name for the repository, the interface will be used to automatically register the concrete Repository for DI.

### That's all folks

At this point you just need to retrieve the Unit of Work of type `IUoW` through DI and call the repository as follow: `_uoW.Repositories["repositoryName"]`.
At this stage it explose the following methos:

| Method    | What is does                                          | Save Context |
| :-------- | :---------------------------------------------------- | :----------- |
| .Get<T>() | Retrieve all entities as `IQueryable` of a given type | N            |
| .Add()    | Add a new entity                                      | Y            |
| .Update() | Update an existing entity                             | Y            |
| .Remove() | Remove an existing entity                             | Y            |

And call `_uoW.Commit()` if needed to save all changes.
