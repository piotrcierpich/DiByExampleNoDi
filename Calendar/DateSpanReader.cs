using System;
using System.Globalization;
using Calendar.Events;

namespace Calendar
{
  class DateSpanReader
  {
    private const string DateFormat = "MMdd";

    public static DateSpan PromptForDateSpan()
    {
      DateSpan dateSpan;
      while (!TryPromptForDateSpan(out dateSpan))
      { }
      return dateSpan;
    }

    private static bool TryPromptForDateSpan(out DateSpan dateSpan)
    {
      try
      {
        DateTime startDate = ReadDate(string.Format("Start date (format {0}): ", DateFormat));
        DateTime endDate = ReadDate(string.Format("End date (format {0}):", DateFormat));
        dateSpan = new DateSpan(startDate, endDate);
        return true;
      }
      catch (ArgumentException argumentException)
      {
        Console.WriteLine("Error occured: " + argumentException.Message);
        dateSpan = DateSpan.Max;
        return false;
      }
    }

    private static DateTime ReadDate(string prompt)
    {
      DateTime dateRead;
      string startDateAsString = PromptAndRead(prompt);
      while (!DateTime.TryParseExact(startDateAsString,
                                     DateFormat,
                                     CultureInfo.InvariantCulture,
                                     DateTimeStyles.None,
                                     out dateRead))
      {
        Console.WriteLine("Incorrect date, expected format '{0}'", DateFormat);
        startDateAsString = PromptAndRead(prompt);
      }

      return dateRead;
    }

    private static string PromptAndRead(string prompt)
    {
      Console.Write(prompt);
      return Console.ReadLine();
    }
  }
}
