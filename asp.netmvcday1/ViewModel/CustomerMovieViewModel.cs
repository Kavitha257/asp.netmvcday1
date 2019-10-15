using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using asp.netmvcday1.Models;
namespace asp.netmvcday1.ViewModel
{
    public class CustomerMovieViewModel
    {
        public List<Movie> Movies { get; set; }
        public Customer Customers { get; set; }
    }
}