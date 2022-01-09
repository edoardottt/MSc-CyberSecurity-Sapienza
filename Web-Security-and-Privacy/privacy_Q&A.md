# Privacy Q&A

**1. Discuss how Bitcoin allows to preserve privacy of users and at the same time it does not allow double spending of bitcoins. Which is the computational hard problem that is used to guaranteee the privacy of users and why we trust bitcoin?**

Bitcoin uses a decentralized system, this means that rather than having a central authority that you have to go in order to register as a user in a system, you can register as a user all by yourself. You don't need to be issued a username nor you need to inform someone that you're going to be using a particular name. If you want a new identity, you can just generate one at any time, and you can make as many as you want. Example: If you prefer to be known by five different names, no problem! Just make five identities. If you want to be somewhat anonymous for a while, you can make a new identity, use it just for a little while, and then throw it away. All of these things are possible with decentralized identity management, and this is the way Bitcoin does identity. These identities are called addresses, in Bitcoin jargon. In the context of Bitcoin and cryptocurrencies an address is a hash of a public key. It's an identity that someone made, as part of this decentralized identity management scheme.  
The problem of btc double spending is solved by the distributed consensus protocol. If a user tries to spend the same btc two times, this means there will be a 'fork' in the blockchain (e.g. A->B and A->C), but this is not possible, the chain of blocks is one and the next blocks have to be concatenated to a single block. The users will choose only one of the two, reaching a shared consensus on which one will be extended, this means there will be a valid block and an unvalid one (called orphan block).
The computational hard problem that guarantees the privacy of the users is the hash function.

**2. Discuss how Bitcoin achieves consensus and discuss how the protocol does not allow i) Stealing Bitcoins, ii) Denial of service attack, and iii) Double spending Bitcoins.**

At regular intervals each node with a ledger proposes a new block to be added containing its own outstanding transaction set. Then all nodes execute some consensus protocol, where each node's input is its own proposed block. Some nodes may be malicious and put invalid transactions into their blocks, but we might assume that other nodes will be honest. If the consensus protocol succeeds, a valid block will be selected as the output. Bitcoin differs from traditional models for consensus: 1) Introduces the idea of incentives (=money), which is novel for a distributed consensus protocol. 2) Bitcoin's consensus algorithm uses randomization. Use of randomization implies that consensus is reached over a long period of time (no time guarantee). In about an hour most nodes reach consensus, but even at the end of that time, nodes can't be certain that any particular transaction or a block has made into the ledger. As time goes on, the probability that your view of any block will match the eventual consensus view increases with times.  
Bitcoin consensus algorithm (simplified):
1. New transactions are broadcast to all nodes
2. Each node collects new transations into a block
3. In each round a random node gets to broadcast its block
4. Other nodes accept the block only if all transactions in it are valid (unspent, valid signature)
5. Nodes express their acceptance of the block by including its hash in the next block they create
6. If there are more possibilities the node chooses the longest chain

Can Alice simply steal bitcoins belonging to another user at an address she doesn't control? No. Even if its is Alice's turn to propose the next block in the chain, she cannot steal other users' bitcoins. Doing so would require Alice to create a valid transation that spends that coin: That is to forge the owners' signatures which she cannot do if a secure digital signature scheme is used.  
Assume Alice really dislikes some other user Bob. Alice can then decide that she will not include any transactions originating from Bob's address in any block that she proposes to get onto the blockchain: she's denying service to Bob. While this is a valid attack that Alice can try but with minor effect: if Bob's transation doesn't make it into the next block that Alice proposes, he will just wait until an honest node gets the chance to propose a block and then his transaction will get into that block.  
Alice may try to launch a double-spend attack. Assume that Alice is a customer of some online that must pay Bob for some service. Alice creates a Bitcoin transaction from her address to Bob’s and broadcasts it to the network. We assume a majority of honest nodes and that some honest node creates the next block, and includes this transaction in that block. So there is now a block that was created by an honest node that contains a transaction that represents a payment from Alice to the merchant Bob. The latest block was generated by an honest node and includes a transaction in which Alice pays Bob. Upon seeing this transaction included in the block chain, Bob concludes that Alice has paid him. Suppose the next random node that is selected in the next round happens to be controlled by Alice. Alice proposes a block that ignores the block that contains the payment to Bob and instead contains a pointer to the previous block and includes a transaction that transfers the coins that she was sending to Bob to a diﬀerent address that she herself controls. Alice double spends. There are two blocks that contradict each other: the one with the Alice -> Bob transaction and the one with the Alice -> Alice transaction. They will not be pulished together by the same node. Which of the two block the network will reach consensus? Honest nodes follow the policy of extending the longest valid branch, so which branch will they extend? We do not know!! At the beginning the two branches have the same length (they only diﬀer in the last block and both of these blocks are valid). The node that chooses the next block then may decide to build upon either one of them, and this choice will largely determine whether or not the double-spend succeeds. In a distributed system the two transactions look identical, we do not know which is the legitimate one. Nodes try to extend the transaction they are aware: the accepted transaction is the one that will be the longest; time to extend is random. The accepted transaction is decided within some time window: more time more certainty. The block containing the short transaction to Bob is ignored by the network, and this is now called an
orphan block.


