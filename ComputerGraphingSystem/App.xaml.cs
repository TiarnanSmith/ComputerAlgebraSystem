using ComputerGraphingSystem.Model;
using ComputerGraphingSystem.Stores;
using ComputerGraphingSystem.ViewModels;
using ComputerGraphingSystem.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ComputerGraphingSystem
{

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NavigationStore _navigationStore;
        private GraphSystem _graphSystem;

        /// <summary>
        /// Constructor for the application class;
        /// </summary>
        public App()
        {
            _graphSystem = new GraphSystem(new ComputerAlgebraSystem.Plotting.PlotView(-5,5,-5,5));

            _navigationStore = new NavigationStore();

            Pages.viewModelFunctions.Add("graph", CreateGraphCanvasViewModel);

        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _navigationStore.CurrentViewModel = CreateGraphCanvasViewModel();

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };

            MainWindow.Show();

            base.OnStartup(e);
        }

        protected GraphCanvasViewModel CreateGraphCanvasViewModel()
        {
            return new GraphCanvasViewModel(_graphSystem, new NavigationService(_navigationStore, "graph"));
        }
    }
}