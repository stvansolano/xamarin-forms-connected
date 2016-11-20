using PruebaXamarinForms.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace PruebaXamarinForms
{
    public partial class ContactsPage : ContentPage
    {
        public ObservableCollection<Contact> Items { get; set; }
        private AzureClient _client;
        public Command RefreshCommand { get; set; }
        public Command LoginCommand { get; set; }
        public Command LogoutCommand { get; set; }

        public ContactsPage()
        {
            RefreshCommand = new Command(() => Load());
            LoginCommand = new Command(() => Login());
            LogoutCommand = new Command(() => Logout());

            Items = new ObservableCollection<Contact>();
            _client = new AzureClient();

            InitializeComponent();
        }

        public async void Load()
        {
            if (_client.IsAuthenticated == false)
            {
                return;
            }
            var result = await _client.GetContacts();

            Items.Clear();

            foreach (var item in result)
            {
                Items.Add(item);
            }
            IsBusy = false;
        }

        private async void Logout()
        {
            loginButton.IsEnabled = true;
            logoutButton.IsEnabled = false;

            await _client.Logout();
        }

        private async void Login()
        {
            var result = await _client.Login();

            if (result)
            {
                loginButton.IsEnabled = false;
                Load();
                return;
            }
            Items.Clear();
            Items.Add(new Contact { Name = ">> Failed", Version = "Sign-in first" });
        }
    }
}