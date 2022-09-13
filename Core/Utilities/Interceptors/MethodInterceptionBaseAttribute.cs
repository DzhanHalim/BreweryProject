using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Interceptors
{
    // this attribute targets classes and methods, it can be used multiple times and can be inherited
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    // we say this class is actually an attribute and an interceptor
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        // which attribute should run first
        public int Priority { get; set; }

        // method from IInterceptor interface
        public virtual void Intercept(IInvocation invocation)
        {

        }
    }
}
