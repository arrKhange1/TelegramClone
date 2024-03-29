using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelegramClone.Data;
using TelegramClone.Hubs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TelegramClone.Data.Interfaces;
using TelegramClone.Data.Implementations;
using TelegramClone.Services;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.SignalR;
using TelegramClone.Utils;
using System.Diagnostics;

namespace TelegramClone
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
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection), ServiceLifetime.Transient);

            services.AddScoped<IRoleRepository, RoleMSSQLRepository>();
            services.AddScoped<IUserRepository, UserMSSQLRepository>();
            services.AddScoped<IUserRefreshTokensRepository, UserRefreshTokensMSSQLRepository>();
            services.AddScoped<IUserContactRepository, UserContactMSSQLRepository>();
            services.AddScoped<IChatRepository, ChatMSSQLRepository>();
            services.AddScoped<IGroupChatUserRepository, GroupChatUserMSSQLRepository>();
            services.AddScoped<IMessageRepository, MessageMSSQLRepository>();
            services.AddScoped<IChatCategoryRepository, ChatCategoryMSSQLRepository>();
            services.AddScoped<JWTService>();
            services.AddScoped<RefreshTokenService>();
            services.AddScoped<UserService>();
            services.AddScoped<RoleService>();
            services.AddScoped<ContactsService>();
            services.AddScoped<ChatsService>();

            services.AddCors();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidAudience = Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                            Configuration["Jwt:Key"])),
                        ClockSkew = TimeSpan.Zero,
                        NameClaimType = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"
                    };
                    //��� ������ � ������
                    //options.Events = new JwtBearerEvents
                    //{
                    //    OnMessageReceived = context =>
                    //    {
                    //        var accessToken = context.HttpContext.Request.Cookies["access"];
                    //        Debug.WriteLine($"access:{accessToken}");

                    //        // ���� ������ ��������� ����
                    //        var path = context.HttpContext.Request.Path;
                    //        if (!string.IsNullOrEmpty(accessToken) && (path.StartsWithSegments("/chat")))
                    //        {
                    //            // �������� ����� �� ������ �������
                    //            context.Token = accessToken;
                    //        }
                    //        return Task.CompletedTask;
                    //    },

                    //    OnAuthenticationFailed = context =>
                    //    {
                    //        if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                    //        {
                    //            Debug.WriteLine("sds");
                    //            context.Response.Headers.Add("IS-TOKEN-EXPIRED", "true");
                    //        }
                    //        return Task.CompletedTask;
                    //    }
                    //};


                });

            services.AddSignalR();
            services.AddSingleton<IUserIdProvider, CustomUserIdProvider>();

            services.AddMvc();
            services.AddControllers();

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "telegram_client/build";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseCookiePolicy(new CookiePolicyOptions
            {
                MinimumSameSitePolicy = SameSiteMode.Strict,
                HttpOnly = HttpOnlyPolicy.Always,
                Secure = CookieSecurePolicy.Always
            });


            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();

            app.UseCors(options => options
                .WithOrigins(new[] { "http://localhost:3000" })
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials());

            app.Use(async (context, next) =>
            {
                var token = context.Request.Cookies["access"];
                if (!string.IsNullOrEmpty(token))
                    context.Request.Headers.Add("Authorization", "Bearer " + token);
               
                await next();
            });
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<ChatHub>("/chat");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "telegram_client";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
