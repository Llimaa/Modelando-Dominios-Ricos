using PaymentContext.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PaymentContext.Shared.Handlers
{
    public interface IHandlers<T> where T : Icommand
    {
        ICommandResult Handle(T command);
    }
}
