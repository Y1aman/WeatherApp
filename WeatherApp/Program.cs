using Microsoft.Extensions.Caching.Memory;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient();
builder.Services.AddMemoryCache();
// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapGet("/weather/{city}", async (string city, IConfiguration config, IHttpClientFactory httpClientFactory, Microsoft.Extensions.Caching.Memory.IMemoryCache cache) =>
{
    string cashKey = $"weather_{city}";
    if (cache.TryGetValue(cashKey, out string cacheWeather))
    {
        return Results.Content(cacheWeather, "application/json");
    }
    var apiKey = config["WeatherAPI:ApiKey"];
    var url = $"https://weather.visualcrossing.com/VisualCrossingWebServices/rest/services/timeline/{city}?unitGroup=metric&key={apiKey}";
    var client = httpClientFactory.CreateClient();
    var response = await client.GetAsync(url);
    var weatherData = await response.Content.ReadAsStringAsync();
    cache.Set(cashKey, weatherData, TimeSpan.FromHours(12));
    return Results.Content(weatherData, "application/json");
});
app.Run();
