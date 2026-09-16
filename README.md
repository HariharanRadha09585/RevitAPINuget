# Revit API NuGet Package

A step-by-step educational project demonstrating how to create, configure, build, test, and publish a **NuGet package for Autodesk Revit API development** using C# and .NET.

> The primary purpose of this repository is to help Revit API developers understand how reusable Revit API code can be converted into a NuGet package and consumed across multiple Revit add-in projects.

---

## 📌 Repository Purpose

While developing Revit plugins, we often write the same utility methods repeatedly.

For example:

```csharp
GetElementName()
GetAllViews()
GetAllSheets()
GetParameterValue()
GetGeometry()
```

Instead of copying the same helper classes into multiple Revit add-in projects, we can create a reusable library and distribute it as a **NuGet package**.

The basic workflow demonstrated by this repository is:

```text
Revit API Helper Methods
          ↓
.NET Class Library
          ↓
Compile the Library
          ↓
Generate NuGet Package (.nupkg)
          ↓
Test the Package
          ↓
Publish to NuGet
          ↓
Install in Revit Add-in
          ↓
Reuse Across Projects
```

---

# 📦 NuGet Package

The NuGet package demonstrated in this repository is:

```text
HariharanRadha.RevitAPI.Helpers
```

The goal is to gradually create reusable helper methods for different areas of Revit API development while keeping them inside a single package.

Example:

```text
HariharanRadha.RevitAPI.Helpers
│
├── Elements
├── Views
├── Sheets
├── Parameters
├── Families
├── Geometry
├── Documents
├── Selection
└── Transactions
```

---

# 🛠 Technologies Used

This repository uses:

- C#
- .NET 10
- Autodesk Revit 2027
- Autodesk Revit API
- Visual Studio
- NuGet
- NuGet.org
- Git
- GitHub

Current development environment:

```text
Autodesk Revit : 2027
.NET           : .NET 10
Language       : C#
IDE            : Visual Studio
Package Manager: NuGet
```

> ⚠️ Revit API and .NET compatibility can vary between Revit versions. Always verify the supported .NET runtime before using the same configuration with another Revit release.

---

# 📁 Project Structure

The library is organized by Revit API functionality.

```text
RevitAPINuget
│
├── Elements
│   └── ElementHelper.cs
│
├── Views
│   └── ViewHelper.cs
│
├── Sheets
│   └── SheetHelper.cs
│
├── Parameters
│   └── ParameterHelper.cs
│
├── Families
│   └── FamilyHelper.cs
│
├── Geometry
│   └── GeometryHelper.cs
│
├── Documents
│   └── DocumentHelper.cs
│
├── Selection
│   └── SelectionHelper.cs
│
├── Transactions
│   └── TransactionHelper.cs
│
├── RevitAPINuget.csproj
│
└── README.md
```

Not every helper needs to be implemented immediately.

The idea is to gradually expand the library as reusable Revit API functionality is identified.

---

# 🚀 Step 1 — Create the Class Library

Open Visual Studio and select:

```text
Create a new project
```

Select:

```text
Class Library
```

For this repository, the project is:

```text
RevitAPINuget
```

The project currently targets:

```xml
<TargetFramework>net10.0</TargetFramework>
```

---

# 🚀 Step 2 — Reference the Revit API

A Revit helper library needs access to Autodesk Revit API classes such as:

```csharp
Element
Document
View
ViewSheet
Parameter
XYZ
Solid
FamilyInstance
```

Therefore, reference:

```text
RevitAPI.dll
```

For Revit 2027, it can normally be found at:

```text
C:\Program Files\Autodesk\Revit 2027\RevitAPI.dll
```

The project reference can be configured as:

```xml
<ItemGroup>

  <Reference Include="RevitAPI">

    <HintPath>
      C:\Program Files\Autodesk\Revit 2027\RevitAPI.dll
    </HintPath>

    <Private>false</Private>

  </Reference>

</ItemGroup>
```

---

## Why is `Private` set to `false`?

```xml
<Private>false</Private>
```

is important.

Our library uses Autodesk Revit API, but we do not want to distribute Autodesk's `RevitAPI.dll` as part of our helper package.

