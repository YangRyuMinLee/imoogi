using System;

[Serializable]
public struct TimeProgress
{
    public long progress;
    private static readonly DateTime startDate = new DateTime(7997, 01, 01);
    public DateTime dateTime => startDate.Add(TimeSpan.FromDays(1) * (progress / 6)).Date;

    public override String ToString()
    {
        return $"{dateTime.Year.ToString("0000")} {dateTime.Month.ToString("00")} {dateTime.Day.ToString("00")} {KoreanDayOfWeek(dateTime.DayOfWeek)}";
    }

    private String KoreanDayOfWeek(DayOfWeek dayOfWeek)
    {
        if(dayOfWeek == DayOfWeek.Sunday)
        {
            return "일";
        }
        else if(dayOfWeek == DayOfWeek.Monday)
        {
            return "월";
        }
        else if(dayOfWeek == DayOfWeek.Tuesday)
        {
            return "화";
        }
        else if(dayOfWeek == DayOfWeek.Wednesday)
        {
            return "수";
        }
        else if(dayOfWeek == DayOfWeek.Thursday)
        {
            return "목";
        }
        else if(dayOfWeek == DayOfWeek.Friday)
        {
            return "금";
        }
        else if(dayOfWeek == DayOfWeek.Saturday)
        {
            return "토";
        }
        return "ㅅㅂ 뭐지?";
    }
}
