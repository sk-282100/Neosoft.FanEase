using AutoMapper;
using MediatR;
using Neosoft.FAMS.Application.Contracts;
using Neosoft.FAMS.Application.Contracts.Persistence;
using Neosoft.FAMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Application.Features.Login.Commands
{
    public class CheckUsernameCommandHandler:IRequestHandler<CheckUsernameCommand,bool>
    {
        private readonly ILoginRepo _loginRepository;
        private readonly IMapper _mapper;
        public CheckUsernameCommandHandler(ILoginRepo loginRepository, IMapper mapper)
        {
            _loginRepository = loginRepository;
            _mapper = mapper;
        }
        public async Task<bool> Handle(CheckUsernameCommand request, CancellationToken cancellationToken)
        {
            var data = await _loginRepository.CheckUsername(request.UserName);
            long id = data.Id;
            if (data != null)
            {
                Random rdm = new Random();
                int code = rdm.Next(1000, 9999);
                string to = request.UserName;
                string subject = "For reset password";
                string body = $"Your code is {code}";
                MailMessage mm = new MailMessage();
                mm.To.Add(to);
                mm.Subject = subject;
                mm.Body = body;
                mm.From = new MailAddress("sanahaju777@gmail.com");
                mm.IsBodyHtml = false;
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.EnableSsl = true;
                smtp.Credentials = new System.Net.NetworkCredential("sanahaju777@gmail.com", "SA@hj#77");
                smtp.Send(mm);

                    PasswordResetRequest passwordResetRequest = new PasswordResetRequest();
                    passwordResetRequest.LoginId=id;
                    passwordResetRequest.RequestedOn=DateTime.Now;
                    passwordResetRequest.ValidCode=code.ToString();
                    passwordResetRequest.ExpiredOn= DateTime.Now.AddMinutes(10);
                   var datatwo = await _loginRepository.AddCode(passwordResetRequest);
                   if(datatwo!=null)
                   {
                        return true;
                   }
                   else
                   {
                        return false;
                   }
                   
            }
            return false;
        }


    }

}
