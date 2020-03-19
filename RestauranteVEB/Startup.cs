using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Impl;
using BLL.Interfaces;
using DAO;
using DAO.Impl;
using DAO.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace RestauranteVEB
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
            //Adicionar os services para injeção de dependencia
            services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();

            services.AddTransient<IPedidoService, PedidoService>();
            services.AddTransient<IPedidoRepository, PedidoRepository>();

            services.AddTransient<IIngredienteService, IngredienteService>();
            services.AddTransient<IIngredienteRepository, IngredienteRepository>();

            services.AddTransient<IRefeicaoService, RefeicaoService>();
            services.AddTransient<IRefeicaoRepository, RefeicaoRepository>();

            services.AddTransient<IBebidaService, BebidaService>();
            services.AddTransient<IBebidaRepository, BebidaRepository>();

            services.AddTransient<ISobremesaService, SobremesaService>();
            services.AddTransient<ISobremesaRepository, SobremesaRepository>();

            //Definindo a conection string.
            services.AddDbContextPool<RContext>(c => c.UseSqlServer(Configuration["ConnectionString"]));

            //Adicionando todas configurações.
            services.AddControllersWithViews();

            //COOKIES   
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = "/Usuario/Login";
                options.LogoutPath = "/Usuario/LogOff";
                options.Cookie.Name = "AshProgHelpCookie";
                options.AccessDeniedPath = "/Home/Index";
            });
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            //COOKIES
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCookiePolicy();
           
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
