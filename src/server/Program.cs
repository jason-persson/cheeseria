using Domain;

var builder = WebApplication.CreateBuilder(args);

// Setup up our dummy persistence layer
builder.Services.AddSingleton<ICheeseRepository, InMemoryCheeseRepository>(x =>
    {
        var repository = new InMemoryCheeseRepository();
        repository.Add(new Cheese(1, "Cheddar", "cheddar.jpg"));
        repository.Add(new Cheese(2, "Brie", "brie.jpg"));
        repository.Add(new Cheese(3, "Danish Blue", "danish_blue.jpg"));
        repository.Add(new Cheese(4, "Parmesan", "parmesan.jpg"));
        repository.Add(new Cheese(5, "Camembert", "camembert.jpg"));
        return repository;
    }
);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(x => 
    x.AllowAnyMethod()
    .WithOrigins("http://localhost:3000"));
}

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapControllers();

app.Run();
