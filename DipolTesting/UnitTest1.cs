using System;
using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.UIA3;
using System.Diagnostics;
using NUnit.Framework;
using static DipolTesting.Utils;


[TestFixture]
public class MyTests
{
    private static Process _process;
    
    [SetUp]
    public void SetUp()
    {
        _process =
            Process.Start(
                "C:\\Users\\user\\RiderProjects\\DipolTestTask\\DipolTestTask\\bin\\Release\\net7.0\\DipolTestTask.exe");
        if (_process == null) throw new Exception("Не удалось запустить приложение.");

        System.Threading.Thread.Sleep(2000);
    }


    [Test]
    public static void FirstTest()
    {
        using (var automation = new UIA3Automation())
        {
            var app = Application.Attach(_process.Id);
            var mainWindow = app.GetMainWindow(automation);

            var textBox = mainWindow
                .FindFirstDescendant(cf => cf.ByControlType(FlaUI.Core.Definitions.ControlType.Edit)).AsTextBox();
            var button = mainWindow.FindFirstChild(cf => cf.ByAutomationId("MyButton"));

            if (textBox != null)
            {
                button.Click();
                var locationX = textBox.BoundingRectangle.Location.X;
                var locationY = textBox.BoundingRectangle.Location.Y;
                Console.Write(locationX);
                Console.Write(locationY);


                var color = GetColorAt(locationX + 10, locationY + 10);

                Console.Write(color);
            }
            else
            {
                Console.WriteLine("TextBox не найден.");
            }
        }
    }


    [TearDown]
    public void TearDown()
    {
        if (_process == null || _process.HasExited) return;
        _process.Kill();
        _process.Dispose();
    }

}