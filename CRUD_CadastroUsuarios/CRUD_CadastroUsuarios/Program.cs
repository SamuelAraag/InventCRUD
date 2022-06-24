using CRUD.Dominio;
using CRUD.Infra;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using CRUD.Infra.ContextoDoBanco;

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

            using (var scope = builder.Services.CreateScope())
            {
                AtualizarBanco(scope.ServiceProvider);
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormularioConsultaUsuarios(usuarioRepositorio));
        }

        private static void AtualizarBanco(IServiceProvider serviceProvider)
        {
            var executar = serviceProvider.GetRequiredService<IMigrationRunner>();
            executar.MigrateUp();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, servicos) => ConfigurarServicos(servicos));
        }

        private static void ConfigurarServicos(IServiceCollection servicos)
        {
            servicos.AddScoped<IUsuarioRepositorio, UsuarioRepositorioComLinqToDb>();
            servicos.ConfigurarFluentMigrator();
        }
    }
}