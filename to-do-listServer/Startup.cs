using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using to_do_listServer.Config;
using to_do_listServer.Config.Jwt;
using to_do_listServer.Database;
using to_do_listServer.Services;
using Microsoft.OpenApi.Models;
using to_do_listServer.Models;
using to_do_listServer.Services.Implementation;
using to_do_listServer.Services.Interfaces;


namespace to_do_listServer
{
    public class Startup
    {
        private const string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), Configuration["ImageFolder"]));

            services.AddDbContext<Context>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddHttpsRedirection(options =>
            {
                options.RedirectStatusCode = StatusCodes.Status307TemporaryRedirect;
                options.HttpsPort = 5001;
            });

            services.AddControllers().AddNewtonsoftJson(x =>
                x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.Configure<FormOptions>(o =>
            {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "Blog", Version = "v1"}); });

            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowCredentials()
                            .AllowAnyMethod();
                    });
            });


            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.AddScoped<IJwtUtils, JwtUtils>();
            services.AddScoped<IUserService, UserService>();

            // services.AddTransient<IBaseRepository<Post>, BaseRepository<Post>>();
            services.AddTransient<IPostService, PostService>();
            services.AddScoped<IPostService, PostService>();
            services.AddTransient<IBaseRepository<Image>, BaseRepository<Image>>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger(c => { c.SerializeAsV2 = true; });
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Blog v1"));
            }

            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider =
                    new PhysicalFileProvider(
                        Path.Combine(Directory.GetCurrentDirectory(), Configuration["ImageFolder"])),
                RequestPath = new PathString("/" + Configuration["ImageFolder"])
            });
            app.UseHttpsRedirection();
            app.UseCors(MyAllowSpecificOrigins);

            app.UseRouting();

            // app.UseAuthorization();
            // app.UseAuthentication();

            app.UseMiddleware<ErrorHandlerMiddleware>();

            // custom jwt auth middleware
            app.UseMiddleware<JwtMiddleware>();

            app.UseEndpoints(x => x.MapControllers());
        }
    }
}