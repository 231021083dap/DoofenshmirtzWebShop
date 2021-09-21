using DoofenshmirtzsWebShop.Authorization;
using DoofenshmirtzsWebShop.Database;
using DoofenshmirtzsWebShop.Helpers;
using DoofenshmirtzsWebShop.Repositories;
using DoofenshmirtzsWebShop.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace DoofenshmirtzsWebShop
{
    public class Startup
    {
        private readonly string CORSRules = "_CORSRules";
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;

        public Startup(IWebHostEnvironment env, IConfiguration configuration)
        {
            _env = env;
            _configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
            options.AddPolicy(name: CORSRules,
                builder => 
                    {
                        builder.WithOrigins("http://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    });
            });

            // Users
            services.Configure<AppSettings>(_configuration.GetSection("AppSettings"));
            services.AddScoped<IJwtUtils, JwtUtils>();

            services.AddDbContext<DoofenshmirtzWebShopContext>(o => o.UseSqlServer(_configuration.GetConnectionString("Default")));

            services.AddScoped<ICategoryService, CategoryServices>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            services.AddScoped<IOrderService, OrderServices>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            services.AddScoped<IProductService, ProductServices>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<IUserService, UserServices>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DoofenshmirtzsWebShop", Version = "v1" });
                //To enable authorization using Swagger (JWT) 
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\r\r\n Enter 'Bearer'[space] and then your token in the text input below. \r\r\r\n Example: \"Bearer 1234abcdef\"",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
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
                        new string[] {}
                    }
                });

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DoofenshmirtzsWebShop v1"));
            }

            app.UseHttpsRedirection();

            app.UseCors(CORSRules);

            app.UseRouting();

            //app.UseAuthorization();

            app.UseMiddleware<JwtMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
