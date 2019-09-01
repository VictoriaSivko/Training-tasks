1. For objects of the Book class (ISBN, author, title, publisher, year of publication,
number of pages, price) to implement the possibility of string representation of different types.
For example, for an object with values ISBN = 978-0-7356-6745-7, AuthorName
= Jeffrey Richter, Title = CLR via C#, Publisher = Microsoft Press, Year = 2012,
NumberOPpages = 826, Price = 59.99$, there may be the following options:
- Jeffrey Richter, CLR via C#
- Jeffrey Richter, CLR via C#, &quot;Microsoft Press&quot;, 2012
- ISBN 13: 978-0-7356-6745-7, Jeffrey Richter, CLR via C#, &quot;Microsoft Press&quot;,
2012, P. 826.
- Jeffrey Richter, CLR via C#, &quot;Microsoft Press&quot;, 2012
- ISBN 13: 978-0-7356-6745-7, Jeffrey Richter, CLR via C#, &quot;Microsoft Press&quot;,
2012, P. 826., 59.99$.
etc.

2. Without changing the Book class, add additional formatting, initially not foreseen in the class.

3. For implemented in tasks 1, 2 functionality to develop unit tests.

4. Refactoring of the class (with the goal of reducing repeated code) algorithms
Euclid (to use delegates for refactoring, refactoring is possible only in
the case when all the method are in the same class!). Class interface does not change
must.

5. In a class with a non-rectangular matrix sorting algorithm taking as
comparator interface IComparer<int[]> add method taking as parameter
delegate-the comparator encapsulates logic string comparison matrix.
To test the work of the developed method on the example of matrix sorting,
using the old comparison criteria. The class is implemented in two ways,
"closing" in the first embodiment, the implementation of the sorting method with a delegate to the method C
in the second – on the contrary.
