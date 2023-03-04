using System;

namespace Shooter
{
    internal interface IExecute : IDisposable
    {
        void Execute();
        void FixedExecute();
    }
}
