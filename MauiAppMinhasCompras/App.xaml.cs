using Microsoft.Extensions.DependencyInjection;
using MauiAppMinhasCompras.Views;
using MauiAppMinhasCompras.Helpers;
namespace MauiAppMinhasCompras
{
    public partial class App : Application
    {
        private static SQLiteDatabaseHelper? _db;

        public static SQLiteDatabaseHelper Db
        {
            get
            {
                if (_db == null)
                {
                    string path = Path.Combine(
                        FileSystem.AppDataDirectory,
                        "minhascompras.db3"
                    );

                    _db = new SQLiteDatabaseHelper(path);
                }

                return _db;
            }
        }

        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new NavigationPage(new ListaProduto()));
        }
    }
}