Revit already provides the required API assemblies when the add-in runs inside Revit.

Conceptually:

```text
Autodesk Revit
      │
      └── RevitAPI.dll
              ↑
              │
Your Revit Add-in
              │
              ↓
HariharanRadha.RevitAPI.Helpers.dll
```

---

# 🚀 Step 3 — Create a Helper Method

The first example in this repository is an element helper.

Create:

```text
Elements
└── ElementHelper.cs
```

Example:

```csharp
using Autodesk.Revit.DB;

namespace HariharanRadha.RevitAPI.Helpers.Elements;

public static class ElementHelper
{
    /// <summary>
    /// Gets the name of the supplied Revit element.
    /// </summary>
    /// <param name="element">Revit element.</param>
    /// <returns>
    /// Element name or an empty string when a name is unavailable.
    /// </returns>
    public static string GetElementName(Element element)
    {
        return element?.Name ?? string.Empty;
    }
}
```

This is intentionally a simple example.

The goal is to understand the complete NuGet workflow before adding complex Revit API functionality.

---

# 🚀 Step 4 — Organize Multiple Helpers

Instead of creating one huge class such as:

```csharp
RevitHelper.GetElementName();
RevitHelper.GetViewName();
RevitHelper.GetSheetNumber();
RevitHelper.GetParameterValue();
```

the library can be organized by responsibility.

For example:

```csharp
ElementHelper.GetElementName(element);

ViewHelper.GetViewName(view);

SheetHelper.GetSheetNumber(sheet);

ParameterHelper.GetParameterValue(element, "Comments");
```

This makes the package easier to:

- Understand
- Maintain
- Extend
- Document
- Test
- Consume

---

# 🚀 Step 5 — Configure the NuGet Package

The `.csproj` contains the NuGet package metadata.

A simplified configuration looks like this:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>

    <TargetFramework>net10.0</TargetFramework>

    <ImplicitUsings>enable</ImplicitUsings>

    <Nullable>enable</Nullable>

    <LangVersion>latest</LangVersion>

    <PackageId>
      HariharanRadha.RevitAPI.Helpers
    </PackageId>

    <Title>
      HariharanRadha Revit API Helpers
    </Title>

    <Authors>
      Hariharan Radha
    </Authors>

    <Company>
      Hariharan Radha
    </Company>

    <Description>
      Reusable helper methods for Autodesk Revit API development.
    </Description>

    <GeneratePackageOnBuild>
      true
    </GeneratePackageOnBuild>

  </PropertyGroup>

</Project>
```

---

# 🚀 Step 6 — Package Naming

The NuGet package ID used by this project is:

```text
HariharanRadha.RevitAPI.Helpers
```

For a clean library structure, the package, assembly, and namespaces can follow the same naming convention.

```text
Package
│
└── HariharanRadha.RevitAPI.Helpers

Assembly
│
└── HariharanRadha.RevitAPI.Helpers.dll

Namespaces
│
├── HariharanRadha.RevitAPI.Helpers.Elements
├── HariharanRadha.RevitAPI.Helpers.Views
├── HariharanRadha.RevitAPI.Helpers.Sheets
└── HariharanRadha.RevitAPI.Helpers.Parameters
```

This makes the library easier for other developers to understand.

---

# 🚀 Step 7 — Build the Library

Build the project using Visual Studio:

```text
Build
   ↓
Build Solution
```

or use the .NET CLI:

```powershell
dotnet build
```

For a Release build:

```powershell
dotnet build -c Release
```

The compiled library is generated inside the output directory.

Example:

```text
bin
└── Release
    └── net10.0
        └── HariharanRadha.RevitAPI.Helpers.dll
```

---

# 🚀 Step 8 — Generate the NuGet Package

The package can be generated using:

```powershell
dotnet pack -c Release
```

Because the project can use:

```xml
<GeneratePackageOnBuild>true</GeneratePackageOnBuild>
```

the `.nupkg` can also be generated automatically during the build.

Example output:

```text
HariharanRadha.RevitAPI.Helpers.1.0.0.nupkg
```

---

# 🔍 Step 9 — Inspect the NuGet Package

A `.nupkg` is essentially a package archive.

For learning purposes, make a copy of:

```text
HariharanRadha.RevitAPI.Helpers.1.0.0.nupkg
```

and rename the copy to:

```text
HariharanRadha.RevitAPI.Helpers.1.0.0.zip
```

Open it.

You should find your compiled library under a structure similar to:

```text
lib
└── net10.0
    └── HariharanRadha.RevitAPI.Helpers.dll
