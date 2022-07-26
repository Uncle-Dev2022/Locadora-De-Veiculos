using Autofac;

namespace LocadoraDeVeiculos.WindowsFormApp.Compartilhado.Ioc
{
    public class ServiceLocatorAutofac
    {
        private readonly IContainer container;

        public ServiceLocatorAutofac()
        {
            var builder = new ContainerBuilder();
            container = builder.Build();
        }
        public T Get<T>() where T : ControladorBase
        {
            return container.Resolve<T>();
        }
    }
}
