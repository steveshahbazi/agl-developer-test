﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AglDeveloperTestWebApplicationNet4.Models
{
    interface IPerson
    {
        string Name { get; set; }
        Gender Gender { get; set; }
    }
}
