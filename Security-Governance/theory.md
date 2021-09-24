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

## Lesson 2 - A model for Information Sec. Governance (Part 1)

In NIST SP 800-100, Information Security Governance is defined as  
“The process of establishing and maintaining a framework and supporting management structure and processes to provide assurance that information security
strategies are aligned with and support business objectives, are consistent with applicable laws and regulations through adherence to policies and internal controls, and provide assignment of responsibility, all in an effort to manage risk.”  

Information Security Governance (ISG from now) must ensure cost-effectiveness.  
- There must be a balance between the cost of protecting electronic resources and the risk to which these resources are exposed
- NO OVERPROTECTION causing unnecessary expenses
- NO UNDERPROTECTION causing risk to materialize and impact the company

A good (IT) Risk management strategy is therefore mandatory to implement a good ISG strategy.  

One proposed model is the following by **Von Solms R. in 2006** in which we can see the direct loop in the front and new layers at the depth with a one big layer that is the best practice. This model should help in **“doing the right things right”**.
![proposed model von Solms](https://github.com/edoardottt/MSc-CyberSecurity-Sapienza/blob/main/Security-Governance/resources/images/02-model-von-solms.png)  

We've already seen the front part that is the *direct control loop*.  
It represents the execution of processes and actions and the influence of the Direct and Control loop on these processes.  
It is based on two core principles:
- It covers the 3 well known level of management (*Strategic*, *Tactical* and *Operational*)
    - We can say that the Strategical level controls **what** to do, the tactical level **how** to do and the operational level is **where** things are actually done.
- Across these 3 levels, there are very distinct actions
    - The board is not interested in having long, fully detailed reports on what things happened during the last period of time, it just wants to know the status of the work done and to do, and if things are going bad it may ask for additional informations.

*The* **Direct** *Part*
| | Strategic | Tactical | Operational |
| ----------- | ----------- | --------- | --------- |
| What does it mean Direct at this level | Identify assets, their relevance and their required level of protection | Directives are 'expanded' into sets of relevant information security policies, company standards and procedures | Inputs are expanded into sets of administrative guidelines and administrative procedures and technical measures are physically implemented and managed |
| Input   | 1. External factors (legal and regulatory prescriptions and other external risks) 2. Internal factors (company’s strategic vision, IT role, competitiveness, etc ) | {Output of Strategic} | {Output of Tactical} |
| Output | a set of Directives indicating (at high level) what the Board expects must be done as far as the protection of the company’s information assets is concerned | policies, procedures and standards | operating procedures specifying how things must be done. It forms the basis of execution on the lowest level |

*The* **Control** *Part*  
To properly Control (manage) we need to measure, so we need to know which information and data to collect.  
This ‘measurability’ characteristic must be at the centre of all directives, policies, standards and procedures produced during the ‘Direct’ part of the model.

| | Operational | Tactical | Strategic |
| ----------- | ----------- | --------- | --------- |
| What does it mean Direct at this level | measurement data is extracted from a wide range of entities (either automatically or manually) | measurement and monitoring against the requirements of the relevant policies, procedures and standards | Situational Awareness |
| Input   | Measurements | {Output of Strategic} | {Output of Tactical} |
| Output | Specialized reports can be created on this level using this extracted operational data. | Tactical Management reports, indicating levels of compliance and conformance | Reports reflecting compliance and conformance to relevant directives including risk considerations |

**Note**: The arrows in the direct control loop are not decreasing and increaing the size casually. The information from the Operational layer are stripped in a more concise format. In the direct part is actually the opposite. So basically one main difference is the **granularity** of the informations.  

Talking about the base of the model... What is a Best Practice?  
**Best Practices** (or Standards or Guidelines) are *a set of documents reporting experiences and solutions** experienced by experts in ISM
- Can be seen as the consensus of experts in the field of Information Security
- Provide an internationally accepted framework that can be used as building block for ISG.  
Many of them exists, focused on related but different aspects (ISO 27000 family, COBIT, NIST SP 800-\*, CSC, NIST CSF).

**ISO 27002**  
It is an International Standard designed to be used by organizations that intend to:
- select controls within the process of implementing an Information Security Management System based on ISO/IEC 27001
- implement commonly accepted information security controls
- develop their own information security management guidelines

It contains 14 security control clauses collectively containing a total of 35 main security categories and 114 controls.  
Each clause defining security controls contains one or more main security categories  
Each main category contains:  
- a control objective stating what needs to be achieved
- one or more controls that can be applied to achieve the control objective

<table>
  <tbody>
    <tr>
      <td>Control</td>
      <td>Defines the specific control statement, to satisfy the control objective.</td>
    </tr>
    <tr>
      <td>Implementation Guidance</td>
      <td>Provides more detailed information to support the implementation of the control and meeting the control objective. The guidance may not be entirely suitable or sufficient in all situations and may not fulfil the organization’s specific control requirements.</td>
    </tr>
    <tr>
      <td>Other Information</td>
      <td>Provides further information that may need to be considered, for example legal considerations and references to other standards. If there is no other information to be provided this part is not shown.</td>
    </tr>
  </tbody>
</table>

**ISO 27001**  
It is an International Standard and specifies the requirements for establishing, implementing, maintaining and continually improving an ISMS within the context
of the organization.  
It also includes requirements for the assessment and treatment of information security risks tailored to the needs of the organization.  
It is generic and intended to be applicable to all organizations, regardless of type, size or nature.  

Comparison between ISO 27002 and 27001:
- **ISO 27001**: 
    - very specific and strict, and spells out, in detail, what a company must comply with and have in place to be formally certified.
- **ISO 27002**:
    - is a ‘guideline’ document, and advises companies on what they should have in place as far as their Information Security Management is concerned, in order to follow ‘Best Practice’
    - guides a company to structure its Information Security Management according to the experience of other companies
    - rather high level, and does not drill down to very detailed specifics.

**Directive**  
For the first layer of the model of the depth view we have the *Directive* part.  
Security Policy documents are required from Standards and Best Practices.  
In order to comply with the requirements of having a documented Direct process, it is important to define a methodology to create, manage and distribute
policy related documents.  
We will consider the following set of documents as component of an **Information Security Policy Architecture (ISPA)**  
- A Board-initiated Directive concerning Information Security Governance
- A Corporate Information Security Policy (CISP) flowing from the Directive
- A set of detailed sub-policies flowing from the CISP
- A set of company standards based on the Corporate and Detailed Policies
- A set of administrative and operational procedures, again flowing from the detailed set of sub-policies

![ISPA](https://github.com/edoardottt/MSc-CyberSecurity-Sapienza/blob/main/Security-Governance/resources/images/03-ISPA.png)  
(Image taken from: von Solms, S.H., von Solms, Rossouw “Information Security Governance”, Springer 2009)  

Guidelines to create a proper **Corporate Information Security Policy (CISP)**:
- The CISP must indicate Board and executive management support and commitment and it must be clear that the CISP flows from a higher-level directive
- The CISP must be accepted and signed by the CEO or equivalent officer
- The CISP must not be along document, nor must it be written in a technical form. The maximum length should be about four to five pages, and it must contain high-level statements concerning Information Security
- The CISP should not change very often, and must be ‘stable’ as far as technical developments and changes are concerned
- For the reason mentioned above, the CISP must not contain any references to specific technologies, and must be ’technology neutral’
- The CISP must indicate who is the owner of the Policy and what the responsibilities of other relevant people are
- The CISP must clearly indicate the Scope of the Policy, that is, all people who will be subject to the Policy
- The CISP must refer to possible (disciplinary) actions for non-conformance to the it and its lower-level constituent policies
- The CISP must be distributed as widely as possible in the company and must be covered in all relevant awareness courses
- The CISP must have a Compliance Clause

The set of **Sub-Policies** may differ from company to company, but usually the following ones will be defined for everybody:
- A Malicious Software Control Policy (Anti-Virus Policy)
- An Acceptable Internet Usage Policy
- An Acceptable Email Usage Policy
- A Logical Access Control Policy
- A Disaster Recovery (Backup) Policy
- A Remote Access Control Policy
- A Third Party Access Control Policy

It is very important that the ISPA clearly indicates where these different policies originate, this means that any sub-policy must be ‘linked’ or ‘traced back’ to the CISP in some way.

**Control**  
Compliance check is the main scope of the Control part of the model.  
It is possible to assess only what we can measure, so the compliance clauses that should be present inside the directives, need to provide a clear metric that can be evaluated.  
Traditionally, Compliance monitoring is done by performing periodic ICT Audit sessions where ICT risks are evaluated and an audit report is produced.  
These actions should be done in a proper way considering the timing. In particular we should be sure that the directive was received by everyone involved in the policies and that enough time has passed in order to perform a valid audit. The monitoring should also be done in near real time due to the fact that the world is fast and dynamic.  
It is not an exact science and few guidelines are available:
- Compliance Clauses must be clear and precise (e.g., a clause like “Employees
must take Information Security seriously” is vague... What does it mean “seriously”?)
- Compliance Clauses should express a way to measure its satisfaction
