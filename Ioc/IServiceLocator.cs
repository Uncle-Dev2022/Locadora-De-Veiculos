using LocadoraDeVeiculos.WindowsFormApp.Compartilhado;

namespace LocadoraDeVeiculos.LocadoraDeVeiculos.WindowsFormApp.Compartilhado.Ioc
{
    public interface IServiceLocator
    {
        T Get<T>() where T : ControladorBase;
    }
}
