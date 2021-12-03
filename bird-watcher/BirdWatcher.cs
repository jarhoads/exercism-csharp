using System;
using System.Linq;

class BirdCount
{
    private int[] birdsPerDay;
    
    // adding last day index to simplify references
    private readonly int lastDayIdx;

    public BirdCount(int[] birdsPerDay)
    {
        this.birdsPerDay = birdsPerDay;
        this.lastDayIdx = this.birdsPerDay.Length - 1;
    }

    public static int[] LastWeek() => new int[] {0, 2, 5, 3, 7, 8, 4};

    public int Today() => (this.birdsPerDay.Length > 0) ? this.birdsPerDay[lastDayIdx] : 0;

    public void IncrementTodaysCount() => this.birdsPerDay[lastDayIdx] = Today() + 1;
    
    public bool HasDayWithoutBirds() => this.birdsPerDay.Any(day => day == 0);

    public int CountForFirstDays(int numberOfDays) => this.birdsPerDay.Take(numberOfDays).Sum();

    public int BusyDays() => this.birdsPerDay.Where(day => day >= 5).Count();

}
