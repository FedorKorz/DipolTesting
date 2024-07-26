using System.Diagnostics;
using System.IO;
using FlaUI.Core;

namespace DipolTesting;

public class Driver
{
    private readonly Application _application;
    private readonly Process _process;


    public Driver()
    {
        var currentDirectory = Directory.GetCurrentDirectory();

        var appRelativePath = "../../../App/DipolTestTask.exe";
        var appFullPath = Path.GetFullPath(Path.Combine(currentDirectory, appRelativePath));


        if (!File.Exists(appFullPath))
            throw new FileNotFoundException($"Не удалось найти приложение по пути: {appFullPath}");

        _process = Process.Start(appFullPath);
        _application = Application.Attach(_process);
    }

    public Application GetApp()
    {
        return _application;
    }

    public Process GetProcess()
    {
        return _process;
    }
}