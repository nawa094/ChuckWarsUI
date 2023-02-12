using ChuckWarsUI;
using ChuckWarsUI.Configuration;
using ChuckWarsUI.Integration.ChuckWarsApi;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
var apiConfig = new ChuckWarsApiConfiguration();
builder.Configuration.GetSection(ChuckWarsApiConfiguration.SectionName).Bind(apiConfig);
builder.Services.AddScoped<IClient, Client>(sp => new Client("https://chuck-wars-api.azurewebsites.net"));

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
