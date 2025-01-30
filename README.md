# Clean Arch
## Migraition

Criar a migração
```bash
dotnet ef migrations add inicial --project ClenaArch.Infrastructure -s ClenaArch.API -c AppDbContext --verbose
```

Aplicar a migração na base de dados
```bash
dotnet ef database update inicial --project ClenaArch.Infrastructure -s ClenaArch.API -c AppDbContext --verbose
```