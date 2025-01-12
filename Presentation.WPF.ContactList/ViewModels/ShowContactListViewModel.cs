

using Business.Models;
using Business.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;

namespace Presentation.WPF.ContactList.ViewModels;

public partial class ShowContactListViewModel : ObservableObject
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ContactService _contactService;

    [ObservableProperty]
    private string _title = "Contact List";

    [ObservableProperty]
    private ObservableCollection<Contact> _contacts = [];

    [RelayCommand]
    private void GoToMainMenu()
    {
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<MenuViewModel>();
    }

    public ShowContactListViewModel(IServiceProvider serviceProvider, ContactService contactService)
    {
        _serviceProvider = serviceProvider;
        _contactService = contactService;

        _contacts = new ObservableCollection<Contact>(_contactService.GetAll());
    }
}
