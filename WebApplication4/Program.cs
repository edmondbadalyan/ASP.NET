using WebApplication4;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddScoped<IMovieScheduleService, MovieScheduleService>();
builder.Services.AddControllers();

var app = builder.Build();

//app.UseHttpsRedirection();
app.MapControllers();
app.UseStaticFiles();

app.MapFallbackToFile("wwwroot.html");

app.Run();