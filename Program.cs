using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

//add services to the controller
builder.Services.AddControllers();

builder.Services.Configure<ApiBehaviorOptions>(options => {
    options.InvalidModelStateResponseFactory = context => {
                var errors = context.ModelState
                .Where(e => e.Value != null && e.Value.Errors.Count > 0)
                .Select(e => new 
                {
                    Field = e.Key,
                    Errors = e.Value != null ? e.Value.Errors.Select(x => x.ErrorMessage).ToArray() : new string[0]
                }).ToList();
                var errorsString = string.Join("; ",errors.
                Select(e => $"{e.Field} : {string.Join(", ",e.Errors)}" ));
                return new BadRequestObjectResult(new {
                    Message = "Validation failed",
                    Errors = errorsString
                });
    };
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

if(app.Environment.IsDevelopment()){
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


//REST API => GET, POST, PUT, DELETE 
app.MapGet("/",() => "Api is working Fine");


app.MapControllers();
app.Run();



//MVC = Models, View, Controllers 