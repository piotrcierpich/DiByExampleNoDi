using System.Collections.Generic;

using Calendar.DataAccess;
using Calendar.Events;
using Calendar.Events.AddPolicy;
using Calendar.UI;

namespace Calendar
{
  class Program
  {
    static void Main()
    {
      EventsRepository eventsRepository = new EventsRepository();
      IAddPolicy shareableTimeAddPolicy = new ShareableTimePolicy(eventsRepository);
      IAddPolicy exclusiveTimeAddPolicy = new ExclusiveSchedulePolicy(eventsRepository);
      IPlanner planner = new Planner(exclusiveTimeAddPolicy, shareableTimeAddPolicy);
      IEnumerable<IOption> options = new IOption[]
                                       {
                                           new AddTodoOption(planner), 
                                           new ListEventsOption(eventsRepository),
                                           new AddMeetingOption(planner),
                                           new EndApplicationOption()
                                       };

      OptionsDispatcher optionsDispatcher = new OptionsDispatcher(options);

      bool continueRunning = true;
      while (continueRunning)
      {
        continueRunning = optionsDispatcher.ChooseOptionAndRun();
      }
    }
  }
}
