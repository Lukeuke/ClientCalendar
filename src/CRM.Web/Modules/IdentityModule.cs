using CRM.Application.DTOs.Identity.SignIn;
using CRM.Application.DTOs.Identity.SignUp;
using CRM.Application.Enums;
using CRM.Application.Services.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Web.Modules;

public static class IdentityModule
{
    public static void AddIdentityEndpoint(this WebApplication app)
    {
        app.MapGet("api/identity", () => Results.Ok())
            .RequireAuthorization();
        
        app.MapPut("api/identity", async (
            [FromBody] SignUpRequestDto requestDto,
            [FromServices] IIdentityService identityService
            ) =>
        {
            var (status, result) = await identityService.SignUpAsync(requestDto);

            return status ? Results.Created("", result) : Results.BadRequest(result);
        });
        
        app.MapPost("api/identity", async (
            [FromBody] SignInRequestDto requestDto,
            [FromServices] IIdentityService identityService
            ) =>
        {
            var (status, result) = await identityService.SignInAsync(requestDto);

            return status switch
            {
                EResponseStatusCode.Ok => Results.Ok(result),
                EResponseStatusCode.BadRequest => Results.BadRequest(result),
                EResponseStatusCode.NotFound => Results.NotFound(result),
                _ => Results.BadRequest(result)
            };
        });
    }
}