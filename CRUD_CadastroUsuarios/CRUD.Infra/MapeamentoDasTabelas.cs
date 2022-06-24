using CRUD.Dominio;
using LinqToDB.Mapping;

namespace CRUD.Infra
{
    public class MapeamentoDasTabelas
    {
        private const string TabelaDeUsuario = "Usuario";

        public static void Mapear()
        {
            var mapper = MappingSchema.Default.GetFluentMappingBuilder();

            mapper
                .Entity<Usuario>()
                .HasTableName(TabelaDeUsuario)
                .HasIdentity(x => x.Id)
                .HasPrimaryKey(x => x.Id);
        }
    }
}
