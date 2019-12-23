using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UniqueBookCase.Api.ViewModels;
using UniqueBookCase.DomainModel.AuthorAggregate;
using UniqueBookCase.DomainModel.Interfaces.Services;

namespace UniqueBookCase.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
       
    {
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public AuthorController(IAuthorService authorService, IMapper mapper, ILogger<AuthorController> logger)
        {
            _authorService = authorService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<AuthorViewModel>> GetAll()
        {
            _logger.LogInformation("Executing api/Author -> GetAll");

            return _mapper.Map<IEnumerable<AuthorViewModel>>(await _authorService.GetAuthorBooks());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<AuthorViewModel>> Get(Guid id)
        {
            _logger.LogInformation("Executing api/Author -> Get");

            var author = _mapper.Map<AuthorViewModel>(await _authorService.GetAuthorBook(id));

            if (author == null) return NotFound();

            return author;
        }

        [HttpPost]
        public async Task<ActionResult<AuthorViewModel>> Post([FromBody] AuthorViewModel authorViewModel)
        {
            _logger.LogInformation("Executing api/Author -> Post");

            if (!ModelState.IsValid) return BadRequest();

            await _authorService.AddAuthor(_mapper.Map<Author>(authorViewModel));

            return Ok(authorViewModel);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AuthorViewModel>> Put([FromBody] AuthorViewModel authorViewModel)
        {
            _logger.LogInformation("Executing api/Author -> Put");

            if (!ModelState.IsValid) return BadRequest();

            await _authorService.UpdateAuthor(_mapper.Map<Author>(authorViewModel));

            return Ok(authorViewModel);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<AuthorViewModel>> Delete(Guid id)
        {
            _logger.LogInformation("Executing api/Author -> Delete");

            await _authorService.DeleteAuthor(id);

            return Ok();
        }

    }
}
