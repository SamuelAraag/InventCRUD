using CRUD.Dominio;
using CRUD.Infra;
using FluentAssertions.Common;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CRUD_CadastroUsuarios  
{

    internal static class Program
    {
        /// <summary>
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            var builder = CreateHostBuilder(args)
                .Build();

            builder.RunAsync();

            var usuarioRepositorio = builder
                .Services
                .GetRequiredService<IUsuarioRepositorio>();

            // see https://aka.ms/applicationconfiguration.
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormularioConsultaUsuarios(usuarioRepositorio));
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                    services.AddScoped<IUsuarioRepositorio, UsuarioRepositorioComBanco>());
        }
    }
}