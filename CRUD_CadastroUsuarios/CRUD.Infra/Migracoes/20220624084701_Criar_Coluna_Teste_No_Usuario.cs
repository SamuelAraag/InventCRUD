using FluentMigrator;
using FluentMigrator.SqlServer;

namespace CRUD.Infra.Migracoes
{
    [Migration(20220624084701)]
    public class _20220624084701_Criar_Coluna_Teste_No_Usuario : Migration
    {
        public override void Up()
        {
            Create.Table("Usuario")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity(100, 1)
                .WithColumn("Nome").AsString(int.MaxValue).NotNullable()
                .WithColumn("Senha").AsString(int.MaxValue).NotNullable()
                .WithColumn("Email").AsString(int.MaxValue).NotNullable()
                .WithColumn("DataNascimento").AsDateTime().Nullable()
                .WithColumn("DataCriacao").AsDateTime().NotNullable();

        }
        public override void Down()
        {

        }
    }
}
