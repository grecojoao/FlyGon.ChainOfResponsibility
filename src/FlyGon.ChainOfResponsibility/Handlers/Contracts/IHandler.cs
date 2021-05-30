namespace FlyGon.ChainOfResponsibility.Handlers.Contracts
{
    public interface IHandler
    {
        IHandler SetNext(IHandler handler);
        object Handle(object request);
    }
}