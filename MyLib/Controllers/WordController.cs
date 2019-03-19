using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace WordStudy.Web.Controllers
{
    [Route("api/word")]
    public class WordController : Controller
    {
        private readonly IWordRepository _wordRepository;

        public WordController(IWordRepository wordRepository)
        {
            _wordRepository = wordRepository;
        }

        public IActionResult Get()
        {
            List<Word> words = _wordRepository.GetAll().ToList();

            return Json(words);
        }
    }
}