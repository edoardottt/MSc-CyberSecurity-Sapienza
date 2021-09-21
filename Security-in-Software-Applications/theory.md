# Security in Software Applications - Theory

## Lesson 1 - Introduction

Brief explanation of the concept *Trusting Trust*, the speech Ken Thompson gave when he won the Turing Award in 1983 (https://www.cs.cmu.edu/~rdriley/487/papers/Thompson_1984_ReflectionsonTrustingTrust.pdf).  
We can define four research cornerstones of Security:
- Software Security
- Network Security
- OS Security
- Cryptography

*Secure software > Security software*:
- Secure Software means that particular program has no bug/issue. It's 100% secure.
- Security Software means programs intended for Security.

Some definitions:
- Bug: an error (or defect/flaw/failure) introduced in a SW 
    - at the specification / design / algorithmic level
    - at the programming / coding level or 
    - even by the compiler (or other program transformation tools) .
- Vulnerability: a bug that opens a security breach
    - non exploitable vulnerability: there is no (known !) way for an attacker to use this bug to corrupt the system
    - exploitable vulnerability: this bug can be used to elaborate an attack (i.e., write an exploit)
- Exploit: a concrete program input to take advantage of a vulnerability (from an attacker point of view)
- Malware: a piece of code “injected” inside a computer to corrupt it (usually exploiting existing vulnerabilities)

Countermeasures:  
Several existing mechanisms to enforce SW security
- at the programming level:
    - disclosed vulnerabilities -> language weaknesses databases -> secure coding patterns and libraries
    - aggressive compiler options + code instrumentation -> early detection of unsecure code
- at the OS level:
    - sandboxing
    - address space randomization
    - non executable memory zones
    - etc.
- at the hardware level:
    - Trusted Platform Modules (TPM)
    - secure crypto-processor
    - CPU tracking
