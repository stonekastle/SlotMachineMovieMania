﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TestDirecTV.Models.Requests
{
    public class ScoreboardUpdateRequest
    {
        [Required] [Range(1, int.MaxValue)]
        public int Id { get; set; }
        public int QuestionSet { get; set; }
    }
}