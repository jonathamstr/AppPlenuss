using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    class ActivityService
    {
        static List<Activity> activities;
        public  static List<Activity> GetActivities()
        {

            if(activities == null)
            {
                activities =  new List<Activity>
             {
                    new Activity(1,"how you doing?"),
                new Activity(2,"sOMETHING IS WRONG  "),
                new Activity(3,"V A P O R W A V E"),
                new Activity(4,"espacebarbrokeplshelpme"),
                new Activity(5,"Just married a 3rd husband with 6 sons and daugthers"),
                new Activity(6,"Random Brainless Comment"),
            };

            }

            return activities;
            
        }   
    }
}
