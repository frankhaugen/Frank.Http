# Frank.Http

Frank.Http is a library for making HTTP requests in a modern way. It is built on top of the `HttpClient` class that is available in .NET Core and .NET Standard. It is designed to be simple to use and easy to extend.

It has simple mechanisms for Authentication, and request enrichment. It also has a simple mechanism for handling errors.

___
[![GitHub License](https://img.shields.io/github/license/frankhaugen/Frank.Markdown)](LICENSE)
[![NuGet](https://img.shields.io/nuget/v/Frank.Http.svg)](https://www.nuget.org/packages/Frank.Http)
[![NuGet](https://img.shields.io/nuget/dt/Frank.Http.svg)](https://www.nuget.org/packages/Frank.Http)

![GitHub contributors](https://img.shields.io/github/contributors/frankhaugen/Frank.Http)
![GitHub last commit](https://img.shields.io/github/last-commit/frankhaugen/Frank.Http)
![GitHub issues](https://img.shields.io/github/issues-raw/frankhaugen/Frank.Http)
![GitHub closed issues](https://img.shields.io/github/issues-closed-raw/frankhaugen/Frank.Http)
![GitHub pull requests](https://img.shields.io/github/issues-pr-raw/frankhaugen/Frank.Http)

![GitHub closed pull requests](https://img.shields.io/github/issues-pr-closed-raw/frankhaugen/Frank.Http)
![GitHub repo size](https://img.shields.io/github/repo-size/frankhaugen/Frank.Http)
![GitHub code size in bytes](https://img.shields.io/github/languages/code-size/frankhaugen/Frank.Http)
![GitHub top language](https://img.shields.io/github/languages/top/frankhaugen/Frank.Http)
![GitHub language count](https://img.shields.io/github/languages/count/frankhaugen/Frank.Http)
![GitHub search hit counter](https://img.shields.io/github/search/frankhaugen/Frank.Http/goto)

![GitHub forks](https://img.shields.io/github/forks/frankhaugen/Frank.Http?style=social)
![GitHub watch count](https://img.shields.io/github/watchers/frankhaugen/Frank.Http?style=social)
![GitHub star count](https://img.shields.io/github/stars/frankhaugen/Frank.Http?style=social)
![GitHub followers](https://img.shields.io/github/followers/frankhaugen?style=social)
![GitHub forks](https://img.shields.io/github/forks/frankhaugen/Frank.Http?style=social)
___

## Installation

You can install the library via NuGet. Just search for `Frank.Http` in the NuGet package manager.

## Usage

Here is a simple example of how to use the library:

```csharp
using Frank.Http;

var client = new RestClient();

var response = await client.GetAsync("https://jsonplaceholder.typicode.com/posts");

if (response.IsSuccessStatusCode)
{
    var content = await response.Content.ReadAsStringAsync();
    Console.WriteLine(content);
}
```
