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
        public ObservableCollection<Contact> Contacts { get; set; }
        private AzureClient _client;
        public Command RefreshCommand { get; set; }

        public ContactsPage()
        {
            RefreshCommand = new Command(() => Load());
            Contacts = new ObservableCollection<Contact>();
            _client = new AzureClient();

            InitializeComponent();
        }


        public async void Load()
        {
            var result = await _client.GetContacts();

            Contacts.Clear();

            foreach (var item in result)
            {
                Contacts.Add(item);
            }
            IsBusy = false;
        }
    }
}