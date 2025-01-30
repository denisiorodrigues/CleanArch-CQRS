# Clean Arch
## Migraition

Criar a migra��o
```bash
dotnet ef migrations add inicial --project ClenaArch.Infrastructure -s ClenaArch.API -c AppDbContext --verbose
```

Aplicar a migra��o na base de dados
```bash
dotnet ef database update inicial --project ClenaArch.Infrastructure -s ClenaArch.API -c AppDbContext --verbose
```