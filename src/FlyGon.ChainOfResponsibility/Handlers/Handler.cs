using FlyGon.ChainOfResponsibility.Handlers.Contracts;

namespace FlyGon.ChainOfResponsibility.Handlers
{
    /// <summary>
    /// Base class for Handlers that manipulate custom objects.
    /// </summary>
    /// <remarks>
    /// Use to create a Handler that manipulates a custom object.
    /// You can define another Handler to handle the object if this is not possible in the current one.
    /// </remarks>
    public abstract class Handler : IHandler
    {
        private IHandler _nextHandler;

        /// <summary>
        /// Use to indicate the next Handler that handles the custom object.
        /// </summary>
        /// <param name="handler">Next Handler that will be able to manipulate the custom object.</param>
        /// <remarks>
        /// Use this method in casted for all Handlers you want to link through the chain of responsibility.
        /// </remarks>
        /// <returns>
        /// Returns the reference of the next Handler.
        /// </returns>
        public IHandler SetNext(IHandler handler)
        {
            _nextHandler = handler;
            return handler;
        }

        /// <summary>
        /// Use to manipulate the custom object.
        /// </summary>
        /// <param name="request">Custom object to be manipulated.</param>
        /// <remarks>
        /// Manipulates the chained object.
        /// If the handler can't handle the object, it passes it on so another handler can handle it.
        /// </remarks>
        /// <returns>
        /// Returns the reference of the Handler that handled the object, or null.
        /// </returns>
        public virtual object Handle(object request)
        {
            if (_nextHandler != null)
                return _nextHandler.Handle(request);
            return null;
        }
    }
}