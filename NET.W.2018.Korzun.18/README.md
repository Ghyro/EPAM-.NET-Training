# Задание Day 18

## deadline 30.11.2017

В текстовом файле построчно хранится информация о URL-адресах, представленных в виде **< scheme >://< host >/<URL‐path>?< parameters >**, где сегмент parameters - это набор пар вида key=value, при этом сегменты URL‐path и parameters  или сегмент parameters могут отсутствовать. 
Разработать систему типов (руководствоваться принципами SOLID) для экспорта данных, полученных на основе разбора информации текстового файла, в XML-документ по следующему правилу, например, для текстового файла с URL-адресами:

    https://github.com/AnzhelikaKravchuk?tab=repositories 
    https://github.com/AnzhelikaKravchuk/2017-2018.MMF.BSU
    https://habrahabr.ru/company/it-grad/blog/341486/

результирующим является XML-документ вида (можно использовать любую XML технологию без ограничений).

Для тех URL-адресов, которые не совпадают с данным паттерном, “залогировать” информацию, отметив указанные строки, как необработанные. 
Продемонстрировать работу на примере консольного приложения.

Решение: [BLL, BLL.Interface, DAL, DAL.Interface](https://github.com/Ghyro/EPAM-.NET-Training/tree/master/NET.W.2018.Korzun.18/Task)

Тест: [Program.cs](https://github.com/Ghyro/EPAM-.NET-Training/blob/master/NET.W.2018.Korzun.18/Tests/Program.cs)

up: некоторые строки должным образом не обрабатываются!

