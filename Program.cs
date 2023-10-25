using System.Text.Json;
using coreapp.Models;
using coreapp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddTransient<JsonFileProductService>();

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
app.MapControllers();


// app.UseEndpoints(endpoints =>
// {
//     endpoints.MapControllers();
//     endpoints.MapGet("/products", async context =>
//     {
//         var productService = context.RequestServices.GetRequiredService<JsonFileProductService>();
//         var products = productService.GetProducts();
//         // var json = JsonSerializer.Serialize<IEnumerable<Product>>(products);
//         await context.Response.WriteAsJsonAsync(products);
//     // });
// });

app.Run();
