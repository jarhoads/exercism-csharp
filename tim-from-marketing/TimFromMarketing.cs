using System;

static class Badge
{
    public static string Print(int? id, string name, string? department)
    {
        var deptName = (department == null) ? "OWNER" : department.ToUpper();
        var idVal = (id == null) ? "" : $"[{id}] - ";

        return $"{idVal}{name} - {deptName}";
    }
}
