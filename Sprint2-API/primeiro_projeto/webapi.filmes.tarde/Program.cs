using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//adiiciona o servico de controllers
builder.Services.AddControllers();

//adiciona o servico de autenticacao JWT Bearer
builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = "JwtBearer";
    options.DefaultAuthenticateScheme = "JwtBearer";
})

    //define os parametros de validacao do token
    .AddJwtBearer(options => { }); //continuar segunda

//Adicione o gerador do Swagger à coleção de serviços
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API Filmes",
        Description = "API para o gerencamento de filmes - Introducao a sprint 2 - Backend-API",
        Contact = new OpenApiContact
        {
            Name = "Catarina Sayuri",
            Url = new Uri("https://github.com/csayuriwz")
        }
    });

    //Configure o Swagger para usar o arquivo XML gerado com as instruções anteriores.
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();

//habilite o middleware para atender ao documento JSON gerado e à interface do usuário do Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Para atender à interface do usuário do Swagger na raiz do aplicativo
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

//mapeia os controllers
app.MapControllers();

app.Run();
  