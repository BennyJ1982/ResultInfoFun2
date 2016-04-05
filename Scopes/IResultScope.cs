using System;

namespace ResultInfoFun.Scopes
{
    public interface IResultScope : IDisposable
    {
        bool IsRoot { get; }

        IResultScope ParentScope { get; }

        string Message { get; set; }

        IResultScope CreateChildScope();
    }
}
