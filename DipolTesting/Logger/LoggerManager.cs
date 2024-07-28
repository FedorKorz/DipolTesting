using System;

namespace DipolTesting.Logger;

public class LoggerManager : ILogger
{
    public void ReportSuccessfullyGenerated()
    {
        Console.WriteLine("Report successfully created");
    }

    public void ErrorReadingReportFile(Exception e)
    {
        UtilsCreateLogs.Init(e.Message);
    }

    public void FailedToCreateReport(Exception e)
    {
        UtilsCreateLogs.Init(e.Message);
    }

    public void FailedToOpenReportTemplate(Exception e)
    {
        UtilsCreateLogs.Init(e.Message);
    }

    public void FailedToReadJson(Exception ex)
    {
        UtilsCreateLogs.Init(ex.Message);
    }

    public void FailedToCallFunction(Exception e)
    {
        UtilsCreateLogs.Init(e.Message);
    }

    public void NecessaryParametersMissing(string errorMessage)
    {
        UtilsCreateLogs.Init(errorMessage);
    }
}