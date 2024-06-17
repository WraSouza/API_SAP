using API_SAP.Endpoint;
using API_SAP.Endpoint.BusinessPartnerEndpoints;
using API_SAP.Endpoint.EstoqueEndpoints;
using API_SAP.Endpoint.MagentoOrdersEndpoints;
using API_SAP.Models;
using API_SAP.Services.Implementations.WriteServices.WriteStocks;
using Coravel;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScheduler();
builder.Services.AddTransient<WriteStoreStockServices>();

builder.Services.Configure<Token>(builder.Configuration.GetSection("MyKeys"));

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
.WithTags("Itens");

app.MapGroup("")
.BusinessPartnerEndpoints()
.WithTags("Business Partner");

app.MapGroup("")
.MagentoOrdersEndpoints()
.WithTags("Orders in Magento");

app.MapGroup("")
.StockInStoreEndpoints()
.WithTags("Stock In Store");

app.MapGroup("")
.EstoquesEndpoints()
.WithTags("Stock In SAP");

app.UseHttpsRedirection();
app.UseSwaggerUI();
app.Run();

