using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Metadata;
namespace MG.Plugins.Email
{
    public class InsertTemplate : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            // Obtain the tracing service
            var tracingService = (ITracingService)serviceProvider.GetService(typeof(ITracingService));
            // Obtain the execution context from the service provider.
            IPluginExecutionContext context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
            // Obtain the organization service reference.
            IOrganizationServiceFactory serviceFactory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
            // Getting the service from the Organisation Service.
            IOrganizationService service = serviceFactory.CreateOrganizationService(context.UserId);

            try
            {

                // The InputParameters collection contains all the data passed in the message request.  
                if (context.InputParameters.Contains("Target") &&
                    context.InputParameters["Target"] is Entity)
                {
                    //Get email
                    Entity emailEntity = (Entity)context.InputParameters["Target"];
                    tracingService.Trace(emailEntity.Id.ToString());
                    emailEntity.Attributes["description"] = "Mira Updated";
                    service.Update(emailEntity);
                }
            }
            catch (Exception ex)
            {
                tracingService.Trace("Email_IsReply_SetTo: {0}", ex.ToString());
                throw new InvalidPluginExecutionException(ex.Message);
            }
        }
    }
}
