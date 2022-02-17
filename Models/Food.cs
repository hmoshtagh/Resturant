using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Resturant.Models
{
    public class Food
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        public string  Description { get; set; }
        public int  Price { get; set; }
        public string  PhotoLocation { get; set; }
        
        [NotMapped]
        public IFormFile Image { get; set; }
        public Food()
        {

        }
        public Food(string name , string description , int price ,string photolocation)
        {
            Name = name;
            Description = description;
            Price = price;
            PhotoLocation = photolocation;
        }

    }
}
