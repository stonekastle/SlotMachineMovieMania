using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TestDirecTV.Models.Requests
{
    public class ScoreboardAddRequest
    {
        [Required]
        public string ImageURL { get; set; }
        public int Score { get; set; }
    }
}