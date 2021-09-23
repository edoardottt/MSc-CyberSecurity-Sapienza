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

## Lesson 2 - Basics

One goal of this course is understand the role that software plays in providing security and as a source of insecurity.  
Software is the weakest link in the security chain, with the possible exception of "the human factor".  

Some examples of problems (threats, vulnerabilities...etc...):
- Slammer worm (https://it.wikipedia.org/wiki/SQL_Slammer)
- Buffer overflow in Cisco Router; CVE-2011-0352 (https://nvd.nist.gov/vuln/detail/CVE-2011-0352)
- Vulnerability in FFmpeg; CVE-2010-4705 (https://nvd.nist.gov/vuln/detail/CVE-2010-4705)
- Vulnerability in Linux/Windows/macOS; CVE-2011-0638, CVE-2011-0640, CVE-2011-0639 (https://nvd.nist.gov/vuln/detail/CVE-2011-0638, https://nvd.nist.gov/vuln/detail/CVE-2011-0639, https://nvd.nist.gov/vuln/detail/CVE-2011-0640)
- Vulnerability in Mozilla/Bugzilla; CVE-2010-4568 (https://nvd.nist.gov/vuln/detail/CVE-2010-4568)
- And so on... (https://us-cert.cisa.gov/ncas/bulletins)

All these problems are due to (bad) software. Such software bugs are why constant patching of system is needed to keep them secure.  
That bad software that can be executed over the network, or executes on (untrusted) input obtained over the network. With ever more network connectivity, ever more software can be attacked.  
Traditionally the focus was on Operating systems and network security, today we have threats also in web-based applications, embedded and mobile devices...  
And even more bad actors are organized, they aren't anymore no-funded young nerd guys.  
[Current prices for 0-days attacks (Zerodium)](https://zerodium.com/program.html).  

Problems are due to:
- lack of awareness (of threats, but also of what should be protected)
- lack of knowledge (of potential security problems, but also of solutions
- compounded by complexity (software written in complicated languages, using large APIs , and running on huge infrastructure)
- people choosing functionality over security
Security is always a secondary concern; primary goal of software is to provide some functionality or services; managing associated risks is a derived/secondary concern.  
Functionality is about what an application does, security is about what an application should not do.  

*Important distinction*
1.**Security weakness / flaw**: Something that is wrong or could be better.
2.**Security vulnerability**: Flaw that can be exploited by an attacker to violate a policy.

So, a flaw must be accessible (an attacker must have access to it) and exploitable (an attacker must be able to use it to compromise system).

Software flaws can be introduced at two levels:
- Design flaw: the flaw is introduced during the design
- Bug / code-level flaw:  the flaw is introduced during implementation

Vulnerabilities can also arise from other levels
- Configuration flaws – when installing the SW
- “User” flaws
- Unforeseen consequences of intended functionality (e.g., spam …)

**Coding flaws**:
Software flaws can be introduced during implementation can be roughly distinguished into
- Flaws that can be understood by looking at the program e.g.: typos, confusing program variables, off-by-one, access to array, error in program logic, …
- Flaws due to the interaction with the underlying platform or with other systems
    - Buffer overflow in C(++) code
    - Integer overflow/underflow in most programming languages
    - SQL injection, XSS, CSRF, … in web applications

**Example of insecure code**
~~~
int balance;

void decrease(int amount)
    {
        if (balance <= amount) {        // ERROR: This should be >=
            balance = balance – amount; 
        } else { 
            printf(“Insufficient funds\n”);
        }
    }

void increase(int amount)
{
    balance = balance + amount;
}
~~~
