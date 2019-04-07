using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WordStudy.WebApi.Interfaces;
using WordStudy.Data.Model;
using Microsoft.AspNetCore.Authorization;

namespace WordStudy.WebApi.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    public class WordController : Controller
    {
        private readonly IWordRepository _wordRepository;

        public WordController(IWordRepository wordRepository)
        {
            _wordRepository = wordRepository;
        }

        //[AllowAnonymous]
        [HttpGet]
        public IActionResult Get()
        {
            Word wrd = new Word();
            wrd.Body = "Calf";
            wrd.Mean = "Dana";
            wrd.CreatedDate = DateTime.Now;

            Word wrd2 = new Word();
            wrd2.Body = "Cat";
            wrd2.Mean = "Dana";
            wrd2.CreatedDate = DateTime.Now;


            _wordRepository.Add(wrd);
            _wordRepository.Add(wrd2);

            IEnumerable<Word> words = _wordRepository.GetAll();
            //return Ok(words);
            return Ok(words);
        }

        [HttpPost("{SearchAsync}")]
        public IActionResult SearchAsync([FromBody]string str)
        {
            IEnumerable<Word> words = _wordRepository.Find(p => p.Body.StartsWith(str));

            return Ok(words);
        }
    }
}