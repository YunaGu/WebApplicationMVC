## Overview

The user can type anything on the input page, once click submit, it will direct you to the output page and you will see a sentence "You just sent ... at xx-xx-xx xx", also, you can click "Show All" button to see all history.

Example:

![/Users/yunkoo/Downloads/Screen Recording 2023-12-08 at 20.29.09.gif](https://github.com/YunaGu/WebApplicationMVC/blob/master/Screen%20Recording%202023-12-08%20at%2020.29.09.gif)


## Technologies

- Frontend: Razor Pages, Bootstrap, jQuery
- Backend: ASP.NET Core MVC (.NET 6), xUnit
- Database: SQL Server
- Others: Docker, Azure Data Studio (Mac)



## How to install and run the project

### Download source code

You can open your IDE and select "Get from VCS", Version control: git, copy and paste the URL below:

```git
https://github.com/YunaGu/WebApplicationMVC.git
```

or using GitHub CLI:

```git
gh repo clone YunaGu/WebApplicationMVC
```

or download ZIP on [GitHub](https://github.com/YunaGu/WebApplicationMVC).

### Change the database settings

In this project, I used Localhost SQL Server. So **please replace the server name, port, admin name and password** in yours. 

If you are a macOS user, you can download Docker and Azure Data Studio to replace SQL Server Management System (SSMS), and use Rider to edit as Visual Studio for Mac has been retired.

> My settings:
>
> server name: localhost
>
> instance name: MSSQLSERVER
>
> port: 1433
>
> admin: SA
>
> password: Password1#

### Build and run the project

You can build and run the project using .NET CLI: `dotnet build` and `dotnet run`. Also, you can click the run button<img src="https://github.com/YunaGu/WebApplicationMVC/blob/master/Screenshot%202023-12-08%20at%2020.55.04.png" alt="Screenshot 2023-12-08 at 20.55.04" style="zoom:25%;" /> on your IDE.

