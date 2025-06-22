# `Erdmier.DomainCore`

_![NuGet Version](https://img.shields.io/nuget/v/Erdmier.DomainCore?style=for-the-badge&link=https%3A%2F%2Fwww.nuget.org%2Fpackages%2FErdmier.DomainCore%2F)_
_![NuGet Downloads](https://img.shields.io/nuget/dt/Erdmier.DomainCore?style=for-the-badge&link=https%3A%2F%2Fwww.nuget.org%2Fpackages%2FErdmier.DomainCore%2F)_
_![GitHub Release Date](https://img.shields.io/github/release-date/JustinianErdmier/Erdmier.DomainCore?style=for-the-badge)_
_![GitHub last commit](https://img.shields.io/github/last-commit/JustinianErdmier/Erdmier.DomainCore?style=for-the-badge)_
_![GitHub contributors](https://img.shields.io/github/contributors/JustinianErdmier/Erdmier.DomainCore?style=for-the-badge)_
_![GitHub issue custom search](https://img.shields.io/github/issues-search?query=repo%3AJustinianErdmier%2FErdmier.DomainCore%20is%3Aopen&style=for-the-badge&label=issues%20%26%20tasks)_

A small and lightweight library designed to give you the core essentials for implementing your domain layer (following Domain Driven Design). The primary benefit to this library is
that it works well with EF Core. Extremely, heavily based on the design and implementation by [Amichai Mantinband](https://github.com/amantinband) in
his [REST API w/ Clean Architecture & DDD](https://youtube.com/playlist?list=PLzYkqgWkHPKBcDIP5gzLfASkQyTdy0t4k&si=aULsyZmIpAnLQjT7) tutorial. Most of the changes I have made to
this code are syntactical.

## Table of Contents

1. [Features](#features)
2. [Road Map](#road-map)
3. [Installing](#installing)
4. [Examples](#examples)

## Features

* Designed to work with EF Core with no additional setup/boilerplate.
* Easily extensible and requires little to no additional custom base class implementations.
* Intuitive and understandable.

## Road Map

This isn't so much a road map as it is a few ideas I would like to see added sometime in the future. Some of these items are listed in the Issues tab, and I plan to address them
soon.

* **Serialization:** There is an issue with trying to deserialize and then serialize aggregates due to the inheritance combined with the type generics. However, as pointed out by
  Amichai, there shouldn't be a reason why you would want your actual aggregate objects used outside your main system (e.g., if you're using Blazor). You would want to follow
  the examples he gave in his tutorial, providing a DTO for each. However, if you are using Blazor, there would be considerable benefit to using your defined value objects.
  Serialization should work out-the-box with types derived from `ValueObject`, but I'd like to add some features/configurations that make the experience much easier for consumers.
* **Source Generation:** This is mostly something I'd like to learn, and this could be a good excuse lol. I'm thinking that it would be nice to be able to implement the
  `ValueObject.GetEqualityComponents()` body via source generation by automatically detecting your model's properties. Of course, there would have to be some way to signal to the
  generator _not_ to do include certain members, but that could easily be done with an annotation (I think lol).
* **Basic/Simple Value Type Derivations:** I'm not too concerned with this, but I have thought about it from time to time. I think there could be some benefit to providing default
  value objects for common concerns (e.g., emails, phone numbers, addresses, etc.). Of course, while this seems like it would be nice, there would be a lot of considerations for
  each one depending on how many potential users I'd like to use it. For example, every country has their own way of defining phone numbers and zip codes. There's also the question
  of whether it's really within scope of this library. The main purpose of this library is to not have to copy-and-paste the code for these base classes every time I start a new
  project. And while I haven't done any sort of advertising or anything at all, over 400 people have downloaded this library. I was astonished by that and to be honest, it's what
  kept me interesting in polishing it. That's all to say, I'd hate to add bloat to something that's really meant to be lean and clean.

## Installing

Add the NuGet package.

```shell
dotnet add package Erdmier.DomainCore
```

## Examples

I am working on adding tests at the moment. Once I am finished with that, I plan to add some demos and perhaps even thorough documentation in addition to the XAML documentation in
the source code. There is no official ETA, but it is on my list of things to do!
