using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Calendar.Logging;

namespace Calendar.UI
{
  internal class OptionsDispatcher
  {
    private readonly IEnumerable<IOption> options;
    private readonly TextReader textReader;
    private readonly ILogger _logger;

    public OptionsDispatcher(IEnumerable<IOption> options, TextReader textReader, ILogger logger)
    {
      this.options = options;
      this.textReader = textReader;
      _logger = logger;
    }

    public bool ChooseOptionAndRun()
    {
      _logger.Log("ChooseOptionAndRun");
      IOption option = PrintAndChooseOption();
      bool result = option.Run();
      _logger.Log("ChooseOptionAndRun completed");
      return result;
    }

    private IOption PrintAndChooseOption()
    {
      PrintAvailableOptions();
      return ChooseOption();
    }

    private IOption ChooseOption()
    {
      while (true)
      {
        string chosenOptionAsString = textReader.ReadLine();
        IOption chosenOption = options.FirstOrDefault(o => o.MatchesString(chosenOptionAsString));
        if (chosenOption != default(IOption))
        {
          return chosenOption;
        }

        Console.WriteLine("Incorrect option, try again");
      }
    }

    private void PrintAvailableOptions()
    {
      Console.WriteLine("Pick option:");
      foreach (var option in options)
      {
        Console.WriteLine(option);
      }
    }
  }
}