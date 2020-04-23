using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP1Module6EntityFrameworkBODojoPart2;

namespace TP1Module6EntityFrameworkDojoPart2.Models
{
    public class SamouraiViewModel
    {
        public Samourai Samourai { get; set; }
        public List<SelectListItem> Armes { get; set; } = new List<SelectListItem>();

        public int ? IdArme { get; set; }

    }
}