using Employee.Business.DTOs;
using Employee.Business.Mappers;
using Employee.Business.Services;
using Employee.DataContext;
using Employee.DataContext.Repositories;
using Employee.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Employee = Employee.Models.Employee;


namespace Employee.Api
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
            services.AddDbContext<EmployeeDataContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddMvc();

            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            services.AddScoped<ISkillService, SkillService>();
            services.AddScoped<ISkillRepository, SkillRepository>();

            services.AddScoped<IMapper<Models.Employee, EmployeeDto>, EmployeeDtoMapper>();
            services.AddScoped<IMapper<Skill, SkillDto>, SkillDtoMapper>();
            services.AddScoped<IMapper<CreateSkillDto, Skill>, CreateSkillDtoMapper>();
            services.AddScoped<IMapper<CreateEmployeeDto, Models.Employee>, CreateEmployeeDtoMapper>();
            services.AddScoped<IMapper<EmployeeDto, Models.Employee>, EmployeeMapper>();
            services.AddScoped<IMapper<SkillDto, Skill>, SkillMapper>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Students API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors(corsPolicyBuilder =>
            {
                corsPolicyBuilder
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowAnyOrigin()
                    .AllowCredentials();
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Student API V1");
            });

            app.UseStaticFiles();

            app.UseMvc();
        }
    }
}
