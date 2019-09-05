### I didn’t write tests for the second task because I didn’t know how to check matrices in tests, there were also console applications in the first task

#### 1. Develop a generic Queue collection class that implements the core operations for working with the queue, and the opportunity iteration by implementing the iterator "manually" (without using iterator output). Test the methods of the developed class. 

#### 2.Create generic classes to represent square, symmetric, and diagonal matrices (a symmetric matrix is a square matrix, which coincides with the transposed to it; the diagonal matrix is a square matrix whose elements outside the main diagonal are known to be have default values for the item type). Describe in created classes event that occurs when a matrix element with indices (i,j). Extend the functionality of the existing class hierarchy by adding the ability to add two matrices of any type. Develop unit- tests.

#### 3.Develop a generic collection class BinarySearchTree (binary tree search). Provide connectivity options interface for implementing order relationships. Implement three ways tree traversal: forward (preorder), transverse (inorder), reverse (postorder): to implement use a block iterator (yield). To test designed class using the following types:
+ ####  System.Int32 (use default comparison and pluggablecomparator);
+ ####  System.String (use default comparison and pluggable comparator);
+ ####  custom class Book, for objects of which it is implemented order relationships (use default comparison and pluggable comparator);
+ ####  Custom Point structure for which objects are not implemented relations of order (use a plug-in comparator)
