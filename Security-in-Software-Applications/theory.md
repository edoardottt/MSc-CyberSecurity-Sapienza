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
        if (balance <= amount) {        // [ 1 ] ERROR: This should be >=
                                        // [ 2 ] ERROR: What if amount is negative?
            balance = balance – amount; 
        } else { 
            printf(“Insufficient funds\n”);
        }
    }

void increase(int amount)
{
    balance = balance + amount;         // [ 3 ] ERROR: What if the sum is too large for an integer?
}
~~~

1. *Logic error*: Can be found by code inspection only
2. *Lack of input validation of (untrusted) user*: Design flaw or implementation flaw ?
3. *Problem with interaction with underlying platform*: lower level than previous ones

To prevent standard mistakes we need knowledge and security taken into account from the beginning and throughout the sw. development life cycle. Often organizations tackle security at the end of Sw development life cycle.  
When we write software, we provide some functionalities. These functionalities come with certain risks. Software security is about managing these risks.  
![touchpoints](https://github.com/edoardottt/MSc-CyberSecurity-Sapienza/blob/main/Security-in-Software-Applications/resources/images/01-touchpoints.gif)  
(http://www.swsec.com/resources/touchpoints/)  

## Lesson 3 - Basics (part 2)

Security is about regulating access to assets (eg. information or functionality). Software provides functionalities that come with certain risks, Software security is about managing these risks.  
Any discussion of security should start with an inventory of the stakeholders, their assets, and the threats to these assets by possible attackers (employees, clients, script kiddies, criminals ...).  
Security is about imposing countermeasures to reduce risks to assets to acceptable levels. A security policy is a specification of what security requirements/goals the countermeasures are intended to achieve, so security mechanisms to enforce the policy.  
Security Objectives: CIA  
- Confidentiality (unauthorised users cannot read information)
- Integrity (unauthorised users cannot alter information)
- Availability (authorised users can access information)
- Non-repudiation for accountability (authorised users cannot deny actions)

Integrity nearly always more important than confidentiality (e.g. think of your bank account information, your medical records, all your software, incl. entire OS)  
Availability may be undesirable for privacy (you want certain data to be or become unavailable)  
The well-known trio (CIA) but there are more “concrete” goals
- traceability and auditing (forensics)
- monitoring (real-time auditing)
- multi-level security
- privacy & anonymity
- ... 
- assurance, the goals are met

How to realise security objectives? AAAA
- Authentication. Who are you?
- Access control/Authorisation. Control who is allowed to do what; this requires a specification of who is allowed to do what
- Auditing. Check if anything went wrong
- Action. If so, take action

Other names for the last three A's
- Prevention. Measures to stop breaches of security goals
- Detection. Measures to detect breaches of security goals
- Reaction. Measures to recover assets, repair damage, and persecute (and deter) offenders

Threats vs security requirements
- information disclosure (confidentiality)
- Tampering with information (integrity)
- Denial of service (availability)
- Spoofing (authentication)
- Unauthorised access (access control)

Countermeasures can also be non-IT related. Countermeasures can lead to new vulnerabilities (eg. if we only allow three incorrect logins, as a countermeasure to brute-force password guessing attacks, which new vulnerability do we introduce?). If a countermeasure relies on software, bugs in this software may mean that it is ineffective, or worse still, that it introduces more weaknesses.  

Security in Software Development Life Cycle  
![ssdlc](https://github.com/edoardottt/MSc-CyberSecurity-Sapienza/blob/main/Security-in-Software-Applications/resources/images/02-ssdlc.png)  
(Gary McGraw, Software security, Security & Privacy Magazine, IEEE, Vol 2, No. 2, pp. 80-83, 2004.)

Security technologies we can use  
- cryptography (for threats related to insecure communication and storage 
- access control (for threats related to misbehaving users). e.g. role-based access control
- language-based security (for threats related to misbehaving programs)
- typing, memory-safety
- sandboxing (e.g. Java, .NET/C# ...)

Security technologies may be provided by the infrastructure/platform an application builds on, for instance. Of course, software in such infrastuctures implementing security has to be secure  
– networking infrastructure, which may eg. use SSL
– operating system or database system, providing eg. access control
– programming platform, for instance Java or .NET sandboxing

Applications are built on top of "infrastructure" (This infrastructure provides security mechanisms, but is also a source of insecurity) consisting of
- operating system  
- programming language/platform/middleware
    - programming language itself
    - interface to CPU & RAM
    - libraries and API (interface to peripherals, provider of building blocks)
- other applications & utilities (e.g. database)

Knowledge about threats & vulnerabilities are crucial. Vulnerabilities can be specific to programming language, operating system, database, the type of application... and are continuously evolving. We cannot hope to cover all vulnerabilities in this course, “Fortunately”, people keep making the same mistakes
and some old favourites never seem to die, esp. public enemy number 1: the buffer overflow and some patterns keep re-emerging.  
Sources of software vulnerabilities
- Bugs in the application or its infrastructure, ie. doesn't do what it should do
- Inappropriate features in the infrastructure, ie. does something that it shouldn't do
- functionality winning over security
- Inappropriate use of features provided by the infrastructure.

Main causes: complexity of these features, functionality winning over security, again ignorance of developers.  

Reading: https://inst.eecs.berkeley.edu/~cs161/fa08/papers/stack_smashing.pdf

Suppose in a C program we have an array of length 4: `char buffer[4];`  
What happens if we execute the statement below?: `buffer[4] = 'a';`
Anything can happen! If the data written (ie. the “a”) is user input that can be controlled by an attacker, this vulnerability can be exploited: anything that the attacker wants can happen.  
The solution to this problem is check the array bounds at runtime. Unfortunately, C and C++ have not adopted this solution, for efficiency reasons (Ada, Perl, Python, Java, C#, and even Visual Basic have). As a result, buffer overflows have been the number 1 security problem in software ever since.  
Any C(++) code acting on untrusted input is at risk. E.g. code taking input over untrusted network (sendmail, web browser, wireless network driver, ...); code taking input from untrusted user on multi-user system (services running with high privileges, as ROOT on Unix/Linux, as SYSTEM on Windows); code acting on untrusted files that have been downloaded or emailed. Also embedded software, eg. in devices with (wireless) network connection such as mobile phones with Bluetooth, wireless smartcards, airplane navigation systems, ...  

How does **Buffer overflow** work?  
The program is responsible for its memory management. Memory management is very error-prone (segmentation fault etc.).  
Typical bugs: 
- Writing past the bound of an array
– Dangling pointers: missing initialisation, bad pointer arithmetic, incorrect de- allocation, double de-allocation, failed allocation, ...
– Memory leaks

For efficiency, these bugs are not detected at run time, as discussed before: behaviour of a buggy program is undefined.  

Process memory layout
![process memory layout](https://github.com/edoardottt/MSc-CyberSecurity-Sapienza/blob/main/Security-in-Software-Applications/resources/images/03-processmemlayout.png)

What if `gets()` read more than 8 bytes?
![stack overflow](https://github.com/edoardottt/MSc-CyberSecurity-Sapienza/blob/main/Security-in-Software-Applications/resources/images/04-stack-overflow.png)
