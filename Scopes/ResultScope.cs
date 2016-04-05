using System;

namespace ResultInfoFun.Scopes
{
    public class ResultScope : IResultScope
    {
        private readonly IResultInfo resultInfo;
        private readonly Action<IResultScope> destructionCallback;
        private bool disposed;

        public ResultScope(IResultInfo resultInfo, Action<IResultScope> destructionCallback)
        {
            this.IsRoot = true;
            this.resultInfo = resultInfo;
            this.destructionCallback = destructionCallback;
        }

        public ResultScope(IResultScope parentScope, IResultInfo resultInfo, Action<IResultScope> destructionCallback)
        {
            this.IsRoot = false;
            this.resultInfo = resultInfo;
            this.ParentScope = parentScope;
            this.destructionCallback = destructionCallback;
        }

        public string Message
        {
            get { return this.resultInfo.Message; }
            set { this.resultInfo.Message = value; }
        }

        public IResultScope ParentScope { get; set; }

        public bool IsRoot { get; private set; }

        public IResultScope CreateChildScope()
        {
            var resultInfo = new ResultInfo();
            this.resultInfo.Children.Add(resultInfo);
            return new ResultScope(this, resultInfo, this.destructionCallback);
        }

        public void Dispose()
        {
            if (!disposed)
            {
                this.destructionCallback(this);
                this.disposed = true;
            }
        }
    }
}
