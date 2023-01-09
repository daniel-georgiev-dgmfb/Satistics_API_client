using Convesys.Kernel.Configuration;
using Convesys.Kernel.Logging;
using Convesys.Kernel.Security.Validation;
using Convesys.Kernel.Web;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
            services.AddTransient<IBackchannelCertificateValidator, Convesys.Platform.Web.HttpClient.BackchannelCertificateValidator>();
            services.AddTransient<ICertificateValidationConfigurationProvider, CertificateValidationConfigurationProvider>();
            services.AddTransient(typeof(IEventLogger<>),typeof(Convesys.Providers.Logging.Microsoft.Logger<>));
            services.AddTransient<Convesys.Platform.Web.HttpClient.HttpClient>();
            services.AddTransient<ConfigurationManager>();
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
