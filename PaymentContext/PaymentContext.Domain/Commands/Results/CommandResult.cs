using PaymentContext.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Domain.Commands.Results
{
    public class CommandResult : ICommandResult
    {
        public CommandResult()
        {

        }
        public CommandResult(bool success, string mensagem)
        {
            Success = success;
            Mensagem = mensagem;
        }

        public bool Success { get; set; }
        public string Mensagem { get; set; }
    }
}
