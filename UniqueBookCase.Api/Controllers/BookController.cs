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
    public class BookController : ControllerBase

    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public BookController(IBookService bookService, IMapper mapper, ILogger<BookController> logger)
        {
            _bookService = bookService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<BookViewModel>> GetAll()
        {
            _logger.LogInformation("Executing api/Book -> GetAll");

            return _mapper.Map<IEnumerable<BookViewModel>>(await _bookService.GetBooksAuthor());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<BookViewModel>> Get(Guid id)
        {
            _logger.LogInformation("Executing api/Book -> Get");

            var author = _mapper.Map<BookViewModel>(await _bookService.GetBookAuthor(id));

            if (author == null) return NotFound();

            return author;
        }

        [HttpPost]
        public async Task<ActionResult<AuthorViewModel>> Post(BookViewModel bookViewModel)
        {
            _logger.LogInformation("Executing api/Book -> Post");

            if (!ModelState.IsValid) return BadRequest();

            await _bookService.AddBook(_mapper.Map<Book>(bookViewModel));

            return Ok(bookViewModel);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BookViewModel>> Put(BookViewModel bookViewModel)
        {
            _logger.LogInformation("Executing api/Book -> Put");

            if (!ModelState.IsValid) return BadRequest();

            await _bookService.UpdateBook(_mapper.Map<Book>(bookViewModel));

            return Ok(bookViewModel);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<AuthorViewModel>> Delete(Guid id)
        {
            _logger.LogInformation("Executing api/Book -> Delete");

            await _bookService.DeleteBook(id);

            return Ok();
        }


    }
}
