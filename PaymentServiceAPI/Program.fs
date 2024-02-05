namespace PaymentServiceAPI

#nowarn "20"

open System
open System.Collections.Generic
open System.IO
open System.Linq
open System.Threading.Tasks
open Microsoft.AspNetCore
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.AspNetCore.HttpsPolicy
open Microsoft.Extensions.Configuration
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.Logging
open Swashbuckle.AspNetCore.Swagger
open Swashbuckle.AspNetCore.SwaggerUI
open Microsoft.OpenApi.Models

module Program =
    open Duende.IdentityServer.Models
    let exitCode = 0

    [<EntryPoint>]
    let main args =
        let builder = WebApplication.CreateBuilder(args)


        builder.Services.AddControllers()

        // Register the Swagger generator
        builder.Services.AddSwaggerGen(fun c -> c.SwaggerDoc("v1", OpenApiInfo(Title = "My API", Version = "v1")))

        builder.Services
            .AddIdentityServer()
            .AddInMemoryClients(
                [| Client(
                       ClientId = "client",
                       AllowedGrantTypes = [| GrantType.ClientCredentials |],
                       ClientSecrets = [| Secret(Value = "secret".Sha256()) |],
                       AllowedScopes = [| "api1" |]

                   ) |]
            )
            .AddInMemoryApiScopes([| ApiScope(Name = "api1", DisplayName = "API 1") |])
            .AddInMemoryApiResources([| ApiResource(Name = "api1", DisplayName = "API 1") |])



        let app = builder.Build()

        // Enable middleware to serve generated Swagger as a JSON endpoint
        app.UseSwagger()

        // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint
        app.UseSwaggerUI(fun c -> c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"))

        // enable identity server middleware
        app.UseIdentityServer()

        app.UseHttpsRedirection()

        app.UseAuthorization()
        app.UseAuthentication()
        app.MapControllers()

        app.Run()

        exitCode
