using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic.Logging;
using RetroRides.Extensions;
using RetroRides.Forms;
using RetroRides.Services.Interfaces;

namespace RetroRides
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        public static ApplicationContext AppContext;

        [STAThread]
        static void Main()
        {
            var services = new ServiceCollection();
            services.AddHotelServices();

            var serviceProvider = services.BuildServiceProvider();

            ServiceLocator.Initialize(serviceProvider);

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var userService = ServiceLocator.GetService<IUserService>();

            AppContext = new ApplicationContext(new Login(userService));
            Application.Run(AppContext);
        }
        public static void SwitchMainForm(Form newForm)
        {
            var oldMainForm = AppContext.MainForm;
            AppContext.MainForm = newForm;
            oldMainForm?.Hide();
            oldMainForm?.Close();
            newForm.ShowDialog();
        }
    }
}