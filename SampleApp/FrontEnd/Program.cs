using FrontEnd.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddHttpClient<TransactionClient>(client =>
{
    var url = builder.Configuration["BACKEND_URL"]
        ?? throw new InvalidOperationException("BACKEND_URL is not set");

    client.BaseAddress = new(url);
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseStaticFiles();
app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.Run();
