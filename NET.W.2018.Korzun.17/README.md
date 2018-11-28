# Задолженности ExtTraining.Autumn.2018.3

1. ***Исправленое задание.*** Дана система типов (проект No1) для верификации пароля согласно некоторым фиксированным правилам и его сохранения, в случае валидности, в хранилище. Какие проблемы возникнут при использовании данного кода, если множество клиентов класса PasswordCheckerService захотят его использовать для различных комбинаций условий валидации (существующих и новых), используя при этом различные хранилища? Выполнить рефакторинг данного кода, устранив обнаруженную проблему (решение поместить в проект No1.Solution). Проверить работу новой системы типов с помощью модульных тестов (в качестве тест-кейсов использовать указанные и новые условия), тесты поместить в проект No1.Tests. Кратко описать предложенное решение.
    
    Решение: [Checkers, Interfaces, Service](https://github.com/Ghyro/EPAM-.NET-Training/tree/master/NET.W.2018.Korzun.17/No1.Solution)
    
    Тесты: [Program.cs](https://github.com/Ghyro/EPAM-.NET-Training/tree/master/NET.W.2018.Korzun.17/No1.Solution.Console)

2. Разработана система типов (проект No3) для расчета различных вариантов среднего арифметического значения для набора вещественных чисел. Выполнить изменения кода с учетом возможности изменения/дополнения алгоритма подсчета среднего значения (решение поместить в проект No3.Solution), проверить работу новой системы типов для тестов из проекта No3.Solution.Tests (unit-тесты изменить для работы с новой системой типов). Предложить, различные варианты (как минимум, два) решения данной задачи. Кратко описать предложенные решения.

    Решение: [Calculate (two options), Ways (two ways), Interface](https://github.com/Ghyro/EPAM-.NET-Training/tree/master/NET.W.2018.Korzun.17/No3.Solution)

    Тесты: 1. [Calculate (basic)](https://github.com/Ghyro/EPAM-.NET-Training/blob/master/NET.W.2018.Korzun.17/No3.Solution.Tests/CalculateTests.cs)
           2. [Calculate (via delegate)](https://github.com/Ghyro/EPAM-.NET-Training/blob/master/NET.W.2018.Korzun.17/No3.Solution.Tests/CalculateDelegateTests.cs)

3. Разработана система типов (проект No5) для описания документа - класс Document, состоящего из различного вида частей документа DocumentPart - BoldText, Hyperlink, PlainText (3 типа представлено только для краткости примера), части документа могут быть получены как часть API класса Document (если есть такая необходимость). Какие проблемы возникнут при использовании данного кода, если часто будет возникать необходимость добавления конвертирования документа в новый формат (например, обычный текст, html, LaTeX и т.д.)? Пересмотреть реализацию типов, устранив обнаруженную проблему (решение поместить в проект No5.Solution), проверить работу новой системы типов в консоли (проект No5.Solution.Console). Кратко описать предложенное решение.

    Решение: [Converters, Parts, other files](https://github.com/Ghyro/EPAM-.NET-Training/tree/master/NET.W.2018.Korzun.17/No5.Solution)
    
    Тесты: [Program.cs](https://github.com/Ghyro/EPAM-.NET-Training/blob/master/NET.W.2018.Korzun.17/No5.Solution.Console/Program.cs)
 
4. Реализовать (решение поместить в проект No6.Solution) обобщенный генератор n-первых членов последовательности, заданной рекуррентной формулой для элементов типа T по правилу

        x(1) = a, x(2) = b, x(n + 1) = f(x(n), x(n - 1)), n = 2, 3, ...  
    
    Проверить работу построенного генератора (проект No6.Solution.Tests) на примере следующих последовательностей.

        1) x(1) = 1, x(2) = 1, x(n + 1) = x(n) +  x(n - 1), n = 2, 3, ... T - целочисленный тип;
        2) x(1) = 1, x(2) = 2, x(n + 1) = 6 * x(n) - 8 * x(n - 1), n = 2, 3, ... T - целочисленный тип;
        3) x(1) = 1, x(2) = 2, x(n + 1) = x(n) +  x(n - 1) / x(n), n = 2, 3, ... T - вещественный тип.

    Решение: [Generator.cs](https://github.com/Ghyro/EPAM-.NET-Training/blob/master/NET.W.2018.Korzun.17/No6.Solution/Generator.cs)

    Тесты: [GeneratorTests.cs](https://github.com/Ghyro/EPAM-.NET-Training/blob/master/NET.W.2018.Korzun.17/No6.Solution.Tests/GeneratorTests.cs) // there're some questions in tests