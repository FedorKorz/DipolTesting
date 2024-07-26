using System;
using System.Diagnostics;
using System.Threading;
using DipolTesting.PageObjectModel;
using FlaUI.Core;
using FlaUI.UIA3;
using NUnit.Framework;
using static DipolTesting.Utils;

namespace DipolTesting;

[TestFixture]
public class MyTests
{
    
    private Process _process;
    private Application _application;
    private MainPage _mainPage;


    [SetUp]
    public void SetUp()
    {
        var automation = new UIA3Automation();

        Thread.Sleep(2000);

        var driver = new Driver();
        _application = driver.GetApp();
        _process = driver.GetProcess();

        if (_process == null) throw new Exception("Не удалось запустить приложение.");

        _mainPage = new MainPage(automation, _application, _process);
    }

    
    [TearDown]
    public void TearDown()
    {
        if (_process == null || _process.HasExited) return;
        _process.Kill();
        _process.Dispose();
    }
    

    [Test, Category("Positive")]
    public void AreAllElementsVisible()
    {
        
        Assert.That(_mainPage.IsHeadervisible(), Is.True, "Заголовок не отображается");
        Assert.That(_mainPage.IsTextBoxVisisble(), Is.True, "Текстовое поле не отображается");
        Assert.That(_mainPage.IsButtonVisisable(), Is.True, "Кнопка смены цвета не отображается");
        Assert.That(_mainPage.IsErrorVisible(), Is.True, "Сообщение об ошибке отображается до активации");
    }


    [Test, Category("Positive")]
    [TestCase("#000000")]
    [TestCase("#FFFFFF")]
    [TestCase("#ABCDEF")]
    public void TestInputTextIsCorrect(string codeColor)
    {
        _mainPage.InsertTextToTextBox(codeColor);
        Assert.That(_mainPage.GetTexFromTextBox(), Is.Not.Null, "В текстовом полне не отображается текст");
        Assert.That(_mainPage.GetTexFromTextBox(), Is.EqualTo(codeColor),
            "Текстовое поле отображает неверное значение");
    }


    [Test, Category("Positive")]
    [TestCase("#ABCDEF")]
    [TestCase("#000000")]
    [TestCase("#FFFFFF")]
    [TestCase("#880808")]
    public void TestThatColorIsMatch(string codeColor)
    {
        _mainPage.InsertTextToTextBox(codeColor);
        _mainPage.ClickButton();
        Assert.That(ArgbToHex(_mainPage.GetTextBlockColor()), Is.EqualTo(codeColor));
    }
    
    [Test, Category("Negative")]
    [TestCase("-1")]
    [TestCase("ZZZZZZ")]
    [TestCase("000000")]
    [TestCase("@")]
    public void TestErrorMsgIsPresent(string codeColor)
    {
        _mainPage.InsertTextToTextBox(codeColor);
        _mainPage.ClickButton();
        Assert.That(_mainPage.GetErrorMsg(), Is.EqualTo("Неверный цветовой код. Используйте #RRGGBB формат."), "Неверно отображается сообщение об ошибке");

    }
}


//TODO 
// 1. Разобраться ожиданиями, избавиться от Thread.sleep()