using Bl;
using Domains;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TripsSystemContext>();
builder.Services.AddScoped<IClsTrips, ClsTrips>();
builder.Services.AddScoped<IClsTickets, ClsTickets>();
builder.Services.AddScoped<IClsCategories, ClsCategories>();

builder.Services.AddScoped<IClsCities, ClsCities>();


// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "Admin",
        pattern: "{area:exists}/{controller=AdminHome}/{action=List}/{id?}");

    endpoints.MapControllerRoute(
       name: "default",
       pattern: "{controller=home}/{action=index}/{id?}");

    


    //endpoints.MapControllerRoute(
    //    name: "default",
    //    pattern: "{controller=home}/{action=index}/{id?}");


   



});
app.Run();