```

This is the DLL that will eventually be referenced by the consuming Revit add-in.

---

# 🧪 Step 10 — Test the NuGet Package Locally

Before publishing to NuGet.org, testing locally is recommended.

Create a folder such as:

```text
C:\LocalNuget
```

Copy the generated `.nupkg` into this folder.

Then open:

```text
Visual Studio
   ↓
Tools
   ↓
NuGet Package Manager
   ↓
Package Manager Settings
   ↓
Package Sources
```

Add:

```text
C:\LocalNuget
```

as a package source.

Now the package can be installed into a separate test Revit add-in without publishing it publicly.

---

# 🚀 Step 11 — Consume the Package

Create a separate Revit add-in project.

Install:

```text
HariharanRadha.RevitAPI.Helpers
```

using Visual Studio's NuGet Package Manager.

Alternatively:

```powershell
dotnet add package HariharanRadha.RevitAPI.Helpers
```

Then import the required namespace.

Example:

```csharp
using HariharanRadha.RevitAPI.Helpers.Elements;
```

The helper can then be called from the Revit add-in:

```csharp
Element element = document.GetElement(elementId);

string elementName =
    ElementHelper.GetElementName(element);
```

---

# ⚠️ Step 12 — Important Runtime Dependency Issue

One important issue discovered while developing this example was that the test Revit add-in could compile successfully but fail when executed inside Revit.

The error was similar to:

```text
Could not load file or assembly
'RevitAPINuget, Version=1.0.0.0'

The system cannot find the file specified.
```

The test add-in output contained:

```text
RevitAPINugetTest.dll
RevitAPINugetTest.pdb
RevitAPINugetTest.deps.json
```

but the NuGet library DLL was missing.

The required structure should be similar to:

```text
RevitAPINugetTest.dll

HariharanRadha.RevitAPI.Helpers.dll
```

One useful SDK-style project setting for the **consuming Revit add-in** is:

```xml
<CopyLocalLockFileAssemblies>true</CopyLocalLockFileAssemblies>
```

Example:

```xml
<PropertyGroup>

  <TargetFramework>
    net10.0-windows
  </TargetFramework>

  <CopyLocalLockFileAssemblies>
    true
  </CopyLocalLockFileAssemblies>

</PropertyGroup>
```

After rebuilding, package runtime assemblies can be copied into the consuming project's output folder.

This is particularly important because:

> **Successful compilation does not necessarily mean all required assemblies will be available when Revit loads the add-in.**

---

# 🚀 Step 13 — Publish to NuGet.org

Once the package works correctly in a test Revit add-in, it can be published.

Generate the Release package:

```powershell
dotnet pack -c Release
```

Then sign in to NuGet.org and upload the generated:

```text
.nupkg
```

For example:

```text
HariharanRadha.RevitAPI.Helpers.1.0.0.nupkg
```

NuGet will validate the package before making it available.

---

# 🔢 Step 14 — Package Versioning

Published NuGet package versions are immutable.

For example, once this combination exists:

```text
Package ID:
HariharanRadha.RevitAPI.Helpers

Version:
1.0.1
```

you cannot upload another package using the same ID and version.

You must increase the version.

For example:

```text
1.0.0
  ↓
1.0.1
  ↓
1.0.2
  ↓
1.1.0
  ↓
