using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Symphony.BlazorServerApp.Areas.Identity;
using Symphony.BlazorServerApp.Services.AboutServices;
using Symphony.BlazorServerApp.Services.BatchServices;
using Symphony.BlazorServerApp.Services.CourseRegistrationService;
using Symphony.BlazorServerApp.Services.CourseServices;
using Symphony.BlazorServerApp.Services.EnrollmentServices;
using Symphony.BlazorServerApp.Services.EventServices;
using Symphony.BlazorServerApp.Services.FaqServices;
using Symphony.BlazorServerApp.Services.NewService;
using Symphony.BlazorServerApp.Services.PaymentStatusServices;
using Symphony.BlazorServerApp.Services.SubjectServices;
using Symphony.Data.EF;
using Symphony.Data.Entities;
using Symphony.Services.BackendServices.EmailSenderService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Symphony.BlazorServerApp
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
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<AppUser>>();
            services.AddDatabaseDeveloperPageExceptionFilter();

            /*
             * Config HttpClient to consumes a web api name symphony with specify uri.
             */
            services.AddHttpClient("symphony", c => { c.BaseAddress = new Uri("http://localhost:39699/api/"); });

            // Add Email Sending Service
            services.AddScoped<IEmailSender, EmailSender>();
            services.Configure<AuthMessageSenderOptions>(Configuration);

            /*
             * DI services
             */
            services.AddTransient<IAboutService, AboutService>();
            services.AddTransient<IBatchService, BatchService>();
            services.AddTransient<ICourseService, CourseService>();
            services.AddTransient<ICourseRegistrationService, CourseRegistrationService>();
            services.AddTransient<IEnrollmentService, EnrollmentService>();
            services.AddTransient<IEventService, EventService>();
            services.AddTransient<IFaqService, FaqService>();
            services.AddTransient<INewService, NewService>();
            services.AddTransient<ISubjectService, SubjectService>();
            services.AddTransient<IPaymentStatusService, PaymentStatusService>();

            /* Google Auth */
            //services.AddAuthentication()
            //    .AddGoogle(options =>
            //    {
            //        IConfigurationSection googleAuthNSection =
            //            Configuration.GetSection("Authentication:Google");

            //        options.ClientId = googleAuthNSection["ClientId"];
            //        options.ClientSecret = googleAuthNSection["ClientSecret"];
            //    });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}