**3. i) Explain what is the meaning of the following claim: "Bitcoins are immutable"; ii)  the number of bitcoins available increases every day (for several years). Discuss this claim explaining why the designer of Bitcoin decided to include such possibility in the protocol.**

Immutability is one of the key features of Bitcoin and blockchain technology. Immutable transactions make it impossible for any entity (for example, a government or corporation) to manipulate, replace, or falsify data stored on the network. Since all historical transactions can be audited at any point in time, immutability enables a high degree of data integrity. The immutability of public blockchains can enhance the current trust and audit system. It can reduce the time and cost of audits since verifying information becomes much simpler or effectively redundant. Immutability can also increase the overall efficiency of many businesses by providing them with the opportunity to maintain a full historical record of their business processes. Immutability can also provide clarity to many business disputes, as it enables a verifiable, shared source of truth.  
The node that creates a block includes a special transaction in that block: a coin-creation transaction and the node can choose the recipient address of this transaction. This is the payment to the node in exchange for the service of creating that block to goes on the consensus chain. Today: the value of the block reward is 6.25 Bitcoins. But it actually halves every 210000 blocks. Based on the rate of block creation this means that the rate drops roughly every four years. We’re now in the second period. Halving every 210000 blocks gives a geometric series, and you might know that it means that there is a ﬁnite sum. It works out to a total of 21 million bitcoins. Every ten minutes, one lucky Bitcoin miner earns a reward for extending the block chain by one block. In 2009, the reward was 50 BTC. Since May 2020 is 6.25 BTC. (See https://blockchain.info to issue queries about the block chain.); every 210000 blocks the reward halves. Mining is the only mechanism for creating new bitcoins. The total number of Bitcoins will never exceed 21M. The rewarded miner also receives all (optional) transaction fees in the block.

**4. Bitcoin network: Bitcoin is completely anonymous but all transactions are public. Discuss how the network of Bitcoin transactions looks like and how it is possible to use this knowledge to deanonymize the Bitcoin network. Discuss at least one example.**  

Many users broadcast transactions; nodes must agree on exactly which transactions were broadcast and the order in which these transactions happened. Many ledgers: At any given point, all the nodes in the peer-to-peer network have a ledger consisting of a sequence of blocks, each containing a list of transactions, that they’ve reached consensus on. The protocol is able to keep consistency (with time delay). All nodes agree on a single, global ledger (=accounting book) for the system. A transaction contains Alice's signature, an instruction to pay to Bob's public key, and a hash. The hash represents a pointer to a previous transaction output that Alice received and is now spending. The pointer references a transaction that was included in some previous block in the consensus chain. Blocks (set of transactions) include a hash pointer to the previous block that they're extending. Extending a block takes a random time and significant computational effort. Ledger (set of blocks) contains all blocks with all Bitcoin transactions.  
Let's define some concepts: 'Anonymous' means without a name: without using your real name or without using any name at all. Bitcoins: addresses are public key hashes rather than real identities, Computer scientists call this pseudonimity. The concept of 'Unlinkability': Hard to link different addresses of the same user, hard to link different transactions of the same user, hard to link sender of a payment to its recipient. *Anonimity = Pseudonymity + Uninkability*. Pseudonymity is not enough for "privacy" in Bitcoins! Bitcoin Block chain (and transactions) is public. Linking Bitcoin addresses to real identities is possible and this might allow to ﬁnd identities. Shared spending is evidence of joint control, addresses can be linked transitively. Can we connect little clusters corresponding to individuals to their real-life identities? Directly transacting with individuals; Via service providers: eventually a bitcoin user will interact with a service provider that must ask your identity (by the law); Carelessness: people are not always concerned; Use of network layer characteristic: often "the ﬁrst node to inform you of a transaction is probably the source of it". Bitcoin is not anonymous. Bitcoin is pseudonymous, but pseudonymity is not enough if your goal is to achieve privacy. Recall that the block chain is public and anyone can look up all Bitcoin transactions that involved a given address. If anyone is ever able to link your Bitcoin address to your real world identity, then all of your transactions (past, present, and future) will have been linked back to your identity. One real life example is Ross Ulbrucht of Silk Road.


**5. Today Bitcoin is very popular and its use is increasing rapidly. Discuss potential problems that might arise in the future and that might dramatically limit the use of Bitcoin.**

The number of BTC that can be mined is limited, the maximum number is 21 million, today we mined about 15 million, the problem is that we don't know how the bitcoin world will evolve after all bitcoins will be mined. Another important problem is the computational power needed to mine new blocks. As the time pass, more power is needed to mantain the blockchain in a trustable manner, this is a huge environmental problem. Another problem is the problem related to the fees. When a new transaction is created, the output cannot be higher than the input (so like creating coins), but the output can be less than the input. This means that the difference between the input and the output will be a 'fee' and that amount will end up in the hands of the miner that mined the block in which the transaction is present. The mining process is a very intensive process, so it's very likely that miners will choose transactions that offer the highest fees. This could mean that the transactions having high fees will be validated in a little time window, instead the ones offering a low fee or no fee will wait a large amount of time. 


**6. Which are the possibility to store bitcoins; discuss the risks that are associated.**

Simplest way: putting them on a local device (phone, laptop). Storing bitcoins implies managing Bitcoin secret keys: public information on the block chain: identity of the coin (QR code); secret information: secret key of the owner of the bitcoin; if you lose the device, if the device crashes, or if your file gets corrupted, your keys are lost, and so are your coins; if someone steals or breaks into your device, or it gets infected with malware, they can copy your keys and then they can then send all your coins to themselves. Storing bitcoins on your computer is like carrying around money in your wallet. It's useful to have some spending money, but you don't want to carry around your life savings because you might lose it, or somebody might steal it. Hot storage: storing bitcoins on your computer is like carrying money around in your wallet; convenient but also risky. Cold storage is oﬄine. It's locked away somewhere and it's not connected to the internet, and it's archival. It's safer and more secure, but of course, not as convenient. To have separate hot and cold storage, you need to have separate secret keys; otherwise the coins in cold storage would be vulnerable if the hot storage is compromised. You’ll want to move coins back and forth between the hot side and the cold side, so each side will need to know the other's addresses, or public keys. Whenever we transfer a coin from the hot side to the cold side we'd like to use a fresh cold address for that purpose. Since the cold side is not online we have to must ﬁnd out about those addresses. Generate a big batch of addresses all at once and those over to the hot side, and the hot side uses them up one by one. A more effective solution is to use a hierarchical wallet. It allows the cold side to use an essentially unbounded number of addresses and the hot side to know about these addresses, but with only a short, one-time communication between the two sides. But it requires a little bit of cryptographic trick. Conclusions: Users can lose bitcoin and other cryptocurrency tokens as a result of theft, computer failure, loss of access keys and more. Cold storage (or offline wallets) is one of the safest methods for holding bitcoin, as these wallets are not accessible via the Internet. Hardware wallets are potentially even safer, although users face the risk of losing access to their tokens if they misplace or forget their keys. There is also the concept of secret sharing: we want to divide our secret key into some number N of pieces. We want to do it in such a way that if we're given any K of those pieces then we'll be able to reconstruct the original secret, but if we're given fewer than K pieces then we won't be able to learn anything about the original secret.


**7. Even when all nodes of Bitcoin are honest, blocks will occasionally get orphaned: if two miners Minnie and Mynie discover blocks nearly simultaneously, neither will have time to hear about the other’s block before broadcasting hers.
    • What determines whose block will end up on the consensus branch?
    • What factors affect the rate of orphan blocks? 
    • if Mynie hears about Minnie’s block just before she’s about to discover hers, does that mean she wasted her effort?**

to do

**8. Discuss digital coins that have been proposed after Bitcoin focusing on their differences from Bitcoin.**

Ethereum is a decentralized platform that runs "smart contracts". Smart contracts are "self-executing" contracts or applications that run exactly as programmed without any possibility of downtime (i.e. the blockchain is always running), censorship, fraud or third-party interference. Ethereum has a capability that goes far beyond that of a pure P2P digital cash equivalent like Bitcoin. In simple terms, it is much like a smartphone operating system on top of which software applications can be built. Technically speaking, the Ethereum platform itself is not a cryptocurrency and is permissioneless blockchains. However Ethereum requires a form of on-chain value to incentivise transaction validation
within the network (i.e. a form of payment for the network nodes that execute the operations). This is where Ethereum's native cryptocurrency "ether" (ETH) comes into play. Ether does not only allow smart contracts to be built on the Ethereum platform (i.e. it fuels them), but it also functions as a medium of exchange.  
Ripple is an open-source, P2P decentalized digital payment platform that allows for fast transfers of currency (e.g. US Dollar, Yen, Bitcoin, ...) launched in 2012 by the company Ripple (Labs) responsible for the further development of the Ripple protocol. First company to have received a "BitLicense" for an institutional use case of digital assets from New York’s Department of Financial Services. Ripple's uses the cryptocurrency XRP. XRP was built to become a bridge currency to allow ﬁnancial institutions to settle cross-border payments a lot faster and cheaper than they can using the global payment networks that are in place today, which can be slow and involve multiple middlemen (i.e. banks). According to Ripple, XRP can handle more than 1,500 transactions per second. While it was initially developed and intended for enterprise use, it has been adopted by a large number of cryptocurrency users. Ripple (XRP) is not based on a PoW or a PoS mechanism to validate transactions, but it makes use of its own speciﬁc consensus protocol. The total supply of XRP has been fully “pre-mined” (or better: created upon the coin’s inception) by its inventors. At present, 8 billion XRP is held by Ripple (Labs), (39 billion XRP has been distributed; and 52 billion XRP has been placed in escrow to create certainty of XRP supply at any given time.
Other mentionable coins are: Bitcoin cash (BCH), litecoin, IOTA.


**9. Illustrate Mixing in Bitcoin discussing its advantages and its limitations; discuss digital coins that allow anonimity.**

Bitcoin activities are recorded and available publicly via the blockchain; when you finally use Bitcoin to pay for goods and services, you will of course need to provide your name and address to the seller for delivery purposes. It means that a third party can trace your transactions and find ID information. To avoid this, such mixing service provide the ability to exchange your bitcoins. Mixing services are used to mix one's funds with other people's money, intending to confuse the trail back to the funds' original source. In traditional financial systems, the equivalent would be moving funds through banks in countries with bank secrecy laws (Cayman islands, Bahamas etc.). When mixing bitcoins, you send your money to an anonymous service and they will send you someone else's coins. So, now, whatever those coins were used for may now be traceable back to you. Additionally, mixing large amounts of money may be illegal.  
It's also possible to use decentralized mixing, why? No bootstrapping problem, theft impossible, possibly better anonymity and more philosophically aligned with Bitcoin.  
Coinjoin algorithm:  
1. Find peers who want to mix
2. Exchange input/output addresses
3. Construct transaction
4. Send it around, collect signatures (Before signing, each peer checks if her output is present)
5. Broadcast the transaction

Coinjoin remaining problems: Hot to find peers, peers know your input-output mapping (This is a worse problem than for centralized mixes), DoS.


**10. Discuss how people might release sensible data in exchange of an immediate advantage. Discuss examples that give evidence to your claims. Possibly give a specific example in which you or a person you know was involved.**

I am not understanding the question.

**11. Discuss extension of blockchain technologies beyond digital currency.**

todo

**12. When do we claim that a social network has been deanonymized? Clearly it is not necessary that all data in the network have been deanonymized. Provide the different definitions that are used to claim that a network has been (possibly partially) deanonymized? Be specific and provide at least one example.**

todo

**13. What is pseudononimity and discuss key features with reference to a practical example. Explain the advantages and weakness of pseudononimity discussing how it should be used in practical situations.**

todo

**14. Explain what is k-anonimity of a database and provide one example where a k-anonymous database does not leak any  information (i.e. it preserves privacy) and one in which a k-anonymous database can leak information.**

K-anonimity is a technique used to understand how to release public informations from a private database without violating privacy. However, be aware that only using k-anonimity there could still be some problems (solved partially by t-closeness and l-diversity). When we have a private table, we can distinguish between three main groups of data: Key attributes, quasi-identifiers and sensitive attributes. Of course we don't want to release the sensitive data linked to personally identifiable informations, so we need to delete the first ones (e.g. names, SSN, phone number...). So we have now in our table the quasi-identifiers and the sensitive attributes. We could say that this table preserves privacy, but it could not. We need to modify the table in order to avoid inference control by the attacker. We use the k-anonimity to be sure that, identified an equivalence class (same quasi-identifiers), we have at least k records in that class. Let's make two useful examples: if we have a 4-anonymous table, this means at least 4 records for each equivalence class; let's suppose we have at least 4 records having 4 different sensitive attributes. It's difficult to understand which records belong to. Different is the case if we have 4 sensitive attributes with all the same value. It's obvious in this case that if Bob belongs to that particular equivalence class, that unique sensitive attributes belong to him.

**15. Given the following table
k-Anonymity:
(i) Determine the largest k such that the table is k-anonym. Explain which rows contradict the (k+1)-
anonymity.
(ii) You may now use suppression on the columns. Assume that by removing one digit from Age or Zip, or suppressing the Sex attribute, you lose one ”value”. What is the minimal value loss required to achieve 5-anonymity?
l-anonimity
(iii) What is the largest l such that the above mentioned dataset is distinct l-diverse?
(iv) Assume suppressing the last digit of the Zip column and generalising Age to {[0- 22]; [23-90]}
For what value of l can distinct l-diversity now be guaranteed.**

i) The largest k is 2. This because under the Age column we have only 2 occurrences of the value 24, so it's the minimum.  
ii) The minimal loss I found is obtained removing the second digit for the Age value (2*) and suppressing the zip values 10001.  
iii) This generalized table is 2-diverse.  
iv) This is still 2-diverse.  

