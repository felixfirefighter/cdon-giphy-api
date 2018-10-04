using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace CDON.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiphyController : ControllerBase
    {
        private readonly static int limit = 20;

        [HttpGet]
        public IActionResult Get(string q, int offset)
        {
            var client = new RestClient("http://api.giphy.com");

            var request = new RestRequest("v1/gifs/search", Method.GET);
            
            request.AddParameter("api_key", "kBsvqRlzJwdEsIL9V2BcLoVFz2kaRHtG");
            request.AddParameter("limit", limit);
            request.AddParameter("offset", offset * limit);
            request.AddParameter("q", q);


            IRestResponse response = client.Execute(request);

            if (!response.IsSuccessful)
            {
                return BadRequest();
            }

            var content = response.Content;
            return Ok(content);
        }

        
    }
}