2.0.0
```

The common format is:

```text
MAJOR.MINOR.PATCH
```

Example:

```text
1.2.3
│ │ │
│ │ └── Patch
│ └──── Minor
└────── Major
```

### PATCH

Use for backward-compatible bug fixes.

```text
1.0.0 → 1.0.1
```

Examples:

```text
Bug fix
Small code correction
Packaging correction
Documentation correction
```

### MINOR

Use for new backward-compatible functionality.

```text
1.0.1 → 1.1.0
```

Examples:

```text
Added ViewHelper
Added SheetHelper
Added ParameterHelper
```

### MAJOR

Use when making breaking changes.

```text
1.1.0 → 2.0.0
```

Examples:

```text
Changed public method signatures
Removed existing APIs
Changed namespace architecture
Introduced incompatible behavior
```

---

# 🔄 Step 15 — Update the NuGet Package

Suppose the current version is:

```text
1.0.1
```

and a small fix is made.

Update the project:

```xml
<Version>1.0.2</Version>
```

Then run:

```powershell
dotnet pack -c Release
```

The new package becomes:

```text
HariharanRadha.RevitAPI.Helpers.1.0.2.nupkg
```

Upload the new version to NuGet.org.

Do not try to overwrite:

```text
1.0.1
```

---

# 🧩 Future Helper Architecture

As this educational project grows, additional helpers can be introduced.

For example:

```text
ElementHelper
│
├── GetElementName()
├── GetElementCategory()
├── GetElementType()
└── GetElementLevel()

ViewHelper
│
├── GetAllViews()
├── GetViewByName()
├── GetViewTemplates()
└── DuplicateView()

SheetHelper
│
├── GetAllSheets()
├── GetSheetByNumber()
├── CreateSheet()
└── GetViewsOnSheet()

ParameterHelper
│
├── GetParameter()
├── GetParameterValue()
└── SetParameterValue()

GeometryHelper
│
├── GetSolids()
├── GetFaces()
├── GetEdges()
└── GetBoundingBox()

FamilyHelper
│
├── GetFamilySymbol()
├── ActivateFamilySymbol()
└── GetFamilyInstances()
```

These examples represent possible future learning exercises rather than a guarantee that every method is currently implemented.

---

# 💡 Why NuGet for Revit API?

Without a reusable package:

```text
Plugin A
└── ElementHelper.cs

Plugin B
└── ElementHelper.cs

Plugin C
└── ElementHelper.cs
```

The same code may be duplicated across many projects.

With a NuGet package:

```text
       HariharanRadha
      RevitAPI.Helpers
             │
       ┌─────┼─────┐
       ↓     ↓     ↓
   Plugin A  B     C
```

multiple add-ins can consume the same reusable library.

This provides:

- ♻️ Code reuse
- 📦 Centralized reusable functionality
- 🔢 Version management
- 🧹 Cleaner Revit add-in projects
- 🛠 Easier maintenance
- 🤝 Easier sharing between developers
- 📚 Better organization
- 🚀 Faster plugin development

---

# ⚠️ Revit Version Compatibility

Revit API libraries require special consideration because different Revit releases can use different .NET runtimes and Autodesk API assemblies.

Conceptually:

```text
Revit Version
      ↓
.NET Runtime
      ↓
RevitAPI.dll
      ↓
NuGet Helper Library
      ↓
Revit Add-in
```

The current repository is focused on demonstrating the NuGet workflow with the configured Revit/.NET environment.

Do not assume that a package compiled against one Revit API version will automatically be compatible with every Revit release.

Multi-version support can be added as a more advanced stage of this project.

---

# 🎓 What You Can Learn From This Repository

By following this repository, you can learn:

1. How to create a .NET Class Library for Revit API.
2. How to reference `RevitAPI.dll`.
3. How to create reusable Revit API helper classes.
4. How to organize helper methods.
5. How to configure NuGet metadata.
6. How to generate a `.nupkg`.
7. How to inspect a NuGet package.
8. How to test a package locally.
9. How to consume a NuGet package from a Revit add-in.
10. How to troubleshoot missing runtime DLLs.
11. How NuGet package versioning works.
12. How to update an existing NuGet package.
13. How to publish a package to NuGet.org.
14. How to gradually build a reusable Revit API library.

---

# 🎯 Main Goal

The primary purpose of this repository is **not simply to provide a collection of Revit API helper methods**.

The main purpose is to demonstrate the complete process:

```text
Write Revit API Code
        ↓
Create Reusable Class Library
        ↓
Configure NuGet
        ↓
Build
        ↓
Pack
        ↓
Test
        ↓
Consume in Revit
        ↓
Debug Runtime Issues
        ↓
