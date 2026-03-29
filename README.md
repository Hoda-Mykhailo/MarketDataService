# MarketDataService


The task was considered and the decision was made from the very beginning to build a project structure to make it easier to understand where and what is located, by creating folders with appropriate names and inside them there will already be classes and controllers, in general code. The next steps will be to prepare the classes for creating migrations through EF using the code-first method.

--

I performed a migration from code for two tables, price and asset. During the migration, there were some problems with the initialization of the migration and updating the database. At first, I thought about doing it right away on Doсker, but I did it on Sqlite. Just when I was doing it for docker, there were problems, maybe some obvious ones, but I played with migrations for a long time and could not finish it correctly. It was decided to simply implement the migration at least on something and then (if there is time), rewrite some code for docker, as I searched the Internet for an explanation, it may take quite a bit of time (+- 5 minutes). The next step will probably be to do the client part and services.

--

All other files (controllers, DTO, mapping) were added. After rebuilding the project, no errors occur, but there are errors when starting the program. The code cannot retrieve login data on the finance platform because there is no API key. Therefore, it throws a 401 error when running in the terminal. Further steps are just to fix this error.

--

In general, the code works, but of course not all the points that were relatively covered in the TK are fulfilled. The previous problem was that the resource with the currency and exchange rate did not have an API or it was hidden, because I did not find it there. Therefore, I decided to use a fake Token, I thought that it might help and remove the error in the terminal when the program is launched, in general it helped or I do not know whether this is the right step. Also, after analyzing the TK, I completely understood that the level of the test is somewhere in the middle)) (subjectively, my opinion), and here I understood why you warned about the complexity.

--

I did everything I could in the allotted time and on time. I hope this solution will suit you)) I would also be happy to receive feedback on the task if possible, which could help me in developing in .NET. Thanks.
