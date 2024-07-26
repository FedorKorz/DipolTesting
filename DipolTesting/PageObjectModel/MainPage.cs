using System;
using System.Diagnostics;
using System.Drawing;
using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.UIA3;

namespace DipolTesting.PageObjectModel;

using static Utils;

public class MainPage
{
    private static TextBox _textBox;
    private static Button _button;
    private static Label _header;
    private static Label _errorTextBlock;


    public MainPage(UIA3Automation automation, Application app, Process process)
    {
        var mainWindow = app.GetMainWindow(automation);
        _textBox = mainWindow.FindFirstDescendant(cf => cf.ByAutomationId("MyTextBox"))?.AsTextBox();
        _button = mainWindow.FindFirstDescendant(cf => cf.ByAutomationId("MyButton"))?.AsButton();
        _header = mainWindow.FindFirstChild(cf => cf.ByAutomationId("MyHeader"))?.As<Label>();
        _errorTextBlock = mainWindow.FindFirstChild(cf => cf.ByAutomationId("ErrorTextBlock"))?.As<Label>();
    }


    public bool IsTextBoxVisisble()
    {
        return _textBox.IsAvailable;
    }

    public bool IsButtonVisisable()
    {
        return _button.IsAvailable;
    }

    public bool IsHeadervisible()
    {
        return _header.IsAvailable;
    }

    public bool IsErrorVisible()
    {
        return _errorTextBlock.IsAvailable;
    }

    public void ClickButton()
    {
        _button.Click();
    }

    public string GetTexFromTextBox()
    {
        return _textBox.Text;
    }

    public void InsertTextToTextBox(string codeColor)
    {
        _textBox.Text = codeColor;
    }

    public Color GetTextBlockColor()
    {
        const int offsetFromBorder = 10;

        var locationX = _textBox.BoundingRectangle.Location.X;
        var locationY = _textBox.BoundingRectangle.Location.Y;
        return GetColorAt(locationX + offsetFromBorder, locationY + offsetFromBorder);
    }

    public string GetErrorMsg()
    {
        return _errorTextBlock.Text;
    }
}