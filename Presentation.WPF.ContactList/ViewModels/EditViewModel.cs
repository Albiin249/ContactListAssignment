using Business.Factories;
using Business.Models;
using Business.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Presentation.WPF.ContactList.ViewModels;

public partial class EditViewModel : ObservableObject
{

    private readonly IServiceProvider _serviceProvider;
    private readonly ContactService _contactService;


    [ObservableProperty]
    private string _title = "Edit Contact";

    [ObservableProperty]
    private Contact _contact = new();

    [ObservableProperty]
    private ObservableCollection<Contact> _contacts = [];


    [RelayCommand]
    private void Cancel()
    {
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<EditDeleteContactViewModel>();
    }

    [RelayCommand]
    private void SaveContact()
    {
        var result = _contactService.Update(Contact);
        if (result)
        {
            var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
            mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<EditDeleteContactViewModel>();
        }
        
    }


    public EditViewModel(IServiceProvider serviceProvider, ContactService contactService)
    {
        _serviceProvider = serviceProvider;
        _contactService = contactService;

        _contacts = new ObservableCollection<Contact>(_contactService.GetAll());

    }

}
