---
theme : "black"
transition: "zoom"
highlightTheme: "darkula"
separator: ^---$
verticalSeparator: ^--$
---

#### EPH EDD 2019

### C# 8

#### by Marek Linka

--

### Agenda

0. What came before - C# 7
0. Nullable reference types
0. Pattern matching improvements
0. Default interface members
0. Indices and ranges
0. Async streams
0. Syntactic sugar

---

### C# 7

* Pattern matching
* Tuples
* Discards
* refs, readonly structs and high performance code

---

### Nullable reference types

* Allows for expression of intent about null values
* Minimizes the occurence of NREs
* Is a static analysis, NREs can still occur
* Not much value in small project but potentially huge for large projects
* Opt-in

--

### Simple demo

--

### Viacar demo and compiler bug

[GitHub](https://github.com/dotnet/roslyn/issues/40033)

---

### Pattern matching improvements

* switch expressions
* property patterns
* tuple patterns
* positional patters

--

### Demo

---

### Default interface members

* Only works on Core 3+ and netstandard2.1+
* Allows members on interfaces
* Enables trait behavior
* Pretty weird but powerful

--

### Demo

---

### Indices and ranges

* New syntax for accessing collections
* Similar to python indices
* System.Index + System.Range
* Supported on arrays and spans, limited on lists
* array[^0] ~ array[array.Length] ~ exception
* Range start is inclusive and range end is exclusive

--

### Demo

---

### Async streams

* Iterating over streams coming from async IO
* Unblocks threads, increases throughput
* Important for scenarios such as web apps accessing a database

--

### Demo

---

### Syntactic sugar

* using declarations
* static local functions
    * performance improvement in some scenarios
* null-coalescing assignment
* readonly struct members
    * way to indicate that a method does not modify the struct state