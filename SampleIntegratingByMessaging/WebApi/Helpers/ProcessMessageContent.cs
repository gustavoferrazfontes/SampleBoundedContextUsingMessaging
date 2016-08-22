using Newtonsoft.Json;
using SharedKernel.Commands;
using SharedKernel.Commands.Interfaces;
using SharedKernel.Messaging;

namespace WebApi.Helpers
{

    public static class ProcessMessageContent<TCommand> where TCommand : ICommand
    {

        public static void Process(Message message)
        {
            var context = JsonConvert.DeserializeObject<TCommand>(message.Value);
            DomainCommand.Send<TCommand>(context);
        }
    }

}