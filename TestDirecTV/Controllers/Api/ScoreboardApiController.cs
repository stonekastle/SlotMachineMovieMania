using TestDirecTV.Domain;
using TestDirecTV.Models.Requests;
using TestDirecTV.Models.Responses;
using TestDirecTV.Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TestDirecTV.Controllers.Api
{
    [RoutePrefix("api/scoreboard")]
    public class ScoreboardApiController : ApiController
    {
        ScoreboardService _scoreboardService = new ScoreboardService();

        [HttpPost]
        [Route]
        public HttpResponseMessage Create(ScoreboardAddRequest model)
        {
            try
            {
                ItemResponse<int> response = new ItemResponse<int>();
                response.Item = _scoreboardService.Insert(model);

                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new ErrorResponse(ex.Message));
            }
        }


        [HttpGet]
        [Route]
        public HttpResponseMessage GetAll()
        {
            BaseResponse response = null;
            HttpStatusCode statusCode = HttpStatusCode.OK;
            try
            {
                ItemsResponse<ScoreboardDomain> itemsResponse = new ItemsResponse<ScoreboardDomain>();
                itemsResponse.Items = _scoreboardService.SelectAll();
                response = itemsResponse;
                statusCode = HttpStatusCode.OK;
            }
            catch (Exception Error)
            {
                response = new ErrorResponse(Error);
                statusCode = HttpStatusCode.InternalServerError;
            }
            return Request.CreateResponse(statusCode, response);
        }

        [HttpPut]
        [Route]
        public HttpResponseMessage Put(ScoreboardUpdateRequest model)
        {
            BaseResponse response = null;
            HttpStatusCode statusCode = new HttpStatusCode();
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                _scoreboardService.Update(model);
                response = new SuccessResponse();
                statusCode = HttpStatusCode.OK;
            }
            catch (Exception Error)
            {
                response = new ErrorResponse(Error);
                statusCode = HttpStatusCode.InternalServerError;
            }
            return Request.CreateResponse(statusCode, response);
        }
    }
}