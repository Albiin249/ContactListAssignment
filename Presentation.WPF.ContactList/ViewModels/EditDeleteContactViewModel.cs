

using Business.Models;
using Business.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;

namespace Presentation.WPF.ContactList.ViewModels;

public partial class EditDeleteContactViewModel : ObservableObject
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ContactService _contactService;


    [ObservableProperty]
    private string _title = "Edit/Delete Contact";

    [ObservableProperty]
    private ObservableCollection<Contact> _contacts = [];

    [ObservableProperty]
    private Contact _contact = new();

    [RelayCommand]
    private void GoToMainMenu()
    {
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<MenuViewModel>();
    }

    

    [RelayCommand]
    private void GoToEdit(Contact Contact)
    {
        var editViewModel = _serviceProvider.GetRequiredService<EditViewModel>();
        editViewModel.Contact = Contact;

        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = editViewModel;

    }

    [RelayCommand]
    private void DeleteContact(Contact contactToDelete)
    {

        _contactService.Delete(contactToDelete);


        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<EditDeleteContactViewModel>();
    }

    public EditDeleteContactViewModel(IServiceProvider serviceProvider, ContactService contactService)
    {
        _serviceProvider = serviceProvider;
        _contactService = contactService;

        _contacts = new ObservableCollection<Contact>(_contactService.GetAll());

    }
}
