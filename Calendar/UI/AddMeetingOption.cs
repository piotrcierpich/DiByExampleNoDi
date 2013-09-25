using System;

using Calendar.Events;
using Calendar.Logging;

namespace Calendar.UI
{
  class AddMeetingOption : IOption
  {
    private const string MeetingOptionAsString = "m";
    private readonly IPlanner planner;
    private readonly IMeetingFactory _meetingFactory;
    private readonly Logger _logger;

    public AddMeetingOption(IPlanner planner, IMeetingFactory meetingFactory, Logger logger)
    {
      this.planner = planner;
      _meetingFactory = meetingFactory;
      _logger = logger;
    }

    public bool MatchesString(string chosenOptionAsString)
    {
      return StringComparer.InvariantCultureIgnoreCase.Equals(MeetingOptionAsString, chosenOptionAsString);
    }

    public bool Run()
    {
      _logger.Log("Run");
      DateSpan schedule = DateSpanReader.PromptForDateSpan();
      Console.Write("Title: ");
      string title = Console.ReadLine();
      string[] participants = PromptForParticipants();
      Meeting meetingToAdd = _meetingFactory.Create(schedule, title, participants);
      planner.AddEvent(meetingToAdd);
      _logger.Log("Run completed");
      return true;
    }

    private string[] PromptForParticipants()
    {
      Console.Write("Participants' names separated with comas: ");
      string participantsAsString = Console.ReadLine();
      return participantsAsString != null
                ? participantsAsString.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                : new string[0];
    }

    public sealed override string ToString()
    {
      return MeetingOptionAsString + " - meeting";
    }
  }
}