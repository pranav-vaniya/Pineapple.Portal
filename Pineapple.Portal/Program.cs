using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Pineapple.Portal;
using MudBlazor.Services;
using Pineapple.Portal.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:3000/api/") });
builder.Services.AddMudServices();
builder.Services.AddScoped<CookieService>();
builder.Services.AddScoped<LeadService>();
builder.Services.AddScoped<NoteService>();

await builder.Build().RunAsync();
