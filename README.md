# Json2Cdf

This is a tool to convert **Star Wars CCG Card JSON Database** files (.json) to **Star Wars CCG Holotable** format (.cdf).

It was written in [C# 14 / .NET 10.0](https://dotnet.microsoft.com/en-us/download).  I am an amateur C# programmer, so be kind.  :)

You can build and run it using the .NET CLI.

Before you do, place copies of these latest JSON files from the [swccgpc/swccg-card-json](https://github.com/swccgpc/swccg-card-json) repository into the **Json2Cdf** subfolder (alongside **Json2Cdf.csproj**):

- Dark.json
- DarkLegacy.json
- Light.json
- LightLegacy.json

Then run the dotnet restore, build and test commands in the terminal from the **Json2Cdf** subfolder:

```
PS C:\Users\ronhowe\repos\ronhowe\Json2Cdf\Json2Cdf> dotnet restore
Restore complete (1.3s)

Build succeeded in 1.7s
PS C:\Users\ronhowe\repos\ronhowe\Json2Cdf\Json2Cdf> dotnet build
Restore complete (0.6s)
  Json2Cdf net10.0 succeeded (4.5s) → bin\Debug\net10.0\Json2Cdf.dll

Build succeeded in 5.8s
PS C:\Users\ronhowe\repos\ronhowe\Json2Cdf\Json2Cdf> dotnet test --logger "console;verbosity=detailed" --filter "TestCategory=Integration"
Restore complete (0.5s)
  Json2Cdf net10.0 succeeded (0.4s) → bin\Debug\net10.0\Json2Cdf.dll
A total of 1 test files matched the specified pattern.
C:\Users\ronhowe\repos\ronhowe\Json2Cdf\Json2Cdf\bin\Debug\net10.0\Json2Cdf.dll
Test Parallelization enabled for C:\Users\ronhowe\repos\ronhowe\Json2Cdf\Json2Cdf\bin\Debug\net10.0\Json2Cdf.dll (Workers: 16, Scope: MethodLevel)
Test Parallelization enabled for C:\Users\ronhowe\repos\ronhowe\Json2Cdf\Json2Cdf\bin\Debug\net10.0\Json2Cdf.dll (Workers: 16, Scope: MethodLevel)
  Passed Main ("Light.json","LightLegacy.json","lightside.cdf","reb.gif") [334 ms]
  Standard Output Messages:


 Debug Trace:
 ********************************************************************************
 https://github.com/ronhowe
 ********************************************************************************
 2026-02-12 17:40:40.666 (LOCAL)
 2026-02-12 22:40:40.670 (UTC)
 Initializing Test
 Reading C:\Users\ronhowe\repos\ronhowe\Json2Cdf\Json2Cdf\bin\Debug\net10.0\Light.json
 Reading C:\Users\ronhowe\repos\ronhowe\Json2Cdf\Json2Cdf\bin\Debug\net10.0\LightLegacy.json
 Writing C:\Users\ronhowe\repos\ronhowe\Json2Cdf\Json2Cdf\bin\Debug\net10.0\lightside.cdf
 Cleaning Test


  Passed Main ("Dark.json","DarkLegacy.json","darkside.cdf","imp.gif") [332 ms]
  Standard Output Messages:


 Debug Trace:
 ********************************************************************************
 https://github.com/ronhowe
 ********************************************************************************
 2026-02-12 17:40:40.666 (LOCAL)
 2026-02-12 22:40:40.670 (UTC)
 Initializing Test
 Reading C:\Users\ronhowe\repos\ronhowe\Json2Cdf\Json2Cdf\bin\Debug\net10.0\Dark.json
 Reading C:\Users\ronhowe\repos\ronhowe\Json2Cdf\Json2Cdf\bin\Debug\net10.0\DarkLegacy.json
 Writing C:\Users\ronhowe\repos\ronhowe\Json2Cdf\Json2Cdf\bin\Debug\net10.0\darkside.cdf
 Cleaning Test



Test Run Successful.
Total tests: 2
     Passed: 2
 Total time: 1.2022 Seconds
  Json2Cdf test net10.0 succeeded (1.8s)

Test summary: total: 2, failed: 0, succeeded: 2, skipped: 0, duration: 1.8s
Build succeeded in 3.3s
PS C:\Users\ronhowe\repos\ronhowe\Json2Cdf\Json2Cdf>
```

After running the tests, you should find the generated CDF files in the build folder (e.g., **bin\Debug\net10.0**).

The log output from the test run will also show the paths to the generated CDF files.

You can copy these files to your Holotable installation folder for use with the game or submit them to the [swccgpc/holotable](https://github.com/swccgpc/holotable) repository.
