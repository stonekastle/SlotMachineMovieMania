using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

using TestDirecTV.Models.Requests;
using TestDirecTV.Domain;

namespace TestDirecTV.Services
{
    public interface InterfaceScoreboardService
    {
        void Delete(int id);
        void DeleteByLastName(string LastName);
        int Insert(ScoreboardAddRequest model);
        List<ScoreboardDomain> SelectAll();
        ScoreboardDomain SelectById(int id);
        void Update(ScoreboardUpdateRequest model);
    }
}