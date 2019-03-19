using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WordStudy.Data.Model;
using WordStudy.WebApi.Interfaces;

namespace WordStudy.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IWordRepository _wordRepository;

        public ValuesController(IWordRepository wordRepository)
        {
            _wordRepository = wordRepository;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Word> words = _wordRepository.GetAll();
            //return Ok(words);
            return Ok(words);

            //return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
