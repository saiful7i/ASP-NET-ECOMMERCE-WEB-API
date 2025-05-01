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

app.MapGet("/hello",() =>{
   // var response = new {message = "This is a json object", success=true};
    // return "Get Method: Hello";
    return Results.Content("<h1> Hello World </h1>","text/html");
});


app.Run();
