using Microsoft.EntityFrameworkCore;
using SphinxTask.DataAccess.DataBase;
using SphinxTask.DataAccess.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
string ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContextPool<AppDB>(option => option.UseSqlServer(ConnectionString));
builder.Services.AddScoped<IProductRepo, ProductRepo>();
builder.Services.AddScoped<IClientRepo, ClientRepo>();
builder.Services.AddScoped<IClientProductRepo, ClientProductRepo>();

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

app.Run();
