using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using NetCoreBackend.Business.Abstract;
using NetCoreBackend.Business.Concrate;
using NetCoreBackend.Business.DependencyResolvers.Autofac;
using NetCoreBackend.Core.DependencyResolvers;
using NetCoreBackend.Core.Extensions;
using NetCoreBackend.Core.Utilities.IoC;
using NetCoreBackend.Core.Utilities.Security.Encryption;
using NetCoreBackend.Core.Utilities.Security.JWT;
using NetCoreBackend.DataAccess.Abstract;
using NetCoreBackend.DataAccess.Concrate.Context;
using NetCoreBackend.DataAccess.Concrate.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<NorthwindContext>();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory()).ConfigureContainer<ContainerBuilder>(opt =>
{
    opt.RegisterModule(new AutofacBusinessModule());
});
var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = tokenOptions.Issuer,
            ValidAudience = tokenOptions.Audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
        };
    });

// Ýleride baþka modullerimiz olursa new diyerek yanýna ekleyebiliriz
builder.Services.AddDependencyResolvers(new ICoreModule[]
{
    new CoreModule()
});
ServiceTool.Create(builder.Services);



//builder.Services.AddScoped<IProductDal, EfProdcutDal>();

//builder.Services.AddScoped<IProductService, ProductManager>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
