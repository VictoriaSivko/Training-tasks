1. В текстовом файле построчно хранится информация о URL-адресах, представленных в виде
&lt;scheme&gt;://&lt;host&gt;/&lt;URL‐path&gt;?&lt;parameters&gt;, где сегмент parameters - это набор пар вида key=value, при этом
сегменты URL‐path и parameters или сегмент parameters могут отсутствовать.
Разработать систему типов (руководствоваться принципами SOLID) для экспорта данных, полученных
на основе разбора информации текстового файла, в XML-документ по следующему правилу, например, для
текстового файла с URL-адресами

https://github.com/AnzhelikaKravchuk?tab=repositories
https://github.com/AnzhelikaKravchuk/2017-2018.MMF.BSU
https://habrahabr.ru/company/it-grad/blog/341486/

результирующим является XML-документ вида (можно использовать любую XML технологию без ограничений).

Для тех URL-адресов, которые не совпадают с данным паттерном, “залогировать” информацию, отметив
указанные строки, как необработанные.
Продемонстрировать работу на примере консольного приложения.

Задание
Рассмотреть специфику ссылочных (на примере класса) и значимых типов (на примере структуры),
используя SOS.dll (https://msdn.microsoft.com/en-us/library/bb190764%28v=vs.110%29.aspx), WinDbg и
Disassembly (VS) в контексте вызова экземплярных не виртуальных, виртуальных методов, унаследованных от
Object (переопределенных и не переопределенных), а также методов интерфейсов, таблицы методов, структуры
EEClass и т.д. Полезные материалы https://msdn.microsoft.com/ru-ru/library/dd335945.aspx и главы 2, 3 (TYPE
INTERNALS) книги .NET Performance.

Начать разбираться/знакомится с WEB!
- IIS and ASP.NET
- ASP.NET MVC 5
