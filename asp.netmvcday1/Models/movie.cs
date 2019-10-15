using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace asp.netmvcday1.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Movie name cannot be empty")]
        [Column(TypeName = "varchar")]
        [Display(Name = "Movie Name")]
        [StringLength(50)]
        public string Name { get; set; }
        // public string Genre { get; set; }


        [Required(ErrorMessage ="Release date cannot be empty")]
        [Display(Name ="Release Date")]
          
        public DateTime? ReleaseDate { get; set; }



        [Required(ErrorMessage = "Date added cannot be empty")]
        [Display(Name = "Date Added")]
   
        public DateTime? DateAdded { get; set; }
        //Reference Table


        //[Required(ErrorMessage = "Genres cannot be empty")]
        public Genre Genres { get; set; }

        //Reference Column
        [Display(Name="Genre Id")]
        [Required(ErrorMessage ="Genre Id cannot be empty")]
        public int? GenreId { get; set; }


        [Display(Name = "Available Stock")]

        [Required(ErrorMessage = "Available stock cannot be empty")]
        public int? AvailableStock { get; set; }
    }
}