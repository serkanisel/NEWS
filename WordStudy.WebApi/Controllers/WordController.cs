using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WordStudy.WebApi.Interfaces;
using WordStudy.Data.Model;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using WordStudy.WebApi.Dtos;

namespace WordStudy.WebApi.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    public class WordController : Controller
    {
        private readonly IWordRepository _wordRepository;
        private readonly IMapper _mapper; 

        public WordController(IWordRepository wordRepository, IMapper mapper)
        {
            _wordRepository = wordRepository;
            _mapper = mapper;
        }

        //[AllowAnonymous]
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Word> words = _wordRepository.GetAll();

            var wordReturn = _mapper.Map<IEnumerable<WordDto>>(words);

            return Ok(wordReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Word wrd = await _wordRepository.GetByIdAsync(id);

            var wordReturn = _mapper.Map<WordDto>(wrd);

            return Ok(wordReturn);
        }

        [HttpPost("{SearchAsync}")]
        public IActionResult SearchAsync([FromBody]string str)
        {
            IEnumerable<Word> words = _wordRepository.Find(p => p.Body.StartsWith(str));

            var wordReturn = _mapper.Map<IEnumerable<WordDto>>(words);

            return Ok(wordReturn);
        }
    }
}