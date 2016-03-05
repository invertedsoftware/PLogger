# PLogger
PLogger is a light, fast file appender and database logger build using a parallel pipeline architecture.

To use this logger you need to do is either add the class to your code or use the DLL as a reference. If you chose to use the dll you need to import it in your code as follows: 

using InvertedSoftware.PLogger;
Then to write a log line you simply need to call:

Plogger.Log("My Message");
Nuget Package: https://www.nuget.org/packages/Inverted.Software.Utilities.PLogger
