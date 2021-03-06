# SiteMercado API

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
* Utilizar o token obtido na rota `account/login` com header `Authorization: Bearer token` 
```
/product
```

**Atenção**

Para o correto funcionamento dos testes end-to-end as credenciais do usuário devem
ser salvas nas variáveis de ambiente do sistema local, com o seguinte nome:
```
SiteMercadoUsername
SiteMercadoPassword
```

### Testes
![tests](tests.png) 

### Arquitetura
![proj](project.png) 

### Swagger
![swagger](swagger.png)
