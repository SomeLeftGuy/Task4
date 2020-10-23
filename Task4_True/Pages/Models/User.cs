using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace Task4_True.Pages.Models
{
    public class User
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; private set; }
        [Display(Name = "Email")]
        public string  email { get; set; }
        [Display(Name ="Name")]
        public string Name { get; set; }
        public string Number { get; set; }
        [Display(Name ="Password")]
        public string Password { get; private set;}
        public override string ToString() => JsonSerializer.Serialize<User>(this);
    }
 
}
