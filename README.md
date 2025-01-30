# Clean Arch
## Migraition

Criar a migração
```bash
dotnet ef migrations add Inicial --project ClenaArch.Infrastructure -s ClenaArch.API -c AppDbContext --verbose
```

Aplicar a migração na base de dados
```bash
dotnet ef database update Inicial --project ClenaArch.Infrastructure -s ClenaArch.API -c AppDbContext --verbose
```

Remove a última migração
```bash
dotnet ef migrations remove --project ClenaArch.Infrastructure -s ClenaArch.API -c AppDbContext --verbose
```

Apaga todas as alterações até 0 migrações
```bash
dotnet ef database update 0 --project ClenaArch.Infrastructure -s ClenaArch.API -c AppDbContext --verbose
```
