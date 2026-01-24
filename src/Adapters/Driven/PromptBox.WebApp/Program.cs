using PromptBox.Persistence.Extensions;

var builder = WebApplication.CreateBuilder(args);

// configurations
builder.Configuration.SetBasePath(builder.Environment.ContentRootPath);
builder.Configuration.AddJsonFile($"Configurations/appsettings.json", optional: false, reloadOnChange: true);
builder.Configuration.AddJsonFile($"Configurations/appsettings.{builder.Environment.EnvironmentName}.json", optional: false, reloadOnChange: true);
builder.Configuration.AddJsonFile($"Configurations/loggingsettings.json", optional: false, reloadOnChange: true);
builder.Configuration.AddJsonFile($"Configurations/loggingsettings.{builder.Environment.EnvironmentName}.json", optional: false, reloadOnChange: true);
builder.Configuration.AddJsonFile($"Configurations/databasesettings.json", optional: false, reloadOnChange: true);
builder.Configuration.AddJsonFile($"Configurations/databasesettings.{builder.Environment.EnvironmentName}.json", optional: false, reloadOnChange: true);



// services 
builder.Services.AddControllersWithViews();
builder.Services.AddAppDatabase(builder.Configuration);




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
