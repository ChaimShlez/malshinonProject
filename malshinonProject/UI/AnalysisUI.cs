using malshinonProject.Controller;
using malshinonProject.Entitys;
using System.Collections.Generic;
using System;

internal class AnalysisUI
{
    private ControllerAlert _controlleerAlert;

    public AnalysisUI(ControllerAlert controlleerAlert)
    {
        _controlleerAlert = controlleerAlert;
    }

    public void GetAnalysis()
    {
        List<Alert> listAlert = GetAllAlerts();

        foreach (var alert in listAlert)
        {
            Console.WriteLine(alert);
        }

        List<PersonReportAverageDTO> averages = GetAverages();
        foreach (var avg in averages)
        {
            Console.WriteLine($"{avg.FullName} ({avg.CodeName}): {avg.Average:F2}");
        }
    }

    private List<Alert> GetAllAlerts()
    {
        return _controlleerAlert.GetAllAlerts();
    }

    private List<PersonReportAverageDTO> GetAverages()
    {
        return _controlleerAlert.GetPersonByAverage();
    }
}
