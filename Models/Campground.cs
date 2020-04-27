using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication10.Models
{
    public class Campground
    {
        [Key]
        public int C_Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
    }
}