using SharedKernel.Commands.Interfaces;
using SharedKernel.Interfaces;
using System;

namespace SharedKernel.Commands
{
    public static  class DomainCommand
    {
        public static IContainer Container { get; set; }

        public static void Send<T>(T args) where T : ICommand
        {
            try
            {
                if (Container != null)
                {
                    var obj = Container.GetService(typeof(IMessageHandler<T>));
                    ((IMessageHandler<T>)obj).Handle(args);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in container commands", ex);
            }
        }
    }
}
