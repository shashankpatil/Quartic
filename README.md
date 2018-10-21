"# Quartic" 

Pre-requiste: microsoft/dotnet:2.0-sdk https://download.visualstudio.microsoft.com/download/pr/7010cdb4-ae43-408b-8c9f-5f94101a1c70/3e1ae56a072c7c397f10278d7643b3e9/dotnet-sdk-2.1.403-win-gs-x64.exe
Procedure to run: Go to the project path .\Quartic\RulesEngine\RulesEngine dotnet build -- debug dotnet run Check voilations at .\Quartic\RulesEngine\RulesEngine\VolidatedSource.txt

Briefly describe the conceptual approach you chose! What are the trade-offs?

Spent 5 hours for solving the problem
I am reading the whole raw_data.json file in-memory and processing each single signal in parallel. So, performance also depends on the core present in the OS.
Parallel programming using blockingcollection thread-safe for contious signal processing.
Each signal is being characterized into three data types and using dependency injection validating the signal.
I am writing the output to the text file i.e. ValidatedSource.txt.
Further check resource files in properties.
Compromise made on the unity container which would have made single instance for each class which is reuired.
What's the runtime performance? What is the complexity? Where are the bottlenecks?

As I am using TPL of .NET Core so performance of runtime is better. But taken more time then would have provided the performance matrix with the problem statement
Complexity - Reading the whole json file in-memory takes less time + depending on number of signals and os core present the application runs faster
bottlenecks - understanding the .net core concept for the deployment in any machine/OS.
If you had more time, what improvements would you make, and in what order of priority?

I would have added the value and the max value to the output file
I am Reading the whole file at a time. I would have taken an approach to read single data ata a time and get the poutput parallelly.
I would have customized the problem with more different approach.
Logger is not added to the problem statement which makes difficult where the program broke.
Running this in docker container, tried but was failing due to some credential issues, check the dockerfile.
