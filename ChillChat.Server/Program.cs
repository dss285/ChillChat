using ChillChat.DataModels;
using ChillChat.Server;
using ChillChat.Server.Hubs;
using ChillChat.Services;
using Microsoft.AspNetCore.SignalR;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Configuration.AddJsonFile("appsettings.json");

builder.Services.AddControllers()
    .AddJsonOptions(options => { options.JsonSerializerOptions.PropertyNamingPolicy = null; });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR(options =>
{

}).AddJsonProtocol(options => options.PayloadSerializerOptions.PropertyNamingPolicy = null);

builder.Services.AddTransient(sp => sp);
builder.Services.AddTransient(sp => new ChillChatDbRepository(builder.Configuration));
builder.Services.AddTransient(sp => new MessageService(sp.GetRequiredService<ChillChatDbRepository>()));
builder.Services.AddTransient(sp => new ServerService(sp.GetRequiredService<ChillChatDbRepository>()));
builder.Services.AddTransient(sp => new ChannelService(sp.GetRequiredService<ChillChatDbRepository>()));

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy => policy.SetIsOriginAllowed((_) => true).AllowCredentials().AllowAnyHeader().AllowAnyMethod());
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();

//app.UseHttpsRedirection();
//app.UseAuthorization();

app.MapHub<ChatHub>("/Chat");
app.MapControllers();

app.Run();
