using System.Text.Json.Serialization;
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
            services.AddControllers();

            services.AddDbContext<ExpensionDataContext>();

            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IBoughtItemRepository, BoughtItemRepository>();
            services.AddScoped<IExpenseRepository, ExpenseRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IBoughtItemService, BoughtItemService>();
            services.AddScoped<IExpenseService, ExpenseService>();

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
