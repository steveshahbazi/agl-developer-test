using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AglDeveloperTestWebApplicationNet4.Models
{
    public class AnimalOwner : IPerson
    {
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public List<Animal> Pets { get; set; }
    }
}