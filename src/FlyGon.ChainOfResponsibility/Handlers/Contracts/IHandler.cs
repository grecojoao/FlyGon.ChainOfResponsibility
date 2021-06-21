namespace FlyGon.ChainOfResponsibility.Handlers.Contracts
{
    /// <summary>
    /// Interface that defines a Handler.
    /// </summary>
    /// <remarks>
    /// Use to create a Handler that manipulates a custom object.
    /// You can define another Handler to handle the object if this is not possible in the current one.
    /// </remarks>
    public interface IHandler
    {
        /// <summary>
        /// Implement to indicate the next Handler to handle the custom object.
        /// </summary>
        IHandler SetNext(IHandler handler);

        /// <summary>
        /// Implement to handle the custom object.
        /// </summary>
        object Handle(object request);
    }
}