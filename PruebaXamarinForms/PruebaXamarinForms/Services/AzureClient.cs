using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace PruebaXamarinForms.Services
{
    public class AzureClient
    {
        private IMobileServiceClient _client;
        private IMobileServiceTable<Contact> _table;
        private MobileServiceUser _user;

        public bool IsAuthenticated
        {
            get
            {
                return _user != null;
            }
        }

        public AzureClient()
        {
            _client = new MobileServiceClient("http://MY_APP_SERVICE.azurewebsites.net");
            _table = _client.GetTable<Contact>();
        }

        public async Task<IEnumerable<Contact>> GetContacts()
        {
            var empty = new Contact[0];
            try
            {
                return await _table.ToEnumerableAsync();
            }
            catch (Exception ex)
            {
                return empty;
            }
        }

        public Task Logout()
        {
            return _client.LogoutAsync();
        }

        public async Task<bool> Login()
        {
            try
            {
                var provider = MobileServiceAuthenticationProvider.Twitter;
                _user = await _client.LoginAsync(provider.ToString(), new JObject());
                
                return IsAuthenticated;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}