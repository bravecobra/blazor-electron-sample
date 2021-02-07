#addin "nuget:?package=Cake.Electron.Net&version=1.1.0"
using Cake.Electron.Net;
using Cake.Electron.Net.Commands.Settings;

///////////////////////////////////////////////////////////////////////////////
// ARGUMENTS
///////////////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

///////////////////////////////////////////////////////////////////////////////
// SETUP / TEARDOWN
///////////////////////////////////////////////////////////////////////////////

Setup(ctx =>
{
  // Executed BEFORE the first task.
  Information("Running tasks...");
});

Teardown(ctx =>
{
  // Executed AFTER the last task.
  Information("Finished running tasks.");
});

///////////////////////////////////////////////////////////////////////////////
// TASKS
///////////////////////////////////////////////////////////////////////////////
var projects = GetFiles("./**/*.csproj");
var projectPaths = projects.Select(project => project.GetDirectory().ToString());

public int PackageInstaller(ICakeContext ctx, ElectronTarget target){
  var gitversion = GitVersion(new GitVersionSettings {
        UpdateAssemblyInfo = false
  });
  ElectronNetVersion(ctx.Environment.WorkingDirectory.ToString());

  ElectronNetBuildSettings settings = new ElectronNetBuildSettings();
  settings.WorkingDirectory = ctx.Environment.WorkingDirectory.ToString();
  settings.ElectronTarget = target;
  settings.DotNetConfig = DotNetConfig.Release;
  settings.ElectronParams = new [] {
    $"c.extraMetadata.version={gitversion.SemVer}",
    $"c.extraMetadata.buildVersion={gitversion.AssemblySemFileVer}"
  };
  //Hack to pass in extra arguments
  settings.RelativePath = $". /PublishSingleFile false /PublishReadyToRun false";
  return ElectronNetBuild(settings);
}

Task("Compile")
.Does(() => {
  foreach(var path in projectPaths)
  {
    Information($"Restoring {path}...");
    DotNetCoreRestore(path);
  }
  DotNetCoreBuild("./blazor-electron-sample.sln");
});

Task("Package - Windows")
.Does((ctx) => {
  if (ctx.Environment.Platform.Family == PlatformFamily.Windows){
    PackageInstaller(ctx, ElectronTarget.Win);
  }
  else
  {
    Console.WriteLine($"Skipping since build platform is {ctx.Environment.Platform.Family.ToString()}");
  }
});

Task("Package - Linux")
.Does((ctx) => {
  if (ctx.Environment.Platform.Family == PlatformFamily.Linux){
    PackageInstaller(ctx, ElectronTarget.Linux);
  }
  else
  {
    Console.WriteLine($"Skipping since build platform is {ctx.Environment.Platform.Family.ToString()}");
  }
});

Task("Package - OSX")
.Does((ctx) => {
  if (ctx.Environment.Platform.Family == PlatformFamily.OSX){
    PackageInstaller(ctx, ElectronTarget.MacOs);
  }
});

Task("Default")
.IsDependentOn("Compile")
.IsDependentOn("Package - Linux")
.IsDependentOn("Package - OSX")
.IsDependentOn("Package - Windows")
;

RunTarget(target);