# «адолженности

1. –азработана система типов (проект No3) дл€ расчета различных вариантов среднего арифметического значени€ дл€ набора вещественных чисел. ¬ыполнить изменени€ кода с учетом возможности изменени€/дополнени€ алгоритма подсчета среднего значени€ (решение поместить в проект No3.Solution), проверить работу новой системы типов дл€ тестов из проекта No3.Solution.Tests (unit-тесты изменить дл€ работы с новой системой типов). ѕредложить, различные варианты (как минимум, два) решени€ данной задачи.  ратко описать предложенные решени€.

    –ешение: [Calculate (two options), Ways (two ways), Interface](https://github.com/Ghyro/EPAM-.NET-Training/tree/master/DebtsTraining/No3.Solution)

    “есты: 1. [Calculate (basic)](https://github.com/Ghyro/EPAM-.NET-Training/blob/master/DebtsTraining/No3.Solution.Tests/CalculateTests.cs)
           2. [Calculate (via delegate)](https://github.com/Ghyro/EPAM-.NET-Training/blob/master/DebtsTraining/No3.Solution.Tests/CalculateDelegateTests.cs)

2. –еализовать (решение поместить в проект No6.Solution) обобщенный генератор n-первых членов последовательности, заданной рекуррентной формулой дл€ элементов типа T по правилу

        x(1) = a, x(2) = b, x(n + 1) = f(x(n), x(n - 1)), n = 2, 3, ...  
    
    ѕроверить работу построенного генератора (проект No6.Solution.Tests) на примере следующих последовательностей.

        1) x(1) = 1, x(2) = 1, x(n + 1) = x(n) +  x(n - 1), n = 2, 3, ... T - целочисленный тип;
        2) x(1) = 1, x(2) = 2, x(n + 1) = 6 * x(n) - 8 * x(n - 1), n = 2, 3, ... T - целочисленный тип;
        3) x(1) = 1, x(2) = 2, x(n + 1) = x(n) +  x(n - 1) / x(n), n = 2, 3, ... T - вещественный тип.

    –ешение: [Generator.cs](https://github.com/Ghyro/EPAM-.NET-Training/blob/master/DebtsTraining/No6.Solution/Generator.cs)

    “есты: [GeneratorTests.cs](https://github.com/Ghyro/EPAM-.NET-Training/blob/master/DebtsTraining/No6.Solution.Tests/GeneratorTests.cs) // there're some questions in tests
 