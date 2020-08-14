using System;
using System.ComponentModel.DataAnnotations;

namespace Skyportfolio.Models
{
    public class Portfolio
    {
        public int PortfolioID { get; set; }
        public string Img { get; set; }
        public string Link { get; set; }
        public string Tech { get; set; }
        public string Cmt { get; set; }
        public string Title { get; set; }
    }
}