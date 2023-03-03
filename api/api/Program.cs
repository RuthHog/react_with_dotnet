using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Configuration.AddEnvironmentVariables();


builder.Services.AddCors(options => options.AddPolicy("CorsPolicy", policy =>
{
    policy.AllowAnyHeader().AllowAnyMethod().AllowCredentials().WithOrigins("http://localhost:3000");
}));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{

    //options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    //{
    //    Type = SecuritySchemeType.OAuth2,
    //    Flows = new OpenApiOAuthFlows()
    //    {
    //        //Implicit = new OpenApiOAuthFlow()
    //        //{
    //        //    AuthorizationUrl = new Uri($"https://login.microsoftonline.com/{builder.Configuration["AzureAd:TenantId"]}/oauth2/v2.0/authorize"),
    //        //    TokenUrl = new Uri($"https://login.microsoftonline.com/common/oauth2/token"),
    //        //    Scopes = new Dictionary<string, string>
    //        //{
    //        //    { $"api://{builder.Configuration["AzureAd:ClientId"]}/user_impersonation", "Access to spts api" }
    //        //}
    //        //}
    //    }
    //});


    options.AddSecurityDefinition(
    "oauth2",
    new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\"),",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });


    //options.AddSecurityRequirement(new OpenApiSecurityRequirement()
    //{
    //    {
    //       new OpenApiSecurityScheme
    //       {
    //            Reference = new OpenApiReference
    //            {
    //                Type = ReferenceType.SecurityScheme,
    //                Id = "oauth2"
    //            },
    //            Scheme = "oauth2",
    //            Name = "oauth2",
    //            In = ParameterLocation.Header
    //       },
    //        new List<string>()
    //    }
    //});
});


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
  .AddMicrosoftIdentityWebApi(builder.Configuration);



var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseCors("CorsPolicy");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
