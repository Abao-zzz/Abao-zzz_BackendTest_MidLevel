# Backend Interview Mid-Level Test

此專案為後端工程師技術測試，使用 **.NET 8 Web API**、**EF Core**、**SQL Server 2019+** 實作 `MyOffice_ACPD` 資料表的 CRUD API，並透過 **Swagger** 提供測試介面。

## 技術棧

- .NET 8 Web API
- Entity Framework Core 8
- SQL Server 2019+
- Swagger / Swashbuckle
- Visual Studio 2022
- Git / GitHub

## 專案架構

```text
Solution/
└─ po.BackendTest.Api/
   ├─ Controllers/
   │  └─ MyOfficeAcpdController.cs
   ├─ Data/
   │  └─ MyofficeAcpdContext.cs
   ├─ Models/
   │  └─ Entities/
   │     └─ MyOfficeAcpd.cs
   ├─ Properties/
   │  └─ launchSettings.json
   ├─ appsettings.json
   ├─ Program.cs
   └─ po.BackendTest.Api.csproj