using System;
using System.Globalization;

static class Appointment
{
    public static DateTime Schedule(string appointmentDateDescription) => 
        (DateTime.TryParse(appointmentDateDescription, out DateTime dateTime)) ? dateTime : DateTime.Now;    

    public static bool HasPassed(DateTime appointmentDate) => DateTime.Compare(appointmentDate, DateTime.Now) < 0;

    public static bool IsAfternoonAppointment(DateTime appointmentDate) => (appointmentDate.Hour >= 12 && appointmentDate.Hour < 18);

    public static string Description(DateTime appointmentDate) => $"You have an appointment on {appointmentDate.ToString("d")} {appointmentDate.ToString("T")}.";

    public static DateTime AnniversaryDate() => new DateTime(DateTime.Now.Year, 9, 15, 0, 0, 0);
}
