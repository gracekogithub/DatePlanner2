using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneOne.Models
{
    public class Admin
    {
        [Key]
        public int AdminId
        {
            get; set;
        }
        public string Name
        {
            get; set;
        }
        [ForeignKey("IdentityUser")]
        public string IdentityUserId
        {
            get; set;
        }
        public IdentityUser IdentityUser
        {
            get; set;
        }
        [Display(Name = "Longitude")]
        public double Longitude
        {
            get; set;
        }
        [Display(Name = "Latitude")]
        public double Latitude
        {
            get; set;
        }
    }
}
