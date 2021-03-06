﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UniqueBookCase.Api.ViewModels;
using UniqueBookCase.DomainModel.CQRS.Commands.AuthorCommands;
using UniqueBookCase.DomainModel.CQRS.Communication.Mediator;
using UniqueBookCase.DomainModel.Interfaces.Services;

namespace UniqueBookCase.Api.Controllers
{
    [ApiVersion("1.0")]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
       
    {
        private readonly IAuthorService _authorService;
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public AuthorController(IAuthorService authorService, IMediatorHandler mediatorHandler, IMapper mapper, ILogger<AuthorController> logger)
        {
            _authorService = authorService;
            _mediatorHandler = mediatorHandler;
            _mapper = mapper;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<AuthorViewModel>> GetAll()
        {
            _logger.LogInformation("Executing api/Author -> GetAll");

            return _mapper.Map<IEnumerable<AuthorViewModel>>(await _authorService.GetAuthorBooks());
        }

        [AllowAnonymous]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<AuthorViewModel>> Get(Guid id)
        {
            _logger.LogInformation("Executing api/Author -> Get");

            var author = _mapper.Map<AuthorViewModel>(await _authorService.GetAuthorBook(id));

            if (author == null) return NotFound();

            return author;
        }

        [HttpPost]
        public async Task<ActionResult<AuthorViewModel>> Post(AuthorViewModel authorViewModel)
        {
            _logger.LogInformation("Executing api/Author -> Post");

            if (!ModelState.IsValid) return BadRequest();

            var command = _mapper.Map<AddAuthorCommand>(authorViewModel);
            await _mediatorHandler.SendCommand(command);

            return Ok();
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<AuthorViewModel>> Put(Guid id, AuthorViewModel authorViewModel)
        {
            _logger.LogInformation("Executing api/Author -> Put");

            if (id != authorViewModel.Id)
            {
                return BadRequest("The id entered is not the same as the one passed in the query.");
            }

            if (!ModelState.IsValid) return BadRequest();

            var command = _mapper.Map<UpdateAuthorCommand>(authorViewModel);
            await _mediatorHandler.SendCommand(command);

            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<AuthorViewModel>> Delete(Guid id)
        {
            _logger.LogInformation("Executing api/Author -> Delete");

            var author = _mapper.Map<AuthorViewModel>(await _authorService.GetAuthor(id));

            var command = _mapper.Map<DeleteAuthorCommand>(author);
            await _mediatorHandler.SendCommand(command);

            return Ok();
        }

    }
}
