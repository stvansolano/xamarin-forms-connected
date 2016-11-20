using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaXamarinForms
{
    [DataTable("Contacts")]
    public class Contact
    {
        [JsonProperty]
        public string Id { get; set; }

        [JsonProperty]
        public string Name { get; set; }

        [Version]
        public string Version { get; set; }
    }
}
