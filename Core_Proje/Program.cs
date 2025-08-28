using DataAccessLayer.Concrete;
using EntityLayer.Concrete;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<WriterUser, WriterRole>().AddEntityFrameworkStores<Context>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseRouting();

app.UseAuthorization();

// Controller route'u tanýmla
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Default}/{action=Index}/{id?}"
    );
});

app.Run();
