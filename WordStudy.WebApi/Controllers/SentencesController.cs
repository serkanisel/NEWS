using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WordStudy.Data.Model;
using WordStudy.WebApi.Dtos;
using WordStudy.WebApi.Interfaces;

namespace WordStudy.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class SentencesController : Controller
    {
        private readonly ISentencesRepository _sentencesRepository;
        private readonly IMapper _mapper;

        public SentencesController(ISentencesRepository sentencesRepository,IMapper mapper)
        {
            _mapper = mapper;
            _sentencesRepository = sentencesRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Sentence> sentences = _sentencesRepository.GetAll();

            var sentenceReturn = _mapper.Map<IEnumerable<SentenceDto>>(sentences);

            return Ok(sentences);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Sentence snc = await _sentencesRepository.GetByIdAsync(id);

            var sentenceReturn = _mapper.Map<SentenceDto>(snc);

            return Ok(snc);
        }
    }
}