Version
        ↓
Publish
        ↓
Reuse
```

The repository can therefore be used as a reference by BIM developers who want to learn how **NuGet package development can be applied to Autodesk Revit API development**.

---

# 🔗 Repository

GitHub Repository:

https://github.com/HariharanRadha09585/RevitAPINuget

---

# 👨‍💻 Author

**Hariharan Radha**

BIM / Revit API Developer

Areas of interest:

```text
Autodesk Revit API
C#
.NET
WPF
Dynamo
Computational Design
BIM Automation
AEC Software Development
```
# 🧠 Key Learnings & Troubleshooting

While creating and testing this Revit API NuGet package, I encountered a few important issues.

This section documents those problems, why they happened, and how they were resolved.

The goal is to help other Revit API developers avoid the same mistakes.

---

## ⚠️ Issue 1 — NuGet Package Works in Visual Studio but Fails in Revit

After installing the NuGet package in a Revit add-in project, the helper methods were available in Visual Studio and the project compiled successfully.

For example:

```csharp
using HariharanRadha.RevitAPI.Helpers.Elements;
```

and:

```csharp
string name = ElementHelper.GetElementName(element);
```

worked correctly during development.

However, when the command was executed inside Autodesk Revit, Revit reported an error similar to:

```text
Revit could not complete the external command.

Could not load file or assembly
'RevitAPINuget, Version=1.0.0.0'

The system cannot find the file specified.
```

At first, this can be confusing because:

```text
NuGet Package Installed     ✅
Code Compilation            ✅
IntelliSense                ✅
Build                       ✅
Execution inside Revit      ❌
```

---

## 🔍 What Was the Problem?

The NuGet package was available to the project during compilation, but its DLL was not being copied to the Revit add-in output directory.

The output directory contained files such as:

```text
RevitAPINugetTest.dll
RevitAPINugetTest.pdb
RevitAPINugetTest.deps.json
```

but the NuGet library DLL was missing.

Conceptually, the Revit add-in depended on:

```text
Revit
  ↓
RevitAPINugetTest.dll
  ↓
HariharanRadha.RevitAPI.Helpers.dll
```

When Revit loaded:

```text
RevitAPINugetTest.dll
```

the .NET runtime also needed to locate the helper assembly.

If that dependency was not present in the deployed output, the add-in could compile successfully but fail at runtime.

---

## ✅ Solution

The following property was added to the **consuming Revit add-in project's `.csproj` file**:

```xml
<CopyLocalLockFileAssemblies>true</CopyLocalLockFileAssemblies>
```

For example:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>

    <TargetFramework>net10.0-windows</TargetFramework>

    <ImplicitUsings>enable</ImplicitUsings>

    <Nullable>enable</Nullable>

    <CopyLocalLockFileAssemblies>true</CopyLocalLockFileAssemblies>

  </PropertyGroup>

</Project>
```

After adding this property:

1. Clean the solution.
2. Delete the `bin` and `obj` folders if necessary.
3. Restore NuGet packages.
4. Rebuild the solution.
5. Verify the output directory.

The required NuGet dependency should now be copied into the output.

Example:

```text
bin
└── Debug
    └── net10.0-windows
        │
        ├── RevitAPINugetTest.dll
        ├── RevitAPINugetTest.pdb
        ├── RevitAPINugetTest.deps.json
        │
        └── HariharanRadha.RevitAPI.Helpers.dll
```

The Revit add-in can now locate the helper library at runtime.

---

## 💡 What Does `CopyLocalLockFileAssemblies` Do?

The property:

```xml
<CopyLocalLockFileAssemblies>true</CopyLocalLockFileAssemblies>
```

instructs the .NET SDK to copy resolved NuGet package runtime assemblies into the project's output directory.

This is particularly important for Revit add-ins because Revit loads the add-in DLL from its deployment location.

Any additional assemblies required by the add-in must also be available where the .NET runtime can resolve them.

Without the helper DLL:

```text
Revit
  ↓
MyPlugin.dll
  ↓
❌ Helper DLL not found
```

With the dependency copied:

```text
Revit
  ↓
MyPlugin.dll
  ↓
HariharanRadha.RevitAPI.Helpers.dll
  ↓
Helper Methods
```

