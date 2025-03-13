using FluentEmail.Core;
using Microsoft.AspNetCore.Mvc;

namespace S17L1.Services
{
    public class EmailService
    {
        private readonly IFluentEmail _fluentEmail;

        public EmailService(IFluentEmail fluentEmail)
        {
            _fluentEmail = fluentEmail;
        }

        public async Task<bool> SendEmailAsync()
        {
            var result = await _fluentEmail.To("pietro.smusi@email.com").Subject("Grazie per aver scelto EpiBooks").Body("Grazie per aver scelto il servizio di prestito libri di EpiBooks, speriamo di rivederti presto!").SendAsync();
            
            return result.Successful;
        }
    }
}
