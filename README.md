# CleanMediatorMinimalApi

Minimal API (.NET 8) + Clean Architecture + MediatR + AutoMapper + FluentValidation + Serilog + MemoryCache

---

## 🚀 Requirements

ก่อนเริ่มต้น คุณต้องติดตั้ง:

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Git (เพื่อ clone โปรเจกต์)
- IDE เช่น Visual Studio 2022+ หรือ Visual Studio Code

---

## 📦 NuGet Packages ที่ใช้

```bash
dotnet add package MediatR.Extensions.Microsoft.DependencyInjection
dotnet add package FluentValidation.AspNetCore
dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection
dotnet add package Microsoft.Extensions.Caching.Memory
dotnet add package Serilog.AspNetCore
dotnet add package Serilog.Sinks.Console
dotnet add package Serilog.Sinks.File
dotnet add package Serilog.Settings.Configuration
dotnet add package Asp.Versioning.Http
dotnet add package Asp.Versioning.Mvc.ApiExplorer
dotnet add package Swashbuckle.AspNetCore