namespace DipolTesting;
using System;
using System.IO;

public static class UtilsCreateLogs
{
    public static void Init(string data)
    {
        var filePath = "C:\\Users\\user\\RiderProjects\\DipolTesting\\DipolTesting\\Output\\logs.txt";

        try
        {
            using (var sw = new StreamWriter(filePath))
            {
                sw.WriteLine(data);
                sw.Close();
            }
        }
        catch (Exception e)
        {
           
        }
    }
}