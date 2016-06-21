using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FaceYourNation.Models
{
    public class Vote
    {
        public string vID { get; set; } //unique ID of a vote
        public string District { get; set; } // ex: TN5, NY16, TX25
        public string video_id { get; set; } //ID of video
        public string issue_name { get; set; }
        public string house_id { get; set; }
        public string senate_id { get; set; }
        public string support { get; private set; }

        public void LogPublicPosition(bool _bool)
        {
            if(_bool == false)
            {
                support = "Against";
            }
            else
            {
                support = "For";
            }

        }
    }
}

//Deployment: make sure HeyGubaamint is bold. Right Click and 'Publish'
//Click Azure App Service
//Sub: 'Pay as you go', 'Resource Group'
//WebAppName is {SubDomain}.Azureapp.com
//New ResourceGroup. New AppservicePlan
//Location SouthCentral US. Size is free.
//Add on the SQL Server database.
//Add a servername +dbserver
//Add an admin / and password. Make sure it's DefaultConnection String
//Resource type should now include three things: Service, SQL Server, dbase
//Hit create. Wait. NOW ALWAYS CHECK SAVE PASSWORD. Validate connection.
//Next. Look at connection string. Check code first migrations.
//Next is preview page. 