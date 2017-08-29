using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Sabio.Data;
using TestDirecTV.Domain;
using TestDirecTV.Models.Requests;

namespace TestDirecTV.Services
{
    public class ScoreboardService : BaseService
    {
        public int Insert(ScoreboardAddRequest model)
        {
            int id = 0;
            DataProvider.ExecuteNonQuery(GetConnection
                , "dbo.Users_Insert"
                , inputParamMapper: delegate (SqlParameterCollection paramCollection)
                    {
                        paramCollection.AddWithValue("@imageUrl", model.ImageURL);
                        paramCollection.AddOutputParameter("@id", System.Data.SqlDbType.Int);
                    }
                , returnParameters: delegate (SqlParameterCollection param)
                    {
                        id = Convert.ToInt32(param["@id"].Value);
                    }
                );

            return id;
        }

        public List<ScoreboardDomain> SelectAll()
        {
            List<ScoreboardDomain> myList = null;
            DataProvider.ExecuteCmd(GetConnection
                , "dbo.Users_SelectAll"
                , inputParamMapper: null
                , map: delegate (IDataReader reader, short set)
                {
                    ScoreboardDomain ScoreboardObj = MapScoreboard(reader);
                    if (myList == null)
                    {
                        myList = new List<ScoreboardDomain>();
                    }
                    myList.Add(ScoreboardObj);
                });
                return myList;
            }

        public ScoreboardDomain SelectLastCreated()
        {
            ScoreboardDomain scoreboard = null;
            DataProvider.ExecuteCmd(GetConnection
                , "dbo.Users_SelectLastCreated"
                , inputParamMapper: null
                , map: delegate (IDataReader reader, short set)
                    {
                        scoreboard = MapScoreboard(reader);
                    }
            );
            return scoreboard;
        }

        public void UpdateScore(ScoreboardUpdateRequest model)
        {        
            DataProvider.ExecuteNonQuery(GetConnection
                , "dbo.Users_UpdateScore"
                , inputParamMapper: delegate (SqlParameterCollection paramCollection)
                    {                      
                        paramCollection.AddWithValue("@id", model.Id);
                        
                    }
                , returnParameters: null
            );

        }

        public void UpdateQuestionSet(ScoreboardUpdateRequest model)
        {
            DataProvider.ExecuteNonQuery(GetConnection
                , "dbo.Users_UpdateQuestionSet"
                , inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@id", model.Id);
                    paramCollection.AddWithValue("@questionSet", model.QuestionSet);
                }
                , returnParameters: null
            );

        }

        private ScoreboardDomain MapScoreboard(IDataReader reader)
        {
            ScoreboardDomain scoreboard = new ScoreboardDomain();
            int startingIndex = 0; //startingOrdinal
            scoreboard.Id = reader.GetSafeInt32(startingIndex++);
            scoreboard.ImageURL = reader.GetSafeString(startingIndex++);
            scoreboard.Score = reader.GetSafeInt32(startingIndex++);
            scoreboard.QuestionSet = reader.GetSafeInt32(startingIndex++);

            return scoreboard;
        }
    }
}