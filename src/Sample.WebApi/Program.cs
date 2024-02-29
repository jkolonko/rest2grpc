var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var nouns = new[]
{
    "Alpha", "Bravo", "Charlie", "Delta", "Echo", "Foxtrot", "Golf", "Hotel", "India", "Juliett"
};

app.MapGet("/sampleendpoint", () =>
{
    return  Enumerable.Range(1, 5).Select(index =>
        new SamplePayload
        (
            nouns[Random.Shared.Next(nouns.Length)],
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            (decimal)Random.Shared.Next(-20, 55) + (decimal)Random.Shared.NextDouble()
        ))
        .ToArray();
})
.WithName("SampleEndpoint")
.WithOpenApi();

app.Run();


record SamplePayload(string SomeString, DateOnly SomeDate, decimal SomeMoney);
