using IMS.Plugins.InMemory;
using IMS.UseCases.PluginInterfaces;
using IMS.UseCases.UseCases.Inventory;
using IMS.UseCases.UseCases.Product;
using IMS.WebApp.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents();
builder.Services.AddSingleton<IInventoryRepository, InventoryRepository>();
builder.Services.AddTransient<IViewInventoriesByNameUseCase, ViewInventoriesByNameUseCase>();
builder.Services.AddTransient<IAddNewInventoryUseCase, AddNewInventoryUseCase>();
builder.Services.AddTransient<IEditInventoryUseCase, EditInventoryUseCase>();
builder.Services.AddTransient<IViewInventoryByIdUseCase, ViewInventoryByIdUseCase>();
builder.Services.AddTransient<IDeleteInventoryUseCase, DeleteInventoryUseCase>();

builder.Services.AddSingleton<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IViewProductsByNameUseCase, ViewProductsByNameUseCase>();
builder.Services.AddTransient<IAddNewProductUseCase, AddNewProductUseCase>();
builder.Services.AddTransient<IEditProductUseCase, EditProductUseCase>();
builder.Services.AddTransient<IViewProductByIdUseCase, ViewProductByIdUseCase>();
builder.Services.AddTransient<IDeleteProductUseCase, DeleteProductUseCase>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

await app.RunAsync();