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
//Create => Create a Category