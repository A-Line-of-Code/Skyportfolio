using System;
using System.ComponentModel.DataAnnotations;

namespace Skyportfolio.Models
{
    public class Blog
    {
        public int BlogID { get; set; }
        public string Date { get; set; }        
        public string Cmt { get; set; }
    }
}