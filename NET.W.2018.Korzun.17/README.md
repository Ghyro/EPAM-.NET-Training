# ������������� ExtTraining.Autumn.2018.3

1. ***����������� �������.*** ���� ������� ����� (������ No1) ��� ����������� ������ �������� ��������� ������������� �������� � ��� ����������, � ������ ����������, � ���������. ����� �������� ��������� ��� ������������� ������� ����, ���� ��������� �������� ������ PasswordCheckerService ������� ��� ������������ ��� ��������� ���������� ������� ��������� (������������ � �����), ��������� ��� ���� ��������� ���������? ��������� ����������� ������� ����, �������� ������������ �������� (������� ��������� � ������ No1.Solution). ��������� ������ ����� ������� ����� � ������� ��������� ������ (� �������� ����-������ ������������ ��������� � ����� �������), ����� ��������� � ������ No1.Tests. ������ ������� ������������ �������.
    
    �������: [Checkers, Interfaces, Service](https://github.com/Ghyro/EPAM-.NET-Training/tree/master/NET.W.2018.Korzun.17/No1.Solution)
    
    �����: [Program.cs](https://github.com/Ghyro/EPAM-.NET-Training/tree/master/NET.W.2018.Korzun.17/No1.Solution.Console)

2. ����������� ������� ����� (������ No3) ��� ������� ��������� ��������� �������� ��������������� �������� ��� ������ ������������ �����. ��������� ��������� ���� � ������ ����������� ���������/���������� ��������� �������� �������� �������� (������� ��������� � ������ No3.Solution), ��������� ������ ����� ������� ����� ��� ������ �� ������� No3.Solution.Tests (unit-����� �������� ��� ������ � ����� �������� �����). ����������, ��������� �������� (��� �������, ���) ������� ������ ������. ������ ������� ������������ �������.

    �������: [Calculate (two options), Ways (two ways), Interface](https://github.com/Ghyro/EPAM-.NET-Training/tree/master/NET.W.2018.Korzun.17/No3.Solution)

    �����: 1. [Calculate (basic)](https://github.com/Ghyro/EPAM-.NET-Training/blob/master/NET.W.2018.Korzun.17/No3.Solution.Tests/CalculateTests.cs)
           2. [Calculate (via delegate)](https://github.com/Ghyro/EPAM-.NET-Training/blob/master/NET.W.2018.Korzun.17/No3.Solution.Tests/CalculateDelegateTests.cs)

3. ����������� ������� ����� (������ No5) ��� �������� ��������� - ����� Document, ���������� �� ���������� ���� ������ ��������� DocumentPart - BoldText, Hyperlink, PlainText (3 ���� ������������ ������ ��� ��������� �������), ����� ��������� ����� ���� �������� ��� ����� API ������ Document (���� ���� ����� �������������). ����� �������� ��������� ��� ������������� ������� ����, ���� ����� ����� ��������� ������������� ���������� ��������������� ��������� � ����� ������ (��������, ������� �����, html, LaTeX � �.�.)? ������������ ���������� �����, �������� ������������ �������� (������� ��������� � ������ No5.Solution), ��������� ������ ����� ������� ����� � ������� (������ No5.Solution.Console). ������ ������� ������������ �������.

    �������: [Converters, Parts, other files](https://github.com/Ghyro/EPAM-.NET-Training/tree/master/NET.W.2018.Korzun.17/No5.Solution)
    
    �����: [Program.cs](https://github.com/Ghyro/EPAM-.NET-Training/blob/master/NET.W.2018.Korzun.17/No5.Solution.Console/Program.cs)
 
4. ����������� (������� ��������� � ������ No6.Solution) ���������� ��������� n-������ ������ ������������������, �������� ������������ �������� ��� ��������� ���� T �� �������

        x(1) = a, x(2) = b, x(n + 1) = f(x(n), x(n - 1)), n = 2, 3, ...  
    
    ��������� ������ ������������ ���������� (������ No6.Solution.Tests) �� ������� ��������� �������������������.

        1) x(1) = 1, x(2) = 1, x(n + 1) = x(n) +  x(n - 1), n = 2, 3, ... T - ������������� ���;
        2) x(1) = 1, x(2) = 2, x(n + 1) = 6 * x(n) - 8 * x(n - 1), n = 2, 3, ... T - ������������� ���;
        3) x(1) = 1, x(2) = 2, x(n + 1) = x(n) +  x(n - 1) / x(n), n = 2, 3, ... T - ������������ ���.

    �������: [Generator.cs](https://github.com/Ghyro/EPAM-.NET-Training/blob/master/NET.W.2018.Korzun.17/No6.Solution/Generator.cs)

    �����: [GeneratorTests.cs](https://github.com/Ghyro/EPAM-.NET-Training/blob/master/NET.W.2018.Korzun.17/No6.Solution.Tests/GeneratorTests.cs) // there're some questions in tests