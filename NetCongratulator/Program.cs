using NetCongratulator.Data;
using NetCongratulator.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddOpenApiDocument(settings => {
    settings.Title = "Congratulator API";
});

builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

builder.Services.AddRazorPages();
builder.Services.AddSqlite<UserCardContext>("Data Source=NetCongratulator.db");

builder.Services.AddScoped<UserCardService>();
builder.Services.AddScoped<ImageService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi(c => {
        c.DocExpansion = "list";
    });

    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.MapRazorPages();

//app.MapGet("/", () => @"Congratulator management API. Navigate to /swagger to open the Swagger test UI.");

app.Run();
