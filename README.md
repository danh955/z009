**_Archived_** . . . Will try another day.

# z009 - Blazor 2D multi user war game

Okay, it was interesting trying to figure out how to get a session going in Blazor.  More like how to identify a game player based on there browser.   I ended up using LocalStorage to identify the user based on the browser.  Then used SessionStorage to track the user as a game player in a browser tab.

### Using

- [Visual Studio v16.8](https://visualstudio.microsoft.com/vs/preview)
- [.NET 5.0](https://dotnet.microsoft.com/download/dotnet/5.0)
- [Pure.css](https://purecss.io/)

### NuGet

- [Blazored.LocalStorage](https://www.nuget.org/packages/Blazored.LocalStorage)
- [Blazored.SessionStorage](https://www.nuget.org/packages/Blazored.SessionStorage)
- [Microsoft.Extensions.DependencyInjection.Abstractions](https://www.nuget.org/packages/Microsoft.Extensions.DependencyInjection.Abstractions)
- [StyleCop.Analyzers](https://www.nuget.org/packages/StyleCop.Analyzers)
- [Microsoft.CodeAnalysis.NetAnalyzers](https://www.nuget.org/packages/Microsoft.CodeAnalysis.NetAnalyzers)

### Visual Studio Settings

- Tools > Options > Text Editor > C# > Advanced > Place 'System' directives first when sorting using = Checked.

### Visual Studio Extensions

- [CodeMaid](https://marketplace.visualstudio.com/items?itemName=SteveCadwallader.CodeMaid)
- [Visual Studio Spell Checker (VS2017 and Later)](https://marketplace.visualstudio.com/items?itemName=EWoodruff.VisualStudioSpellCheckerVS2017andLater)
