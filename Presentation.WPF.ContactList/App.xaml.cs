using Business.Factories;
using Business.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Presentation.WPF.ContactList.ViewModels;
using Presentation.WPF.ContactList.Views;
using System.Windows;

namespace Presentation.WPF.ContactList;

public partial class App : Application
{
    private IHost _host;

    public App ()
    {
        _host = Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
                services.AddSingleton<MainViewModel>();
                services.AddSingleton<MainWindow>();

                services.AddTransient<MenuViewModel>();
                services.AddTransient<MenuView>();

                services.AddTransient<AddContactViewModel>();
                services.AddTransient<AddContactView>();

                services.AddTransient<ShowContactListViewModel>();
                services.AddTransient<ShowContactListView>();

                services.AddTransient<EditDeleteContactViewModel>();
                services.AddTransient<EditDeleteContactView>();

                services.AddTransient<EditViewModel>();
                services.AddTransient<EditView>();

                services.AddTransient<ContactFactory>();
                services.AddTransient<ContactService>();
            })
            .Build();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        var mainWindow = _host.Services.GetRequiredService<MainWindow>();
        mainWindow.Show();
    }
}
