using Domain;

var builder = WebApplication.CreateBuilder(args);

// Setup up our dummy persistence layer
builder.Services.AddSingleton<ICheeseRepository, InMemoryCheeseRepository>(x =>
    {
        var repository = new InMemoryCheeseRepository();
        repository.Add(new Cheese(1, "Cheddar", "cheddar.jpg", "Yellow", 3.55m));
        repository.Add(new Cheese(2, "Brie", "brie.jpg", "Pale yellow", 5.50m));
        repository.Add(new Cheese(3, "Danish Blue", "danish_blue.jpg", "White with blue streaks", 7.00m));
        repository.Add(new Cheese(4, "Parmesan", "parmesan.jpg", "Orangish yellow", 8.25m));
        repository.Add(new Cheese(5, "Camembert", "camembert.jpg", "Pale yellow", 4.75m));
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
        .WithOrigins("http://localhost:3000")
    );
}

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapControllers();

app.Run();
