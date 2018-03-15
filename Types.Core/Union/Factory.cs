using System;

namespace Types.Core.Union
{
    public abstract class Factory<TMonad>
    {
        private readonly Func<TMonad> _factory;

        protected Factory(Func<TMonad> factory)
        {
            _factory = factory;
        }
    }
}
