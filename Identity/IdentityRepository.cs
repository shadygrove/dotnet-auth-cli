using dotnet_auth_cli.Identity.Models;
using IdentityModel.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_auth_cli.Identity
{
    public class IdentityRepository
    {
        private DiscoveryDocument _discoveryDocument;

        public IdentityRepository ()
        {
        }

        public DiscoveryDocument GetDiscoveryDocument ()
        {
            return _discoveryDocument;
        }

        public void SaveDiscoveryDocument(DiscoveryDocument discoveryDocument)
        {
            _discoveryDocument = discoveryDocument;
        }
    }
}
