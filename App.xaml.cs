namespace Tarea1._3_AndreaCastro
{
    public partial class App : Application
    {
        static Controllers.DBPersonas instancia;

        public static Controllers.DBPersonas Instancia
        {
            get
            {
                if (instancia == null)
                {
                    string dbname = "PersonasDB.db3";
                    string dbpath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    string dbfull = Path.Combine(dbpath, dbname);
                    instancia = new Controllers.DBPersonas(dbfull);
                }
                return instancia;
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}