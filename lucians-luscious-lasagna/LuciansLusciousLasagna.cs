class Lasagna
{
    // TODO: define the 'ExpectedMinutesInOven()' method
    public int ExpectedMinutesInOven() => 40;

    // TODO: define the 'RemainingMinutesInOven()' method
    public int RemainingMinutesInOven(int minutes) => (minutes >= 40 || minutes < 0) ? 0 : ExpectedMinutesInOven() - minutes;
    

    // TODO: define the 'PreparationTimeInMinutes()' method
    public int PreparationTimeInMinutes(int layers) => 2*layers;

    // TODO: define the 'ElapsedTimeInMinutes()' method
    public int ElapsedTimeInMinutes(int layers, int ovenTime) => PreparationTimeInMinutes(layers) + ovenTime;
}
