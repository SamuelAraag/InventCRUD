using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_CadastroUsuarios
{
    public class AcessoAoBancoDeDados
    {
        private static DataTable dataTable = new DataTable();
        public static DataTable GetDataTable()
        {
            string connString = @"Persist Security Info=False;User ID=sa;
            Password=sap@123;Initial Catalog=Usuarios;Data Source=DESKTOP-7MCFTA2";
            
            string query = "select * from Usuario";

            using (SqlConnection sqlCon = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(query, sqlCon))
                {
                    try
                    {
                        sqlCon.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dataTable);
                        return dataTable;
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }
    }
}
