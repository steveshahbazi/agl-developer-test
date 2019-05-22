using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AglDeveloperTestWebApplicationNet4.Models;
using Newtonsoft.Json;

namespace AglDeveloperTestWebApplicationNet4.Controllers
{
    public class CatController : Controller
    {
        // GET: Cat
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var webRequest = WebRequest.Create(@"http://agl-developer-test.azurewebsites.net/people.json");

            var strContent = "";
            using (var response = webRequest.GetResponse())
            using (var content = response.GetResponseStream())
            using (var reader = new StreamReader(content))
            {
                strContent = reader.ReadToEnd();
            }

            List<AnimalOwner> owners = JsonConvert.DeserializeObject<List<AnimalOwner>>(strContent);
            List<string> maleOwnerCatNames = new List<string>();
            List<string> femaleOwnerCatNames = new List<string>();
            foreach (var animalOwner in owners)
            {
                if (animalOwner.Pets == null)
                    continue;
                foreach (var pet in animalOwner.Pets)
                {
                    if (string.Equals(pet.Type, "Cat", StringComparison.CurrentCultureIgnoreCase))
                    {
                        if (animalOwner.Gender == Gender.Male)
                            maleOwnerCatNames.Add(pet.Name);
                        else
                            femaleOwnerCatNames.Add(pet.Name);
                    }
                }    
            }
            maleOwnerCatNames = maleOwnerCatNames.OrderBy(q => q).ToList();
            femaleOwnerCatNames = femaleOwnerCatNames.OrderBy(q => q).ToList();
            CatNames catNames = new CatNames() {maleOwners = maleOwnerCatNames, femaleOwners = femaleOwnerCatNames};
            
            return View(catNames);
        }
    }
}