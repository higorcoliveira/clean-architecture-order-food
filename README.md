# clean-architecture-order-food
This is a simple project intended to test clean architecture concepts.

All credits to https://www.youtube.com/c/AmichaiMantinband

## Tips
To run a single project

```
dotnet run --project OrderFood.Api/
``` 

To create a new sln file:

```
dotnet new sln --name OrderFood.sln
```

To create dependencies between projects
```
dotnet add OrderFood.Api/ reference OrderFood.Contracts/
```
