using FluentValidation.AspNetCore;
using Mc2.CrudTest.Presentation.Server.Core.Repositories.Base;
using Mc2.CrudTest.Presentation.Server.Filters;
using Mc2.CrudTest.Presentation.Server.Infrastructure.Data;
using MicroElements.Swashbuckle.FluentValidation;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Mc2.CrudTest.Presentation.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.Scan(scan => scan
               .FromCallingAssembly()
               .AddClasses(classes => classes.AssignableTo<IService>())
               .AsMatchingInterface()
               .WithScopedLifetime());

            services.AddControllers(options =>
            options.Filters.Add<ApiExceptionFilterAttribute>())
                 .AddFluentValidation(o =>
                 {
                     o.RegisterValidatorsFromAssemblyContaining<Startup>();
                     // Optionally set validator factory if you have problems with scope resolve inside validators.
                     o.ValidatorFactoryType = typeof(HttpContextServiceProviderValidatorFactory);
                 });

            //services.AddRazorPages();
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddDbContext<ApplicationDbContext>(options =>
             options.UseSqlServer(
                Configuration.GetConnectionString("DefaultConnection")
                 ));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DARsimWebApp", Version = "v1" });

            });

            services.AddFluentValidationRulesToSwagger();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseWebAssemblyDebugging();
            }
            else
            {
                //app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Crud Test App v1"));

            app.UseHttpsRedirection();
            //app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
