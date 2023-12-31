using API_testing1.Context;
using API_testing1.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MyAllowSpecificOrigins",
                      builder =>
                      {
                          builder.WithOrigins("http://127.0.0.1:5500")
                                 .AllowAnyHeader()
                                 .AllowAnyMethod();
                      });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRouting(routing => routing.LowercaseUrls = true);

bool contextIsLocal = false;
if (!bool.TryParse(builder.Configuration.GetConnectionString("ConnectionString_isLocal"), out contextIsLocal))
{
    contextIsLocal = false;
}

if (contextIsLocal)
{
    builder.Services.AddDbContext<ContextDB>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString_apitesting1db_local")));
}
else
{
    builder.Services.AddDbContext<ContextDB>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString_apitesting1db_remote")));
}


/* ------------ SERVICES ------------ */
builder.Services.AddTransient<ServiceCustomer>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("MyAllowSpecificOrigins");  // Apply the CORS policy, always after UserRouting
app.UseAuthorization();
app.MapControllers();

app.Run();
