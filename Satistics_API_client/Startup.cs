using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Platform.Common.Location;
using Twilight.Kernel.Configuration;
using Twilight.Kernel.Logging;
using Twilight.Kernel.Security.Validation;
using Twilight.Kernel.Spatial;
using Twilight.Kernel.Web;

namespace Satistics_API_client
{
    public class Startup
    {
        public Startup(Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public Microsoft.Extensions.Configuration.IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddTransient<ICustomConfigurator<IHttpResourceRetriever>, ResourceRetrieverCustomConfigurator>();
            services.AddTransient<IBackchannelCertificateValidator, Twilight.Platform.Web.HttpClient.BackchannelCertificateValidator>();
            services.AddTransient<ICertificateValidationConfigurationProvider, CertificateValidationConfigurationProvider>();
            services.AddTransient(typeof(IEventLogger<>),typeof(Logger<>));
            services.AddSingleton<Microsoft.Extensions.Logging.LoggerFactory>();
            services.AddTransient<Twilight.Platform.Web.HttpClient.HttpClient>();
            services.AddTransient<ConfigurationManager>();
            services.AddTransient<ILocationService, LocationService>();
            MvcServiceCollectionExtensions.AddControllers(services);
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
#if !DEBUG
                app.UseHsts();
#endif
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
