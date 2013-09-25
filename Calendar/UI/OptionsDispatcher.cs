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

    public OptionsDispatcher(IEnumerable<IOption> options, TextReader textReader)
    {
      this.options = options;
      this.textReader = textReader;
    }

    public virtual bool ChooseOptionAndRun()
    {
      IOption option = PrintAndChooseOption();
      return option.Run();
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