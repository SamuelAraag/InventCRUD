using CRUD.Dominio;
using CRUD.Infra;
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

            MapeamentoDasTabelas.Mapear();

            var usuarioRepositorio = builder
                .Services
                .GetRequiredService<IUsuarioRepositorio>();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormularioConsultaUsuarios(usuarioRepositorio));
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                    //services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>());
                    services.AddScoped<IUsuarioRepositorio, UsuarioRepositorioComLinqToDb>());
                    //services.AddScoped<IUsuarioRepositorio, UsuarioRepositorioComBanco>());

        }
    }
}