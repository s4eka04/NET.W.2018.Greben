#### Develop a type system to describe work with a bank account. The status of the account is determined by its number, information about the account holder (name, last name), the amount on the account and some bonus points that increase / decrease each time when replenishing the account / debiting from the account to different values for replenishment and write-offs and calculated depending on some values ​​of the “cost” of the balance sheet and the “cost” of replenishment. The values of the “value” of the balance sheet and the “cost” of replenishment are integer values and depend on the type of account, which can be, for example, Base, Gold, Platinum. To work with the account, implement the following features: 
+ ### make a deposit to the account;
+ ### execute debiting from the account;
+ ### create a new account;
+ ### close an account.
#### To store account information, you can use fake implementation repository (repository) as a wrapper class for the List<Account\>  collection. Demonstrate the operation of classes using the example of a console application. When designing types, consider the following options. functionality extensions / changes
+ ### adding new types of accounts;
+ ### change / add sources of storage of information about accounts;
+ ### change the logic for calculating bonus points;
+ ### changing the logic for generating the account number.
#### To organize classes and interfaces use “The Stairway pattern”
#### To resolve dependencies, use the Ninject framework.
#### Test the Bll layer (NUnit and Moq frameworks).
