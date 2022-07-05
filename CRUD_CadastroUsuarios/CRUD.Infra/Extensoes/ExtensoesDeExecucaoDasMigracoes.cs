using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Reflection;

namespace CRUD.Infra.ContextoDoBanco
{
    public static class ExtensoesDeExecucaoDasMigracoes
    {
        public static void ConfigurarFluentMigrator(this IServiceCollection servicos)
        {
            servicos
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    .AddSqlServer()
                    .WithGlobalConnectionString(ConfigurationManager.ConnectionStrings["conexaoSql"].ConnectionString)
                    .ScanIn(Assembly.GetExecutingAssembly()).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                .BuildServiceProvider(false);
        }
    }
}
