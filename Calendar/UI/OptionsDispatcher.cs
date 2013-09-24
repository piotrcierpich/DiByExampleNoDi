using System;
using System.Collections.Generic;
using System.Linq;

namespace Calendar.UI
{
  internal class OptionsDispatcher
  {
    private readonly IEnumerable<IOption> options;

    public OptionsDispatcher(IEnumerable<IOption> options)
    {
      this.options = options;
    }

    public bool ChooseOptionAndRun()
    {
      IOption option = PrintAndChooseOption();
      bool result = option.Run();
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
        string chosenOptionAsString = Console.ReadLine();
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