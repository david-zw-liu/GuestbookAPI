# ASP.Net Core Web API Demo
A basic CRUD Guestbook API
### Description
This repository is just for demo,
and feel free to fork to modify.
### Before Use
Modify connection string in startup.cs to connect your db, 
and run Update-Database at NuGet Console.
### Usage
 - dotnet restore
 - dotnet run

### API Spec

| API | Description| Request body | Response body |
| :---------------: | :---------------: | :---------------: | :---------------: |
|Get  /api/guestbook/comment | Get all the comments | None | Array of all the comments|
|Get  /api/guestbook/comment/{id} | Get the comment of {id} | None | The comment |
|POST /api/guestbook/comment | Create a comment | Content of the comment | The comment|
|PUT /api/guestbook/comment/{id} | Update the comment of {id} | Content of the comment | None
|DELETE /api/guestbook/comment/{id} | Delete the comment of {id} | None | None |