# .NET 8, MAUI, MySQL

Yksi tapa ottaa MySQL-tietokantayhteys .NET MAUI -sovelluksesta.

Tarvittavat SDK:t ja sovellukset

* .NET 8 SDK, https://dotnet.microsoft.com/en-us/download/dotnet/8.0
    * maui-windows -workload (`dotnet workload install maui-windows`)
* VS Code + .NET MAUI -extension, https://code.visualstudio.com/Download
* MySql.Data Nuget-paketti, https://www.nuget.org/packages/MySql.Data/

Koodi MySQL Connector/NET Developer Guide -ohjeiden mukaan, https://dev.mysql.com/doc/connector-net/en/connector-net-tutorials-connection.html



## MySQL

Testatessa käytetty Azure MySQL -kantaa, https://azure.microsoft.com/en-us/products/mysql, jonne palomuurista sallittu liikenne.

Palvelimelle on luotu pet-taulu https://dev.mysql.com/doc/refman/8.0/en/creating-tables.html ohjeiden mukaan.
