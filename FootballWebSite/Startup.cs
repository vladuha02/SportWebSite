using SportWebSite.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SportWebSite.Extensions;
using FluentValidation.AspNetCore;
using FluentValidation;
using SportWebSite.Domain.Entities;
using SportWebSite.Domain.Validators;
using SportWebSite.Data.Repository;
using System;
using Microsoft.AspNetCore.Identity;
using SportWebSite.Data;
using AutoMapper;
using SportWebSite.Mappings;
using Microsoft.AspNetCore.Authentication.Cookies;
using Google.Apis.Auth.AspNetCore3;
using SportWebSite.Security;
using IEmailSender = SportWebSite.Security.IEmailSender;

namespace SportWebSite
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSignalR(options =>
            {
                options.EnableDetailedErrors = true;
            });
            services.AddDbContext<SportContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<User, Role>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
                options.SignIn.RequireConfirmedEmail = true;
                options.SignIn.RequireConfirmedPhoneNumber = false;
            })
               .AddEntityFrameworkStores<SportContext>().AddDefaultUI().AddDefaultTokenProviders();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new UserMappingProfile());
                mc.AddProfile(new PlayerMappingProfile());
                mc.AddProfile(new TeamMappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;
            });

            services.AddMvc()
                .AddFluentValidation()
                .AddRazorRuntimeCompilation();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
               .AddCookie(options =>
               {
                   options.Cookie.HttpOnly = true;
                   options.ExpireTimeSpan = TimeSpan.FromSeconds(10.0);

                   options.SlidingExpiration = false;

                   options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Identity/Account/Login");
                   options.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Identity/Account/Login");
               });

            services.AddSingleton(mapper);

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITeamService, TeamService>();
            services.AddScoped<IPlayerService, PlayerService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IRepository<Player, int>, PlayerRepository>();
            services.AddScoped<IRepository<Team, int>, TeamRepository>();
            services.AddScoped<IRepository<User, string>, UserRepository>();

            services.AddTransient<IValidator<User>, UserValidator>();
            services.AddTransient<IValidator<Team>, TeamValidator>();
            services.AddTransient<IValidator<Player>, PlayerValidator>();
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<IEncrypting, Encrypting>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseHandleExceptionsMiddleware();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();

                endpoints.MapControllerRoute(
                    name: "MyArea",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}