# Changelog

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/).

## [0.0.50] - 2020-06-02
### Updated
- Nuget package Castle.Core 4.4.1.
- Nuget package NSubstitute 4.2.1.
- Nuget package NUnit 3.12.0.
- Nuget package System.Runtime.CompilerServices.Unsafe 4.7.1.
- Nuget package System.Threading.Tasks.Extensions 4.5.2.
- .NET Framework 4.8.

## [0.0.44] - 2019-06-07
### Updated
- CHANGELOG.md
- README.md
- packages

## [0.0.30] - 2018-08-30
### Added
- CatchException:
	- ClassPersonTests: Add IsValidFileName_CatchException_ThrowsFluent.

## [0.0.20] - 2018-08-29
### Added
- NSubstitute:
	- ClassPersonTests: Add ClassPersonIsNull_CompareAgeWithZero_IsFalse.
	- ClassPersonTests: Add ClassPersonIsMake_CompareAgeWithZero_IsTrue.

## [0.0.10] - 2018-08-28
### Added
- NSubstitute:
	- ClassPerson.
	- ClassPersonTests: Add ExampleNSubstitute with Substitute.For and Substitute.ForPartsOf.
	- ClassPersonTests: Add Setup and Teardown methods.
- CatchException:
	- ClassLogAnalyzer.
	- ClassLogAnalyzerTests: Add TestCase for IsValidFileName_ValidExtensions.
	- ClassLogAnalyzerTests: Add Assert.Catch<Exception> for IsValidFileName_CatchException.
