# MatrixMultiplication
Verification of time complexity of Matrix Multiplication (Divide and conquer algorithm / the Strassen's algorithm)

1.Problem Statement
Matrix multiplication is a binary operation that produces a matrix from two matrices with entries in a field. Given A is an m × p matrix and B is an p × n matrix, their matrix product AB is an m × n matrix.  
 

2.Implementation Characteristics
(1)We assume that A and B are square matrices of size 2^n and set all missing rows and columns as 0.
(2) We divided A into 4 equally sized sub-matrices and partition B in the same way. 
(3) Then  C_1，1 〖=A〗_1，1 B_1，1 + A_1，2 B_2，1	C_1，2 〖=A〗_1，1 B_1，2 + A_1，2 B_2，2
C_2，1 〖=A〗_2，1 B_1，1 + A_2，2 B_1，1	C_2，2 〖=A〗_2，1 B_1，2 + A_2，2 B_2，2
We can compute 7 intermediate produces to get 4 sub-C matrices.
(4)We compute these M intermediate produces in the same way.

3.Time complexity
The we can write the time complexity as T(n)= 7T(n/2) + c n^2, based on Master theorem, it is O(n^log2 7) = O(n^2.81)
