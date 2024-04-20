using MVC_architecture_35.Controller;
using System;
using System.Windows.Forms;

namespace MVC_architecture_35
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LoginController loginController = new LoginController();
            Application.Run(loginController.GetView());
        }
    }
}
