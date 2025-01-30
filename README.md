# Clean Arch
## Migraition

Criar a migra��o
```bash
dotnet ef migrations add Inicial --project ClenaArch.Infrastructure -s ClenaArch.API -c AppDbContext --verbose
```

Aplicar a migra��o na base de dados
```bash
dotnet ef database update Inicial --project ClenaArch.Infrastructure -s ClenaArch.API -c AppDbContext --verbose
```

Remove a �ltima migra��o
```bash
dotnet ef migrations remove --project ClenaArch.Infrastructure -s ClenaArch.API -c AppDbContext --verbose
```

Apaga todas as altera��es at� 0 migra��es
```bash
dotnet ef database update 0 --project ClenaArch.Infrastructure -s ClenaArch.API -c AppDbContext --verbose
```
