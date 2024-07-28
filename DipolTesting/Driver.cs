using System;
using System.Diagnostics;
using System.IO;
using DipolTesting.Logger;
using FlaUI.Core;

namespace DipolTesting;

public class Driver
{
    private readonly Application _application;
    private readonly Process _process;


    public Driver(ILogger logger)
    {
        var currentDirectory = Directory.GetCurrentDirectory();

        var appRelativePath = "../../../App/DipolTestTask.exe";
        var appFullPath = Path.GetFullPath(Path.Combine(currentDirectory, appRelativePath));


        if (!File.Exists(appFullPath))
        {
            logger.FailedToCallFunction(new FileNotFoundException());
            throw new FileNotFoundException($"Не удалось найти приложение по пути: {appFullPath}");
        }
           

        _process = Process.Start(appFullPath);
        
        if (_process == null)
        {
            var processStartException = new InvalidOperationException("Не удалось запустить процесс.");
            logger.FailedToCallFunction(processStartException);
            throw processStartException;
        }
        
        _application = Application.Attach(_process);

        if (_application != null) return;
        var applicationAttachException = new InvalidOperationException("Не удалось прикрепиться к приложению.");
        logger.FailedToCallFunction(applicationAttachException);
        throw applicationAttachException;

        
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