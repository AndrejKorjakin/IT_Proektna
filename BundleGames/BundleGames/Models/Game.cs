using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BundleGames.Models
{
    public class Game
    {

        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name ="Name")]
        public string Game_Name { get; set; }
        [Required]
        [Display(Name ="Preview")]
        public string Game_Image { get; set; }
        [Required]
        [Display(Name = "Price")]
        public float Game_Cena { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string Game_Info { get; set; }
        [Required]
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime Release_Date { get; set; }
        [Required]
        public string Publisher { get; set; }
        [Required]
        public string Developer { get; set; }
        
        public string Tags { get; set; }

       


    }
}