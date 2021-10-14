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

## Lesson 8 - SQL Injection & Input validation

**SQL Injection**  
The ability to inject SQL commands into the database engine through an existing application. It is a flaw in "web application" development, it is not a Database or web server problem. SQL stands for Structured Query Language and allows us to access a database. SQL can: execute queries against a database, retrieve, insert, delete and update records in a database. There are many different versions of the SQL language. They support the same major keywords in a similar manner (such as SELECT, UPDATE, DELETE, INSERT, WHERE, and others). Most of the SQL database programs also have their own proprietary extensions in addition to the SQL standard! A relational database contains one or more tables identified each by a name and tables contain records (rows) with data. With SQL, we can query a database and have a result set returned. We can divide the SQL language in two parts: Data Definition Language (DDL) and Data Manipulation Language (DML).  
How does SQLi work?  
Common vulnerable login query
```SQL
var sql = "SELECT * FROM users
WHERE login = '" + formusr + "'
AND password = '" + formpwd + "'";
```
Injecting : formusr = `' or 1=1 ––` and formpwd = `anything`
```SQL
SELECT * FROM users
WHERE username = '' or 1=1-- 
AND password = 'anything'
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

**Input validation**  
