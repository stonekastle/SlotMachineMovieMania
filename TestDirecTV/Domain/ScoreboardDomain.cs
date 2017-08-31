using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestDirecTV.Domain
{
    public class ScoreboardDomain
    {
        public int Id { get; set; }
        public string ImageURL { get; set; }
        public int Score { get; set; }
        public int QuestionSet { get; set; }
        public string Name { get; set; }
    }
}