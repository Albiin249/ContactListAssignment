using Business.Models;
using Business.Dtos;
using Business.Factories;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using Business.Services;

namespace Presentation.WPF.ContactList.ViewModels;

public partial class AddContactViewModel : ObservableObject
{


    private readonly IServiceProvider _serviceProvider;
    private readonly ContactFactory _contactFactory;
    private readonly ContactService _contactService;


    [ObservableProperty]
    private string _title = "Add New Contact";

    [ObservableProperty]
    private ContactRegistrationForm _contact = new ();

    [RelayCommand]
    private void GoToMainMenu()
    {
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<MenuViewModel>();
    }

    [RelayCommand]
    private void Add()
    {
        var result = _contactFactory.CreateContact(Contact);
        if(result != null) 
        { 
            _contactService.Add(result);

            var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
            mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<MenuViewModel>();
        }
    }

    public AddContactViewModel(IServiceProvider serviceProvider, ContactFactory contactFactory, ContactService contactService)
    {
        _serviceProvider = serviceProvider;
        _contactFactory = contactFactory;
        _contactService = contactService;
    }
}
