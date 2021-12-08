using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Expotech2021.Models;
using Expotech2021.Repo;
using Expotech2021.viewModels;

namespace Expotech2021.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EntryController : Controller
    {
        private readonly IEntryRepo _iEntryRepo;
        private readonly IMapper _mapper;
        public EntryController(IEntryRepo repository, IMapper mapper)
        {
            this._iEntryRepo = repository;
            this._mapper = mapper;
        }

        [HttpGet("GetEntries")]
        public async Task<IActionResult> Get()
        {
            var entries = await this._iEntryRepo.GetAll();
            var entriesVm = _mapper.Map<IEnumerable<EntryVM>>(entries);
            return Ok(entriesVm);
        }


        [HttpGet("GetWithQuestions")]
        public async Task<IActionResult> GetWithPosts()
        {
            var entries = await this._iEntryRepo.GetWithQuestions();
            var entriesVM = _mapper.Map<IEnumerable<EntryVM>>(entries);
            return Ok(entriesVM);
        
        }

        [HttpPost("AddEntry")]
        public async Task<ActionResult<QuestionareEntry>> Add([FromBody] EntryVM entryVm)
        {
            var entry = _mapper.Map<QuestionareEntry>(entryVm);
            await _iEntryRepo.Add(entry);
            return Ok(entryVm);
        }

    }
}

