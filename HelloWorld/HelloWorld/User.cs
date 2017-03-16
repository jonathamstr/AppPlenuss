using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        readonly string ImageUrl;

        string GetImageUrl()
        {
            return this.ImageUrl;
        }

        public User(int id, string name, string description)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.ImageUrl = $"http://lorempixel/200/200/people/{Id}";
        }





    }
}
