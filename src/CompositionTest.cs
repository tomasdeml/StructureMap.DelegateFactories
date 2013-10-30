using System;
using FluentAssertions;
using StructureMap.DelegateFactories.Services;
using Xunit;

namespace StructureMap.DelegateFactories
{
    public class CompositionTest
    {
        [Fact]
        public void ServiceConstructorFromContainerCreatesDefaultServiceImplementation()
        {
            IContainer container = CreateContainer();

            var serviceConstructor = container.GetInstance<ServiceConstructor>();
            IService service = serviceConstructor("Hello world");

            service.Should().BeOfType<DefaultServiceImplementation>();
        }

        private static IContainer CreateContainer()
        {
            var container = new Container();
            container.Configure(configuration =>
            {
                configuration.For<IServiceDependency>().Use<DefaultServiceDependencyImplementation>();
                configuration.For<IService>().Use<DefaultServiceImplementation>();

                configuration.For<ServiceConstructor>()
                             .Use(message => container.With<string>(message).GetInstance<IService>());
            });

            return container;
        }
    }
}
