using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sample_app.Models
{
    public class demo_app
    {
        public int id { get; set; }
        public string Title { get; set; }

        [Display(Name ="ReleaseDate")]
       [DataType(DataType.Date)]
       public DateTime ReleaseDate { get; set; }

        public string Genre { get; set;}

        [Column(TypeName="decimal(18,2)")]
        public decimal Price { get; set;}




    }
}
