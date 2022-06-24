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

            //Fluent Migration, fazendo testes
            using (var scope = builder.Services.CreateScope())
            {
                UpdateDatabase(scope.ServiceProvider);
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormularioConsultaUsuarios(usuarioRepositorio));
        }

        private static void UpdateDatabase(IServiceProvider serviceProvider)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
            runner.MigrateUp();
        }

        //Injeção de dependência
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