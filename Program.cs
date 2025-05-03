using Microsoft.Extensions.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

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

var products = new List<Product>(){
    new Product("Samsung", 4242),
    new Product("Iphone",4242),
};

app.MapGet("/products",() =>{
    
    return Results.Ok(products);
});


app.Run();

public record Product(string Name, decimal Price);