**16. K-anonimity is not sufficient for maintaining anonimity.  Provide other formulations that enforce the concept. Discuss the approach and provide one example that shows that this approach might be better than K-anonimity; show  one negative example that shows that this  approach is not adequate.**

Even if we have a k-anonymous table, if we have an equivalence class and this has all the same sensitive values, it's obvious to link sensitive values and equivalence class records. So we should modify the generalization in a manner that we have diversity in sensitive values of the records in each equivalence class. l-diversity means that we have at least l different elements in those fields for an equivalence class. Anyway, l-diversity doesn't take into account the semantic value of the values: if we take an equivalence class with 99% if values HIV+ and 1% HIV-; this is really different from 99% HIV- and 1% HIV+. Those are two complete different degrees of sensitivity.

**17. The main limitation of K-anonimity and its extensions  for guaranteeing privacy is the use of additional information. Provide at least two examples.**

todo

**18. What is differential privacy and discuss its advantages and disadvantages with respect ot other approaches. Provide one example in which differential privacy is useful.**

todo

**19. Discuss how differential privacy has been used in the US census. In particular discuss an example that motivates why publishing census data does not preserve privacy and discuss the kind of operation that are performed to achieve differential privacy**

There were made some census on US populations in differents years (2000, 2010, 2018...). The data that has been collected concerned about 6 different fields (race, sex, location, age...). The US agencies had roughly ~1.7 GB of data belonging to about 300 million citizens. They cannot publish the data without any modification, because this could mean (and will) a privacy violation. So they managed to collect all the respondents informations, then there was a noise addition, and then they published the statistical data. The main challenge was to understand how much noise add to the records, in order to achieve both privacy and accuracy of the informations. The epsilon in differential privacy is a measure of amount of data loss; the higher epsilon is, more accuracy you have, but of course this means no privacy at all. The lower epsilon is, higher will be the privacy, but the data of course will be less accurate. In a study was discovered that using the informations coming from the first census, it was possible to deanonymize and reconstruct the data of 17% of US population. There were taken into account two methodologies: block by block perturbation and top-down framework perturbation. The first one means add noise to each block separately (a 'block' is the littlest piece of US surface considered), while the latter means add noise for the histograms related to whole population and then consequently to other histograms with higher accuracy of localization (state, city, tracks, group of blocks, block). According to Prof. Ruggles, "Differential privacy will degrade the quality of data available about the population, and will probably make scientifically useful public use microdata impossible."

