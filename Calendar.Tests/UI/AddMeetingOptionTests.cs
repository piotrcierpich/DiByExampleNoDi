using System;

using Calendar.Events;
using Calendar.Logging;
using NSubstitute;

using NUnit.Framework;

namespace Calendar.Tests.UI
{
  [TestFixture]
  class AddMeetingOptionTests
  {
    [Test]
    public void ShouldHaveMAsOptionString()
    {
      StringAssert.AreEqualIgnoringCase("m", AddMeetingOption.AddMeetingOptionString);
    }

    [Test]
    public void ShouldMatchItsOptionString()
    {
      IMeetingFactory meetingFactory = Substitute.For<IMeetingFactory>();
      IPlanner planner = Substitute.For<IPlanner>();
      ILogger logger = Substitute.For<ILogger>();
      AddMeetingOption addMeetingOption = new AddMeetingOption(meetingFactory, planner, logger);
      bool result = addMeetingOption.MatchesString(AddMeetingOption.AddMeetingOptionString);
      Assert.IsTrue(result);
    }

    [Test]
    [Ignore("ignore until implement TextReader dependency injection into AddMeetingOption replacing Console.Readline")]
    public void ShouldCreateMeetingAndAddItToPlanner()
    {
      //Meeting meetingEvent = new Meeting(DateSpan.Max, string.Empty, null, new string[0]);
      //Func<DateSpan, string, string[], Meeting> meetingFactory = Substitute.For<Func<DateSpan, string, string[], Meeting>>();
      //meetingFactory(Arg.Any<DateSpan>(), Arg.Any<string>(), Arg.Any<string[]>()).Returns(meetingEvent);

      //IPlanner planner = Substitute.For<IPlanner>();
      //AddMeetingOption addMeetingOption = new AddMeetingOption(meetingFactory, planner);

      //addMeetingOption.Run();

      //planner.Received(1).AddEvent(meetingEvent);
    }
  }
}
