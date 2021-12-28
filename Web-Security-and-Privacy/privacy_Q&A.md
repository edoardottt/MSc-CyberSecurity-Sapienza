# Privacy Q&A

**1. Discuss how Bitcoin allows to preserve privacy of users and at the same time it does not allow double spending of bitcoins. Which is the computational hard problem that is used to guaranteee the privacy of users and why we trust bitcoin?**

Bitcoin uses a decentralized system, this means that rather than having a central authority that you have to go in order to register as a user in a system, you can register as a user all by yourself. You don't need to be issued a username nor you need to inform someone that you're going to be using a particular name. If you want a new identity, you can just generate one at any time, and you can make as many as you want. Example: If you prefer to be known by five different names, no problem! Just make five identities. If you want to be somewhat anonymous for a while, you can make a new identity, use it just for a little while, and then throw it away. All of these things are possible with decentralized identity management, and this is the way Bitcoin does identity. These identities are called addresses, in Bitcoin jargon. In the context of Bitcoin and cryptocurrencies an address is a hash of a public key. It's an identity that someone made, as part of this decentralized identity management scheme.
The problem of btc double spending is solved by the distributed consensus protocol. If a user tries to spend the same btc two times, this means there will be a 'fork' in the blockchain (e.g. A->B and A->C), but this is not possible, the chain of blocks is one and the next blocks have to be concatenated to a single block. The users will choose only one of the two, reaching a shared consensus on which one will be extended, this means there will be a valid block and an unvalid one (called orphan block).
The computational hard problem that guarantees the privacy of the users is the hash function.

2. Discuss how Bitcoin achieves consensus and discuss how the protocol does not allow i) Stealing Bitcoins, ii) Denial of service attack, and iii) Double spending Bitcoins.

3. i) Explain what is the meaning of the following claim”Bitcoins are immutable”; ii)  the number of bitcoins available increases every day (for several years). Discuss this claim explaining why the designer of Bitcoin decided to include such possibility in the protocol.

4. Bitcoin network: Bitcoin is completely anonymous but  all transactions are public. Discuss how the netowk of Bitcoin transactions looks like and how it is possible to use this knowledge to  deanonymize the Bitcoin network. Discuss at least one example. 

5. Today Bitcoin is very popular and its use is increasing rapidly. Discuss potential problems that might arise in the future and that might dramatically limit the use of Bitcoin.

6. Which are the possibility to store bitcoins; discuss  the risks that are associated.

7. Even when all nodes of Bitcoin are honest, blocks will occasionally get orphaned: if two miners Minnie and Mynie discover blocks nearly simultaneously, neither will have time to hear about the other’s block before broadcasting hers.
    • What determines whose block will end up on the consensus branch?
    • What factors affect the rate of orphan blocks? 
    • if Mynie hears about Minnie’s block just before she’s about to discover hers, does that mean she wasted her effort?

8. Discuss digital coins that have been proposed after Bitcoin  focusing on their differences from Bitcoin.

9. Illustrate  Mixing in Bitcoin discussing its advantages and its limitations; discuss digital coins that allow anonimyty.

10. Discuss how people might release sensible data in exchange of  an immediate advantage.  Discuss examples that give evidence to your claims. Possiblty give a specific example in which you or a person you know was involved. 

11. Discuss extension of blockchain technologies beyond digital currency.

12. When do we claim that a social network has been deanonymized? Clearly it is not necessary that all data in the network have been deanonymized. Provide the different definitions that are used to claim that a network has been (possibly partially) deanonymised? Be specific and provide at least one example.

13. What is pseudoanonimity and discuss key features with reference to a practical example.  Explain the advantages and weakness of pseudoanonimity discussing how it should be used in practical situations. 

14. Explain what is k-anonimity of a data base  and provide one example where a k-anonymous data base does not leak any  information (i.e. it preserves privacy) and one in which  a k-anonymous data base can leak information. 

15. Given the following table


k-Anonymity:
(i) Determine the largest k such that the table is k-anonym. Explain which rows contradict the (k+1)-
anonymity.
(ii) You may now use suppression on the columns. Assume that by removing one digit from Age or Zip, or suppressing the Sex attribute, you lose one ”value”. What is the minimal value loss required to achieve 5-anonymity?
l-anonimity
(iii) What is the largest l such that the above mentioned dataset is distinct l-diverse?
(iv) Assume suppressing the last digit of the Zip column and generalising Age to {[0- 22]; [23-90]}
For what value of l can distinct l-diversity now be guaranteed.

16. K-anonimity is not sufficient for maintaining anonimity.  Provide other formulations that enforce the concept. Discuss the approach and provide one example that shows that this approach might be better than K-anonimity; show  one negative example that shows that this  approach is not adequate.

17. The main limitation of K-anonimity and its extensions  for guaranteeing privacy is the use of additional information. Provide at least two examples.

18. What is differential privacy and discuss its advantages and disadvantages with respect ot other approaches. Provide one example in which differential privacy is useful.

19. Discuss how differential privacy has been used in the US census. In particular discuss an example that motivates why publishing census data does not preserve privacy and discuss the kind of operation that are performed to achieve differential privacy

20. What are according to you the main concerns of privacy protection in social networks? 

21. Discuss the difference between a  semi-honest attacker and a malicious one in a social network; give examples of attacks.  

22. Present and discuss how the Netflix network was deanonymized. 

23. Which are the main characteristics of  the new European regulations for privacy for individuals?

24. Which are the main characteristics of  the new European regulations for privacy for business? 

25.  Privacy by Design (PbD) is an  important technical elements in the GDPR.  Present main ideas of  PbD, its adavantages and its limitations.

26. Pseudoanonymization is an  important technical elements in the GDPR.  Present main ideas of  Pseudoanonymization, its adavantages and its limitations. 

27. According to the new European rules companies and organizations need a Data Protection Officer; which are the task and the obligations related to this person?

28. The regulations and law that protect sensible data are evolving.  With reference to the Italian regulations  discuss which data are considered sensible and which are the main rules to protect such data. Discuss which are the main problems in processing information  according to the regulations and which kind of  difficulties/problems such regulations poses  to companies and administrations.

29. What are the main challenges and difficulties of making a job as an expert in  privacy protection? Do you think that there will be good opportunities (e.g. well paid?, interesting?) for such a job?  Which are the main issues that you foresee. Explain why yes or not. 
