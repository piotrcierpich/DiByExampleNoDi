using System;
using System.IO;

namespace Calendar.Logging
{
  internal class Logger : IDisposable, ILogger
  {
    private readonly StreamWriter streamWriter;

    public Logger()
    {
      streamWriter = new StreamWriter("log.txt", true);
    }

    public void Log(string message)
    {
      streamWriter.WriteLine(DateTime.Now + " " + message);
    }

    public void Dispose()
    {
      streamWriter.Dispose();
    }
  }
}
