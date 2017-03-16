using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    public class Activity
    {
        public int UserId { set; get; }
        public string Description { set; get; }

        public string imageUrl { get; set; }

        private string GetImageUrl()
        {
            return imageUrl;
        }

        private void SetImageUrl(string value)
        {
            imageUrl = value;
        }

        public Activity(int UserId, string Description)
        {
            this.UserId = UserId;
            this.Description = Description;
            imageUrl = "http://lorempixel.com/100/100/people/" + UserId.ToString();
        }
    }
}
