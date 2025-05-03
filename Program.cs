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

List<string> errors = new List<string>();

//REST API => GET, POST, PUT, DELETE 
app.MapGet("/",() => "Api is working Fine");

//GET /api/categories => Read Categories

app.MapGet("/api/categories",() =>{
    
    return Results.Ok();
});


app.Run();

public record Category{
    public Guid CategoryId{ get; set; }
    public string? CategoryName{ get; set; }
    public string? CategoryDescription{ get; set; }
    public DateTime CreateAt{ get; set; }    
}

public record Product{
    public Guid ProductId{get; set;}
    public string? ProductName{get; set;}
    public string? Description{get; set;}
    public decimal ProductPrice{get; set;}
    public int StockQuantity{get; set;}
    public string? CategoryName{get; set;}
}
//CRUD
//Create => Create a Category => POST: /api/categories
//Read  => Read a Category => GET:  /api/categories
//Update  => Update a Category => GET:  /api/categories
//Delete  =>  a Category => GET:  /api/categories