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
    public class ListsController : Controller
    {
        private readonly IListsRepository _listsRepository;
        private readonly IMapper _mapper;

        public ListsController(IListsRepository listsRepository, IMapper mapper)
        {
            _listsRepository = listsRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var lists = await _listsRepository.GetAllAsync();

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