**20. What are according to you the main concerns of privacy protection in social networks?**

todo

**21. Discuss the difference between a  semi-honest attacker and a malicious one in a social network; give examples of attacks.**

todo

**22. Present and discuss how the Netflix network was deanonymized.**

Due to a contest for recommendation system Netflix released a version of the database of ratings, with some level of anonymization (names removed, perturbation of information). Combined with background knowledge, which was IMDB, an attacker can perform a deanonymization attack with usage of another, similar, database.  
In details, the objective was to:  
- Fix some target record of original Netflix dataset  
- Try to learn as much about this record as possible  

But background knowledge (IMDB dataset) was noisy, and Netflix dataset was perturbed (with only a sample of records released).
Anyway, since ratings about not top100 movies are very personalized (is unusual for two users give same rating on same not so known movies), the researchers in this project found out that, with this cross references on movie ratings and date of ratings, some users turned out to be members of both IMDB and Netflix (with some personal informations voluntarily released on IMDB), and personal information was obtained with a very low percentage of error (in the experiment, just 4 ratings, in mean, were enough to uniquely identify the user).
With only eight movie ratings, and dates that may be up to two weeks in error, they can uniquely identify 99% of the records in the dataset. After all, all they need is a little bit of identifiable data: from the IMDb, from your blog, from anywhere.
The moral is that it takes only a small named database for someone to pry the anonymity off a much larger anonymous database

