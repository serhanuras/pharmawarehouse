# Pharmacy API

PharmacyWarehouse API, is a .NET Core project that is used by PharmacyWarehouse APP

## EF Data Migration

Installing .NET migration tool.

```bash
dotnet tool install --global dotnet-ef
```

Create Migration

```bash
dotnet ef migrations add <MIGRATION NAME>
```

Remove Migration

```bash
dotnet ef migrations remove
```

Run Migration

```bash
dotnet ef database update
```

Remove Migration

```bash
dotnet ef database drop
```
