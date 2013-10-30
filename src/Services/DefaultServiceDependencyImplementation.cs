namespace StructureMap.DelegateFactories.Services
{
    public class DefaultServiceDependencyImplementation : IServiceDependency
    {
        public string HelpMe()
        {
            return "Lorem ipsum?";
        }
    }
}
