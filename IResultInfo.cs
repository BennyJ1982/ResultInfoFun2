using System.Collections.Generic;

namespace ResultInfoFun
{
    public interface IResultInfo
    {
        string Message { get; set; }

        IList<IResultInfo> Children { get; }
    }
}
