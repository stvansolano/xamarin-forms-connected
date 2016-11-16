﻿using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaXamarinForms
{
    public class AzureClient
    {
        private IMobileServiceClient _client;
        private IMobileServiceTable<Contact> _table;

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
    }
}
