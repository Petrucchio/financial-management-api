using FinancialManagementAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new()
    {
        Title = "Financial Management API",
        Version = "v1",
        Description = "API for managing personal financial transactions."
    });
});

builder.Services.AddSingleton<ITransactionService, TransactionService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler("/error"); // ← middleware global de erros
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();