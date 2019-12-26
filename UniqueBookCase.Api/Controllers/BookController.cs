using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UniqueBookCase.Api.ViewModels;
using UniqueBookCase.DomainModel.AuthorAggregate;
using UniqueBookCase.DomainModel.CQRS.Commands.BookCommands;
using UniqueBookCase.DomainModel.CQRS.Communication.Mediator;
using UniqueBookCase.DomainModel.Interfaces.Services;

namespace UniqueBookCase.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase

    {
        private readonly IBookQueries _bookQueries;
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public BookController(IBookQueries bookQueries, IMediatorHandler mediatorHandler, IMapper mapper, ILogger<BookController> logger)
        {
            _bookQueries = bookQueries;
            _mediatorHandler = mediatorHandler;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<BookViewModel>> GetAll()
        {
            _logger.LogInformation("Executing api/Book -> GetAll");

            return _mapper.Map<IEnumerable<BookViewModel>>(await _bookQueries.GetBooksAuthor());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<BookViewModel>> Get(Guid id)
        {
            _logger.LogInformation("Executing api/Book -> Get");

            var author = _mapper.Map<BookViewModel>(await _bookQueries.GetBookAuthor(id));

            if (author == null) return NotFound();

            return author;
        }

        [HttpPost]
        public async Task<ActionResult<AuthorViewModel>> Post(BookViewModel bookViewModel)
        {
            _logger.LogInformation("Executing api/Book -> Post");

            if (!ModelState.IsValid) return BadRequest();

            var command = _mapper.Map<AddBookCommand>(bookViewModel);
            await _mediatorHandler.SendCommand(command);

            return Ok();
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

            var command = _mapper.Map<UpdateBookCommand>(bookViewModel);
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
