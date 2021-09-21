# Security Governance - Theory

## Lesson 1 - Introduction

A generic enterprise in order to accomplish its mission it will design some processes to be carried out.  
These processes involves both **humans**, **relationships** between them and **IT infrastructures**.  
There are different definitions of governance:  
- “Governance is all of the processes of governing, whether undertaken by a government, a
market or a network, over a social system (family, tribe, formal or informal organization, a
territory or across territories) and whether through the laws, norms, power or language of an
organized society.” (Mark Bevir)
- “The Governance is the processes of interaction and decision-making among the actors
involved in a collective problem that lead to the creation, reinforcement, or reproduction of
social norms and institutions.” (Marc Hufty)

We have a strict definition of *Enterprise Governance*: "Enterprise governance is the structure and relationships that control, direct, or regulate the performance of an enterprise [and its] projects, portfolios, infrastructure, and processes." (Wilson, W. L., 2009, Conceptual Model for Enterprise Governance, Ground System Architectures Workshop).  
We can divide E.G. into Corporate Governance and Business Governance:  
- Corporate governance is the system of rules, practices and processes by which a firm is directed and controlled. ( Compliance Processes)
- Business Governance is a set of policies and business processes that set the way that the organisation’s business is run. (Performance Processes)

We are interested in the first one. (*Corporate Governance*)  

Every governance system use the **direct/control loop**.  
![direct control loop](https://github.com/edoardottt/MSc-CyberSecurity-Sapienza/blob/main/Security-Governance/resources/images/01-direct-control-loop.png)
The final goal is to take care of threats and vulnerabilities (bugs, errors, backdoors.. etc..) putting in place a security governance process.  
Remember that we can have threats in *any* part of the processes (not only technical ones).  
The control loop starts from the bottom to reach the top producing reports for upper layers. This report contains the monitor of a metric that measures the effectiveness of the procedures.  
The **Direct/Control loop is driven by Risks**, the IT Governance Institute redefine the concept of Enterprise (and thus Corporate) Governance as follow:  
“Enterprise governance is a set of responsibilities and practices exercised by the board and executive management with the goal of providing strategic direction, ensuring that objectives are achieved, ascertaining that risks are managed appropriately and verifying that the enterprise’s resources are used responsibly.”  
So the **direct loop** has as objective the reduction of the risks and **the control** has instead the objective to measure risk reduction after the application of policies and procedures defined before.  

We will focus more specifically on **IT Governance**.  
IT based systems causes serious risks to a company as it manages and stores many (if not all) electronic assets like:
- Data and information stored
- Data and information transmitted over the network
- All the systems and application required to store, transmit and process data and information.

Electronic assets are exposed to many threats aiming at compromising their CIA properties (Confidentiality, Integrity and Availability).

*“Security governance is the means by which you control and direct your organisation’s approach to security.”*
(UK National Cyber Security Centre)

Which approach your organization should use? Unfortunately there is no 'one fits all' method. Each case is different and we should find the perfect method for each one. There are some parameters we can take in consideration, like the size of the company, the resources, the main goals of the com., the legal and all the external considerations...  
In few words we should detect (in our company):
- **What** (Security decisions)
- **Who** (i.e. Deciders)
- **Data** (the information required to make sensible and informed choices)

The **Security Governance** is not only responsible for IT Governance but also of the Corporate Governance and Business Governance because an enterprise must be
secured not only from the perspective of infrastructure but also from the business and corporate points of view that includes people and processes.  

Why you should take care of Security Governance?  
Read the [Verizon 2021 Data Breach Investigations Report](https://enterprise.verizon.com/resources/reports/2021/2021-data-breach-investigations-report.pdf).

An advanced persistent threat (APT) is a set of stealthy and continuous computer hacking processes, often orchestrated by a person (or persons) targeting a specific entity.  
Usually targets either private organizations, states or both for business or political reasons.  
Typically, it requires a long period of time to be concluded:
- **advanced** implies sophisticated techniques using malware to exploit vulnerabilities in systems.
- **persistent** suggests that an external command and control system is continuously monitoring and extracting data from a specific target.
- **threat** indicates human involvement in orchestrating the attack.
