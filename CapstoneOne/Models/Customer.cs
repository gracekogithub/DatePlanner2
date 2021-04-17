using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneOne.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId
        {
            get; set;
        }
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is a Required Input")]
        public string FirstName
        {
            get; set;
        }
        [Display(Name = "Last Name")]
        public string LastName
        {
            get; set;
        }
        [Display(Name = "StreetName")]
        public string StreetName
        {
            get; set;
        }

        [Display(Name = "City")]
        public string City
        {
            get; set;
        }
        [Display(Name = "State")]
        public string State
        {
            get; set;
        }
        [Display(Name = "ZipCode")]
        public string ZipCode
        {
            get; set;
        }


        [Display(Name = "Your Partner's Birthday ")]

        public DateTime? Scheduler
        {
            get; set;
        }

        [Display(Name = "Favorite Date Activity")]
        public string Activity
        {
            get; set;
        }


        [Display(Name = "Anniversary Date")]
        public DateTime? Anniversary
        {
            get; set;
        }


        [Display(Name = "Favorite Places To Go")]
        public string FavoritePlaces
        {
            get; set;
        }


        [Display(Name = "Any Allergies?")]
        public string Allergies
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

        public string UserEmail
        {
            get; set;
        }

        [NotMapped]
        public SelectList Activities
        {
            get; set;
        }

        public ICollection<CustomerProduct> ShoppingCart
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
        [NotMapped]
        [Display(Name = "Please Select A Package")]
        public SelectList Packages
        {
            get; set;
        }
    }
}
