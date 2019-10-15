using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace asp.netmvcday1.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage="Name cannot be empty")]
        [Column(TypeName ="varchar")]
        [Display(Name="Full Name")]
        [StringLength(50)]
        public string Name{ get; set; }


        [Required(ErrorMessage = "Dob cannot be empty")]
        [Display(Name="Date of Birth")]
        public DateTime? BirthDate { get; set; }


        [Required(ErrorMessage = "Gender cannot be empty")]
        [Column(TypeName ="char")]
        [StringLength(8)]
        public string Gender { get; set; }

        [Required(ErrorMessage = "City cannot be empty")]
        [Column(TypeName ="varchar")]
        [Display(Name="Your City")]
        [StringLength(100)]
        public string City { get; set; }
       
        //Reference Table
        public  MembershipType MembershipType{ get; set; }

        //Reference Column
        [Required]
        [Display(Name="Membership Type")]
        public int? MembershipTypeId  { get; set; }
        
    }
}