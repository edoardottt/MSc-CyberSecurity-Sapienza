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


**5. Today Bitcoin is very popular and its use is increasing rapidly. Discuss potential problems that might arise in the future and that might dramatically limit the use of Bitcoin. [INCOMPLETE]**

One problem ould be the mining difficulty: Diﬃculty changes every 2016 blocks to maintain the time for ﬁnding a block to be about 10 minutes (more hash power more diﬃcult, less hash power less diﬃcult. Today about 500 x 10^9 hash). The more we go forward, higher will be the difficulty to mine new blocks. This means miners will have to upgrade the hash power (cost of electricity, cold climate, network speed...).  


**6. Which are the possibility to store bitcoins; discuss the risks that are associated.**

Simplest way: putting them on a local device (phone, laptop). Storing bitcoins implies managing Bitcoin secret keys: public information on the block chain: identity of the coin (QR code); secret information: secret key of the owner of the bitcoin; if you lose the device, if the device crashes, or if your file gets corrupted, your keys are lost, and so are your coins; if someone steals or breaks into your device, or it gets infected with malware, they can copy your keys and then they can then send all your coins to themselves. Storing bitcoins on your computer is like carrying around money in your wallet. It's useful to have some spending money, but you don't want to carry around your life savings because you might lose it, or somebody might steal it. Hot storage: storing bitcoins on your computer is like carrying money around in your wallet; convenient but also risky. Cold storage is oﬄine. It's locked away somewhere and it's not connected to the internet, and it's archival. It's safer and more secure, but of course, not as convenient. To have separate hot and cold storage, you need to have separate secret keys; otherwise the coins in cold storage would be vulnerable if the hot storage is compromised. You’ll want to move coins back and forth between the hot side and the cold side, so each side will need to know the other's addresses, or public keys. Whenever we transfer a coin from the hot side to the cold side we'd like to use a fresh cold address for that purpose. Since the cold side is not online we have to must ﬁnd out about those addresses. Generate a big batch of addresses all at once and those over to the hot side, and the hot side uses them up one by one. A more effective solution is to use a hierarchical wallet. It allows the cold side to use an essentially unbounded number of addresses and the hot side to know about these addresses, but with only a short, one-time communication between the two sides. But it requires a little bit of cryptographic trick. Conclusions: Users can lose bitcoin and other cryptocurrency tokens as a result of theft, computer failure, loss of access keys and more. Cold storage (or offline wallets) is one of the safest methods for holding bitcoin, as these wallets are not accessible via the Internet. Hardware wallets are potentially even safer, although users face the risk of losing access to their tokens if they misplace or forget their keys. There is also the concept of secret sharing: we want to divide our secret key into some number N of pieces. We want to do it in such a way that if we're given any K of those pieces then we'll be able to reconstruct the original secret, but if we're given fewer than K pieces then we won't be able to learn anything about the original secret.


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
