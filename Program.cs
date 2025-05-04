using Microsoft.AspNetCore.Mvc;
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

List<Category> categories = new List<Category>();

//REST API => GET, POST, PUT, DELETE 
app.MapGet("/",() => "Api is working Fine");

//GET: /api/categories => Read Categories
app.MapGet("/api/categories",() =>{
    return Results.Ok(categories);
});

//Post: /api/categories => Create a Categories
app.MapPost("/api/categories",([FromBody] Category categoryData) =>{
    Console.WriteLine($"{categoryData}");
    
    // var newCategory = new Category{
    //     CategoryId = Guid.NewGuid(),
    //     CategoryName="Electronics",
    //     CategoryDescription="Devices and gadgets including phones, Laptops and other electronic equipment",
    //     CreateAt = DateTime.UtcNow,
    // };
    // categories.Add(newCategory);
    // return Results.Created($"/api/categories/{newCategory.CategoryId}",newCategory);
    return Results.Ok();
});

//DELETE  : /api/categories => Delete a Categories
app.MapDelete("/api/categories",() =>{
    var foundCategory = categories.FirstOrDefault(category => category.CategoryId == Guid.Parse("d8b81522-f859-4712-ad68-76063c81e0ac"));
    if(foundCategory == null){
        return Results.NotFound("Category with this id does not exits");
    }
    categories.Remove(foundCategory);
    return Results.NoContent();
});

//Update: /api/categories => Update Categories
app.MapPut("/api/categories",() =>{
    var foundCategory = categories.FirstOrDefault(category => category.CategoryId== Guid.Parse("d8b81522-f859-4712-ad68-76063c81e0ac"));
    if(foundCategory == null){
        return Results.NotFound("Category with this id does not exits");
    }
    foundCategory.CategoryName = "Smart Phone";
    foundCategory.CategoryDescription = "smart phone have lots of company";
    return Results.Ok(categories);
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