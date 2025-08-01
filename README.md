# Linkedlistsstory

This is a small WPF-based interactive story application. The story content is stored in `Adventures/adventure.json` and displayed using a simple user interface. User accounts are stored locally using Entity Framework Core with SQLite.

The project targets **.NET 8.0 for Windows**. To build and run it you need the .NET SDK with Windows Desktop components installed on a Windows machine:

```bash
dotnet build Linkedlistsstory.sln
```

Run the application with:

```bash
dotnet run --project Linkedlistsstory.csproj
```

On non-Windows platforms the project will not build because WPF is Windows-only.
