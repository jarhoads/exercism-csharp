using System;

class RemoteControlCar
{
    private int speed;
    private int batteryDrain;
    private int distance;
    private int battery;

    public RemoteControlCar(int s, int b)
    {
        speed = s;
        batteryDrain = b;
        distance = 0;
        battery = 100;
    }

    public bool BatteryDrained() => battery < batteryDrain;
    
    public int DistanceDriven() => distance; 

    public void Drive()
    {
        if (battery >= batteryDrain)
        {
            distance += speed;
            battery -= batteryDrain;
        }
    }

    public static RemoteControlCar Nitro() => new(50, 4);
    
}

class RaceTrack
{
    private int trackLength;

    public RaceTrack(int dist)
    {
        trackLength = dist;
    }

    public bool CarCanFinish(RemoteControlCar car)
    {

        car.Drive();
        while (car.DistanceDriven() < trackLength && !car.BatteryDrained())
        {
            car.Drive();
        }

        return (car.DistanceDriven() >= trackLength);
    }
}
