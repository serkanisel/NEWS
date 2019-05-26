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
    public class WrdListController : Controller
    {
        private readonly IListsRepository _listsRepository;
        private readonly IMapper _mapper;

        public WrdListController(IListsRepository listsRepository, IMapper mapper)
        {
            _listsRepository = listsRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var lists = _listsRepository.GetAll();

            var listsToReturn = _mapper.Map<IEnumerable<WrdListDto>>(lists);

            return Ok(listsToReturn);
        }

        [HttpPost("AddWrdList")]
        public async Task<IActionResult> AddWrdList(WrdListDto wrdListDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            WrdList w = new WrdList()
            {
                ListName = wrdListDto.ListName
            };

            var createWrdList = await _listsRepository.AddWrdList(w);

            return StatusCode(201);
        }
    }
}