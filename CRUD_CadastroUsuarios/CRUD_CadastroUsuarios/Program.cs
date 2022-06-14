using CRUD_CadastroUsuarios;

namespace CRUD_CadastroUsuarios
{
    internal static class Program
    {
        /// <summary>
        /// </summary>
        [STAThread]
        static void Main()
        {
            // see https://aka.ms/applicationconfiguration.
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(FormularioConsultaUsuarios());
        }
    }
}