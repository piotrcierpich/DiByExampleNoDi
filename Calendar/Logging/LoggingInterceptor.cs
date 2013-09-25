using System;
using Castle.DynamicProxy;

namespace Calendar.Logging
{
  class LoggingInterceptor : IInterceptor
  {
    private readonly ILogger logger;

    public LoggingInterceptor(ILogger logger)
    {
      this.logger = logger;
    }

    public void Intercept(IInvocation invocation)
    {
      try
      {
        logger.Log("Calling method " + invocation.Method.Name);
        invocation.Proceed();
      }
      finally
      {
        logger.Log("Method " + invocation.Method.Name + "Completed");
      }
    }
  }
}
