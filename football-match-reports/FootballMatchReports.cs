using System;

public static class PlayAnalyzer
{
    public static string AnalyzeOnField(int shirtNum) => shirtNum switch
	{
        1 => "goalie",
        2 => "left back",
        3 => "center back",
        4 => "center back",
        5 => "right back",
        6 => "midfielder",
        7 => "midfielder",
        8 => "midfielder",
        9 => "left wing",
        10 => "striker",
        11 => "right wing",
        _ => throw new ArgumentOutOfRangeException()
	};

    public static string AnalyzeOffField(object report)
    {
        if (report is int supporters)
        {
            return $"There are {supporters} supporters at the match.";
        }
        else if (report is string announcement)
        {
            return $"{announcement}";
        }
        else if (report is Incident incident)
        {
            return (incident is Injury injury) ? $"Oh no! {incident.GetDescription()} Medics are on the field." : 
                                                 $"{incident.GetDescription()}";
        }
        else if (report is Manager manager)
        {
            return string.IsNullOrWhiteSpace(manager.Club) ? $"{manager.Name}" : $"{manager.Name} ({manager.Club})";
        }
        else
        {
            throw new ArgumentException();
        }


    }
}
