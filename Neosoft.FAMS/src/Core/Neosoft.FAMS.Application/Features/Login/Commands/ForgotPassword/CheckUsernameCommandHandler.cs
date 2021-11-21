using AutoMapper;
using MediatR;
using Neosoft.FAMS.Application.Contracts.Persistence;
using Neosoft.FAMS.Domain.Entities;
using System;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Application.Features.Login.Commands
{
    public class CheckUsernameCommandHandler : IRequestHandler<CheckUsernameCommand, bool>
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
            if (data != null)
            {
                long id = data.Id;
                Random rdm = new Random();
                int code = rdm.Next(1000, 9999);
                string to = request.UserName;
                string subject = "Reset password for FanEase Portal";
                string body = $"Your 4 digit code is {code}";
                MailMessage mm = new MailMessage();
                mm.To.Add(to);
                mm.Subject = subject;
                mm.Body = body;
                mm.BodyEncoding = System.Text.Encoding.GetEncoding("utf-8");
                mm.SubjectEncoding = System.Text.Encoding.Default;
                mm.From = new MailAddress("fanease11@gmail.com");
                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.EnableSsl = true;
                smtp.Credentials = new System.Net.NetworkCredential("fanease11@gmail.com", "FanEase05");
                smtp.Send(mm);

                PasswordResetRequest passwordResetRequest = new PasswordResetRequest();
                passwordResetRequest.LoginId = id;
                passwordResetRequest.RequestedOn = DateTime.Now;
                passwordResetRequest.ValidCode = code.ToString();
                passwordResetRequest.ExpiredOn = DateTime.Now.AddMinutes(10);
                var datatwo = await _loginRepository.AddCode(passwordResetRequest);
                if (datatwo != null)
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
