using IdentityModel.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_auth_cli.Identity.Models
{
    public class DiscoveryDocument
    {
        public DiscoveryDocument(DiscoveryDocumentResponse idDiscDoc) {
            this.TokenEndpoint = idDiscDoc.TokenEndpoint;
        }

        public string TokenEndpoint { get; private set; }
    }
}
