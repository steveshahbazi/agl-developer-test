using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AglDeveloperTestWebApplicationNet4.Models
{
    public class Animal : IAnimal
    {
        public string Name { get; set; }
        public string Type { get; set; }
    }
}