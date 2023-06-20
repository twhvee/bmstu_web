using Course.Model;
using Course.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Cors;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RevWorld.Model;
using RevWorld.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace RevWorld
{
    public class Startup
    {
        private readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.RequireHttpsMetadata = false;
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            // укзывает, будет ли валидироваться издатель при валидации токена
                            ValidateIssuer = true,
                            // строка, представляющая издателя
                            ValidIssuer = AuthOptions.ISSUER,

                            // будет ли валидироваться потребитель токена
                            ValidateAudience = true,
                            // установка потребителя токена
                            ValidAudience = AuthOptions.AUDIENCE,
                            // будет ли валидироваться время существования
                            ValidateLifetime = true,

                            // установка ключа безопасности
                            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                            // валидация ключа безопасности
                            ValidateIssuerSigningKey = true,
                        };
                    });

            /*
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = new PathString("/Account/Login");
                });
            */

            services.AddControllersWithViews();
            string connectionString = "Host=localhost;Port=5432;Database=dbcourse;Username=postgres;Password=klainer1";
            services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(connectionString));
            services.AddTransient<IBooksRepository, BooksRepository>();
            services.AddTransient<IReviewsRepository, ReviewRepository>();
            services.AddTransient<ICommentsRepository, CommentsRepository>();
            services.AddTransient<ITagsRepository, TagsRepository>();
            services.AddTransient<IUsersRepository, UsersRepository>();
            services.AddTransient<ITagReviewRepository, TagReviewRepository>();
            services.AddTransient<ReviewService>();
            services.AddTransient<UserService>();         
            services.AddTransient<BookService>();
            services.AddTransient<CommentService>();
            services.AddTransient<TagService>();
            services.AddTransient<TagReviewService>();

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            // Add framework services.
            services.AddCors(); // Make sure you call this previous to AddMvc
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

                // Set the comments path for the Swagger JSON and UI.
                //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                // var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //c.IncludeXmlComments(xmlPath);

                //c.DescribeAllEnumsAsStrings();

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                        new string[]{}
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
            }

            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("Server", "RevWorld");
                await next.Invoke();
            });

            app.UseSwaggerUI(c =>
            {

                c.RoutePrefix = "api/v1/swagger";
                //c.RoutePrefix = string.Empty;
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.SwaggerEndpoint("../swagger/v1/swagger.json", "My API V1");
            });

            app.UseSwaggerUI();

            /*
            app.UseSwagger(c =>
            {
                c.RouteTemplate = "swagger/{documentName}/swagger.json";
                c.PreSerializeFilters.Add((swaggerDoc, httpReq) =>
                {
                    swaggerDoc.Servers = new List<OpenApiServer> { new OpenApiServer { Url = $"{httpReq.Scheme}://localhost/api/v1/" } };
                });
            });

            

            /*
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {

                c.RoutePrefix = "api";
                //c.RoutePrefix = string.Empty;
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            */


            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            //app.UseMvc();

            // app.UseMvc();

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();


            //app.UseEndpoints(endpoints =>
            //{
                
             //   endpoints.MapControllers();
            //});


            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
            
        }
    }
}
