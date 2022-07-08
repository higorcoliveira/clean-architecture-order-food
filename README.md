# clean-architecture-order-food
This is a simple project intended to practice clean architecture concepts.

All credits to https://www.youtube.com/c/AmichaiMantinband

## Tips
To run a single project

```
dotnet run --project OrderFood.Api/
``` 

To create a new sln file:

```
dotnet new sln --name OrderFood
dotnet sln add OrderFood.Api/OrderFood.Api.csproj
```

To create dependencies between projects
```
dotnet add OrderFood.Api/ reference OrderFood.Contracts/
```

To generate a secret into dev environment
```
dotnet user-secrets init --project OrderFood.Api
dotnet user-secrets set --project OrderFood.Api "JwtSettings:SecretKey" "super-secret-key-from-super"
```
