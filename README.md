# SiteMercado

desenvolvido em dotnet core 3.1

### Passo a passo para rodar a aplicação: 
1. Configurar a connectionString;
2. Aplicar a migration do banco `dotnet ef database update`
3. Rodar a aplicação `dotnet restore | dotnet run`

### rotas publicas:
```
/account/login
```

### rotas privadas:
Utilizar o token obtido na rota `account/login` com header `Authorization: Bearer token` 
```
/home
/product
```
