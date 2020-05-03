using Bot72.repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Bot72
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

            services.AddTransient<CepRepository, CepRepository>();

            // CORS 
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
            });


            services.AddHttpClient();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            
            services.Configure<IISOptions>(options =>
            {
                options.ForwardClientCertificate = false;
            });
            

            // compressao de dados no json
            services.AddResponseCompression();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();


          

            // CORS
            app.UseCors(
                 options => options.AllowAnyOrigin()
                 .AllowAnyHeader()
                 .AllowAnyMethod()
                 .AllowAnyOrigin()
                 );

            
            app.UseResponseCompression();



            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
