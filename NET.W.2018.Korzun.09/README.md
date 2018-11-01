Задания
========

 1. Для объектов класса Book (ISBN, автор, название, издательство, год издания, количество страниц, цена) (домашнее задание 8-ого дня)
	1.1 реализовать возможность строкового представления различного вида. Например, для объекта со значениями ISBN = 978-0-7356-6745-7, AuthorName  = Jeffrey Richter, Title = CLR via C#, Publisher = Microsoft Press, Year = 2012, NumberOPpages = 826, Price = 59.99$, могут быть следующие варианты:
		- Jeffrey Richter, CLR via C#
		- JJeffrey Richter, CLR via C#, "Microsoft Press", 2012
		- JISBN 13: 978-0-7356-6745-7, Jeffrey Richter, CLR via C#, "Microsoft Press", 2012, P. 826.
		- JJeffrey Richter, CLR via C#, "Microsoft Press", 2012
		- JISBN 13: 978-0-7356-6745-7, Jeffrey Richter, CLR via C#, "Microsoft Press", 2012, P. 826., 59.99$.
		и т.д.

	Смотреть тут -> [Book.cs](https://github.com/Ghyro/EPAM-.NET-Training/blob/master/NET.W.2018.Korzun.08/Tasks/Task1/Entities/Book.cs)
	 
 2. Не изменяя класс Book, добавить для объектов данного класса дополнительную возможность форматирования, изначально не предусмотренную классом.

	Смотреть тут -> [CustomFormat.cs](https://github.com/Ghyro/EPAM-.NET-Training/blob/master/NET.W.2018.Korzun.08/Tasks/Task1/CustomFormatBook/CustomFormat.cs)

 3. Для реализованных в пп. 1, 2 функциональностей разработать модульные тесты.

 	Смотреть тут -> [BookTests.cs](https://github.com/Ghyro/EPAM-.NET-Training/blob/master/NET.W.2018.Korzun.08/BookNUnitTests/BookTests.cs)
 	
 4. Выполнить рефакторинг класса (с целью сокращения повторного кода) в алгоритмах Евклида (для рефакторинга использовать делегаты, рефакторинг возможен только в случае, когда все метод находятся в одном классе!). Интерфейс класса измениться не должен.

 	Смотреть тут -> [Task1_2.cs](https://github.com/Ghyro/EPAM-.NET-Training/blob/master/NET.W.2018.Korzun.03-04/Tasks/Task1_2/Task1_2.cs)

 	Тесты -> [Task1_2NTests.cs](https://github.com/Ghyro/EPAM-.NET-Training/blob/master/NET.W.2018.Korzun.03-04/TasksTests/Task1_2/Task1_2Tests.cs)

 5. В класс с алгоритмом сортировки не прямоугольной матрицы, принимающим как компаратор интерфейс IComparer<int[]> добавить метод, принимающий как параметр делегат-компаратор, инкапсулирующий логику сравнения строк матрицы. Протестировать работу разработанного метода на примере сортировки матрицы, используя прежние критерии сравнения. Класс реализовать двумя способами, «замкнув» в первом варианте реализацию метода сортировки с делегатом на метод с интерфейсом, во втором – наоборот.

