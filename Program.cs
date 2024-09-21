var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//sdsdsdsd
Dictionary<string, string> path = new Dictionary<string, string>();
path.Add("json", "config/config.json");
path.Add("xml", "config/config.xml");
path.Add("ini", "config/config.ini");

builder.Configuration.AddJsonFile(path["json"])
    .AddXmlFile(path["xml"])
    .AddIniFile(path["ini"]);

builder.Services.AddSingleton<CompanyService>();

var app = builder.Build();
app.MapGet("/", (IConfiguration appConf, CompanyService companyService) =>
{
    var Apple = new Company("Apple", appConf);
    var Microsoft = new Company("Microsoft", appConf);
    var Google = new Company("Google", appConf);

    var largestStuff = companyService.GetMaxStaffCompanyName(
        new List<Company> { Apple, Google, Microsoft });

    return $"{Apple}\n\n{Microsoft}\n\n{Google}\n\n\nMax Staff Company Name : {largestStuff}";
});

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for
    // production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(name: "default",
                       pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
