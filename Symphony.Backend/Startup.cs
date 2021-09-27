using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Symphony.Data.EF;
using Symphony.Services.BackendServices.AboutServices;
using Symphony.Services.BackendServices.BatchServices;
using Symphony.Services.BackendServices.ConsultServices;
using Symphony.Services.BackendServices.CourseServices;
using Symphony.Services.BackendServices.EventServices;
using Symphony.Services.BackendServices.FAQServices;
using Symphony.Services.BackendServices.NewsServices;
using Symphony.Services.BackendServices.QuestionServices;
using Symphony.Services.BackendServices.SubjectServices;
using Symphony.Services.BackendServices.TeacherServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Symphony.Backend
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
            services.AddDbContext<SymphonyDBContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("SymphonyDb")));

            /*
             * Data Injection
             */
            services.AddTransient<ITeacherService, TeacherService>();
            services.AddTransient<INewsService, NewsService>();
            services.AddTransient<IConsultService, ConsultService>();
            services.AddTransient<IAboutService, AboutService>();
            services.AddTransient<IFAQService, FAQService>();
            services.AddTransient<IEventService, EventService>();
            services.AddTransient<ISubjectService, SubjectService>();
            services.AddTransient<ICourseService, CourseService>();
            services.AddTransient<IQuestionService, QuestionService>();
            services.AddTransient<IBatchService, BatchService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Symphony.Backend", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Symphony.Backend v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}