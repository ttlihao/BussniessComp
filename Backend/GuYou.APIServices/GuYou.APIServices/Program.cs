using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using GuYou.Repositories.Models;
using GuYou.Repositories.DbContext;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using AutoMapper;
using GuYou.Repositories.Configure;
using FluentValidation;
using GuYou.Services.Implements;
using GuYou.Services.Interfaces;
using GuYou.Repositories.Repositories.Interfaces;
using GuYou.Repositories.Repositories.Implements;
using Microsoft.AspNetCore.Identity.UI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpContextAccessor();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "v1",
        Title = "API"

    });

    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "JWT Authorization header sử dụng scheme Bearer.",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Name = "Authorization",
        Scheme = "bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {
            {
                new OpenApiSecurityScheme
                {
                Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    },
                    Scheme = "oauth2",
                    Name = "Bearer",
                    In = ParameterLocation.Header,
                },
                new List<string>()
                }
            });
});

builder.Services.AddAutoMapper(typeof(MappingProfile));
var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});
IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddSingleton<TokenValidationParameters>(provider =>
{
    return new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidAudience = builder.Configuration["Jwt:Issuer"],
        ValidIssuer = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!)),
        ClockSkew = TimeSpan.FromMinutes(60)
    };
});
builder.Services.AddIdentityCore<User>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<CoffeShopManagementContext>();

builder.Services.AddIdentityCore<User>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;
})
.AddEntityFrameworkStores<CoffeShopManagementContext>();


builder.Services.AddScoped<IUserRepository, UserRepository>();


builder.Services.AddScoped<IUserContextService, UserContextService>();
builder.Services.AddScoped<ITimeService, TimeService>();
builder.Services.AddScoped<IAuthenticateService, AuthenticateService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IEmailService, EmailService>();

// Add the services for the newly implemented entities
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICoffeeBeanService, CoffeeBeanServices>();
builder.Services.AddScoped<ICoffeeMixService, CoffeeMixServices>();
builder.Services.AddScoped<ICoffeeMixDetailService, CoffeeMixDetailServices>();
builder.Services.AddScoped<IDiscountService, DiscountServices>();
builder.Services.AddScoped<IInventoryService, InventoryServices>();
builder.Services.AddScoped<IOrderService, OrderServices>();
builder.Services.AddScoped<IOrderDetailService, OrderDetailServices>();
builder.Services.AddScoped<IPackagingService, PackagingServices>();
builder.Services.AddScoped<IPaymentService, PaymentServices>();
builder.Services.AddScoped<IReviewService, ReviewServices>();
builder.Services.AddScoped<IReviewLikeService, ReviewLikeServices>();
builder.Services.AddScoped<IShippingDetailService, ShippingDetailServices>();
builder.Services.AddScoped<ISupplierService, SupplierServices>();

// Add the repositories for dependency injection
builder.Services.AddScoped<CategoryRepository>();
builder.Services.AddScoped<CoffeeBeanRepository>();
builder.Services.AddScoped<CoffeeMixRepository>();
builder.Services.AddScoped<CoffeeMixDetailRepository>();
builder.Services.AddScoped<DiscountRepository>();
builder.Services.AddScoped<InventoryRepository>();
builder.Services.AddScoped<OrderRepository>();
builder.Services.AddScoped<OrderDetailRepository>();
builder.Services.AddScoped<PackagingRepository>();
builder.Services.AddScoped<PaymentRepository>();
builder.Services.AddScoped<ReviewRepository>();
builder.Services.AddScoped<ReviewLikeRepository>();
builder.Services.AddScoped<ShippingDetailRepository>();
builder.Services.AddScoped<SupplierRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
});
builder.Services.AddDbContext<CoffeShopManagementContext>(options =>
    options.UseSqlServer("server=localhost;database=CoffeShopManagement;uid=sa;pwd=12345;Integrated Security=true;Trusted_Connection=false;TrustServerCertificate=True"));


builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<CoffeShopManagementContext>()
    .AddDefaultTokenProviders();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!)),
        ClockSkew = TimeSpan.FromMinutes(5)
    };
})
.AddCookie(options =>
{
    options.Cookie.Name = "jwt";
    options.Events = new CookieAuthenticationEvents
    {
        OnValidatePrincipal = async context =>
        {
            var token = context.Request.Cookies["jwt"];
            var handler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]);
            var validations = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = true,
                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                ValidateAudience = true,
                ValidAudience = builder.Configuration["Jwt:Audience"],
                ValidateLifetime = true
            };

            var principal = handler.ValidateToken(token, validations, out var securityToken);
            context.Principal = principal;
        }
    };
});
//.AddGoogle(googleOptions => {
//    googleOptions.ClientId = builder.Configuration["Authentication:Google:ClientId"];
//    googleOptions.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
//}
//);

//builder.Services.AddIdentityApiEndpoints<User>()
//    .AddEntityFrameworkStores<CoffeShopManagementContext>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAll");
app.UseHttpsRedirection();

app.UseRouting();
app.Use(async (context, next) =>
{
    context.Response.Headers.Append("Access-Control-Allow-Origin", "*");
    context.Response.Headers.Append("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS");
    context.Response.Headers.Append("Access-Control-Allow-Headers", "Content-Type, Authorization");
    if (context.Request.Method == "OPTIONS")
    {
        context.Response.StatusCode = 204;
        await context.Response.CompleteAsync();
        return;
    }
    await next();
});


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();


app.Run();
