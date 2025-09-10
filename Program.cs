using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Projeto_ASP.NET_Core_ATEC.Data;
using Projeto_ASP.NET_Core_ATEC.Data.Repositories;
using System.Threading.Tasks;

namespace Projeto_ASP.NET_Core_ATEC
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
             

            builder.Services.AddDbContext<BancoContext>( 
                options => options.UseSqlServer( 
                    builder.Configuration.GetConnectionString
                    ("DataBase"))); 

            


            builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
            builder.Services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
            builder.Services.AddScoped<IProjetoRepository, ProjetoRepository>();
            builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();



            // Add services to the container.
            builder.Services.AddControllersWithViews();



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Login}/{action=Index}/{id?}")
                .WithStaticAssets();


            

            app.Run();
        }
    }
}
