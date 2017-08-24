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
    public class ScoreboardService : BaseService /*,InterfaceScoreboardService*/
    {
        //public void Delete(int id)
        //{
        //    DataProvider.ExecuteNonQuery(GetConnection
        //        , "dbo.Scoreboard_Delete"
        //        , inputParamMapper: delegate (SqlParameterCollection paramCollection)
        //            {
        //                paramCollection.AddWithValue("@id", id);
        //            }
        //        , returnParameters: null);
            
        //}//Delete (byId)

        //public void DeleteByLastName(string LastName)
        //{
        //    DataProvider.ExecuteNonQuery(GetConnection
        //       ,"dbo.Scoreboard_DeleteByLastName"
        //       , inputParamMapper: delegate (SqlParameterCollection paramCollection)
        //            {
        //                paramCollection.AddWithValue("@lastName", LastName);
        //            }
        //       , returnParameters: null);
        //}

        public int Insert(ScoreboardAddRequest model)
        {
            int id = 0;
            DataProvider.ExecuteNonQuery(GetConnection
                , "dbo.Scoreboard_Insert"
                , inputParamMapper: delegate (SqlParameterCollection paramCollection)
                    {
                        paramCollection.AddWithValue("@FirstName", model.FirstName);
                        paramCollection.AddWithValue("@LastName", model.LastName);
                        paramCollection.AddOutputParameter("@Id", System.Data.SqlDbType.Int);
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
                , "dbo.Scoreboard_SelectAll"
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

        //public ScoreboardDomain SelectById(int id)
        //{
        //    ScoreboardDomain scoreboard = null;
        //    DataProvider.ExecuteCmd(GetConnection
        //        , "dbo.Scoreboard_SeclectById"
        //        , inputParamMapper: delegate (SqlParameterCollection paramCollection)
        //            {
        //                paramCollection.AddWithValue("@Id", id);
        //            }
        //        , map: delegate (IDataReader reader, short set)
        //            {
        //                scoreboard = MapScoreboard(reader);
        //            }
        //    );
        //    return scoreboard;
        //}

        public void Update(ScoreboardUpdateRequest model)
        {        
            DataProvider.ExecuteNonQuery(GetConnection
                , "dbo.Scoreboard_Update"
                , inputParamMapper: delegate (SqlParameterCollection paramCollection)
                    {                      
                        paramCollection.AddWithValue("@Id", model.Id);
                        
                    }
                , returnParameters: null
            );

        }

        private ScoreboardDomain MapScoreboard(IDataReader reader)
        {
            ScoreboardDomain scoreboard = new ScoreboardDomain();
            int startingIndex = 0; //startingOrdinal
            scoreboard.Id = reader.GetSafeInt32(startingIndex++);
            scoreboard.FirstName = reader.GetSafeString(startingIndex++);
            scoreboard.LastName = reader.GetSafeString(startingIndex++);
            scoreboard.Score = reader.GetSafeInt32(startingIndex++);

            return scoreboard;
        }
        

        
        

      
        
    }
}