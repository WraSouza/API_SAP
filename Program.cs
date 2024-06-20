using API_SAP.Endpoint;
using API_SAP.Endpoint.BusinessPartnerEndpoints;
using API_SAP.Endpoint.EstoqueEndpoints;
using API_SAP.Endpoint.MagentoOrdersEndpoints;
using API_SAP.Endpoint.SAPEndpoints;
using API_SAP.Models;
using API_SAP.Services.Implementations.WriteServices.LoginService;
using API_SAP.Services.Implementations.WriteServices.WriteStocks;
using API_SAP.Services.Interfaces.IWriteInterfaces.ILogin;
using Coravel;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScheduler();
builder.Services.AddTransient<WriteStoreStockServices>();
builder.Services.AddSingleton<ILoginService, LoginServices>();

var app = builder.Build();

app.Services.UseScheduler(scheduler => 
{
    scheduler.Schedule<WriteStoreStockServices>()
    .Weekly();
});


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGroup("")
.ItemsEndpoints()
.WithTags("SAP - Itens");

app.MapGroup("")
.BusinessPartnerEndpoints()
.WithTags("SAP - Business Partner");

app.MapGroup("")
.MagentoEndpoints()
.WithTags("Magento");

app.MapGroup("")
.StockInStoreEndpoints()
.WithTags("Magento - Estoque");

app.MapGroup("")
.StockSAPEndpoints()
.WithTags("SAP - Estoques");

app.UseHttpsRedirection();
app.UseSwaggerUI();
app.Run();

