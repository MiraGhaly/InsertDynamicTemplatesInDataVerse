using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
namespace MG.Generic.Helper
{
    public class MessageHelper
    {
        public static string GetMessageWithValues(EntityReference primaryEntity, string message, IOrganizationService svc,ITracingService tracingService)
        {
            char currChar; //contains the current char
            string finalMessageOut = string.Empty; //this is the final message with values
            string fieldName = string.Empty;
            string fieldValue = string.Empty;
            string lookupName = string.Empty;
            string dynamicValue = string.Empty;
            string type = string.Empty;
            int indexToContinue = 0;

            for (int i = 0; i < message.Length; i++)
            {
                currChar = message[i];

                if (currChar != '{')
                {
                    finalMessageOut += currChar;
                }
                else if (currChar == '{')
                {
                    indexToContinue = i + 1;
                    currChar = message[indexToContinue];

                    while (currChar != '}')
                    {
                        dynamicValue += currChar;

                        indexToContinue++;
                        currChar = message[indexToContinue];
                    }

                    if (dynamicValue.Contains(":"))
                    {
                        string[] splitedDynamicValue = dynamicValue.Split(':');
                        type = splitedDynamicValue[0];
                       
                        if (type == "lookup")
                        {
                            lookupName = splitedDynamicValue[1];
                            fieldName = splitedDynamicValue[2];
                            fieldValue = GetLookupValue(lookupName, fieldName, svc, primaryEntity).ToString();
                        }

                        else if (type == "env")
                        {
                            fieldName = splitedDynamicValue[1];
                            fieldValue = "Coming Soon!";
                        }
                            
                        

                    }
                    else
                    {
                        fieldName = dynamicValue;
                        fieldValue = GetFieldValue(fieldName, svc, primaryEntity).ToString();
                    }

                    finalMessageOut += fieldValue;// + ' ';

                    dynamicValue = string.Empty;
                    fieldName = string.Empty;
                    fieldValue = string.Empty;
                    lookupName = string.Empty;
                    type = string.Empty;

                    //indexToContinue++;

                    if (indexToContinue > message.Length)
                        break;
                    else
                        i = indexToContinue;
                }//End if currChar = { 
            }//End For

            return finalMessageOut;
        }
        private static string GetFieldValue(string fieldName, IOrganizationService svc, EntityReference primaryEntity)
        {
            Entity currEntity = new Entity();
            string fieldValue = string.Empty;
           
            if (string.IsNullOrEmpty(fieldName))
                return string.Empty;
         
            ColumnSet retrievedCols = new ColumnSet(new string[]
            {
                fieldName
            });
            currEntity = svc.Retrieve(primaryEntity.LogicalName, primaryEntity.Id, retrievedCols);

            if (currEntity.Attributes.Contains(fieldName))
                fieldValue = GetFieldValueToString(currEntity, fieldName);
            

            return fieldValue;
        }

        private static string GetLookupValue(string lookupName, string fieldName, IOrganizationService svc, EntityReference primaryEntity)
        {
            Entity currEntity = new Entity();
            string fieldValue = string.Empty;

            if (string.IsNullOrEmpty(fieldName))
                return string.Empty;
        
                ColumnSet retrievedCols = new ColumnSet(new string[]
                {
                    lookupName
                });
                currEntity = svc.Retrieve(primaryEntity.LogicalName, primaryEntity.Id, retrievedCols);

                if (currEntity.Attributes.Contains(lookupName))
                {
                    string entityType = ((EntityReference)currEntity.Attributes[lookupName]).LogicalName;
                    Guid entityId = ((EntityReference)currEntity.Attributes[lookupName]).Id;

                    ColumnSet retrievedLookupCols = new ColumnSet(new string[]
                    {
                        fieldName
                    });
                    Entity lookupEntity = svc.Retrieve(entityType, entityId, retrievedLookupCols);

                    fieldValue = GetFieldValueToString(lookupEntity, fieldName);
                }


            
           

            return fieldValue;
        }
        private static string GetFieldValueToString(Entity entity, string fieldName)
        {
            if (entity.Attributes.Contains(fieldName))
            {
                if (entity.Attributes[fieldName] is String) //String
                    return ((String)entity.Attributes[fieldName]).ToString();

                else if (entity.Attributes[fieldName] is OptionSetValue) //OptionSet
                    return entity.FormattedValues[fieldName];

                else if (entity.Attributes[fieldName] is BooleanManagedProperty) //Boolean
                    return ((BooleanManagedProperty)entity.Attributes[fieldName]).Value.ToString();

                else if (entity.Attributes[fieldName] is float) //float
                    return ((float)entity.Attributes[fieldName]).ToString();

                else if (entity.Attributes[fieldName] is int) //Integer
                    return ((int)entity.Attributes[fieldName]).ToString();

                else if (entity.Attributes[fieldName] is EntityReference) //Lookup
                    return ((EntityReference)entity.Attributes[fieldName]).Name;

                else if (entity.Attributes[fieldName] is Money) //Crm Money
                    return ((Money)entity.Attributes[fieldName]).Value.ToString();

                else if (entity.Attributes[fieldName] is decimal) //Decimal
                    return ((decimal)entity.Attributes[fieldName]).ToString();

                else if (entity.Attributes[fieldName] is Guid) //Guid
                    return ((Guid)entity.Attributes[fieldName]).ToString();

                else
                    return "";
            }
            else
                return "";
        }
    }
}
