# Minimals

API built using .Net 6 and the new minimal code way.

# How To Run

## SQL Server

SQL Server in this example was run using docker, the command below is used to start

`docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=!One2Three" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2019-latest`

The data used is the Northwind Database, instructions on how to set this up can be found at [https://github.com/Microsoft/sql-server-samples/tree/master/samples/databases/northwind-pubs](https://github.com/Microsoft/sql-server-samples/tree/master/samples/databases/northwind-pubs) , essentially copy the contents of `instnwnd.sql` and run using a tool such as [SQL Server Management Studio](https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver15)


## Code

You will need the .Net 6 SDK installed, get it from [https://dotnet.microsoft.com/download/dotnet/6.0](https://dotnet.microsoft.com/download/dotnet/6.0)

Clone this repository

`git clone https://github.com/DoesDotNet/minimals-api.git`

either open in Visual Studio 2022 Preview or newer and press F5 or use the command `dotnet run --project  .\src\Minimals.Api\Minimals.Api.csproj` from the root of the repository.

