namespace LocadoraDeVeiculos.WindowsFormApp.Compartilhado
{
    public interface IServiceLocator
    {
        T Get<T>() where T : ControladorBase;
    }
}