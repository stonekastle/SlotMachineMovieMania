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
        [Route()]
        public HttpResponseMessage CreateUser(ScoreboardAddRequest model)
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
        [Route()]
        public HttpResponseMessage GetAllUsers()
        {
            BaseResponse response = null;
            HttpStatusCode statusCode = HttpStatusCode.OK;
            try
            {
                ItemsResponse<ScoreboardDomain> itemsResponse = new ItemsResponse<ScoreboardDomain>();
                itemsResponse.Items = _scoreboardService.SelectAllFinished();
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

        [HttpGet]
        [Route("lastcreated")]
        public HttpResponseMessage GetLastCreated()
        {
            BaseResponse response = null;
            HttpStatusCode statusCode = HttpStatusCode.OK;
            try
            {
                ItemResponse<ScoreboardDomain> itemResponse = new ItemResponse<ScoreboardDomain>();
                itemResponse.Item = _scoreboardService.SelectLastCreated();
                response = itemResponse;
                statusCode = HttpStatusCode.OK;
            }
            catch (Exception Error)
            {
                response = new ErrorResponse(Error);
                statusCode = HttpStatusCode.InternalServerError;
            }
            return Request.CreateResponse(statusCode, response);
        }

        [HttpGet]
        [Route("lastunfinished")]
        public HttpResponseMessage GetLastUnfinished()
        {
            BaseResponse response = null;
            HttpStatusCode statusCode = HttpStatusCode.OK;
            try
            {
                ItemResponse<ScoreboardDomain> itemResponse = new ItemResponse<ScoreboardDomain>();
                itemResponse.Item = _scoreboardService.SelectLastUnfinished();
                response = itemResponse;
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
        [Route("score")]
        public HttpResponseMessage UpdateScore(ScoreboardUpdateRequest model)
        {
            BaseResponse response = null;
            HttpStatusCode statusCode = new HttpStatusCode();
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                _scoreboardService.UpdateScore(model);
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

        [HttpPut]
        [Route("questionset")]
        public HttpResponseMessage UpdateQuestionSet(ScoreboardUpdateRequest model)
        {
            BaseResponse response = null;
            HttpStatusCode statusCode = new HttpStatusCode();
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                _scoreboardService.UpdateQuestionSet(model);
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

        [HttpPut]
        [Route("finished")]
        public HttpResponseMessage UpdateFinished(ScoreboardUpdateRequest model)
        {
            BaseResponse response = null;
            HttpStatusCode statusCode = new HttpStatusCode();
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                _scoreboardService.UpdateFinished(model);
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