using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneOne.Models
{
    public class DateActivity
    {
        [Key]
        public int Id
        {
            get; set;
        }
        
       [DisplayName ("Activity to plan")]
       [Required]
        public string ActivityName{ get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage ="Budget must be greater than 0!")]
        public int Budget { get; set; }

        [Display(Name = "ToDo Schedule for reminder")]
        public DateTime? Scheduler
        {
            get; set;
        }


        //date
    }
}
