using ResultInfoFun.Scopes;
using System;

namespace ResultInfoFun
{
    public static class TracingContext
    {
        [ThreadStatic]
        private static IResultScope currentScope;

        public static IResultScope EnterScope(string message)
        {
            if (currentScope == null)
            {
                throw new InvalidOperationException("Initial result scope hasn't been set for the current thread.");
            }

            var scope = currentScope.CreateChildScope();
            scope.Message = message;

            currentScope = scope;
            return scope;
        }

        internal static IResultScope EnterInitialScope(string message, IResultInfo resultInfo)
        {
            return currentScope = new ResultScope(resultInfo, LeaveScope) { Message = message };
        }

        private static void LeaveScope(IResultScope scope)
        {
            currentScope = scope.ParentScope;
        }
    }
}
