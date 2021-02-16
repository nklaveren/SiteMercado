# SiteMercado

desenvolvido em dotnet core 3.1

Passo a passo para rodar a aplicação: 
1 - configurar a connectionString;
2 - aplicar a migration do banco
    dotnet ef database update
3 - roodar a aplicação
    cd .\src\SiteMercado.WebApi
    dotnet restore | dotnet run
