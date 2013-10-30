using System;

namespace StructureMap.DelegateFactories.Services
{
    public delegate IService ServiceConstructor(string message);

    public class DefaultServiceImplementation : IService
    {
        private readonly string message;
        private readonly IServiceDependency dependency;

        public DefaultServiceImplementation(string message, IServiceDependency dependency)
        {
            this.message = message;
            this.dependency = dependency;
        }

        public void SayIt()
        {
            Console.WriteLine("{0} and {1}", message, dependency.HelpMe());
        }
    }
}
