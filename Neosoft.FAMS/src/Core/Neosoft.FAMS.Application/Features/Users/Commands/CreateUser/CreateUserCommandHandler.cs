using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Neosoft.FAMS.Application.Contracts.Infrastructure;
using Neosoft.FAMS.Application.Contracts.Persistence;

using Neosoft.FAMS.Application.Models.Mail;
using Neosoft.FAMS.Application.Responses;
using Neosoft.FAMS.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Response<Guid>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<CreateUserCommandHandler> _logger;

  
        public CreateUserCommandHandler(IMapper mapper, IUserRepository userRepository, IEmailService emailService, ILogger<CreateUserCommandHandler> logger)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<Response<Guid>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
           // var validator = new CreateUserCommandValidator(_userRepository);
            //var validationResult = await validator.ValidateAsync(request);

            //if (validationResult.Errors.Count > 0)
            //    throw new Exceptions.ValidationException(validationResult);

            var @user = _mapper.Map<UserDemo>(request);

            @user = await _userRepository.AddAsync(@user);

            //Sending email notification to admin address
            var email = new Email() { To = "gill@snowball.be", Body = $"A new event was created: {request}", Subject = "A new event was created" };

            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception ex)
            {
                //this shouldn't stop the API from doing else so this can be logged
                _logger.LogError($"Mailing about event {@user.Id} failed due to an error with the mail service: {ex.Message}");
            }

            var response = new Response<Guid>(@user.Id, "Inserted successfully ");

            _logger.LogInformation("Handle Completed");

            return response;
        }

       
    }
}
