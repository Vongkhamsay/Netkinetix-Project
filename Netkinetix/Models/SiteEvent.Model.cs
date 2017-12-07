using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Netkinetix.Models
{
    public class SiteEvent
    {
        [Key]
        public int SeId { get; set; }
        public string SeTitle { get; set; }
        public DateTime SeStartDate { get; set; }
        public DateTime SeEndDate { get; set; }
        public string SeLocation { get; set; }
        public string SeDescription { get; set; }
        public string SeURL { get; set; }
        public bool SeActive { get; set; }
    }
}