---

## 🎯 Important Learning

One of the most important lessons from this issue is:

> **A successful build does not guarantee that a Revit add-in has all the assemblies required at runtime.**

There are two different stages to consider:

```text
Compile Time
    ↓
Can Visual Studio find the referenced package?
    ↓
Build Successful
```

and:

```text
Runtime
    ↓
Revit loads the add-in
    ↓
.NET resolves referenced assemblies
    ↓
Are all required DLLs available?
```

Both must work correctly.

When troubleshooting a Revit error such as:

```text
Could not load file or assembly...
```

one of the first things to check should therefore be the add-in's output/deployment directory.

Verify that all required custom dependency DLLs are present.

---

## ⚠️ Issue 2 — Do Not Copy Autodesk RevitAPI.dll With the Package

The helper library references:

```text
RevitAPI.dll
```

because classes such as:

```csharp
Element
View
ViewSheet
Document
Parameter
XYZ
```

come from Autodesk Revit API.

However, `RevitAPI.dll` should not be treated like our own helper dependency.

The project therefore uses:

```xml
<Reference Include="RevitAPI">

  <HintPath>
    C:\Program Files\Autodesk\Revit 2027\RevitAPI.dll
  </HintPath>

  <Private>false</Private>

</Reference>
```

The important part is:

```xml
<Private>false</Private>
```

This prevents `RevitAPI.dll` from being copied as one of our library's local assemblies.

The intended relationship is:

```text
Autodesk Revit
     │
     ├── RevitAPI.dll
     │
     └── Loads MyPlugin.dll
                    │
                    └── HariharanRadha.RevitAPI.Helpers.dll
```

Revit provides its own API assemblies.

Our NuGet package provides only our reusable helper functionality.

---

## ⚠️ Issue 3 — Published NuGet Versions Cannot Be Replaced

Another important learning during this project was NuGet package versioning.

After publishing:

```text
HariharanRadha.RevitAPI.Helpers
1.0.1
```

attempting to upload another package with:

```text
Package ID : HariharanRadha.RevitAPI.Helpers
Version    : 1.0.1
```

results in an error similar to:

```text
A package with ID 'HariharanRadha.RevitAPI.Helpers'
and version '1.0.1' already exists and cannot be modified.
```

This is expected NuGet behavior.

A published package version is immutable.

Instead of replacing:

```text
1.0.1
```

create a new version:

```text
1.0.1
   ↓
1.0.2
```

Update:

```xml
<Version>1.0.2</Version>
```

and generate the package again:

```powershell
dotnet pack -c Release
```

This produces:

```text
HariharanRadha.RevitAPI.Helpers.1.0.2.nupkg
```

which can then be published as a new version.

---

# 📋 Key Takeaways

The main lessons learned while building this project are:

| Learning | Key Point |
|---|---|
| Build vs Runtime | Successful compilation does not guarantee successful execution inside Revit |
| NuGet Dependencies | Required package DLLs must be available when Revit loads the add-in |
| `CopyLocalLockFileAssemblies` | Can be used to copy resolved NuGet runtime assemblies to the output directory |
| RevitAPI.dll | Reference it for compilation, but do not package it as your own library |
| `Private=false` | Prevents the Revit API assembly from being copied locally |
| Package Versioning | A published NuGet version cannot be overwritten |
| Semantic Versioning | Publish fixes and features using a new package version |
| Output Verification | Always inspect the final Revit add-in deployment directory |
---

# 🤝 Contributions

This repository is primarily created for educational and demonstration purposes.

Suggestions, issues, improvements, and contributions related to Revit API NuGet development are welcome.

If you find an issue or have an improvement idea, feel free to create an Issue or Pull Request.

---

# ⭐ Support

If this repository helps you understand how to create NuGet packages for Autodesk Revit API development, consider giving the repository a ⭐.

It can help other BIM, automation, and Revit API developers discover the project.

---

# ⚠️ Disclaimer

This repository is an independent educational project.

It is not an official Autodesk product and is not affiliated with or endorsed by Autodesk.

Autodesk and Revit are trademarks or registered trademarks of Autodesk, Inc.
