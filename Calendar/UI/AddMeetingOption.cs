using System;

using Calendar.Events;

namespace Calendar.UI
{
  class AddMeetingOption : IOption
  {
    private const string MeetingOptionAsString = "m";
    private readonly IPlanner planner;

    public AddMeetingOption(IPlanner planner)
    {
      this.planner = planner;
    }

    public bool MatchesString(string chosenOptionAsString)
    {
      return StringComparer.InvariantCultureIgnoreCase.Equals(MeetingOptionAsString, chosenOptionAsString);
    }

    public bool Run()
    {
      DateSpan schedule = DateSpanReader.PromptForDateSpan();
      Console.Write("Title: ");
      string title = Console.ReadLine();
      string[] participants = PromptForParticipants();
      Meeting meetingToAdd = new Meeting(schedule, title, participants);
      planner.AddEvent(meetingToAdd);
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