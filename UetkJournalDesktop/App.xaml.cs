using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using JournalDesktop.Application;
using Microsoft.Extensions.DependencyInjection;
using JournalDesktop.ViewModels;
using MediatR;
using JournalDesktop.Stores;

namespace JournalDesktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        private readonly IHost _host;
        private readonly NavigationStore _navigationStore; // Возможно, нужен интерфейс, и регать его в контейнере
        private readonly TeacherStore _teacherStore;

        public App()
        {
            var builder = Host.CreateDefaultBuilder();
            builder.ConfigureServices(services =>
            {
                services.AddSingleton<MainWindow>(); // Зачем его регать 
                services.AddApplication();
            });
            _host = builder.Build();

            _navigationStore = new NavigationStore();
            _teacherStore = new TeacherStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();

            var mediator = _host.Services.GetRequiredService<IMediator>();
            MainWindow = _host.Services.GetRequiredService<MainWindow>();
            _navigationStore.CurrentViewModel = new LoginViewModel(mediator, _navigationStore, _teacherStore);
            MainWindow.DataContext = new MainViewModel(mediator, _navigationStore, _teacherStore);
            MainWindow.Show();

            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _host.StopAsync();
            _host.Dispose();

            base.OnExit(e);
        }
    }
}
