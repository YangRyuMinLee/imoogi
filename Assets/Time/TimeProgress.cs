using System;

public class TimeProgress
{
    public long progress = 0L;
    private DateTime startDate = new DateTime(7997, 1, 1);
    private TimeSpan tickTimeSpan = new TimeSpan(4, 0, 0);
    public DateTime dateTime => startDate.Add(tickTimeSpan * progress);
}
