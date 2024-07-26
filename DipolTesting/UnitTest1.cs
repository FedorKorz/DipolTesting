using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.UIA3;
using NUnit.Framework;
using static DipolTesting.Utils;


namespace DipolTesting;

[TestFixture]
public class MyTests
{
    private static Process _process;
    private static Application _application;
    private static Window _mainWindow;
    private static TextBox _textBox;
    private static Button _button;
    private static Label _header;
    private static Label _errorTextBlock;


    [SetUp]
    public void SetUp()
    {
        const string appPath =
            "C:\\Users\\user\\RiderProjects\\DipolTestTask\\DipolTestTask\\bin\\Release\\net7.0\\DipolTestTask.exe";

        var automation = new UIA3Automation();

        if (!File.Exists(appPath))
            throw new FileNotFoundException($"Не удалось найти приложение по пути: {appPath}");

        Thread.Sleep(2000);

        _process = Process.Start(appPath);
        _application = Application.Attach(_process);

        _mainWindow = _application.GetMainWindow(automation);

        _textBox = _mainWindow.FindFirstDescendant(cf => cf.ByAutomationId("MyTextBox"))?.AsTextBox();
        _button = _mainWindow.FindFirstChild(cf => cf.ByAutomationId("MyButton"))?.As<Button>();
        _header = _mainWindow.FindFirstChild(cf => cf.ByAutomationId("MyHeader"))?.As<Label>();
        _errorTextBlock = _mainWindow.FindFirstChild(cf => cf.ByAutomationId("ErrorTextBlock"))?.As<Label>();
        if (_textBox == null || _button == null) throw new Exception("Не удалось найти элемент.");
        if (_process == null) throw new Exception("Не удалось запустить приложение.");
    }

    [Test]
    public void AreAllElementsVisible()
    {
        Assert.That(_header.IsAvailable, Is.True, "Заголовок не отображается");
        Assert.That(_mainWindow.IsAvailable, Is.True, "Главное окно не отображается");
        Assert.That(_textBox.IsAvailable, Is.True, "Текстовое поле не отображается");
        Assert.That(_button.IsAvailable, Is.True, "Кнопка смены цвета не отображается");
        Assert.That(_errorTextBlock.IsAvailable, Is.True, "Сообщение об ошибке отображается до активации");
    }


    [Test]
    public static void FirstTest()
    {

        _textBox.Text = "#123123";
        _button.Click();
        var locationX = _textBox.BoundingRectangle.Location.X;
        var locationY = _textBox.BoundingRectangle.Location.Y;
        Console.Write(locationX);
        Console.Write(locationY);
        
        var color = GetColorAt(locationX + 10, locationY + 10);
        Console.Write(color);
    
    }


    [TearDown]
    public void TearDown()
    {
        if (_process == null || _process.HasExited) return;
        _process.Kill();
        _process.Dispose();
    }
}