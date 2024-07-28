using System;
    
namespace DipolTesting.Logger
{
    public interface ILogger
    {
        void ReportSuccessfullyGenerated();
        void FailedToCreateReport(Exception e);
        void FailedToOpenReportTemplate(Exception e);
        void FailedToReadJson(Exception e);
        void FailedToCallFunction(Exception e);
        void NecessaryParametersMissing(string errorMessage);
    }
}
