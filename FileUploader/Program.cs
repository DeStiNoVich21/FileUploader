using FileUploader.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("Policy", corsBuilder =>
    {
        corsBuilder.WithOrigins(builder.Configuration["CorsUrls"].Split(";"))
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});
builder.Services.AddScoped<IServices, Services>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseCors("Policy");

app.UseAuthorization();

app.MapControllers();

app.Run();
