using System;
using ParcNautic.Data;
using System.IO;

namespace ParcNautic
{
    public partial class App : Application
    {
        static NauticPlanDatabase database;
        public static NauticPlanDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new
                   NauticPlanDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
                   LocalApplicationData), "NauticPlan.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }
    }
}