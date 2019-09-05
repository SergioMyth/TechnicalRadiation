using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebApplication5.Services;
using WebApplication5.TechnicalRadiation.Models;

namespace WebApplication5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyController : ControllerBase
    {
        public IConfiguration Config { get; }
        public IMuggurService Muggur { get; }
        public ILameService LameService { get; }

        public MyController(IConfiguration config, IMuggurService muggur, ILameService lameService)
        {
            Config = config;
            Muggur = muggur;
            LameService = lameService;
        }

        // GET api/
        [HttpGet]
        public ActionResult<List<HyperMediaModel>> Get()
        {
            List<HyperMediaModel> listinn = null;
            try
            {
                listinn = Muggur.GetStuff();
            }
            catch (Exception)
            {

                throw;
            }
            return listinn;
        }

        // GET api/
        [HttpGet]
        [Route("/allnewsfilter/{pageNumber}/{pageSize}")]
        public ActionResult<string> Get(int pageNumber, int pageSize, [FromHeader]string xApiKey)
        {
            if (LameService.Authenticate(xApiKey) == false) 
            {
                return "Not authenticated, stay out!";
            }
            return $"{pageNumber} in year {pageSize} Authenticated";
        }

        // GET api/
        [HttpGet]
        [Route("/api/{newsItemId}")]
        public ActionResult<string> Get(int newsItemId, [FromHeader]string xApiKey)
        {
            if (LameService.Authenticate(xApiKey) == false)
            {
                return "Not authenticated, stay out!";
            }
            return $"{newsItemId} Authenticated";
        }

        // No filter
        [HttpGet]
        [Route("/api")]
        public ActionResult<List<string>> GetAllNews()
        {
            int i = 0;
            var listi = new List<string>();
            for (i = 0; i < 10; i++)
            {
                listi.Add($"{i}");
            }

            return listi;
        }


        // POST api/
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
