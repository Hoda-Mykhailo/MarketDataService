# MarketDataService

The task was considered and the decision was made from the very beginning to build a project structure to make it easier to understand where and what is located, by creating folders with appropriate names and inside them there will already be classes and controllers, in general code. The next steps will be to prepare the classes for creating migrations through EF using the code-first method.
--
I performed a migration from code for two tables, price and asset. During the migration, there were some problems with the initialization of the migration and updating the database. At first, I thought about doing it right away on Doсker, but I did it on Sqlite. Just when I was doing it for docker, there were problems, maybe some obvious ones, but I played with migrations for a long time and could not finish it correctly. It was decided to simply implement the migration at least on something and then (if there is time), rewrite some code for docker, as I searched the Internet for an explanation, it may take quite a bit of time (+- 5 minutes). The next step will probably be to do the client part and services.
--
