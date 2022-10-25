using EYEEXAMAPI_Parser.Parsers;
using EYEEXAMAPI_Parser.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddTransient<IScheduleService, ScheduleService>();
builder.Services.AddTransient<IScheduleParser, ScheduleParser>();
builder.Services.AddHttpClient("eyeexamapiClient", c => c.BaseAddress = new System.Uri("https://localhost:7203/"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();

app.MapControllers();

app.Run();
