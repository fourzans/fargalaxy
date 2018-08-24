using FarGalaxy.Contracts;
using FarGalaxy.Dto;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static NewRelic.Api.Agent.NewRelic;

namespace FarGalaxy.Api.Controllers
{
    public abstract class BaseApiController : ApiController
    {
        protected static T Get<T>(int resourceId, Func<int, T> predicate, string message) where T : BaseDto
        {
            try
            {
                T response = predicate(resourceId);

                if (response == default(T))
                {
                    HttpResponseMessage httpResponseMessage = new HttpResponseMessage(HttpStatusCode.NotFound)
                    {
                        ReasonPhrase = "Resource not found.",
                        Content = new StringContent(message)
                    };
                    throw new HttpResponseException(httpResponseMessage);
                }

                return response;
            }
            catch (Exception e)
            {
                NoticeError(e);
                throw;
            }
        }
    }
}