namespace SistemaAlumnos.FE
{
    internal static class Program
    {
        /// <summary>
        ///  Punto de entrada de nuestra aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}
