using Application.Features.Doctor.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api.Endpoints
{
    public static class DoctorEndpoints
    {
        public static void MapDoctorEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("api/doctors");

            group.MapPost("/", CreateDoctor);
        }

        private static async Task<IResult> CreateDoctor(
            [FromBody] CreateDoctorCommand command,
            ISender mediator)
        {
            if (command is null) return Results.BadRequest("The body cannot be empty");

            var doctorid = await mediator.Send(command);
            return Results.Ok(doctorid);
        }
    }
}
