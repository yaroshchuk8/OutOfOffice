# OutOfOffice - ASP.NET Core MVC App
## Requirements: .NET 8 SDK, SQL Server
### Execution in terminal:

```bash
> git clone https://github.com/yaroshchuk8/OutOfOffice.git
> cd .\OutOfOffice\OutOfOffice.Web\
```
> If needed, modify connection string in ./OutOfOffice.Web/appsettings.json according to your SQL Server path
```bash
> dotnet ef database update
> dotnet run
```
> Terminal log: **Now listening on: http://localhost:port**

---

### Database schema:
![Database schema](https://raw.githubusercontent.com/yaroshchuk8/OutOfOffice/master/OutOfOffice.Web/wwwroot/photos/db-diagram.png)