# Security in Software Applications - Theory

- [Lesson 1 - Introduction](https://github.com/edoardottt/MSc-CyberSecurity-Sapienza/blob/main/Security-in-Software-Applications/theory.md#lesson-1---introduction)
- [Lesson 2 - Basics](https://github.com/edoardottt/MSc-CyberSecurity-Sapienza/blob/main/Security-in-Software-Applications/theory.md#lesson-2---basics)
- [Lesson 3 - Basics (part 2) and Buffer overflows](https://github.com/edoardottt/MSc-CyberSecurity-Sapienza/blob/main/Security-in-Software-Applications/theory.md#lesson-3---basics-part-2-and-buffer-overflows)
- [Lesson 4 - Format string, Integer overflows and dynamic countermeasures](https://github.com/edoardottt/MSc-CyberSecurity-Sapienza/blob/main/Security-in-Software-Applications/theory.md#lesson-4---format-string-integer-overflows-and-dynamic-countermeasures)
- [Lesson 5 - Buffer overflow defenses and code injection](https://github.com/edoardottt/MSc-CyberSecurity-Sapienza/blob/main/Security-in-Software-Applications/theory.md#lesson-5---buffer-overflow-defenses-and-code-injection)
- [Lesson 6 - Program Analysis](https://github.com/edoardottt/MSc-CyberSecurity-Sapienza/blob/main/Security-in-Software-Applications/theory.md#lesson-6---program-analysis)
- [Lesson 7 - Code Analysis and tools](https://github.com/edoardottt/MSc-CyberSecurity-Sapienza/blob/main/Security-in-Software-Applications/theory.md#lesson-7---code-analysis-and-tools)
- [Lesson 8 - Input validation, Command Injection and SQL Injection](https://github.com/edoardottt/MSc-CyberSecurity-Sapienza/blob/main/Security-in-Software-Applications/theory.md#lesson-8---input-validation-command-injection-and-sql-injection)
- [Lesson 9 - Input Validation (part 2), Race conditions and Security design principles](https://github.com/edoardottt/MSc-CyberSecurity-Sapienza/blob/main/Security-in-Software-Applications/theory.md#lesson-9---input-validation-part-2-race-conditions-and-security-design-principles)
- [Lesson 10 - Security design principles (part 2)](https://github.com/edoardottt/MSc-CyberSecurity-Sapienza/blob/main/Security-in-Software-Applications/theory.md#lesson-10---security-design-principles-part-2)
- [Lesson 11 - Software Security Engineering](https://github.com/edoardottt/MSc-CyberSecurity-Sapienza/blob/main/Security-in-Software-Applications/theory.md#lesson-11---software-security-engineering)
- [Lesson 12 - Secure Software Development Models/Methods](https://github.com/edoardottt/MSc-CyberSecurity-Sapienza/blob/main/Security-in-Software-Applications/theory.md#lesson-12---secure-software-development-modelsmethods)
- [Lesson 13 - Build Security](https://github.com/edoardottt/MSc-CyberSecurity-Sapienza/blob/main/Security-in-Software-Applications/theory.md#lesson-13---build-security)
- [Lesson 14 - Language-based Security. Overview of Types](https://github.com/edoardottt/MSc-CyberSecurity-Sapienza/blob/main/Security-in-Software-Applications/theory.md#lesson-14---language-based-security-overview-of-types)
- [Lesson 15 - Language-based Security. Safety](https://github.com/edoardottt/MSc-CyberSecurity-Sapienza/blob/main/Security-in-Software-Applications/theory.md#lesson-15---language-based-security-safety)
- [Lesson 16 - Java guarantees & aliasing](https://github.com/edoardottt/MSc-CyberSecurity-Sapienza/blob/main/Security-in-Software-Applications/theory.md#lesson-16---java-guarantees--aliasing)
- [Lesson 17 - Program Verification and JML](https://github.com/edoardottt/MSc-CyberSecurity-Sapienza/blob/main/Security-in-Software-Applications/theory.md#lesson-17---program-verification-and-jml)
- [Lesson 18 - Sandboxing](https://github.com/edoardottt/MSc-CyberSecurity-Sapienza/blob/main/Security-in-Software-Applications/theory.md#lesson-18---sandboxing)
- [Lesson 19 - Proof Carrying Code & Information Flow](https://github.com/edoardottt/MSc-CyberSecurity-Sapienza/blob/main/Security-in-Software-Applications/theory.md#lesson-19---proof-carrying-code--information-flow)
- [Lesson 20 - Project SPARTA](https://github.com/edoardottt/MSc-CyberSecurity-Sapienza/blob/main/Security-in-Software-Applications/theory.md#lesson-20---project-sparta)
- Lesson 21 - Code obfuscation
- Lesson 22 - Fuzz testing

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
```Java
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
```

1. *Logic error*: Can be found by code inspection only
2. *Lack of input validation of (untrusted) user*: Design flaw or implementation flaw ?
3. *Problem with interaction with underlying platform*: lower level than previous ones

To prevent standard mistakes we need knowledge and security taken into account from the beginning and throughout the sw. development life cycle. Often organizations tackle security at the end of Sw development life cycle.  
When we write software, we provide some functionalities. These functionalities come with certain risks. Software security is about managing these risks.  
![touchpoints](https://github.com/edoardottt/MSc-CyberSecurity-Sapienza/blob/main/Security-in-Software-Applications/resources/images/01-touchpoints.gif)  
(http://www.swsec.com/resources/touchpoints/)  

## Lesson 3 - Basics (part 2) and Buffer overflows

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

What if `gets()` read more than 8 bytes? (*Never* use `gets()`)
![stack overflow](https://github.com/edoardottt/MSc-CyberSecurity-Sapienza/blob/main/Security-in-Software-Applications/resources/images/04-stack-overflow.png)

**Stack overflow** is the overflow of a buffer allocated on the stack.  
**Heap overflow** idem, of buffer allocated on the heap.  
Common causes:
- poor programming with of arrays and strings (library functions for null-terminated strings
- problems with format strings
- But other low-level coding defects than can result in buffer overflows, eg integer overflows or data races

Example: gets.  
Never use gets. Use `fgets(buf, size, stdin)` instead  
```C
char buf[20];
gets(buf);  // read user input until
            // first EoL or EoF character
```

Example: strcpy.  
strcpy assumes dest is long enough, and assumes src is null-terminated. Use `strncpy(dest, src, size)` instead
```C
char dest[20];
strcpy(dest, src); // copies string src to dest
```

Example:
```C
char buf[20];
char prefix[] = ”http://”;
...
strcpy(buf, prefix);
// copies the string prefix to buf
strncat(buf, path, sizeof(buf));  
// concatenates path to the string buf
// == ERROR ==
// strncat’s 3rd parameter is number of chars to copy, not the buffer size
```

Example:
```C
char src[9];
char dest[9];
char base_url = "www.ru.nl";
strncpy(src, base_url, 9);
// copies base_url to src
// == ERROR ==
// base_url is 10 chars long, incl. its null terminator, so src won’t be null-terminated
strcpy(dest, src);
// copies src to dest
```
Use this if `dest` should be null-terminated!  
```C
strncpy(dest, src, sizeof(dest)-1)
dst[sizeof(dest-1)] = `\0`;
```

Example:
```C
char *buf;
int i, len;
read(fd, &len, sizeof(len));
// read sizeof(len) bytes, ie. an int and store these in len
// == ERROR ==
// We forget to check for bytes representing a negative int, so len might be negative
buf = malloc(len);
// == ERROR ==
// no space for null-terminating char
read(fd,buf,len);
// == ERROR ==
// len cast to unsigned and negative length overflows. read then goes beyond the end of buf
```

In programming languages with “security” provisions, the programmer would not have to worry about
- writing past the bounds of the array (IndexOutOfBoundsException for example)
- implicit conversion from signed to unsigned integers (forbidden or warned by compiler/typechecker)
- malloc returning null value (OutOfMemoryException for example)
- malloc non initializing memory (by default)
- integer overflow (IntegerOverflowException for example)

Example:
```C
#ifdef UNICODE
#define _sntprintf _snwprintf
#define TCHAR wchar_t
#else
#define _sntprintf _snprintf
#define TCHAR char
#endif

TCHAR buff[MAX_SIZE];
_sntprintf(buff, sizeof(buff), ”%s\n”, input);
// == ERROR ==
// _snwprintf’s 2 nd param is # of chars in buffer, not # of bytes
// CodeRed worm exploited su ch an ANSI/Unicode mismatch
```

Example:
The integer overflow is the root problem, but the (heap) buffer overflow that this enables make it exploitable
```C
#define MAX_BUF = 256

void BadCode (char* input) {
    short len;
    char buf[MAX_BUF];
    len = strlen(input);
    // == ERROR ==
    // What if input is longer than 32K?
    // len will be a negative number, due to integer overflow
    if (len < MAX_BUF) strcpy(buf,input); // ... hence: potential buffer overflow
}
```

Example:
```C
bool CopyStructs(InputFile* f, long count) {
    structs = new Structs[count];
    // == ERROR ==
    // effectively does a malloc(count*sizeof(type)) which may cause integer overflow
    for (long i = 0; i < count; i++)
        { if !(ReadFromFile(f,&structs[i])))
            break;
    }
}
```

Example:
```C
char buff1[MAX_SIZE], buff2[MAX_SIZE];
// make sure url a valid URL and fits in buff1 and buff2:
if (! isValid(url)) return;
if (strlen(url) > MAX_SIZE – 1) return;
// copy url up to first separator, ie. first ’/’, to buff1
// == ERROR ==
// length up to the first null
out = buff1;
do {
    // skip spaces
    if (*url != ’ ’) *out++ = *url;
} while (*url++ != ’/’);
// == ERROR ==
// what if there is no ‘/’ in the URL?
strcpy(buff2, buff1);
...
```

## Lesson 4 - Format string, Integer overflows and dynamic countermeasures

**Format string attacks**  
Complete new type of attack, invented/discovered in 2000. Like integer overflows, it can lead to buffer overflows.
Strings can contain special characters, eg %s in `printf(“Cannot find file %s”, filename);`  
Such strings are called format strings. What happens if we execute the code below?  
`printf(“Cannot find file %s”);`  
What may happen if we execute printf(string) where string is user-supplied ? (if it contains special characters, eg `%s`, `%x`, `%n`, `%hn`?)  

- `%x` reads and prints 4 bytes from stack. This may leak sensitive data.  
- `%n` writes the number of characters printed so far onto the stack. This allow stack overflow attacks...
- Note that format strings break the **don’t mix data & code** principle.
- Easy to spot & fix: replace `printf(str)` by `printf("%s", str)`
 
Dynamic countermeasures protection by kernel (Doesn't prevent against heap overflows)
- non-executable memory (NOEXEC). Prevents attacker executing her code
- address space layout randomisation (ASLR). Generally makes attacker's life harder
- instruction set randomisation. Hardware support needed to make this efficient enough.
 
Protection inserted by the compiler
- stack canaries to prevent or detect malicious changes to the stack; examples to follow
- obfuscation of memory addresses

Dynamic countermeasure: **stack canaries**
- introduced in StackGuard in gcc
- a dummy value (stack canary or cookie) is written on the stack in front of the return address and checked when function returns
- a careless stack overflow will overwrite the canary, which can then be detected.
- a careful attacker can overwrite the canary with the correct value.

Additional countermeasures:
– use a random value for the canary
– XOR this random value with the return address
– include string termination characters in the canary value

IMPORTANT. None of these protections is perfect!
- even if attacks to return addresses are caught, integrity of other data other the stack can still be abused
- clever attacks may leave canaries intact
- where do you store the "master" canary value, a cleverer attack could change it
- none of this protects against heap overflows, eg buffer overflow within a struct...

We can take countermeasures at different points in time: before we even begin programming, during development, when testing, when executing code.  
To prevent, to detect (at (pre)compile time or at runtime), and to migitate problems with buffer overflows.  Don't use C or C++.

Dangerous C system calls
![dangerous C system calls](https://github.com/edoardottt/MSc-CyberSecurity-Sapienza/blob/main/Security-in-Software-Applications/resources/images/05-dangerous-C-syscall.png)  
(Building secure software, J. Viega & G. McGraw, 2002)  

There is a choice between using statically vs dynamically allocated buffers
- static approach easy to get wrong, and chopping user input may still have unwanted effects
- dynamic approach susceptible to out-of-memory errors, and need for failing safely

**Better string libraries**
- `libsafe.h` provides safer, modified versions of eg strcpy. Prevents buffer overruns beyond current stack frame in the dangerous functions it redefines
- `libverify` enhancement of libsafe. Keeps copies of the stack return address on the heap, and checks if these match
- `strlcpy(dst,src,size)` and `strlcat(dst,src,size)` with size the size of dst, not the maximum length copied. Consistently used in OpenBSD
- `glib.h` provides Gstring type for dynamically growing null-terminated strings in C, but failure to allocate will result in crash that cannot be intercepted, which may not be acceptable
- `Strsafe.h` by Microsoft guarantees null-termination and always takes destination size as argument
- C++ string class, but data() and c-str() return low level C strings, ie char*, with result of data() is not always null-terminated on all platforms...

**Detection before shipping**
- Testing
    - Difficult! How to hit the right cases?
    - Fuzz testing (test for crash on long, random inputs) can be succesful in finding some weaknesses
- Code reviews. Expensive & labour intensive
- Code scanning tools (aka static analysis). E.g.
    - RATS (), also for PHP, Python, Perl
    - Flawfinder , ITS4 , Deputy , Splint
    - PREfix, PREfast by Microsoft 
    - Plus other commercial tools (Coverity, Parasoft, Klockwork...)
- Bounds Checkers
    - add additonal bounds info for pointers and check these at run time
    - e.g. Bcc, RTcc, CRED ...
    - RICH prevents integer overflows
- Safe variants of C
    - adding bound checks, but also type checks and more: eg garbage collection or region-based memory management) 
    - Cyclone, CCured, Vault, Control-C, Fail-Safe C ...
- Program verification
    - proving by mathematical means (e.g. Hoare logic) that memory management of a program is safe, but extremely labour intensive.
- Reducing attack surface
    - Not running or even installing certain software, or enabling all features by default, mitigates the threat

General Summary: Buffer overflow is an instance of three more general problems:
- lack of input validation
- mixing data & code
    - data and return address on the stack 
- believing in & relying on an abstraction
    - in this case, the abstraction of procedure calls offered by C

There are more ideas to prevent buffer overflows attacks (StackGuard, SSP, /GS...) based on protecting the memory, make it read-only, or make read-only justthe return address and so on. But the main cause of buffer overflows is not the memory management, but the function pointers. To bypass these protections we can just write a function pointer with another malicious function pointer; e.g. we find a function pointer stored in the stack and we overwrite it with another one, so the destination function will be called. Of course we have to make sure we are not overriding the canary value.  

**Integer overflow**  
In mathematics, integers form an infinite set, but in systems they are binary strings of fixed length (precision), so a finite set.
Familiar rules of arithmetic do not apply.
In unsigned 8-bit integer arithmetic
- 255+1= 0,
- 16 X 17=16 and
- 0-1=255

In particular, a negative value (as in 3.) can be interpreted as a ‘large’ positive one and this can break the checks if they use that value to make comparisons. 

Example:
```C
char buf [128]
combine(char *s1, size_t len1, char *s2,size_t, len2) {
    if (len1+len2+1 <= sizeof(buf)) {
        strncpy(buf, s1, len1);
        strncat(buf, s2, len2); 
    }
}
```
The system could be attacked by constructing s1 so that len1 <= sizeof(buf) and set len2=`0xFFFFFFFF` (as unsigned integer, it corresponds to 4294967295). Now, since len1+0xFFFFFFFF+1 = len1 <=sizeof(buf)) the strncat is executed and the buffer overrun.  

Example:
```C
int main(int argc, char* argv[]) {
    char _t[10]
    char p[]="xxxxxxx";
    char k[]="zzzz";
    strncpy(_t, p, sizeof(_t);
    strncat(_t, k, sizeof(_t) – strlen(_t)-1);
    return 0;
}
```
After execution, the resulting string in \_t is xxxxxxxzz; Now if we supply 10 chars in p (xxxxxxxxxx), then sizeof(\_t) and strlen(\_t) are equal and the third argument is -1. Since strncat expects unsigned as third argument, it is interpreted as 0xFFFFFFFF and therefore the strcat is unbounded and the buffer overrun again.

## Lesson 5 - Buffer overflow defenses and code injection

Kinds of Defenses:
- Better software engineering practices
- Find-and-patch methods
- Language tools
- Analysis tools
- Compiler tools
- Operating system tools

Testing: Execution of the software with selected data.  
Code Inspection: Inspection of the code by humans with a checklist to make sure the code meets certain criteria.  
Documentation of vendor code: Documentation of vendor code components that others may reuse in their own projects.  

**Testing**:  
- Pros:
    - Good testing practices should catch most buffer overflows
- Cons:
    - Time is money, sometimes it is a more economically sound solution to allow buffer overflows than to find them
    - When using vendor software, you cannot white-box test software that you do not have the source code or the documentation for
    - Data corruption is harder to detect than abnormal program behavior without dynamic analysis tools

**Code inspection**:  
- Pros:
    - Code inspection may catch many buffer overflows that testing won't
- Cons:
    - Time is money
    - When using vendor software, you cannot do a code inspection if you do not have the source code

**Documentation**:  
- Pros:
    - Good documentation of reusable software components will allow people who use your code in their own projects to test and inspect it
- Cons:
    - Time is money, and the cost of documenting the code gets passed on to the customers
    - Often software companies do not want to release the source code for libraries that they sell

**Find and Patch methods**:  
- Software patches: Released by vendors when a security problem in their software is found, to fix the vulnerability.  
    - Pros:
        - Very effective at preventing known buffer overflow attacks for specific vulnerabilities
    - Cons:
        - No protection against unknown attacks or known attacks for which a patch has not been released
        - Not all patches fix the buffer overflow, some are specific to one attack but leave the buffer overflow itself in place
        - The customer must regularly check for patches for their system (at the vendor’s website or www.cert.org) and install them.
- Programs that block known attacksPrograms that keep a list of known attacks and watch for those attacks on your system.  
    - Pros:
        - Very effective against specific attacks that are known
    - Cons:
        - Not effective against unknown attacks or attacks for which the anti-virus program does not yet have the signature
        - The program must keep a current list of signatures for known attacks and must be updated regularly

**Language tools**:
- Languages less susceptible to buffer overflows: Languages other than C/C++ that are less susceptible to buffer overflows when used properly.  
    - Pros:
        - Automatic bounds checking makes them less susceptible to the buffer overflow problem
        - Exception handling can greatly ameliorate the problem
    - Cons:
        - Using different languages can increase development cost
        - None of these languages give the programmer access to the machine at a low level
        - None of these languages give you the performance of C/C++, most require distributable run-time environments
        - C/C++ are popular languages that many programmers are familiar with
        - What happens when a string that is too long is entered or an array is referenced out of bounds, is an exception generated, does the buffer grow, does the program just halt, is the user asked to provide different input?
        - Programmer still must be aware of buffer overflows to provide exception handlers to do what they want (Exception handling comes with its own set of problems)
- Languages based on C: Languages like Cyclone that were designed with preventing buffer overflows in mind.  
    - Pros:
        - The transition from C to Cyclone is an easy one because Cyclone is nearly identical to C
    - Cons:
        - Existing C source code must be recompiled and probably modified
        - Code ported to Cyclone must be debugged, and gdb (a commonly used UNIX-based debugger) does not work well with Cyclone
        - Using pointers in Cyclone is considerably more complicated than using pointers in C ('*' is replaced with '*', '@', and '?')
        - Cyclone does not provide object-oriented features
- "Safe" buffers: Buffers that automatically truncate inputs, generate exceptions, grow bigger.  
    - Pros:
        - Much safer than standard string handling in C
        - Exceptions can be handled instead of a program halt
    - Cons:
        - Require the use of different library functions, meaning that existing code has to be modified or interfaced with in a low-level way
        - A "limitless" string has to continually be reallocated meaning a bigger heap and a performance cost
        - What if you do not want the buffer to grow and accept a bigger input?
- Safer library functions: Library functions that are less susceptible to buffer overflows than the standard C library.  
    - Pros:
        - Eliminates problems with unsafe library function calls in C/C++
    - Cons:
        - Existing code has to be modified
        - Programmers have to become familiar with a different set of libraries
        - Often string and memory handling libraries are replaced, but not standard library functions specific to an operating system, like file handling and environment variable functions which can also lead to buffer overflows
        - Not all buffer overflows are caused by library functions
        - What happens when a buffer’s limit is reached? Does the program halt? Is the string truncated? Is an exception generated?

**Analysis tools**:  
- *Static*: e.g. Software that searches source code for unsafe library function calls like ITS4
    - Pros:
        - Can be a very effective tool during code inspection by finding unsafe library function calls and making recommendations
    - Cons:
        - Only effective against buffer overflows caused by unsafe standard C library function calls
        - Produces many false positives, only a fraction of the library function calls that are reported are actually unsafe
- *Dynamic*: e.g. Tools that analyze memory use of a program during testing, like Purify
    - Pros:
        - Can detect buffer overflows that occur during testing
        - Sometimes testing will not catch buffer overflows where data is corrupted but program behavior is not affected, dynamic analysis will
    - Cons:
        - Buffer overflows that lead to erratic program behavior can usually be found during testing without dynamic analysis tools

**Compiler tools**:  
- Add bounds checking to all buffers. E.g. Attempts to add bounds checking to gcc.  
    - Pros:
        - Does not require modification of the source code, although you do still have to recompile
    - Cons:
        - Very significant decrease in performance, code size and execution time can double
        - All of the programs that a systems administrator wants to protect must be recompiled
        - Cannot prevent every possible buffer overflow
- Protect the return pointer on the stack. E.g. Placing a canary on the stack to detect buffer overflows such as StackGuard, or adding automatic bounds checking for all strings on the stack like libsafe  
    - Pros:
        - Does not require that existing code be modified (although it sometimes must be recompiled)
        - Will effectively prevent stack smashing attacks
    - Cons:
        - Not all buffer overflow attacks are stack smashing attacks, program execution can be hijacked using heap-based attacks and data can always be corrupted
        - Significant performance overhead
        - StackGuard causes the program to halt upon detection of a buffer overflow leaving it open to denial-of-service attacks
        - StackGuard requires that the target program to be protected is recompiled, libsafe doesn’t

**Operating system tools**:  
- Disable execution of code outside the code space. It is possible on some architectures to distinguish between code and data, and not allow data to be executed as code.
    - Pros:
        - Currently, the most common and most devastating buffer overflow exploit is stack smashing and this patch makes stack smashing much more difficult
        - Does not require that existing software be modified or recompiled
        - A zero byte in the address of a system call forces the attacker to have a null character in the attack string
    - Cons:
        - Does not prevent all stack smashing attacks, often attack code can be placed in global variables or on the heap, or library code to spin a shell already exists in the code space (i.e., system() or execv())
        - Crashing still leaves programs open to denial-of-service and core dump attacks
        - A null character in just the right place in an attack string is not always impossible for an attacker to accomplish, and they can always jump to a small piece of code in variable space that contains a second jump to the desired location
        - Some legitimate programs execute code on the stack, but very few, and there is a work- around for this
- Intrusion detection systems. These are programs that watch for abnormal behavior or behavior that is similar to attack behavior.
    - Pros:
        - Could be able to detect a variety of hijacking attacks, not just stack smashing
        - Could be able to detect many attacks on unknown vulnerabilities
    - Cons:
        - Intrusion detection is a developing technology
        - The offending process will probably be killed, leaving it open to a denial-of-service attack
- Generation of an interrupt. With hardware support it is possible to set bounds on a buffer and generate an interrupt when an attempt is made to access or change memory outside those bounds.
    - Pros:
        - Would prevent many buffer overflows if done properly
    - Cons:
        - Pointer arithmetic would still be unbounded as a pointer might be pointing to an array of 100 bytes, and array of 50 bytes, or to the 40 th byte of an array of 50 bytes
        - Programmers would still have to be educated about buffer overflows because they need to write an interrupt handler to do what they want it to (halt, truncate the buffer, ask the user for different input?)

**(Code injection) Format string attack**  
In C, you can print using a format string: `printf(const char *format, ...);`, `printf(“Mary has %d cats”, cats);`.  
- `%d` specifies a decimal number (from an int)
- `%s` would specify a string argument
- `%x` would specify an unsigned uppercase hexadecimal (from an int)
- `%f` expects a double and converts it into decimal notation, rounding as specified by a precision argument
- ...

It is a fundamental C problem, there is no way to count arguments passed to a C function, so missing arguments are not detected. Format string is interpreted: it mixes code and data.  
What happens if the following code is run? 
```C
int main {
    printf("Mary has %d cats.");
}
```
Result: `Mary has -1073742416 cats`

The program reads missing arguments off the stack! And gets garbage (or interesting stuff if you want to probe the stack).  
What happens if the following code is run, assuming there is an argument input by a user?
```C
int main(int argc, char *argv[]) {
    printf(argv[1]);
    exit(0);
}
```
Try it and input `%s%s%s%s%s%s%s%s%s%s`. How many `%s` arguments do you need to crash it?  
The program will be terminated by OS. Segmentation fault, bus error, etc... because the program attempted to read where it was not supposed to. User input is interpreted as string format (e.g., %s, %d, etc...). Anything can happen, depending on input!  
How you should correct the program: `printf("%s", argv[1]);`  
Discovered relatively recently (~2000), it is a limitation of C family languages. It can affect various memory locations, can be used to create buffer overflows, can be used to read the stack. Not straightforward to exploit, but examples of root compromise scripts available on the web.  
A format string vulnerability is a call to a function with a format string argument, where the format string is either:  
- Possibly under the control of an attacker
- Not followed by appropriate number of arguments

Difficult to establish whether a data string could possibly be affected by an attacker; considered very bad practice to place a string to print as the format string argument. Sometimes the bad practice is confused with the actual presence of a format string vulnerability.  
Some functions using Format Strings: `printf` (prints to "stdout" stream), `fprintf` (prints to stream), `warn` (standard error output), `err` (standard error output), `setproctitle` (sets the invoking process's title), `sprintf` (char \*str, const char \*format, ...);  
A possible attack: `%n` format command writes a number to the location specified by argument on the stack. The argument is treated as int pointer. Often either the buffer being written to, or the raw input, are somewhere on the stack. Attacker controls the pointer value! Writes the number of characters written so far. Keeps counting even if buffer size limit was reached! E.g.: `"Count these characters %n"`.  

Preventing format string vulnerabilities:  
- Always specify a format string
    - Most format string vulnerabilities are solved by specifying `"%s"` as format string and not using the data string as format string
- If possible, make the format string a constant
    - Extract all the variable parts as other arguments to the call
    - Difficult to do with some internationalization libraries
- If the above two practices are not possible, use runtime defenses such as FormatGuard
    - Rare at design time
    - Perhaps a way to keep using a legacy application and keep costs down
    - Increase trust that a third-party application will be safe
- Pscan searches for format string functions called with the data string as format string (few false positives)

**Goal of Code Injection**:  
Trick program into executing an attacker's code by clever input construction that mixes code and data. Mixed code and data channels have special characters that trigger a context change between data and code interpretation. The attacker wants to inject these meta-characters through some clever encoding or manipulation, so supplied data is interpreted as code.  
Defend against it by using input cleansing and validation; type casts may help if they are possible. Need to keep track of which data has been cleansed, or keep track of all sources of inputs and cleanse as the input is received.  

Basic example:
```Bash
$> cat example
#!/bin/sh
A = $1
eval "ls $A"
```
If the "example" file is executable by anyone and we have confidential files not readable by others we could inject this code: `./example ".;chmod o+r *"`.  
Inside the program, the eval statement becomes equivalent to: `eval "ls .;chmod o+r *"`. Any statement after the ";" would also get executed, because ";" is a command separator. The data argument for "ls" has become code!  

Another Example:
In PHP backticks ``: execution in a command line by command substitution `command` gets executed before the rest of the command line.  
Imagine a program that calls a shell to run grep. What happens when this is run? 
```PHP
eval "grep `./malicious-script` afile"
```
First malicious-script is executed and then the command is executed.  

Another Example:  
```C
int main(int argc, char *argv[], char **envp) {
    char buf [100];
    buf[0] = '\0';
    snprintf(buf,sizeof(buf),"grep %s text",argv[1]);
    system(buf);
    exit(0);
}
```
What happens when we run the following? 
```
$> ./a.out \`./script\`
```
The program calls ```system(“grep `./script` text”);```, can be verified by adding ```"printf( "%s", buf)"``` to the program.  
So we could make a.out execute any program we want. Imagine that we provide the argument remotely, anyone running a.out would run arbitrary code as the owner of a.out. What if a.out runs with root privileges?  

Shell metacharacters:
- \` to execute something (command substitution)
- `;` is a command (“pipeline”) separator
- `&` start process in the background
- `|` is a pipe (connecting standard output to standard input)
- `&&` ,`||` logical operators AND and OR
- `<<` or `>>` prepend, append
- `#` to comment out something
- Refer to the appropriate man page (man csh) for all characters

**Defending against Code Injection**  
- Input cleansing and validation
    - Model the expected input (Discard what does not fit (e.g., metacharacters))
    - Keep track of which data has been cleansed (e.g. Perl's taint mode)
    - Keep track of all sources of inputs (or cleanse as the input is received)
- Type and range verification, type casts
- Separating code from data
    - Transmit, receive and manipulate data using different channels than for code

Input Cleansing:  
- Key to preventing code injection attacks
- Common problem where code is generated dynamically from some data
    - SQL (database Simple Query Language)
    - System calls and equivalents in PHP, Windows CreateProcess, etc...
    - HTML may contain JavaScript (Cross-site scripting vulnerabilities)

Intuitive Approach:  
Block or escape all metacharacters, but what are they? Problems:  
- Character encodings
    - octal, hexadecimal, UTF-8, UTF-16, binary, Base-64, URL encoding, ...
- Obfuscation
    - Escaped characters that can get interpreted later
- Engineered strings such that by blocking a character, something else is generated

Wrong way to cleanse input:  
```C
int main(int argc, char *argv[], char **envp) {
    static char bad_chars[] = "/ ;[]<>&\t";
    char *user_data;
    char *cp;
    /* Get the data */
    user_data = getenv("QUERY_STRING");
    /* Remove bad characters. WRONG! */
    for (cp = user_data; *(cp += strcspn(cp,bad_chars));
    /* */)
    *cp = '_';
    ...    
```

Another wrong way to cleanse input:  
```C
(...)
    strcpy(commandstr, "/usr/local/bin/ph -m ");
    escape_shell_cmd(serverstr);
    strcat(commandstr, serverstr);
    (...)
    phfp = popen(commandstr,"r");
(...)
void escape_shell_cmd(char *cmd) {
    (...)
    if(ind("&;`'\"|*?~<>^()[]{}$\\" ,cmd[x]) != -1){
    (...)
}
```
Author forgot to list newlines in "if" statement. *Exploit*: input "newline" (`\n`) and the commands you want executed...

Defense: Input Sanitization  
- Do not attempt to list all forbidden characters
    - It is easy to forget and and one missed character leads to defeat
- Make a list of all allowed characters
    - Without metacharacters
- Convert to a variable of numerical type, if a number is expected
- Truncate input strings if the expected length is known

Order for Cleansing and Input Validation:  
1) Resolve all character encoding issues first
2) Cleanse
    - If combinations of characters can produce metacharacters, you may need to do several passes. Example: "a" and "b" are legal if separated from each other, but "ab" is considered a metacharacter. The character "d" is not allowed. After you filter out "d" from "adb", you may be allowing "ab" through the filter!
3) Validate type, range, and format
4) Validate semantics (i.e., meaning of input)

## Lesson 6 - Program Analysis

Refer to the slides of the course for this topic.

## Lesson 7 - Code Analysis and tools

**Types of analysis**:  
- Static analysis: Approach for verifying software (including finding defects) without executing software
    - Source code vulnerability scanning tools, code inspections, etc.
- Dynamic analysis: Approach for verifying software (including finding defects) by executing software on specific inputs and checking results ("oracle")
    - Functional testing, fuzz testing, etc.
- Hybrid analysis: Combine above approaches
- Operational: Tools in operational setting
    - Minimize risks, report information back, etc.
    - may be static, dynamic, hybrid; often dynamic

| Analysis/tool report | Report correct | Report incorrect | 
| ------ | ------ | ------ |
| Reported a defect | **True positive (TP)**: Correctly reported a defect | **False positive (FP)**: Incorrect, it reported a "defect" that's not a defect | 
| Did not report a defect | **True negative (TN)**: Correctly did not report a (given) defect | **False negative (FN)**: Incorrect because it failed to report a defect |

- False positive rate: `FPR = #FP / ( #TP + #FP )`, the probability that an alert is false
- True positive rate: `TPR = #TP / ( #TP + #FN )`, percentage of vulnetabilities found
- Developers worry about large false positive rate (the tool makes waste my time)
- Auditors worry about small or <100% TPR for a given category (the tool missed something important)

Binary classifiers must generally trade off between FP rates and TP rates  
To get more reports (larger TP rate), must accept larger FP rate. What’s more important to you, low FP rate or high TP rate?  

See https://samate.nist.gov/docs/CAS_2011_SA_Tool_Method.pdf

Some tool information sources:
- Software SOAR (“State-of-the-Art Resources (SOAR) for Software Vulnerability Detection, Test, and Evaluation”) by David A. Wheeler and Rama S. Moorthy, IDA Paper P-5061
    - http://www.acq.osd.mil/se/docs/P-5061-software-soar-mobility-Final-Full-Doc-20140716.pdf
    - “Appendix E” has a large matrix of different types of tools
- NIST SAMATE (http://samate.nist.gov)
    - “Classes of tools and techniques”: http://samate.nist.gov/index.php/Tool_Survey.html
    - Can test tools using Software Assurance Reference Dataset (SARD), formerly known as the SAMATE Reference Dataset (SRD). It’s a set of programs with known properties: http://samate.nist.gov/SARD/
- Build security in (https://buildsecurityin.us-cert.gov)
    - Software Assurance (SwA) Technology and tools working group
    - Overview of SwA tools: https://buildsecurityin.us-cert.gov/swa/swa_tools.html
    - NAVSEA “Software Security Assessment Tools” https://buildsecurityin.us-cert.gov/swa/downloads/NAVSEA-Tools-Paper-2009-03-02.pdf
- NSA Center for Assured Software (CAS)
- OWASP (https://www.owasp.org)

Static analysis: Source vs. Executables
- Source code pros:
    - Provides much more context; executable-only tools can miss important information
    - Can examine variable names and comments (can be very helpful!)
    - Can fix problems found (hard with just executable)
    - Difficult to decompile code
Source code cons:
    - Can mislead tools; executable runs, not source (if there’s a difference)
    - Often cannot get source for proprietary off-the-shelf programs
        - Can get for open source software
        - Often can get for custom
- Bytecode is somewhere between

(Some) Static analysis approaches:
- Human analysis (including peer reviews)
- Type checkers
- Compiler warnings
- Style checkers / defect finders / quality scanners
- Security analysis (text scanners and beyond)
- Property checkers
- Knowledge extraction
- formal methods (separately)

Human (manual) analysis:
Humans are great at discerning context and intent, but get bored and overwhelmed. They are expensive, especially if analyzing executables. Can be one person, e.g. "desk-checking". Can focus on specific issues e.g. "Is everything that’s supposed be authenticated covered by authentication processes?"  

Automated tool limitations:
- Tools typically don’t "understand":
    - System architecture
    - System mission/goal
    - Technical environment
    - Human environment
- Except for formal methods...
    - Most have significant FP and/or FN rates
- Best when part of a process to develop secure software, not as the only mechanism

Typical static analysis tool:  
![tsat](https://github.com/edoardottt/MSc-CyberSecurity-Sapienza/blob/main/Security-in-Software-Applications/resources/images/06-tsat.png)  

Many static analysis tools' focus is other than security, may look for generic defects, or focus on "code cleanliness" (maintainability, style, “quality”etc.), but some defects are security vulnerabilities. Reports that clean code is easier for other (security-specific) static analysis to analyze (for fewer false positives/negatives). Probably easier for humans to review too; no hard evidence, some would be welcome! Such tools often faster, cheaper and easier (many do not need to do whole-program analysis). Such tools may be useful in reducing as a precursor step before using security-specific tools. For Java users: Consider quality scanners FindBugs or PMD.  

**Type checkers**  
- Many languages have static type checking built in
    - Some more rigorous than others
    - C/C++ not very strong (and must often work around)
    - Java/C# stronger (interfaces, etc., ease use)
- Can detect some defects before fielding
    - Including some security defects
    - Also really useful in documenting intent
- Work with type system – be as narrow as you can
    - Beware diminishing returns

Compiler warnings: Not security-specific but useful. Where practical, enable compiler/interpreter warnings and fix anything found. Turn on run-time warnings too: May detect security vulnerabilities.  

Style checkers/Defect finders/Quality scanners
- Compare code (usually source) to set of pre-canned “style” rules or probable defects
- Goal:
    - Make it easier to understand/modify code
    - Avoid common defects/mistakes, or patterns likely to lead to them
- Some try to have low FP rate
    - Don’t report something unless it’s a defect

Security defect text scanners
- Scan source code using simple grep-like lexer
    - Typically "know" about comments and strings
    - Look for function calls likely to be problematic
- Examples: RATS, ITS4, Flawfinder (D.A.Wheeler)
- Pros:
    - Fast and cheap
    - Can process partial code (including un-compilable code)
- Cons:
    - Lack of context leads to large FN & FP rates
    - Useful primarily for warning of "dangerous" functions

Security defect finders
- Read software and create internal model of software
- Look for patterns likely to lead to security defects
- Examples
    - Proprietary: HP/Fortify, Coverity
    - OSS: splint (for C), LAPSE+ (for Java)

**Analysis approach: Examining structure / method calls**  
Example: Warn about calls to gets(): FunctionCall: function is `name == "gets"`.  

**Analysis Approach: Data flow - Taint propagation**  
- Many tools (static and dynamic) perform "taint propagation"
    - Input from untrusted users ("sources") considered "tainted"
    - Warn/forbid sending tainted data to certain methods and constructs ("sinks")
    - Some operations (e.g. checking) may "untaint" data 
- Static analysis:
    - Follow data flow from sources through program
    - Determine if tainted data can get to vulnerable "sink"
- Dynamic analysis (e.g. Perl, Ruby):
    - Variables have "taint" value set when input from some sources
    - Certain operations (sinks) forbid direct use of tainted data
        - Counters accidental use of untrusted and unchecked data
        - esp. useful on injection (SQL, command) and buffer overflow

Example (Taint Propagation): 
```Java
buffer = getUntrustedInputFromNetwork(); // Source
copyBuffer(newBuffer, buffer); // Pass-through
exec(newBuffer); // Sink
```

**Property checkers**  
- "Prove" that a program has very specific narrow property
- Typically focuses on very specific temporal safety, e.g.:
    - "Always frees allocated memory"
    - "Can never have livelock / deadlock"
- Many strive to be sound ("reports all possible problems")
- Examples: GrammaTech, GNATPro Praxis, Polyspace

**Knowledge extraction / program understanding**  
- Create view of software automatically for analysis
    - Especially useful for large code bases
    - Visualizes architecture
    - Enables queries, translation to another language
- Examples:
    - Hatha Systems’ Knowledge Refinery
    - IBM Rational Asset Analyzer (RAA)
    - Relativity MicroFocus (COBOL-focused)

Done with static analysis, we start talking about dynamic analysis. There is one huge problem here, the fact that we can't test all the possible inputs: Given a trivial program like "Add two integers", we have: Input space = `(2^64)*(2^64) = 2^128 possibilities`. This could take up to ~10^15 years.  
Security (and safety) requirements often have the form "X never happens" (negative requirement). Easier to show there is at least one case where something happens than to show it never happens.  

Functional testing for security
- Use normal testing approaches, but add tests for security requirements
    - Test both "should happen" and "should not happen"
    - Often people forget to test what "should not happen"
        - "Can I read/write without being authorized to do so?"
        - "Can I access the system with an invalid certificate?"
- Branch/statement coverage tools may warn you of untested paths
- As always, automate and rerun

**Web application scanners**  
- Attempt to go through the various web forms and links
- Send in attack-like and random data
    - Key issues: Input vector (Query string? HTTP body? JSON? XML?), scan barrier, crawl / input vector extraction, which vulnerabilities it detects (and how well)
    - Often build on "fuzzing" techniques (discussed next)

**Fuzz testing ("fuzzing")**  
- Testing technique that:
    - Provides (many!) invalid/random input to inputs
    - Monitors program for crashes and other signs of trouble (failing code assertions, appearance of memory leaks)... not if the final answer is "correct" (this process is the "oracle")
- Simplifies "oracle" so can create massive data set
- Do not need source, might not even need executable
- Often quickly finds a number of real defects
    - Attackers use it; do not have easy-to-find vulnerabilities
- Can be very useful for security, often finds problems
- Typically diminishing rate of return

**Fuzz testing variations: Input**  
- Test data creation approaches:
    - Mutation based: mutate existing samples to create test data
    - Generation based: create test data based on model of input
        - Including fully random, but that often has poorer coverage
    - May try to create "likely security vulnerability" patterns (e.g. metachars) to increase value
- May concentrate on mostly-valid or mostly-invalid
- Type of input data: File formats, network protocols, environment variables, API call sequences, database contents, etc.
- Input selection may be based on other factors, including info about program (e.g., uncovered program sections)

**Fuzz testing variations: oracle**  
- Originally, just "did it crash / hang"?
- Adding program assertions (enabled!) can reveal more
- Test other "should not happen"
    - Ensure files/directories unchanged if shouldn’t be
    - Memory leak (e.g., valgrind)
    - Invalid memory access, e.g. using AddressSanitizer (aka ASan) for C/C++/Objective-C to detect buffer overflows and double-frees
    - More intermediate (external) state checking
    - Final state "valid" (!= "correct")

**Fuzz testing: Problems**  
- Fully random often does not test much
    - e.g. if input has a checksum, fuzz testing ends up primarily checking the checksum algorithm
- Fuzz testing only finds "shallow" problems
    - Special cases ("if (a == 2) ...") rare in input space
    - Sequence of rare-probability events by "random" input will typically not be covered by testing
    - Can modify generators to increase probability... but you have to know very specific defect pattern before you find defect
    - In general, only a small amount of program gets covered
- Once defects found by fuzz testing fixed, fuzz testing has a quickly diminishing rate of return
    - Fuzz testing is still a good idea… but not by itself

Done with dynamic analysis, we start talking about hybrid analysis. Hybrid means combining both static and dynamic analysis. The historical common hybrid approach is "Coverage measure". This approach measures how well program has been tested in dynamic analysis.  
Two common coverage for dynamic testing:
- Statement coverage: Which (%) program statements have been executed by at least one test?
- Branch coverage: Which (%) program branch options have been executed by at least one test?

**Penetration testing**  
- Pretend to be adversary, try to break in
- Depends on the skills of pentesters
- Need to set rules-of-engagement (RoE)
    - Problem: RoE often unrealistic
- Really a combination of static and dynamic approaches

Remember, a fool with a tool is still a fool.

## Lesson 8 - Input validation, Command Injection and SQL Injection

Lack of input validation is the most commonly exploited vulnerability. Many variants of attacks that exploit this: buffer overflows, command injection, SQLi, XSS... 

**Command Injection**  
- A CGI script might contain
    - `cat thefile | mail clientaddress`
- An attack might enter email address
    - `pippo@di.uniroma1.it | rm -rf /`
- What happens then ?
    - `cat thefile | mail pippo@di.uniroma1.it | rm -rf /`

Can you think of countermeasures ?
- validate input
- reduce access rights of CGI script (defense in depth)
- maybe we shouldn’t use such a scripting languages for this?

Code that uses the system interpreter to print to a user-specified printer might include
```C
char buf[1024];
snprintf(buf, "system lpr –P %s", printer_name, sizeof(buf)-1);
system(buf);
```
This can be attacked in the same way; entering `miro;xterm&` is less destructive and more interesting than `...;rm –fr /`  
Vulnerability: many API calls and language constructs in many languages are affected, e.g.
- C/C++ `system()`, `execvp()`, `ShellExecute()`, ...
- Java `Runtime.exec()`, ...
- Perl `system`, `exec`, `open`, \`, `/e`, ...
- Python `exec`, `eval`, `input`, `execfile`, ...
- ...
- Countermeasures
    - validate all user input
    - whitelist, not blacklist
- run with minimal privilige. Doesn't prevent, but mitigates effects  

**SQL Injection**  
The ability to inject SQL commands into the database engine through an existing application. It is a flaw in "web application" development, it is not a Database or web server problem. SQL stands for Structured Query Language and allows us to access a database. SQL can: execute queries against a database, retrieve, insert, delete and update records in a database. There are many different versions of the SQL language. They support the same major keywords in a similar manner (such as SELECT, UPDATE, DELETE, INSERT, WHERE, and others). Most of the SQL database programs also have their own proprietary extensions in addition to the SQL standard! A relational database contains one or more tables identified each by a name and tables contain records (rows) with data. With SQL, we can query a database and have a result set returned. We can divide the SQL language in two parts: Data Definition Language (DDL) and Data Manipulation Language (DML).  
How does SQLi work?  
Common vulnerable login query
```Java
var sql = "SELECT * FROM users WHERE login = '" + formusr + "' AND password = '" + formpwd + "'";
```
Injecting : formusr = `' or 1=1 ––` and formpwd = `anything`
```SQL
SELECT * FROM users WHERE username = '' or 1=1 -- AND password = 'anything'
```
The power of `'`: It closes the string parameter. Everything after is considered part of the SQL command. String fields are very common but there are other types of fields: Numeric, Dates ...  
For the numbers it's the same: Injecting formacct = `1 or 1=1 --`.  
Input validation circumvention and IDS Evasion techniques are very similar and rely on "signatures". Signatures can be evaded easily. Input validation, IDS detection AND strong database and OS hardening must be used together.  
Some IDS Signature Evasion:
- `' OR 'unusual' = 'unusual'`
- `' OR 'something' = 'some'+'thing'`
- `' OR 'text' = N'text'`
- `' OR 'something' like 'some%'`
- `' OR 2 > 1`
- `' OR 'text' > 't'`
- `' OR 'whatever' IN ('whatever')`
- `' OR 2 BETWEEN 1 AND 3`

SQL Injection Characters
- `'` or `"`: character String Indicators
- `--` or `#`: single-line comment
- `/*…*/`: multiple-line comment
- `+`: addition, concatenate (or space in url)
- `||`: (double pipe) concatenate
- `%`: wildcard attribute indicator
- `?Param1=foo&Param2=bar`: URL Parameters
- `PRINT`: useful as non transactional command
- `@variable`: local variable
- `@@variable`: global variable
- `waitfor delay '0:0:10'`: time delay

IDS and input validation can also be circumvented by encoding: URL encoding, Unicode/UTF-8, Hex enconding, char() function...  
Example: Inject without quotes (string = "root"): `' union select * from users where login = char(114,111,111,116);`  

**Defending against SQL injections**  
- Sanitize all input.
    - Assume all input is harmful.
    - Validate user input that contains dangerous keywords or SQL characters, such as “xp_cmdshell”, “- -”, and “;”.
    - Consider using regular expressions to remove unwanted characters. This approach is safer than writing your own search and replace routines.
- Run with least privilege.
    - Do not execute an SQL SELECT statement as “sa”. Create low-privilege accounts to access data.
    - Use SQL permissions to lock down databases, stored procedures, and tables.
    - Remove unused stored procedures.
- Do not allow clients to view ODBC/OLE DB error messages. Handle these errors with your own code. By default, ASP pages returns error messages to clients.
- Enable logging of all user access, and set alerts to log all failed attempts to access objects.
- Do not use string concatenations to build SQL queries. Instead, use parameterized queries or parameterized stored procedures, because they explicitly define input and output values and do not process multiple statements as a batch.  

Example (Why is it safer? Because the SQL server knows that the value of the parameter is not actual code to execute, but data):  
Replace this
```Java
var sql = "SELECT * FROM users WHERE login = '" + formusr + "' AND password = '" + formpwd + "'";
```
with this
```Java
SqlConnection objConnection=new SqlConnection(_ConnectionString);
objConnection.Open();
SqlCommand objCommand = new SqlCommand( "SELECT * FROM User WHERE login = @Name AND password = @Password", objConnection);
objCommand.Parameters.Add("@Name", NameTextBox.Text);
objCommand.Parameters.Add("@Password", PasswordTextBox.Text);
SqlDataReader objReader = objCommand.ExecuteReader();
if (objReader.Read()) { 
    ...
```

Another Example: Stored procedure in Oracle's PL/SQL
```SQL
CREATE PROCEDURE login
(name VARCHAR(100), pwd VARCHAR(100)) AS
DECLARE @sql nvarchar(4000)
SELECT @sql =' SELECT * FROM Account WHERE
username=' + @name + 'AND password=' + @pwd
EXEC (@sql)
```
called from Java with
```Java
CallableStatement proc =
connection.prepareCall("{call login(?, ?)}");
proc.setString(1, username);
proc.setString(2, password);
```

## Lesson 9 - Input Validation (part 2), Race conditions and Security design principles

**File name injection aka path traversal**  
- user-supplied file name may be
    - existing file: `../../../etc/passwd`
    - not really a file: `/var/spool/lpr`
    - file the user can access in other ways: `/mnt/usbkey`, `/tmp/file`
- this may break
    - confidentiality (leaking information to the user)
    - integrity ( (eg. of file or system)
    - availability (eg. trying to open print device for reading)

Filename Injection: File names constructed from user input (eg by string concatenation) are suspect too. Eg what is `"/usr/local/client-info/" ++ name` if name is `../../../etc/passwd`?  
Directory traversal attack; validating file names is difficult: reuse existing code and/or use chroot jail.  

**General remarks about input validation**  
Input validations problems are the most common vulnerabilities
- Never ever trust any user input
    - Apart from generic risks dicussed so far (command, SQL, XSS, filenames ...), there will be additional input risks specific to an application
- Beware of implicit assumptions on user input
    - eg, that usernames only contain alphanumeric characters
- Think like an attacker!
    - think how you might abuse a system with weird input

**Input validation problems: prevention**  
Find out about potential vulnerabilities: use community resources to find out vulnerabilities of the system/language used; avoid use of unsafe constructs, if possible. Make sure all input is validated at clear choke-points in code when doing input validation. Use white-lists, not black-lists (unless you are 100% sure your black-list is complete). Reuse existing input validation code known to be correct.  
**Input validation problems: detection**  
- Testing, test with inputs likely to cause problems (There are some tools that can help)
    - for buffer overflow, long inputs (fuzzing)
    - for SQL injection, inputs with fragments of SQL commands
    - ...
- Tainting
    - effectively typing, with runtime checking or static analysis (more precisely, data flow analysis)
- Code reviews, possibly using static analysis

Lack of input validation no #1 problem in various guises
- Never trust user input!
- Think about, test, and detect malicious inputs!
- Find out about the vulnerabilities of specific language, platform... and about countermeasures

See https://cwe.mitre.org/data/definitions/1337.html

**Race conditions**  
Two or more processes have access to the same object. Algorithm used by processes does not properly enforce an access order. At least one process modifies the
object. In a pre-emptively multi-tasked environment, anything can happen in-between the execution of two statements. Check if something is OK to do, do it (perhaps the conditions have changed?), Semaphores and locks are mechanisms that prevent concurrent access to, or modification of, an object by different processes. Race condition occurs when a certain condition assumed true does not hold. Window of vulnerability: interval of time when violation of assumption leads to incorrect behavior. Reduce window to zero: make relevant code atomic. An operation that cannot be interrupted with regards to an object is called "atomic". Example in Java: the keyword `synchronized`.  
Effects of race conditions:
- Normally:  
    - race conditions show up as periodic errors 
    - frequency of the error will depend upon how likely the 'bad' order is to occur
    - it is often hard to get race condition errors to repeat
- When exploited:
    - crackers can attempt to force the particular conditions that will produce a flaw
    - depending upon the exact form of the flaw, it may be produced with high probability
    - most common (mis)use: modify the value of some shared object

An example(Between calls to access and open the file might be removed!):
```C
const char *filename="/tmp/erik";
if (access(filename, R_OK)!=0) {
    ... // handle error and exit;
}
// file exists and we have access
int fd open (filename, O_RDONLY);
...
```
Anyway, these types of problems can be avoided using modern programming languages and safe programming desing.

**Security Principles**  
- Variations of lists of security principles appear in literature & on-line (see course website)
- Security vulnerabilities often exploit violations of these principles
- Good security solutions or countermeasures follow these principles
- Some overlap & some tension between principles
- More generally, checklists are useful for security

See http://web.mit.edu/Saltzer/www/publications/protection/index.html

These are some of them:
- secure the weakest link
- defence in depth
- principle of least privilige
- minimise attack surface
- compartmentalize
- secure defaults
- keep it simple
- fail securely
- promote privacy
- hiding secrets is hard
- use community
- resources
- be reluctant to trust
- ...

These principles can be applied at many levels, eg. in source code of a application, between applications on a machine, at OS level, at network level, within an organisation, between organisations, ...  

**Secure the weakest link**  
Spend your efforts on improving the security of the weakest part of a system, as this is where attackers will attack. Educating users may be best investment to improve security. e.g. think of phishing attacks, weak passwords. Web application visible through firewall may be easier to break than the firewall (improve web application security, not the firewall).  
**Practice defence in depth**  
Have several layers of security, two controls are better than one (no single point of failure). A typical violation: having a firewall, and only having firewall (a user bringing in a laptop circumvents firewall, this is an example of enviromental creep).  A typical example: have a firewall *and* secure web application software *and* run web application with minimal priviliges *and* use OS access control to restrict access to sensitive files *and* encrypt them.  
**Principle of least privilege**  
Be stingy with priviliges. Only grant permissions that are really needed, resource permissions (eg memory limits, CPU priorities), network permissions, file permissions... Typical violations: logging in as root/administrator, device drivers having to run in kernel mode. Important cause of violations: laziness.  
In organisation: don’t give everyone access to root passwords, don’t give everyone administrator rights. On computer: run process with minimal set of priviliges.  
Example (Java):
```Java
// not the default policy
grant codeBase "file:${{java.ext.dirs}}/*" {
    permission java.security.AllPermission;
};
// --> but minimum required
grant codeBase "file:./forum/*" {
    permission java.security.FilePermission;
    "/home/forumcontent/*","read/write";
};
```
Still in Java, remember to use `private`, `protected` or `package` instead of `public` when the last one is not needed. Expose minimal functionality in interfaces of objects, classes, packages, applications.  
Applying the principle of least privilige in code is tricky & hard and requires work & discipline.  


## Lesson 10 - Security design principles (part 2)

**Compartmentalize**  
Principle of least privilige works best if access control is all or nothing for large chunks (compartments) of a system. For simplicity and containing attacker in case of failure.  
Examples:
- Use different machines for different tasks (e.g. run web application on a different machine from employee salary database)
- Use different user accounts on one machine for different tasks 
    - unfortunately, security breach under one account may compromise both...
    - compartmentalization provided by typical OSs is poor!
- Partition hard disk and install OS twice
- chroot jail
    - Restricts access of a process to subset of file system, ie. changes the root of file system for that process
    - E.g. run an application you just downloaded with `chroot /home/sos/paperino/trial;/tmp`.
    - Nice idea, but hard to get working, and hard to get working correctly.
- Virtual Machines
- OS Hypervisors
- In code (aka modularisation)
    - using objects, classes, packages, etc.
    - Restrict sensitive operations to small modules, with small interfaces 
        - so that you can concentrate efforts on quality of these modules
        - so that only these have to be subjected to code reviews

**Minimize attack surface**  
Minimize number open sockets, services, services running by default, services running with high priviliges, dynamic content webpages, accounts with administrator rights, files & directories with weak access control and so on...  
Note that applying the principle of least privilege you are at the same time minimizing the attack surface.  
Examples (Minimize attack surface in time):
- Automatically log off users after n minutes
- Automatically lock screen after n minutes
- Unplug network connection if you don’t use it
- Switch off computer if you don’t use it

**Use secure defaults**  
By default, security should be switched on and permissions turned off. This will ensure that we apply principle of least privilige. Counterexample: on bluetooth connection on mobile phone is by default on, but can be abused.  
**Keep it simple**  
Complexity important cause of security problems; complexity leads to unforeseen feature interaction; complexity leads to incorrect use and insecure configuration by users and developers. Note: compartmentalization is a way of keeping access control simple. Eg: good practice: choke point (small interface through which all control flow must pass).  
**Fail securely**  
Incorrect handling of unexpected errors is a major cause of security breaches.  
Counterexamples:
- fallback to unsafe(r) modes on failure
    - sometimes for backward compatibility
    - asking user if security settings can be lowered
- crashing on failure, leading to DoS attack
- leaking interesting information for an attacker

Of course, having exceptions in a programming language has a big impact.  
Example:
```Java
isAdmin = true; // enter Admin mode
try {
    something that may throw SomeException
} catch (SomeException ex) {
    // should we log?
    log.write(ex.toString());
    // how should we proceed?
    isAdmin = false;
    // or should we exit?
}
```
Failing insecurely threats:
- Information leakage
    - about cause of error, which can be exploited
- Ignoring errors
    - Easier in a programming language without exceptions! (e.g. forgetting to check for -1 return value in C)
- Misinterpreting errors
- Useless errors (why does strncopy return an error value at all?)
- Handling wrong exceptions
- Handling all exceptions

**Promote privacy**  
Privacy of users, but also of systems. Examples: telnet or even all SQL errors report an identical, standard error page, without any further info, errors may still leak information. Worse still, response time may still leak information

**It's hard to keep secrets**  
- Don’t rely on security by obscurity
- Don’t assume attackers don’t know the application source code, and can’t reverse-engineer binaries
    - Don’t hardcode secrets in code.
    - Don’t rely on code obfuscation

**Use community resources**  
Use google, books, webforum, etc. to learn & reuse. Learn about vulnerabilities and avoid making the same mistakes. Learn about solutions and countermeasures and reuse them. If security mechanism is too cumbersome, users will switch it off, or find clever ways around it. User education may improve the situation, but only
up to a point. 

**Don't mix data and code**  
This is the cause of many problems, eg
- traditional buffer overflow attacks, which rely on mixing data and code on the stack
- VB scripts in Office documents, leads to attacks by hostile .doc or .xls
- javascript in webpages, leads to XSS (cross site scripting attacks)
- SQL injection relies on use data (user input!) as part of SQL query

**Be reluctant to trust**  
Read "Ken Thompson - Reflections on trusting trust".  
All user input is evil! E.g. unchecked user input leads to
- buffer overflows
- SQL injection
- XSS on websites (maybe better to talk about output sanitization...)

User input includes cookies, environment variables... User input should not be trusted, and subjected to strong input validation checks before being is used. Don’t trust third-party software.  

In short, "Software Design": Determine components (e.g., classes, programming languages, frameworks, database systems, etc.) that you’ll use, and how you’ll use them ( interconnections/APIs ), to solve the problem.  
- There are various key design principles (e.g. Saltzer and Schroeder)
- Need to design program to counterattack, e.g.:
    - Minimize privileges
    - Counter TOCTOU issues
- Use attack/threat modeling to look for potentially-successful attacks
    - Before the attacker tries them
- Many design approaches for self-protection
- Consider principles and rules-of-thumb in design


## Lesson 11 - Software Security Engineering

Software Engineering: Concept of creating and maintaining software applications by applying technologies and practices from computer science and project management fields. (wikipedia)  
Over 30 years of software development experience created a well defined application software development lifecycle.

- REQUIREMENTS
- DESIGN
- IMPLEMENTATION
- TESTING
- DEPLOYMENT
- MAINTENANCE

There are many software development methodologies (ex. XP, waterfall, etc) they all have these basic steps. Capability Maturity Model for Software (SW-CMM) is used to measure quality of methodologies employed.  
This application development process in its essence fails to address security issues. Consequently, security flaws are identified only at the later stages of the application lifecycle. And thus much greater cost to fix, high maintenance cost...  
Nearly every company/organization utilizes network security infrastructure (e.g. Firewalls, IDS, etc), but very small number of them invest in application security strategy, design, and code review services.  
For the software industry, the key to meeting demand for improved security is to implement repeatable processes that reliably deliver measurably improved security. Thus, there must be a transition to a more stringent software development process that greatly focuses on security. Goal: minimize the number of security vulnerabilities in design, implementation, and documentation. Identify and remove vulnerabilities in the development lifecycle as early as possible!!!  
Three essential components
- Repeatable process
- Engineer Education
- Metrics and Accountability

SDL, Secure Development Lifecycle: Used along with traditional/current software development lifecycle/techniques in order to introduce security at every stage of
software development.  

**SDL - Requirements Phase**  
- Development of requirements
    - Gather information about application (customer/experience/survey)
- Analysis of requirements
    - Are all the security issues addressed (C, I, A, ...)
- Verification of requirements
    - Any inconsistencies? system interface
    - correctness
    - Documentation !!!
    - Feasibility of requirements
- repeat

Planning at this stage offers the best opportunity to build secure software in the most efficient manner (cost, time, etc).  
- Develop Security Requirements
    - Security Requirements of a system/application must be developed along with any other requirements (e.g. functional, legal, user, etc)
- Risk analysis
    - Identify all the assets at risk
    - Identify all the threats
- Develop security policies
    - Used as guidelines for requirements
- Develop security metrics

**SDL - Desing Phase**  
- At this stage, all design decisions are made, about
    - Software Architecture
    - Software components
    - Programming languages
    - Interfaces
    - ...
- Develop documentation
- Confirm that all requirements are followed and met
- Threat Models
- Input Data Types
- Security Use Cases
- Security Architecture
- Defense in Layers / Separate Components / Least Privilege
- Tool
    - SecureUML and UMLsec

**SDL - Implementation Phase**  
- This is the stage where coding is done.
- To produce secure software
    - Coding Standards
    - Centralized Security Modules
    - Secure builds and configurations
    - Known security vulnerabilities - use good programming practices. Be aware of
        - Implementation
        - Race conditions
        - Buffer overflow
        - Format string
        - Malicious logic
        - ...
- Follow Design and Develop Documentation

**SDL - Verification Phase**  
- Testing of the code developed in the previous stage
- Cleared security tests
- Security vulnerability tracking
- Code Reviews
- Documentation

**SDL - Release Phase**  
- Secure Management Procedures
- Monitoring Requirements
- Security Upgrade Procedures

**SDL – Response Phase**  
- Causes:
    - Costumer feedback
    - Security incident details and vulnerability reports
    - ...
- Types of maintenance
    - Need to introduce new functionality
    - Need to upgrade to keep up with technology
    - Discovered vulnerability

Every security vulnerability / flaw overlooked in an earlier phase will show-up at later phase(s) resulting into greater Cost, Time of the software development and/or maintenance.  

**Microsoft – Case Study SD^3 + C**  
- Secure by Design
    - Software designed and implemented to “protect” itself and its information
- Secure by Default
    - Accept the fact that software will not achieve perfect security
    - To minimize the harm when vulnerabilities exploited, software's default state should promote security (e.g. least necessary privileges)
- Secure in Deployment
    - Software accompanied by tools and guidance to assist secure use
- Communications
    - Developers should be prepared for discovery of product vulnerabilities and should communicate openly and responsibly with end users. (e.g. patching, deploying workarounds)

Read https://elearning.uniroma1.it/pluginfile.php/1085661/mod_resource/content/1/MS_SDL_Version_3.2%20copia.pdf

## Lesson 12 - Secure Software Development Models/Methods  
For this part refer to the slides because it's full of images.

## Lesson 13 - Build Security

Renewed interest  
- “idea of engineering software so that it continues to function correctly under malicious attack”
- Existing software is riddled with design flaws and implementation bugs 
- “any program, no matter how innocuous it seems, can harbor security holes”

**Software security is about**  
- Understanding software-induced security risks and how to manage them
- Leveraging software engineering practice, thinking security early in the software lifecyle
- Knowing and understanding common problems
- Designing for security
- Subjecting all software artifacts to thorough objective risk analyses and testing
- It is a knowledge intensive field

Solution for flaws, defects, bugs... **Three pillars of security**  

**Pillar I: Applied Risk management**  
- Architectural risk analysis
    - Sometimes called threat modeling or security design analysis
    - Is a best practice and is a touchpoint
- Risk management framework
    - Considers risk analysis and mitigation as a full life cycle activity

**Pillar II: Software Security Touchpoints**  
- “Software security is not security software”
    - Software security
        - is system-wide issues (security mechanisms and design security)
        - Emergent property
- Touchpoints in order of effectiveness (based on experience)
    - Code review (bugs)
    - Architectural risk analysis (flaws)
        - first two can be swapped
    - Penetration testing
    - Risk-based security tests
    - Abuse cases
    - Security requirements
    - Security operations
- Many organization
    - Penetration first
        - a reactive approach
- CR and ARA can be switched; skipping one solves only half of the problem
- Big organization may adopt these touchpoints simultaneously

![Best practices](https://github.com/edoardottt/MSc-CyberSecurity-Sapienza/blob/main/Security-in-Software-Applications/resources/images/07-best-practices.png)  

**Pillar III: Knowledge**  
- Involves
    - Gathering, encapsulating, and sharing security knowledge
- Software security knowledge catalogs
    - Principles
    - Guidelines
    - Rules
    - Vulnerabilities
    - Exploits
    - Attack patterns
    - Historical risks

**Risk management framework: Five Stages**  
1. Identify the Business and Technical Risk
    - Risk management
        - Occurs in a business context
        - Affected by business motivation
    - Key activity of an analyst
        - Extract and describe business goals – clearly
            - Increasing revenue; reducing dev cost; meeting SLAs; generating high return on investment (ROI)
        - Set priorities
        - Understand circumstances
    - Bottomline. answer the question
        - who cares?
2. Understand the Business context
    - Business risks have impact
        - Direct financial loss; loss of reputation; violation of customer or regulatory requirements; increase in development cost
    - Severity of risks
        - Should be capture in financial or project management terms
    - Key is tie technical risks to business context  
3. Synthesize and Rank the Risks
    - Prioritize the risks alongside the business goals
    - Assign risks appropriate weights for resolution
    - Risk metrics
        - Risk likelihood
        - Risk impact
        - Number of risks mitigated over time 
4. Define the Risk Mitigation Strategy 
    - Develop a coherent strategy
        - For mitigating risks in cost effective manner; accounting for
            - Cost, Completeness, Likelihood of success, Implementation time, Impact
    - A mitigation strategy should
        - Be developed within the business context
        - Be based on what the organization can afford, integrate and understand
        - Must directly identify validation techniques
5. Carry out fixes And validate
    - Execute the chosen mitigation strategy
        - Measure completeness
        - Estimate (Progress, residual risks)
    - Validate that risks have been mitigated
        - Testing can be used to demonstrate and measure
        - Develop confidence that unacceptable risk does not remain

**Code Review**  
Focus is on implementation bugs, Essentially those that static analysis can find. Security bugs are real problems, but architectural flaws are just as big a problem (e.g. Code review can capture only half of the problems, Buffer overflow bug in a particular line of code). Architectural problems are very difficult to find by looking at the code esppecially true for today's large software.  
*Taxonomy of coding errors:*  
- Input validation and representation
    - Some source of problems:
        - Meta-characters, alternate encodings, numeric representations
        - Forgetting input validation
        - Trusting input too much
        - Example: buffer overflow; integer overflow
- API abuse
    - API represents contract between caller and callee e.g., failure to enforce principle of least privilege
- Security features
    - Getting right security features is difficult e.g., insecure randomness, password management, authentication, access control, cryptography, privilege management, etc.
- Time and state
    - Typical race condition issues
    - e.g., TOCTOU; deadlock
- Error handling
    - Security defects related to error handling are very common
    - Two ways
        - Forget to handle errors or handling them roughly
        - Produce errors that either give out way too much information or so radioactive no one wants to handle them e.g., unchecked error value; empty catch block
- Code quality
    - Poor code quality leads to unpredictable behavior
    - Poor usability
    - Allows attacker to stress the system in unexpected ways
    - E.g., Double free; memory leak
- Encapsulation
    - Object oriented approach
    - Include boundaries
    - E.g., comparing classes by name
- Environment
    - Everything outside of the code but is important for the security of the software
    - E.g., password in configuration file (hardwired)

**Architectural risk analysis**  
Three critical steps (or subprocesses)
    - Attack Resistance Analysis
    - Ambiguity Analysis
    - Weakness Analysis

## Lesson 14 - Language-based Security. Overview of Types

Objective:  
- Design security into the language
- Compiler rules out insecure programs
- Compiler does not run the program (no testing)

What is insecure?  
- Buffer overflows
- Information-flow leaks
- Violations of access rights
- ...

One approach is based on *types*.  
A type is a specification of data or code in a program.  
Examples from C:
- Basic types
    - `int`, `char`, `float`, `double`, `void`
    - `int x;`, variable x will store an integer
- Function types
    - `int -> double`, ...
    - `int factorial(int);`, factorial is a function that takes an integer as an argument and returns an integer (type int -> int)
- Structures types
- `struct pair {int x; int y;};`, type
- `pair p;`, variable p stores a pair
- Array types
    - `int[n]`, `char[n][m]`, ...
    - `int arr[8];`, variable arr stores sequence of 8 integers
- Pointer types
    - `int*`, `int**`, ...
    - `int* p;`, variable p stores the address of a variable that stores an integer
    - `int** p;`, variable p stores the address of a variable that stores the address of a variable that stores an integer

Type correct program:
```C
int readint();                  // readint: void -> int
void writeint(int);             // writeint: int -> void
int factorial(int n){           // factorial: int -> int
    int f = 1;                  // f: int
    int c = 1;                  // c: int
    while (c <= n) {            // c <= n: boolean
        f = f * c;              // *: (int,int) -> int
        c++;                    // ++: int -> int
    }
    return f;                   // f: int
}                   
void main() {                   // main: void -> void
    int v;                      // v: int
    v = readint();              // readint(): int
    writeint(factorial(v));     // factorial(v): int
}
```
With this piece of code as main function would be type correct?
```C
void main() {
    string s;
    s = readint();
    writeint(factorial(s));
}
```

- Types are necessary to compile source code
- What is the binary representation of variables?
    - `int x;`, x is 4 bytes
    - `char x;`, x is 1 byte
    - `int arr[8];`, arr is 32 bytes
- How to compute in assembly?
    - `int x; int y; x + y` --> `add r1,r2`
    - `float x; float y; x + y` --> `fadd r1,r2`
    - Difference is based on types

Type checking: A compiler can ensure that data and code are used only as specified by types without running the program.
Types can be used to reject at compile time programs that:
- Use strings as integers
- Use integers as pointers
- Cause null-pointer exceptions
- Cause array overflows
- Leak secret information

A program is called safe if it's not stuck and has not crashed. A language is called type-safe if well-typed programs always remain safe. Presence of types does not imply type-safety (e.g. C has types but is not type-safe).  
Buffer overflow with scanf in C:
```C
void readstring(char str[]) {
    scanf(“%s”,str);
}
void main() {
    char buf[8];
    readstring(buf);
...
}
```
This program is well-typed, but can crash with input longer than 7 bytes. C is not type-safe. char[] != char[8]. This program should be rejected! However, C allows unsafe type-casting and accepts the program.  

Type-casting: convert the type of a variable to another
- The C compiler will convert types (e.g. from char[8] to char[])
- Some conversions violate type specifications
- This makes C type-unsafe

**Safe and unsafe Type cast in C**
| Type cast | Safe in C? |
| ------ | ------ |
| `char* x; int* y = (int*) x` | No |
| `int* x; void* y = (void*) x` | Yes |
| `void* x; int* y = (int*) x` | No |
| `int x; char* y = (char*) x` | No |
| `char* x; int y = (int) x` | Yes |
| `int x; float y = (float) x` | Yes |
| `float x; int y = (int) x` | Yes |

- Untyped languages do not have types
    - e.g., Bash, Perl, Ruby, …
    - Usually interpreted; difficult to compile without types
    - Program safety is programmer's responsibility: programs difficult to debug
- Weakly typed languages use types only for compilation; no type-safety
    - e.g., C, C++, etc.
    - Often allow unsafe casts, e.g., char[8] to char[] and int to char*
    - Program safety is programmer's responsibility: buffer overflows and segmentation faults are common in programs
- Strongly typed languages use types for compilation and guarantee type-safety
    - e.g., BASIC, Pascal, Cyclone, Haskell, SML, Java, etc.
    - No unsafe casts, e.g., an integer cannot be cast to a pointer, an array of length 8 is not an unbounded array, etc.
    - Safety is guaranteed but believed unsuitable for some low-level programs (debatable)

- Types are specifications of data and code
- Compiler may check well-typedness without executing the program
- Existence of type specifications may imply program safety (type-safety)
- Not all languages with types are type-safe
    - e.g., C is not type-safe

Here the lesson follows with a simple type-safe language to understand type-safety more formally, read this part on the slides.

## Lesson 15 - Language-based Security. Safety

Programming Languages can provide security features and guarantees
- safety guarantees
    - memory safety
    - type safety (different levels depending on expressivity)
    - thread safety
- Access Control (in some form)
    - visibility and access restrictions (public, private, ...)
    - sandboxing mechanisms
- Information Flow Control (in some form)
    - JFlow/Jif or next generation Javascript
- These features often interdependent (type needs memory, sandboxing needs memory and type, ...)

A programming language can help security also if it:
- offers good APIs and libraries
    - API with parametrized queries for SQL
    - secure string libraries for C
- supports external languages
- offers useful features
    - such as exceptions and their handling
- makes assurance easier
    - understand code in modular way ...

Insecure programs can be written in ANY language (forget input validation, flaw in program logic, ...)  
Sometimes confused (Separation line not clear, but good for safety also good for security):  
- *SAFETY*: system protected against accidental failures
- *SECURITY*: system protected against induced failures (active attacker)

When does the assignment `a[i] = (byte)b;` make sense?  
- `a` must be a non-null byte array
- `i` a non-negative integer < arraylength
- `b` should be a byte or converted to one

Two approaches:
1. the programmer is responsible for verifying these conditions (unsafe approach)
2. the language is responsible for checking these conditions (safe approach)

Safe programming languages impose some discipline (via restrictions) on the programmer. Offer abstractions (enforced with associated guarantees) to the programmer. Reduced freedom and flexibility in exchange for added safety and clearer understanding.  
Example abstractions: programming languages constructs provide abstraction from CPU instructions, programming language variables and types provide abstraction of memory, procedure call mechanism provides abstraction over call stack mechanism...  
We have of course abstractions also from a pov of OS: OS provides virtual memory as abstraction of raw memory, OS provides process as abstraction of CPU and memory, OS provide security by separating processes, controlling access to resources by process, BUT this security breaks whenever these abstractions break!  

Abstractions are crucial to reduce complexity, reducing complexity reduces bugs. Abstractions provide security (access control): memory access control by paging/segmentation, access to files (bits of hard disk) by processes.

A programming language can be considered safe if:
1. the abstractions provided by the language can be trusted
    - enforced and cannot be broken
    - boolean always true or false, never 35 or null,
    - independently of representation 0x00 / true
2. programs have precise and well-defined semantics
    - undefined behavior is source of trouble
3. the behavior of programs can be understood in a modular way

Safety: how? mechanisms to provide safety include
- compile time checks (e.g., type checking)
- run time checks (for array bounds, null pointers, runtime type checks, ...)
- garbage collector for automated memory management (no need to free() dynamic memory)
- execution engine
    - in JVM, bytecode verifier to type-check code, runtime checks, garbage collector invoked periodically

| Compiled binaries | Execution engines | 
| --------- | ---------- |
| Compiled binary runs on bare hardware. Any defensive measures must be compiled into the code | Execution engine isolates code from hardware. The programming language is still "there" at runtime and the execution engine can provide checks at runtime |

A programming language is memory-safe if it guarantees that:
1. programs can never access unallocated or deallocated memory
    - hence, no segmentation faults at runtime
    - so: OS access control for memory not necessary (if there are no bugs in execution engine)
2. (maybe) programs can never access uninitialized memory
    - so there is no need to zero-out memory before deallocating to avoid information leaks (if there ...)

Unsafe language features that can break memory-safety: unchecked array bounds, pointer arithmetic, null pointers (only when behavior is undefined).  
Also: manual memory management: de-allocation e.g. free() in C causing dangling pointers, use-after-free and double-free bugs can be avoided by not using the heap at all (in MISRA C), automating it with garbage collection, first used in LISP in 1959, then accepted with Java in 1995.  
- Types assert invariant properties of elements of a program
    - this variable will always hold an integer
    - this function will always return an object of class C
    - this array will never store more than 10 elements
- Type checking verifies these assertions and can be done
    - at compile time (static typing)
    - at runtime (dynamic typing)
- Type soundness (type-safety / strong typing) refers to a system that guarantees that the assertions hold at runtime

Type-safe programming languages guarantee that programs that pass the type-checker verification can only manipulate data in ways allowed by their type: booleans are not multiplied, integers are not dereferenced, references not the argument of square roots in OO languages, never Method_not_found errors at runtime...  
Programming languages can be: 
- memory-safe, typed and type safe
- memory-safe and untyped
- memory-unsafe, typed and type unsafe

Ruled-out at the language level by combination of
- compile-time (static) type checking
    - also at load-time by bytecode verifier (bcv)
- runtime (dynamic) checks

what runtime checks are performed during the execution of
```Java
public class A extends Super{
    protected int[] d;
    private A next;
    public A() { d = new int[3] ; }         // runtime check for non-nullness of d and array bound
    public void m(int j) { d[0] = j ;}
    public setNext(Object s) {
        next = (A)s;                       // runtime check for type downcast
    }
}
```

Buffer overflow can still be present
- in native code
- in C# in code blocks declared unsafe
- through bugs in the Virtual Machine (VM) implementation (typically written in C++)
- through bugs in the implementation of the type-checker or in the type system (unsound)
- The VM (along with the bcv) is part of the Trusted Computing Base (TCB) for both memory and type safety

Type safety is not a robust property. Data values and objects are just memory locations. If type confusion is created (e.g. by having different references with
different types referring to the same memory locations), there can be NO type guarantees.  

How to know a type system is sound?  
- Representation independence (for booleans)
    - no difference if true is represented as 0 and false as 1 (or FF) or viceversa
        - given program with either representation guaranteed to produce same result
    - test for it or prove it
        - given formal definition of language, prove that the representation of true/false has no effect on any program
    - similar properties should hold for all datatypes
- Give two formal definitions of the programming language
    - a typed operational semantics, which records and checks type information at runtime
    - an untyped operational sematics which does not and prove their equivalence for all well-typed programs 
- in other words, prove the equivalence of
    - a defensive execution engine (which records and checks all type information at runtime) and
    - a normal execution engine which does not for any program accepted by the type checker

Many ways to enrich type systems (further)  
e.g. distinguish non-null and possibly-null types `public @nonNull String hello = “hello”;` to improve efficiency, prevent null pointer bugs or catch them earlier, at compile time. Alias control to restrict interferences due to "double names" information flow to control the way tainted information flows through

Other language-based guarantees: visibility: public, private etc. Immutability: of primitive values (constants)...

*Safe arithmetic*: What happens if i=i+1; overflows ?
1. Unsafest approach : leaving this as an undefined behavior (as in C and C++)
2. Safer approach : specify how over/under flow behaves (as in Java and C#)
3. Safer still : integer overflow results in an exception (as in checked mode in C#)
4. Safest approach : have infinite precision integers and reals, so that overflow never happens (in some experimental functional languages)

*(Lack of) tread safety*  
Two concurrent execution threads executing the same statement `x = x+1;`, at the end x can have value 2 or 1. Cause: data race since `x = x+1;` is not an atomic
operation, but consists of two steps which may be interleaved in unexpected ways (and can cause security problems ...).  
Data races and thread safety: 
- a program contains a data race if two threads simultaneously access (not in read only) the same variable
- thread-safety = the behavior of a program consisting of several threads can be understood as interleaving of those thread
- in Java, the semantics of programs with data races is effectively undefined, so only programs without data races are thread-safe
- MORAL: even “safe” programming languages can sport weird behavior in presence of concurrency

*Typing breaks in C, Java, C# ...:*  
Dangerous combinations: aliasing & mutation threads or objects A and B both have references to a mutable object shared. This can cause many problems, not just with concurrency:  
1. in concurrent (multi-threaded) context: data races. Locking objects (as with `synchronized` in Java) can help but is expensive and risks deadlock
2. in single-threaded context : dangling pointers
3. in single-threaded context: broken assumptions, who is responsible for free-ing shared? A or B? If A changes the shared object, B's assumptions about shared may not hold and B's code broken

In multi-threaded programs, references to mutable data structures can be a problem, since referenced data can change even in safe languages (like Java or C#).  
```Java
public void f(char[] x) {
    if (x[0] != ‘a’ {throw new Exception();}
    // cannot assume first element is ‘a’
    ...
}
```
Another thread with reference to x can change the content of the array at any moment, also just after the if-statement has been executed.  
In multi-threaded programs, references to immutable data structures are safer.  
```Java
public void g(String x) {
    if (x.charAt(0) != ‘a’ {throw new Exception();}
    // can assume here that first character is ‘a’
    ...
}
```
Another thread with a reference to the same string x cannot change the content of the array (value of the string) since Java strings are immutable.  

*"Secure" programming languages*  
- Languages like Java and .NET can provide security guarantees in the presence of untrusted code
- the languages can guarantee restrictions on the possible interactions between different modules by using a combination of
    - typing
    - visibility
- enforced by a combination of static and runtime checks
    - static checks at load-time rather than at compile-time

## Lesson 16 - Java guarantees & aliasing

The Java platform offers security features
- memory safety
- strong typing
- visibility restrictions (public, private,…)
- sandboxing based on stackwalking

This allows security guarantees to be made: even if part of the code is untrusted, or simply buggy. Of course, the same goes for Microsoft .NET/C#.  
Even if type system is sound, VM and type checker are correct, sandboxing is sound and implemented correctly, a particular Java class may still be vulnerable to attacks by untrusted code. Programming guidelines have been proposed to prevent known vulnerabilities.  
Spot the defect
```Java
public class String{
    public char[] contents; public int offset, len;
    // idea: String is contents[offset ... offset+len]
    String() {contents=null; offset=0; len=0;}
    String(char[] a) {
        contents = a; offset = 0; len = a.len;
    }
    String substring(int take) {
        if (take<=0) throw new NegativeSizeException();
        String s = new String(); s.content=this.content;
        s.offset=0; s.len=Math.min(take,s.len); return s;
    }
    int getLength() { return len; }
...
```
1. class should be final to prevent malicious subclasses
2. fields should be not be public to prevent unauthorised changes, ie. preserve integrity
3. fields should be final (for thread-safety)
4. array should be cloned to prevent representation exposure which allows unauthorised changes

NB the context of these rules: only really relevant for  
- applications that are – or may some day be – extended with less trusted or untrusted code
- API components that are by definition extended with less trusted code

**Java security programming guidelines**  
- Do not use public fields
- Do not use protected fields
    - Why? Protected fields can be accessed in
        1. subclasses
        2. in the package
    - Anyone can (1) create subclasses or (2) extend the package
    - We can rule out 1 by making a class final
    - We can rule out 2 by making a package sealed
- Do not rely on package protection for security
- Limit access to classes, methods, and fields
    - make them private, unless... there is a need for them to be more visible
- Never return (a reference to) a mutable object (incl. arrays) to untrusted code
- Never store a reference to a mutable object (incl. arrays) obtained from untrusted code
- Don’t use inner classes.
- Make classes non-cloneable
- Make classes non-deserialiseable.
- Make classes non-serialiseable.

Potential visibility loophole: *reflection*
- Reflection allows access to fields that are normally not visible
- The default security manager prevents this, and will throw an AccessControlException
- unless java.lang.reflect.ReflectPermission is granted

General observations:  
- Flexibility & extensibility provided by OO is nice for programming, but nasty for security
    - usual tension between functionality & security
- These issues are not at all obvious, and typical programmers won’t know these things, unless they have actively looked for information
    - see principle: use your community resources, eg google for language/setting specific security guidelines

More programming guidelines:  
- There are more programming guidelines, that are not directly motivated by security.
- Specific APIs may come with their own programming guidelines, possibly security-related
- Guidelines are very useful as checklists, but do not be tempted into thinking they are complete and give absolute guarantees.

**Aliasing**  
- Safe languages such as Java and C# do not have pointer arithmetic (eg &x; x*, ...) but they do have references and allow aliasing
- aliasing = having more than one reference to the same object

*desirable aliasing*:  
- Efficiency
    - in time: e.g. alias to middle of list in list traversal
    - in space, by sharing object
- Consistent view to shared objects
- Useful programming patterns
    - e.g. callbacks, observer pattern, ...
- For "objects“/”things” in the informal sense of the word, as opposed to values, using references make sense
    - e.g. files, windows, USB sticks, ....
    - e.g. for anything that is hard in functional programming

*undesirable aliasing*:  
- side-effects hard to control and understand
    - hard to debug
    - hard to maintain object invariants
    - hard to ensure consistent access
        - esp. when concurrency can cause race conditions
- aliases allow to by-pass interface operations
    - i.e. break encapsulation boundaries
    - aka representation exposure
    - This can cause problems if you have several pieces of code, some of which are more trusted than others, because untrusted code may exploit this

*two ways to unwanted alias of internal representation*:
- exporting a reference: `int[] getcontents() { return c;}`
- importing a reference: `IntSet(int[] a) { c = a; }`

Many systems have been (and are being) proposed for alias control (aka ownership, encapsulation, confinement,...).  
Many of these require annotations to express the programmer's intent.

Which fields do you think are (not) meant to be aliased?  
```Java
public class BankTransfer{
private BankAccount from,to;
private int[] amount;
private char[] description;
...
}
```
Several alias control type systems use notion of rep field
```
public class BankTransfer{
private BankAccount from,to;
private @rep int[] amount;
private @rep char[] description;
...
}
```
- rep field is owned by the object
- Important design decision, about the programmer's intention, which should be made explicit

Idea: objects of type @rep int[] and of type int[] are not assignment compatible
Question: should a.amount and b.amount be assignment compatible for different Banktransfer objects a and b?
Question: could this solve the signers problem?

- Many type systems have been, and are still being, proposed for alias control, e.g. 
    - universes by Peter Muller
        - fine-grained alias control per object
    - confined types by Jan Vitek and Boris Bokowski
        - coarser alias control per package
- Design challenge: defining a system that is
    - flexible and expressive enough to capture typical programming patterns,
    - simple enough to be understandable and statically checkable

- Another way to prevent aliasing problems:
    - make objects immutable
- About 660 (20%) classes in the Java standard library are immutable
    - Prime example: java.lang.String is immutable.
    - NB many (trusted) API methods take/produce strings as arguments/result. (Why is immutability important then?)
- The programming language Scala clearly distinguishes immutable objects and treats them in special ways, encouraging a more functional programming style

*advantages of immutability*  
- Immutable objects can be aliased without problems
- They are immune to race conditions
- Conceptually simple (they are values)
- Because immutable objects can be safely shared, this can improve efficiency
    - because sharing objects saves the cost of copying them
- However, using immutable objects can also decrease efficiency
    - because not being able to change requires the creation of new objects for every change
    - eg think of using StringBuffer vs String

Using immutability in the BankTransfer example: instead of
```Java
public class BankTransfer{
    private BankAccount from,to;
    private int[] amount;
    // should not be aliased!!
    private char[] description; // should not be aliased!!
```
we would get->
```Java
public class BankTransfer{
    private BankAccount from,to;
    private Integer amount;
    // Integer objects are immutable, so no worries
    private String description;
    // String objects are immutable , so no worries
```
Even better
```Java
public class BankTransfer{
    final private BankAccount from,to;
    final private Integer amount;
    // Integer objects are immutable
    final private String description;
    // String objects are immutable
    ...
}
```
Immutability of classes is an important property that deserved to be made explicit in code, and checked.  
e.g. `public @Immutable class BankTransfer{ ...}`.  

We need to know which fields are rep-fields, ie. part of the object representation, in order to know what immutabity means.

**Recap**:  
- Language constructs such as public/private/... enable protection of access to fields, methods, classes
- but do not provide a way to protect integrity of objects in system of interacting objects
- Confined Types
    - a particular scheme for alias control, that can provide integrity
    - all package scoped objects should be confined?
- Immutability
    - another way to avoid/reduce aliasing problems
    - built-in in newer programming languages such as Scala

## Lesson 17 - Program Verification and JML 

For this part refer to the appropriate slides (Verification and intro JML), because they are full of pieces of code and images.  
Read also http://www-verimag.imag.fr/~mounier/Enseignement/Software_Security/Java-Architecture.pdf.  

## Lesson 18 - Sandboxing

**Overview**  
1. Compartmentalisation
2. Classic OS access control (compartementalisation between processes)
3. Language-level access control
    - compartementalisation within a process
    - by sandboxing support in safe programming languages
    - notably Java and .NET
4. Hardware-based sandboxing
    - compartementalisation within a process, also for unsafe languages

Compartmentalisation can be applied on many levels: organization, IT system, single computer, inside a program...  

**Compartmentalisation for security**  
1. Divide systems into chunks, aka compartments, components... Different compartments for different tasks
2. Give minimal access rights to each compartment aka principle of least privilege
3. Have strong encapsulation between compartments so flaw in one compartment cannot corrupt others
4. Have clear and simple interfaces between compartments exposing minimal functionality

Benefits:
    - reduces TCB (Trusted Computing Base) for certain security-sensitive functionality
    - reduces the impact of any security flaws.

Sandboxing: Runtime access control aka sandboxing is one of the standard ways to provide compartmentalisation. This involves right/permissions and policies that give rights to parties (who is allowed to do that).  

**Problems with OS access control**  
1. Size of the TCB. The Trusted Computing Base for OS access control is HUGE so there will be security flaws in the code. The only safe assumption: a malicious process on a typical OS (Linux, Windows, BSD, iOS, Android, ...) will be able to get superuser/root/administrator rights.
2. Too much complexity. The languages to express access control policy are very complex, so people will make mistakes 
3. Not enough expressivity/granularity. E.g. the OS cannot do access control within process, as processes as the "atomic" units.

Note the fundamental conflict between the need for expressivity and the desire to keep things simple.  

**Complexity problem (resulting in privilige escalation)**  
UNIX access control uses 3 permissions (rwx) for 3 categories of users (owner,group,others) for files and directories. Windows XP uses 30 permissions, 9 categories of users, and 15 kinds of objects. 

Example common configuration flaw in XP access control, in 4 steps:
1. Windows XP uses Local Service or Local System services for privileged functionality (where UNIX uses setuid binaries)
2. The permission SERVICE_CHANGE_CONFIG allows changing the executable associated with a service
3. But... it also allows to change the account under which it runs, incl. to Local System, which gives maximum root privileges.
4. Many services mistakenly grant SERVICE_CHANGE_CONFIG to all Authenticated Users...

**Limitation of classic OS access control**  
A process has a fixed set of permissions. Usually, all permissions of the user who started it. Execution with reduced permission set may be needed temporarily when executing untrusted or less trusted code. For this OS access control may be too coarse.  
Remedies/improvements: allowing users to drop rights when they start a process, asking user approval for additional permissions at run-time, using different user accounts for different applications (as Android does), split a process into multiple processes with different access rights.  

![chrome](https://github.com/edoardottt/MSc-CyberSecurity-Sapienza/blob/main/Security-in-Software-Applications/resources/images/08-chrome.png)  

**Access control at the language level**  
In a safe programming language, access control can be provided within a process, at language-level, because interactions between components can be restricted & controlled. This makes it possible to have security guarantees in the presence of untrusted code (which could be malicious or just buggy).  
Without memory-safety, this is impossible. Why? Because B can access any memory used by A.  
Without type-safety, it is hard. Why? Because B can pass ill-typed arguments to A's interface.  

**Sandboxing with code-based access control**  
Language platforms such as Java and .NET provide code-based access control:  
- this treats different parts of a program differently
- on top of the user-based access control of the OS

Ingredients for this access control, as for any form of access control:
1. permissions
2. components (aka protection domains), in traditional OS access control, this is the user ID
3. policies, which gives permissions to components ie. who is allowed to do what

Example configuration file that expresses a policy (Java):
```Java
grant
    codebase "http://www.edoardoottavianelli.it/example", signedBy "FPP",
        { permission
            java.io.FilePermission "/home/edoardottt","read";
        };

grant
    codebase "file:/.*"         // <- protection domain
        { permission
            java.io.FilePermission "/home/edoardottt","write";
        };
```
Protection domains based on evidence  
1. Where did it come from? where on the local file system (hard disk) or where on the internet
2. Was it digitally signed and if so by who? using a standard PKI

When loading a component, the Virtual Machine (VM) consults the security policy and remembers the permissions.  

Permissions represent a right to perform some actions e.g. `FilePermission(name, mode)`, `NetworkPermission`, `WindowPermission`. Permissions have a set semantics, so one permission can be a superset of another one. Developers can define new custom permissions.  

Complication: method calls.  
There are different possibilities here
1. allow action if top frame on the stack has permission
2. only allow action if all frames on the stack have permission
3. ...

Pros? Cons?
1. is very dangerous: a class may accidentally expose dangerous functionality
2. is very restrictive: a class may want to, and need to, expose some dangerous functionality, but in a controlled way

More flexible solution: stackwalking aka stack inspection

Exposing dangerous functionality, (in)securely
```Java
Class Good {
    public void unsafeMethod(File f){
        delete f; // Could be abused by evil caller 
    } 
    public void safeMethod(File f) {
        ... // lots of checks on f;
        // if all checks are passed, then delete f;}
        // Cannot be abused, assuming checks are bullet-proof
    public void anotherSafeMethod(){
        delete ″/tmp/bla″; 
    }
        // Cannot be abused, as filename is fixed.
        // Assuming this file is not important..
}
```

Using visibility to control access? Use `private` in unsafeMethod !!!!!

**Stack walking**  
Every resource access or sensitive operation protected by a demandPermission(P) call for an appropriate permission P, no access without asking permission!  
The algorithm for granting permission is based on stack inspection aka stack walking.  

![stackwalking](https://github.com/edoardottt/MSc-CyberSecurity-Sapienza/blob/main/Security-in-Software-Applications/resources/images/09-stackwalking.png)  

Basic algorithm is too restrictive in some cases. E.g.:
- allowing an untrusted component to delete some specific files
- giving a partially trusted component the right to open specially marked windows (eg. security pop-ups) without giving it the right to open arbitrary windows
- giving an app the right to phone certain phone numbers (eg. only domestic ones, or only ones in the mobile’s phonebook)

**Stack walk modifiers**  
- Enable_permission(P):
    - means: don’t check my callers for this permission, I take full responsibility
    - This is essential to allow controlled access to resources for less trusted code
- Disable_permission(P):
    - means: don’t grant me this permission, I don’t need it
    - This allows applying the principle of real privilege (ie. only give or ask the privileges really needed, and only when they are really needed)

Spot the security flaw:
```Java
Class Good{
    public void m1 (String filename) {
        // lot of checks on filename;
        enablePermission (FileDeletionPermission);
        delete(filename);
    }
    public void m2( byte[] filename) {
        // lot of checks on filename;
        enablePermission (FileDeletionPermission);
        delete(filename);
    }
}
```
- m1 is secure, because Strings are immutable
- m2 is insecure, because byte arrays are mutable: an attacker could change the value of filename after the checks, in a multi-threaded execution

**Programming language platform vs OS**  
Note the similarity between
- methods which enable some permissions
- Linux setuid root programs or Windows Local System Services which can be started by any user, but then run in admin mode
- OS systems calls invoked from a user program 

All are trusted services that elevate the privileges of their clients
- hopefully in a secure way...
- if not: privilege elevation attacks

In any code review, such code obviously requires extra attention!

**Sandboxing in unsafe languages**  
- Unsafe languages cannot provide sandboxing at language level
- An application written in an unsafe language could still use OS sandboxing by splitting the code across different processes (as e.g. Chrome does)
- An alternative approach: use sandboxing support provided by underlying hardware
- Additional possible benefit: drastically reducing the size of TCB by keeping OS outside the TCB for executing security-sensitive code
    - Less flexible than eg. Java sandboxing, but more secure by having a smaller TCB:
        - the "platform", incl. VM and OS, no longer in the TCB

**Secure enclaves**  
- Enclaves isolates part of the code together with its data
    - Code outside the enclave cannot access the enclave's data
    - Code outside the enclave can only jump to valide entry points for the code in the enclave
- Less flexible than stack walking:
    - Code in the enclave cannot inspect the stack as the basis for security decisions
- Not such a rich collection of permissions, and programmer cannot define his own permissions
- More secure, because
    - OS & Java VM (Virtual Machine) are not in the TCB
    - Also some protection against physical attacks is possible

**Recap**:  
- Conventional OS access control (access control of applications and between applications)
- Language-level sandboxing in safe languages (e.g. Java sandboxing using stackwalking)
- Hardware-supported enclaves in unsafe languages

- Language-based sandboxing is a way to do access control within a application: different access right for different parts of code
    - This reduces the TCB for some functionality
    - This may allows us to limit code review to small part of the code
    - This allows us to run code from many sources on the same VM and don’t trust all of them equally
- Hardware-based sandboxing can also achieve this also for unsafe programming languages
    - This has much smaller TCB: OS and VM are no longer in the TCB
    - But less expressive & less flexible
        - no stackwalking or rich set of permissions

## Lesson 19 - Proof Carrying Code & Information Flow  

For this part refer to the appropriate slides.

## Lesson 20 - project SPARTA

For this part refer to the appropriate slides.
