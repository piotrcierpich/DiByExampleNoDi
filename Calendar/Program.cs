using System;
using System.Collections.Generic;

using Calendar.DataAccess;
using Calendar.Events;
using Calendar.Events.AddPolicy;
using Calendar.Logging;
using Calendar.UI;

namespace Calendar
{
  class Program
  {
    static void Main()
    {
      using (Logger logger = new Logger())
      {
        EventsRepository eventsRepository = new EventsRepository("calendarData.dat");
        IAddPolicy shareableTimeAddPolicy = new ShareableTimePolicy(eventsRepository);
        IAddPolicy exclusiveTimeAddPolicy = new ExclusiveSchedulePolicy(eventsRepository);
        IPlanner planner = new Planner(exclusiveTimeAddPolicy, shareableTimeAddPolicy);
        ITodoFactory todoFactory = new TodoFactory(true);
        IMeetingFactory meetingFactory = new MeetingFactory(false);

        OptionsDispatcher optionsDispatcher = new OptionsDispatcher(
          new IOption[]
            {
              new AddTodoOption(planner, todoFactory, logger),
              new ListEventsOption(eventsRepository, logger),
              new AddMeetingOption(planner, meetingFactory, logger),
              new EndApplicationOption(logger)
            },
          Console.In,
          logger);

        bool continueRunning = true;
        while (continueRunning)
        {
          continueRunning = optionsDispatcher.ChooseOptionAndRun();
        }
      }
    }
  }
}
