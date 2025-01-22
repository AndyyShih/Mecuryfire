using Mecuryfire.DependencyInjectionTool;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//�ޥ�DI���U��k
DependencyInjectionTool.AddDIContainer(builder.Services);

#region Cors Setting

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowSpecificOrigin", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

#endregion

#region SwaggerUI

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "NewProject",
        Version = "2024.10.11",
        Description = "�űM�׽d��",
    });

    // ���J�D�M�ת� XML �����ɮ�
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);

    //���J��L���O�w�� XML �����ɮ�
    var businessRuleXml = Path.Combine(AppContext.BaseDirectory, "BusinessRule.xml");
    var dataAccessXml = Path.Combine(AppContext.BaseDirectory, "DataAccess.xml");
    var commonXml = Path.Combine(AppContext.BaseDirectory, "Common.xml");

    c.IncludeXmlComments(businessRuleXml);
    c.IncludeXmlComments(dataAccessXml);
    c.IncludeXmlComments(commonXml);

});

#endregion




builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
