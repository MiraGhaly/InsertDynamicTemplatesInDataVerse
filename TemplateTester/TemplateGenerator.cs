using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Xrm.Sdk;
using System.ServiceModel;
using System.Text;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Metadata;
using System.ServiceModel.Description;
using System.Net;
using System.Xml;
using System.IO;
using Microsoft.Crm.Sdk;
using Microsoft.Crm.Sdk.Messages;

namespace TemplateTester
{
    public partial class TemplateGenerator : Form
    {
        IOrganizationService organizationService = null;
        OrganizationServiceProxy _serviceProxy;
        ITracingService tracing;
        public TemplateGenerator()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClientCredentials clientCredentials = new ClientCredentials();
            clientCredentials.UserName.UserName = "mgbotros@curiousmira.onmicrosoft.com";
            clientCredentials.UserName.Password = "Pon88650";

            // For Dynamics 365 Customer Engagement V9.X, set Security Protocol as TLS12
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            _serviceProxy = new OrganizationServiceProxy(new Uri("https://org21ffb2a4.api.crm6.dynamics.com/XRMServices/2011/Organization.svc"),
             null, clientCredentials, null);
            _serviceProxy.EnableProxyTypes();
            organizationService = (IOrganizationService)_serviceProxy;
            Guid userId = ((WhoAmIResponse)organizationService.Execute(new WhoAmIRequest())).UserId; 
            EntityReference primaryEntity = new EntityReference(PrimaryEntityName.Text, new Guid(PrimaryEntityID.Text));
           
          //  output.Text =MG.Generic.Helper.MessageHelper.GetMessageWithValues(primaryEntity, template.Text, organizationService, tracing);

        }
    }
}
