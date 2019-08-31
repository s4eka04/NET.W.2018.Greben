##### 1. For objects of class Book (ISBN, author, title, publisher, year of publication, number of pages, price) (homework of the 8th day)
+ реализовать возможность строкового представления различного вида.
Например, для объекта со значениями ISBN = 978-0-7356-6745-7, AuthorName
= Jeffrey Richter, Title = CLR via C#, Publisher = Microsoft Press, Year = 2012,
NumberOPpages = 826, Price = 59.99$, могут быть следующие варианты:
  * Jeffrey Richter, CLR via C#
  * Jeffrey Richter, CLR via C#, &quot;Microsoft Press&quot;, 2012
  * ISBN 13: 978-0-7356-6745-7, Jeffrey Richter, CLR via C#, &quot;Microsoft Press&quot;,
  2012, P. 826.
  * Jeffrey Richter, CLR via C#, &quot;Microsoft Press&quot;, 2012
  * ISBN 13: 978-0-7356-6745-7, Jeffrey Richter, CLR via C#, &quot;Microsoft Press&quot;,
  2012, P. 826., 59.99$.
  *etc.
  
##### 2. Without changing the Book class, add additional objects for this class formatting capability not originally provided by the class.

##### 3. For implemented in paragraphs. 1, 2 functionalities to develop unit tests. 
##### 4. Perform class refactoring (in order to reduce repeated code) in the algorithms Euclid (use delegates for refactoring, refactoring is possible only in case when all the methods are in the same class!). Class interface do not change should.

##### 5. To a class with a non-rectangular matrix sorting algorithm that takes as comparator interface IComparer<int[]>; add method taking as parameter delegate comparator encapsulating matrix row comparison logic. Test the work of the developed method using the example of matrix sorting, using the old comparison criteria. There are two ways to implement a class, "Locking" in the first embodiment, the implementation of the sorting method with a delegate to a method with interface, in the second - vice versa.
