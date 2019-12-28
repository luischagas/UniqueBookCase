using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UniqueBookCase.Api.ViewModels;
using UniqueBookCase.DomainModel.CQRS.Commands.BookCommands;
using UniqueBookCase.DomainModel.CQRS.Communication.Mediator;
using UniqueBookCase.DomainModel.Interfaces.Services;

namespace UniqueBookCase.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase

    {
        private readonly IBookService _bookService;
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public BookController(IBookService bookService, IMediatorHandler mediatorHandler, IMapper mapper, ILogger<BookController> logger)
        {
            _bookService = bookService;
            _mediatorHandler = mediatorHandler;
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
        public ActionResult<AuthorViewModel> Post()
        {
            _logger.LogInformation("Executing api/Book -> Post");

            return BadRequest("Cannot insert book without author");

        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<BookViewModel>> Put(Guid id, BookViewModel bookViewModel)
        {
            _logger.LogInformation("Executing api/Book -> Put");

            if (id != bookViewModel.Id)
            {
                return BadRequest("The id entered is not the same as the one passed in the query.");
            }

            if (!ModelState.IsValid) return BadRequest();

            var bookUpdate = _mapper.Map<BookViewModel>(await _bookService.GetBookAuthor(id));

            bookUpdate.Title = bookViewModel.Title;
            bookUpdate.ReleaseDate = bookViewModel.ReleaseDate;
            bookUpdate.ISBN = bookViewModel.ISBN;
            bookUpdate.Category = bookViewModel.Category;

            var command = _mapper.Map<UpdateBookCommand>(bookUpdate);
            await _mediatorHandler.SendCommand(command);

            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<AuthorViewModel>> Delete(Guid id, BookViewModel bookViewModel)
        {
            _logger.LogInformation("Executing api/Book -> Delete");

            if (id != bookViewModel.Id)
            {
                return BadRequest("The id entered is not the same as the one passed in the query.");
            }

            var command = _mapper.Map<DeleteBookCommand>(bookViewModel);
            await _mediatorHandler.SendCommand(command);

            return Ok();
        }


    }
}
