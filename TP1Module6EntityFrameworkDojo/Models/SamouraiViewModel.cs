using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP1Module6EntityFrameworkBODojo;

namespace TP1Module6EntityFrameworkDojo.Models
{
    public class SamouraiViewModel
    {
        public Samourai Samourai { get; set; }
        public List<SelectListItem> Armes { get; set; } = new List<SelectListItem>();

        public int ? IdArme { get; set; }

    }
}