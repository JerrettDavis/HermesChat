 #HermesChat

A non-trivial realtime communication demo, modeled after other popular chat services.

### Database Migrations

To use `dotnet-ef` for your migrations please add the following flags to your command (values assume you are executing from repository root)

* `--project src/Infrastructure` (optional if in this folder)
* `--startup-project src/WebUI`
* `--output-dir Persistence/Migrations`

For example, to add a new migration from the root folder:

`dotnet ef migrations add "SampleMigration" --project src\Infrastructure --startup-project src\WebUI --output-dir Persistence\Migrations`

 ## Credits and Acknowledgements

The project relies heavily on Uncle Bob's [Clean Architecture Paradigm](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html). The project structure and technologies are heavily influenced by [Jason Taylor's](https://github.com/jasontaylordev) talks and examples.  
