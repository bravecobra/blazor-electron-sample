# Blazor - Electron.NET sample app

![CI](https://github.com/bravecobra/blazor-electron-sample/workflows/Development%20workflow/badge.svg) ![CodeQL](https://github.com/bravecobra/blazor-electron-sample/workflows/CodeQL/badge.svg)

This repo contains an example showcasing [server-side blazor](https://docs.microsoft.com/en-us/aspnet/core/blazor/hosting-models?view=aspnetcore-3.1#blazor-server) with [matBlazor](https://www.matblazor.com/) running in [Electron.NET](https://github.com/ElectronNET/Electron.NET).
It uses [Fluxor](https://github.com/mrpmorris/fluxor) and [Reactive.NET](https://github.com/dotnet/reactive) to maintain application state.

## Building the sample

### Requirements

* dotnet SDK: 6.0
* node : 16.3.0
* NPM : 7.21.0

```powershell
dotnet tool restore
dotnet cake
```
