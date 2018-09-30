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
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var client = new RestClient("http://api.giphy.com");

            var request = new RestRequest("v1/gifs/trending", Method.GET);
            
            request.AddParameter("api_key", "kBsvqRlzJwdEsIL9V2BcLoVFz2kaRHtG");
            request.AddParameter("limit", 1);


            IRestResponse response = client.Execute(request);

            var content = response.Content;

            return Ok(content);
        }

        
    }
}