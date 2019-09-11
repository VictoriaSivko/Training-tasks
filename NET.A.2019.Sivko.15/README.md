Develop a type system to describe how to work with a Bank account.
The status of the account is determined by its number, account holder (name,
last name), the balance in the account and some bonus points that
increase/decrease each time you Deposit/withdraw from the account to
the values are different for replenishment and write-off and are calculated depending on
some values of the "cost" of the balance and the "cost" of replenishment.
The values of the" cost "of the balance and the" cost " of replenishment are integer
values and depend on the type of account, which can be, for example, Base, Gold,
Platinum.
To work with the account, implement the following features:
- make a Deposit to your account;
- perform a debit from the account;
- create new account;
- close an account.
Fake implementation can be used to store account information
repository (storage) as a wrapper class for the List<Account> collection.
  
The classes must be demonstrated in a console application.

Consider the following options when designing types
expansion/functionality changes
- adding new account types;
- change / add sources for storing account information;
- change the logic of calculating bonus points;
- change the logic of account number generation.

Use "The Stairway pattern" to organize classes and interfaces”
(“blank” in the archive AccountSystemDemo.7z).
To resolve dependencies, use the Ninject framework.
Test the Bll layer (NUnit and Moq frameworks).
