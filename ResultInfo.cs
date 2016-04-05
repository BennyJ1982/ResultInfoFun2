using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ResultInfoFun
{
    [DataContract]
    public class ResultInfo : IResultInfo
    {
        private IList<IResultInfo> children;

        public ResultInfo()
        {
            this.children = new List<IResultInfo>();
        }

        [DataMember(Order = 0)]
        public string Message { get; set; }

        [DataMember(Order = 1)]
        public IList<IResultInfo> Children
        {
            get
            {
                return this.children;
            }
        }
    }
}
