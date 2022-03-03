using System;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Expension.Database;
using Expension.Database.Repositories.BoughtItem;
using Expension.Database.Repositories.Expense;
using Expension.Database.Repositories.Item;
using Expension.Database.Repositories.User;
using Expension.Services.BoughtItem;
using Expension.Services.Expense;
using Expension.Services.Item;
using Expension.Services.User;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using VueCliMiddleware;
using System.Threading.Tasks;

namespace Expension
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.SetIsOriginAllowed(origin =>
                    {
                        var host = new Uri(origin).Host;
                        return host == "localhost" || host ==  "localhost:8080";
                    }).AllowAnyMethod().AllowAnyHeader();
                    // builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "expension.azurewebsites.net");
                });
            });

            services.AddControllers();
            var dupa = Configuration.GetValue<String>("ASPNETCORE_ConnectionString");
            services.AddDbContext<ExpensionDataContext>(options =>
                options.UseSqlServer(Configuration.GetValue<String>("ASPNETCORE_ConnectionString")));

            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IBoughtItemRepository, BoughtItemRepository>();
            services.AddScoped<IExpenseRepository, ExpenseRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IBoughtItemService, BoughtItemService>();
            services.AddScoped<IExpenseService, ExpenseService>();
            services.AddScoped<IUserService, UserService>();

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //services.AddSpaStaticFiles(configuration =>
            //{
            //    configuration.RootPath = "Expension.Front/dist";
            //});

            services.AddAuthentication(options => {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["JWT:Key"])),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy => policy.RequireClaim(ClaimTypes.Role, "admin"));
                options.AddPolicy("LoggedUserOnly", policy => policy.RequireClaim(ClaimTypes.Role, "admin", "user"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ExpensionDataContext dataContext)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // dataContext.Database.Migrate();

            app.UseHttpsRedirection();

            //app.UseSpaStaticFiles();

            app.UseRouting();

            app.UseCors();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("dupa");
                });
                endpoints.MapControllers();
            });

            //app.UseSpa(spa =>
            //{
            //    spa.Options.SourcePath = "../Expension.Front";
            //    if (env.IsDevelopment())
            //    {
            //        spa.UseVueCli("serve", 8080);
            //    }
            //});
        }
    }
}