**23. Which are the main characteristics of  the new European regulations for privacy for individuals?**

todo

**24. Which are the main characteristics of  the new European regulations for privacy for business?**

todo

**25. Privacy by Design (PbD) is an important technical element in the GDPR. Present main ideas of PbD, its advantages and its limitations.**

Privacy by Design is a concept recently introduced in the GDPR (effectively active 25 May 2018). This term refers to an approach to system engineering which promotes privacy throghout the whole engineering process; it's not about data protection but designing so data doesn't need protection. It's a proactive methodology and not reactive, this means we would like to have a system in which it's already present data protection, so we don't need to try to recover from a data/privacy breach. Data minimization is the most important safeguard in protecting personally identifiable information (PII). The use of cryptography, de-identification techniques, data aggregation are absolutely critical. De-identification techniques are intended to remove identifying information from a dataset while retaining some utility in the remaining data. The de-identified data can be re-identified and this can cause two problems: Disclosure of private facts affecting individuals whose data were re-identified; Damage to reputation affects instead the organization that performed the de-identification. A problem for the de-identification is the meaning that people and experts give to this term: someone states that this means the percentage of de-identified records that can be re-identified, while others consider it as the probability of record re-identification in the future. As we can understand from these two different concepts, there is no wide accepted standard on de-identification, and this is a huge problem. One other criticism against PbD is the fact that is a 'vague' (or opaque) concept, it leaves so many open questions while engineering systems.  

**26. Pseudoanonymization is an  important technical elements in the GDPR.  Present main ideas of  Pseudoanonymization, its adavantages and its limitations.**

todo

**27. According to the new European rules companies and organizations need a Data Protection Officer; which are the task and the obligations related to this person?**

todo

**28. The regulations and law that protect sensible data are evolving.  With reference to the Italian regulations  discuss which data are considered sensible and which are the main rules to protect such data. Discuss which are the main problems in processing information  according to the regulations and which kind of  difficulties/problems such regulations poses  to companies and administrations.**

todo

**29. What are the main challenges and difficulties of making a job as an expert in  privacy protection? Do you think that there will be good opportunities (e.g. well paid?, interesting?) for such a job?  Which are the main issues that you foresee. Explain why yes or not.**

todo
