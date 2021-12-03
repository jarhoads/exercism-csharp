using System;

class RemoteControlCar
{
    public static readonly int BatteryUnit = 20;

    private int _meters;
    private int _battery;

    public RemoteControlCar()
    {
        _meters = 0;
        _battery = 100;
    }

    public static RemoteControlCar Buy()
    {
        return new RemoteControlCar();
    }

    public string DistanceDisplay()
    {
        return $"Driven {_meters} meters";
    }

    public string BatteryDisplay()
    {
        return (_battery > 0) ? $"Battery at {_battery}%" : "Battery empty";
    }

    public void Drive()
    {
        if (_battery > 0)
        {
            _meters += BatteryUnit;
            _battery--;
        }
    }
}
