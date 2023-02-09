using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//1. add swagger service
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//4. add mysql middle man
builder.Services.AddDbContextPool<ShirtstoreDbContext>(
    dbContextOptions => dbContextOptions
        .UseMySql(
            builder.Configuration.GetConnectionString("MySQLConnection"),
            new MySqlServerVersion(new Version(8, 0, 29))
        //,
        //mySqlOptions => mySqlOptions.CharSetBehavior(CharSetBehavior.NeverAppend)
        )
    //.LogTo(Console.WriteLine, LogLevel.Information)
    //.EanbleSensitiveDataLogging()
    //.EnableDetailedErrors()
    );

//3. add json serializer
builder.Services
        .AddControllersWithViews()
        .AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//2. use swagger
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


//change the default route to be /order/index
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Order}/{action=Index}/{id?}");

app.Run();
