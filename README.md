# NTCalculator
Simple command line interface for various number theory operations, such as prime factorization and Euler phi function. Includes a Utils library for functionality and relevant unit tests.


Created using .NET and C#. Inspired by what I learned in *MATH 312: Introduction to Number Theory* and the online tools I used for that class.

<img width="960" alt="ntcalc" src="https://user-images.githubusercontent.com/5817401/148462708-f76b13b3-6eec-4513-b8b9-6945b8dbdf8b.png">

## Commands
* **Sieve**: returns prime numbers up to given number.
* **Factorization**: returns the prime factorization of a given number.
* **Prime testing**: returns whether the given number is prime or not.
* **Fermat factorization**: returns the Fermat factorization of a given odd number.
* **Euler phi function**: returns the Euler phi function of a given number (number of coprime numbers up to given number).
* **Number of divisors**: returns the number of divisors of a given number.
* **Sum of divisors**: returns the sum of divisors of a given number.

## How to run
In `nt-calc` folder, run command `dotnet publish --configuration Release` in terminal to build. `NTCalculator.exe` and `NTCalculator.dll` are then found in `nt-calc\NTCalculator\bin\Release\net6.0`.

## Potential Improvements and TODO's
* **Performance and benchmarking flags**: allow benchmarking for performance of commands.
* **Performance improvements**
  - Caching: Implementing a cache for already-computed primes (in sieve) to avoid repeated work.
  - Euler and Prime-testing does not require computing the full prime factorization - simpler and more performant to compute prime factors without multiplicity. For convenience however, I re-used the prime factorization code.
  - Fermat factorization uses `long` instead of `int` due to big numbers causing incorrect results. Worth considering switching other methods to use `long` as well to support bigger inputs.
