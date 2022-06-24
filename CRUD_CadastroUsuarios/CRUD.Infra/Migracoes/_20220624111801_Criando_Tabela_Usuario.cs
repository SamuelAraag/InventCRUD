using FluentMigrator;
using FluentMigrator.SqlServer;

namespace CRUD.Infra.Migracoes
{
    [Migration(20220624111801)]
    public class _20220624111801_Criando_Tabela_Usuario : Migration
    {
        public override void Up()
        {
            Create.Table("Usuario")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity(1, 1)
                .WithColumn("Nome").AsString(400).NotNullable()
                .WithColumn("Senha").AsString(600).NotNullable()
                .WithColumn("Email").AsString(400).NotNullable()
                .WithColumn("DataNascimento").AsDateTime().Nullable()
                .WithColumn("DataCriacao").AsDateTime().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("Usuario");
        }
    }
}
