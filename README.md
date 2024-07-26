# DipolTestTask

Проект **DipolTestTask** включает автоматизированные тесты с использованием NUnit. 

## Установка и Запуск

1. Клонируйте репозиторий и перейдите в директорию проекта:

    ```sh
    git clone https://github.com/ваш-репозиторий/DipolTestTask.git
    cd DipolTestTask
    ```

2. Установите необходимые пакеты через NuGet:

    ```sh
    dotnet add package ExtentReports
    dotnet add package NUnit
    dotnet add package NUnit3TestAdapter
    ```

3. Запустите тесты:

    ```sh
    dotnet test
    ```


## Примеры

Пример теста с NUnit:

```csharp
[Test]
public void SampleTest()
{
    Assert.IsTrue(true);
}
