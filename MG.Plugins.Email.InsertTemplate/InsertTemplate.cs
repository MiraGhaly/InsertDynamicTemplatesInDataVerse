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
            var emailDescription = "";
            var templateId = Guid.Empty;
            Entity emailEntityPreImage = null;
            EntityReference regardingObjectId = null;

            string templateSubject=string.Empty;
            string templateDescription = string.Empty;
            try
            {

                // The InputParameters collection contains all the data passed in the message request.  
                if (context.InputParameters.Contains("Target") &&
                    context.InputParameters["Target"] is Entity)
                {
                    tracingService.Trace("Entered Plugin");

                    Entity emailEntity = (Entity)context.InputParameters["Target"];
                    if(context.MessageName=="Update")
                         emailEntityPreImage = (Entity)context.PreEntityImages["Image"];
                    if (emailEntity.Attributes.Contains("description"))
                    {
                        emailDescription = emailEntity.Attributes["description"].ToString();
                    }
                    else
                    {
                        if (context.MessageName == "Update")
                            emailDescription = emailEntityPreImage.Attributes["description"].ToString();
                    }
                    if (emailEntity.Attributes.Contains("tg_emailtemplate"))
                    {
                        templateId = ((EntityReference)emailEntity.Attributes["tg_emailtemplate"]).Id;

                    }
                    else
                    {
                        if(context.MessageName=="Update" && emailEntityPreImage.Attributes.Contains("tg_emailtemplate"))                      
                            templateId = ((EntityReference)emailEntityPreImage.Attributes["tg_emailtemplate"]).Id;
                    }
                    //
                    if (emailEntity.Attributes.Contains("tg_templatesubject"))
                    {
                        templateSubject = emailEntity.Attributes["tg_templatesubject"].ToString();

                    }
                    else
                    {
                        if (context.MessageName == "Update" && emailEntityPreImage.Attributes.Contains("tg_templatesubject"))
                            templateSubject = emailEntityPreImage.Attributes["tg_templatesubject"].ToString();
                    }

                    if (emailEntity.Attributes.Contains("tg_templatedescription"))
                    {
                        templateDescription = emailEntity.Attributes["tg_templatedescription"].ToString();
                        tracingService.Trace(templateDescription);

                    }
                    else
                    {
                        if (context.MessageName == "Update" && emailEntityPreImage.Attributes.Contains("tg_templatedescription"))
                        {
                            templateDescription = emailEntityPreImage.Attributes["tg_templatedescription"].ToString();
                            tracingService.Trace(templateDescription);
                        }
                    }
                    if ((emailEntity.Attributes.Contains("regardingobjectid") || (context.MessageName=="Update" && emailEntityPreImage.Attributes.Contains("regardingobjectid"))))
                    {
                        if(emailEntity.Attributes.Contains("regardingobjectid"))
                          regardingObjectId = (EntityReference)emailEntity.Attributes["regardingobjectid"];
                        else if (context.MessageName == "Update" && emailEntityPreImage.Attributes.Contains("regardingobjectid"))
                            regardingObjectId = (EntityReference)emailEntityPreImage.Attributes["regardingobjectid"];
                        tracingService.Trace("Point 1");
                        EntityReference primaryEntity = new EntityReference(regardingObjectId.LogicalName,regardingObjectId.Id);
                        tracingService.Trace("Point 2");

                        //Get Email template
                       // Entity emailTemplate = service.Retrieve("tg_emailtemplates", templateId, new ColumnSet("tg_emaildescription", "tg_emailsubject"));

                        tracingService.Trace("Point 3");

                        string description = MG.Generic.Helper.MessageHelper.GetMessageWithValues(primaryEntity,templateDescription, service, tracingService);
                        string subject = MG.Generic.Helper.MessageHelper.GetMessageWithValues(primaryEntity, templateSubject, service, tracingService);

                        tracingService.Trace("Point 4"+description);
                        emailEntity.Attributes["description"] = description + emailDescription;
                        emailEntity.Attributes["subject"] = subject;
                    }
                  
                }
            }
            catch (Exception ex)
            {
                tracingService.Trace("Insert Template: {0}", ex.ToString());
                throw new InvalidPluginExecutionException(ex.Message);
            }
        }
    }
}
