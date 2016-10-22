using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace ccm2
{
    [ServiceContract(Namespace = "ccm2.ServiceAuthentification")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ServiceAuthentification
    {
  
   /// --------------------------------------------------------------------------------------------------
   
        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json,ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        public string DoWork()
        {
            // Add your operation implementation here
            return "ok";
        }

    /// --------------------------------------------------------------------------------------------------

        [OperationContract]

        [WebGet(RequestFormat = WebMessageFormat.Json,ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped  )]
        public bool VerifierUser(string userentry,string passentry)
        {
            try
            {
                using (CcmDbEntities Db = new CcmDbEntities())
                {

                    //userentry="USER1";   
                    //passentry  =  "PASSE1";            
                    int nombre_user= (from usr in Db.Utilisateur
                                                  where usr.user == userentry && usr.pass == passentry
                                                  select usr).Count();
                    if (nombre_user>0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch(Exception e)
            {
              throw new Exception  (e.Message);
            }
             
           
                   
       
       }

    }
}