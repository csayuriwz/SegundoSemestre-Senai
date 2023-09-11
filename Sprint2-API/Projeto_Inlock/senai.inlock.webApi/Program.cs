using Microsoft.IdentityModel.Tokens;
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
    .AddJwtBearer("JwtBearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            //valida quem esta solicitando 
            ValidateIssuer = true,

            //valida quem esta recebendo 
            ValidateAudience = true,

            //define se o tempo de expiracao do token sera valiado
            ValidateLifetime = true,

            //forma de criptografia e ainda validacao da chave de autenticacao
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("jogos-chave-autenticacao-webapi-dev")),

            //valida o tempo de expiracao do token
            ClockSkew = TimeSpan.FromMinutes(5),

            //De onde esta vindo (issuer)
            ValidIssuer = "senai.inlock.webApi.",

            //para onde esta indo
            ValidAudience = "senai.inlock.webApi."
        };

    });

//Adicione o gerador do Swagger à coleção de serviços
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API Filmes",
        Description = "API para o gerenciamento de filmes - Introducao a sprint 2 - Backend-API",
        Contact = new OpenApiContact
        {
            Name = "Catarina Sayuri",
            Url = new Uri("https://github.com/csayuriwz")
        }
    });

    //Configure o Swagger para usar o arquivo XML gerado com as instruções anteriores.
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

    //Usando a autenticacao do swagger
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Value : Bearer TokenJWT"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
                }
            },
            new string[]{}
        }

    });
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

//usar a autenticacao
app.UseAuthentication();

//usar a autorizacao
app.UseAuthorization();

//mapeia os controllers
app.MapControllers();

app.Run();

