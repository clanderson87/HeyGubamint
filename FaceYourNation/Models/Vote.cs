using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FaceYourNation.Models
{
    public class Vote
    {
        [Key]
        public string vID { get; set; } //unique ID of a vote
        [Required]
        public string District { get; set; } // ex: TN5, NY16, TX25
        [Required]
        public string video_id { get; set; } //ID of video

        public string issue_name { get; set; }
        public string house_id { get; set; }
        public string senate_id { get; set; }
        //[Required] make sure to uncomment this after migrations...
        public string support { get; set; } //make private set for production. This was made public set because seed method needed it.
        public int importance { get; set; }
        public bool torf { get; set; }

        public void LogPublicSupport(bool _bool)
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