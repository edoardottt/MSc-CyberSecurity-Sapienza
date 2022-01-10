# Privacy Q&A

**1. Discuss how Bitcoin allows to preserve privacy of users and at the same time it does not allow double spending of bitcoins. Which is the computational hard problem that is used to guaranteee the privacy of users and why we trust bitcoin?**

Bitcoin uses a decentralized system, this means that rather than having a central authority that you have to go in order to register as a user in a system, you can register as a user all by yourself. You don't need to be issued a username nor you need to inform someone that you're going to be using a particular name. If you want a new identity, you can just generate one at any time, and you can make as many as you want. Example: If you prefer to be known by five different names, no problem! Just make five identities. If you want to be somewhat anonymous for a while, you can make a new identity, use it just for a little while, and then throw it away. All of these things are possible with decentralized identity management, and this is the way Bitcoin does identity. These identities are called addresses, in Bitcoin jargon. In the context of Bitcoin and cryptocurrencies an address is a hash of a public key. It's an identity that someone made, as part of this decentralized identity management scheme.  
The problem of btc double spending is solved by the distributed consensus protocol. If a user tries to spend the same btc two times, this means there will be a 'fork' in the blockchain (e.g. A->B and A->C), but this is not possible, the chain of blocks is one and the next blocks have to be concatenated to a single block. The users will choose only one of the two, reaching a shared consensus on which one will be extended, this means there will be a valid block and an unvalid one (called orphan block).
The computational hard problem that guarantees the privacy of the users is the hash function.

**2. Discuss how Bitcoin achieves consensus and discuss how the protocol does not allow i) Stealing Bitcoins, ii) Denial of service attack, and iii) Double spending Bitcoins.**

Blockchain is a open permissionless P2P network in which anyone can join and leave as they want. As every P2P network is composed by several nodes and they have to communicate with peers and all together they will form a network. When a node wants to create a new transaction that node has to sign the transaction with its private key, then broadcasts the transaction to its peers and they will send it to their peers, reaching the whole network. When a node hears about a new unvalidated transaction, it puts it in the memory pool (also called mempool), then it tries to validate it and if it is not valid it rejects that trans. If it is valid, it tries to mine a new block with that transaction inside that block. Then, if it finds a valid nonce and so a valid block is mined it broadcasts the new mined block hoping the majority of the nodes will include that block inside the blockchain. To steal a bitcoin that you don't own means to has the private key of an address. If you have the private key, you can steal it; meanwhile if you don't know the private key of another user it's nearly impossible to find that key, so it's quite impossible to steal bitcoins. Let's suppose Alice doesn't like Bob, this means Alice will reject ans treat as invalid any new transaction or block proposed by Bob. Does this mean Bob won't be part of the blockchain? No, if the transactions made by Bob will not finish in a block mined by Alice they will be part of a block of another user. We can say that the Bob's transactions will find their way inside the blockchain. The problem of double spending is when a user owns a coin and he/she tries to spend the same coin two times. For example Charlie has to pay Bob, he creates two transactions: one from C to B and the other one from C to C. The solution to this problem is the Bitcoin consensus algorithm: the nodes have to validate the transactions and the transactions are valid only if the majority of nodes agree on the validity of a transaction. Therefore, this means only one of the transaction will be valid, invalidating the other one.

**3. i) Explain what is the meaning of the following claim: "Bitcoins are immutable"; ii)  the number of bitcoins available increases every day (for several years). Discuss this claim explaining why the designer of Bitcoin decided to include such possibility in the protocol.**

Immutability is one of the key features of Bitcoin and blockchain technology. Immutable transactions make it impossible for any entity (for example, a government or corporation) to manipulate, replace, or falsify data stored on the network. Since all historical transactions can be audited at any point in time, immutability enables a high degree of data integrity. The immutability of public blockchains can enhance the current trust and audit system. It can reduce the time and cost of audits since verifying information becomes much simpler or effectively redundant. Immutability can also increase the overall efficiency of many businesses by providing them with the opportunity to maintain a full historical record of their business processes. Immutability can also provide clarity to many business disputes, as it enables a verifiable, shared source of truth.  
The node that creates a block includes a special transaction in that block: a coin-creation transaction and the node can choose the recipient address of this transaction. This is the payment to the node in exchange for the service of creating that block to goes on the consensus chain. Today: the value of the block reward is 6.25 Bitcoins. But it actually halves every 210000 blocks. Based on the rate of block creation this means that the rate drops roughly every four years. We’re now in the second period. Halving every 210000 blocks gives a geometric series, and you might know that it means that there is a ﬁnite sum. It works out to a total of 21 million bitcoins. Every ten minutes, one lucky Bitcoin miner earns a reward for extending the block chain by one block. In 2009, the reward was 50 BTC. Since May 2020 is 6.25 BTC. (See https://blockchain.info to issue queries about the block chain.); every 210000 blocks the reward halves. Mining is the only mechanism for creating new bitcoins. The total number of Bitcoins will never exceed 21M. The rewarded miner also receives all (optional) transaction fees in the block.

**4. Bitcoin network: Bitcoin is completely anonymous but all transactions are public. Discuss how the network of Bitcoin transactions looks like and how it is possible to use this knowledge to deanonymize the Bitcoin network. Discuss at least one example.**  

Many users broadcast transactions; nodes must agree on exactly which transactions were broadcast and the order in which these transactions happened. Many ledgers: At any given point, all the nodes in the peer-to-peer network have a ledger consisting of a sequence of blocks, each containing a list of transactions, that they’ve reached consensus on. The protocol is able to keep consistency (with time delay). All nodes agree on a single, global ledger (=accounting book) for the system. A transaction contains Alice's signature, an instruction to pay to Bob's public key, and a hash. The hash represents a pointer to a previous transaction output that Alice received and is now spending. The pointer references a transaction that was included in some previous block in the consensus chain. Blocks (set of transactions) include a hash pointer to the previous block that they're extending. Extending a block takes a random time and significant computational effort. Ledger (set of blocks) contains all blocks with all Bitcoin transactions.  
Let's define some concepts: 'Anonymous' means without a name: without using your real name or without using any name at all. Bitcoins: addresses are public key hashes rather than real identities, Computer scientists call this pseudonimity. The concept of 'Unlinkability': Hard to link different addresses of the same user, hard to link different transactions of the same user, hard to link sender of a payment to its recipient. *Anonimity = Pseudonymity + Unlinkability*. Pseudonymity is not enough for "privacy" in Bitcoins! Bitcoin Block chain (and transactions) is public. Linking Bitcoin addresses to real identities is possible and this might allow to ﬁnd identities. Shared spending is evidence of joint control, addresses can be linked transitively. Can we connect little clusters corresponding to individuals to their real-life identities? Directly transacting with individuals; Via service providers: eventually a bitcoin user will interact with a service provider that must ask your identity (by the law); Carelessness: people are not always concerned; Use of network layer characteristic: often "the ﬁrst node to inform you of a transaction is probably the source of it". Bitcoin is not anonymous. Bitcoin is pseudonymous, but pseudonymity is not enough if your goal is to achieve privacy. Recall that the block chain is public and anyone can look up all Bitcoin transactions that involved a given address. If anyone is ever able to link your Bitcoin address to your real world identity, then all of your transactions (past, present, and future) will have been linked back to your identity. One real life example is Ross Ulbricht of Silk Road.


**5. Today Bitcoin is very popular and its use is increasing rapidly. Discuss potential problems that might arise in the future and that might dramatically limit the use of Bitcoin.**

The number of BTC that can be mined is limited, the maximum number is 21 million, today we mined about 15 million, the problem is that we don't know how the bitcoin world will evolve after all bitcoins will be mined. Another important problem is the computational power needed to mine new blocks. As the time pass, more power is needed to mantain the blockchain in a trustable manner, this is a huge environmental problem. Another problem is the problem related to the fees. When a new transaction is created, the output cannot be higher than the input (so like creating coins), but the output can be less than the input. This means that the difference between the input and the output will be a 'fee' and that amount will end up in the hands of the miner that mined the block in which the transaction is present. The mining process is a very intensive process, so it's very likely that miners will choose transactions that offer the highest fees. This could mean that the transactions having high fees will be validated in a little time window, instead the ones offering a low fee or no fee will wait a large amount of time. 


**6. Which are the possibility to store bitcoins; discuss the risks that are associated.**

Simplest way: putting them on a local device (phone, laptop). Storing bitcoins implies managing Bitcoin secret keys: public information on the block chain: identity of the coin (QR code); secret information: secret key of the owner of the bitcoin; if you lose the device, if the device crashes, or if your file gets corrupted, your keys are lost, and so are your coins; if someone steals or breaks into your device, or it gets infected with malware, they can copy your keys and then they can then send all your coins to themselves. Storing bitcoins on your computer is like carrying around money in your wallet. It's useful to have some spending money, but you don't want to carry around your life savings because you might lose it, or somebody might steal it. Hot storage: storing bitcoins on your computer is like carrying money around in your wallet; convenient but also risky. Cold storage is oﬄine. It's locked away somewhere and it's not connected to the internet, and it's archival. It's safer and more secure, but of course, not as convenient. To have separate hot and cold storage, you need to have separate secret keys; otherwise the coins in cold storage would be vulnerable if the hot storage is compromised. You’ll want to move coins back and forth between the hot side and the cold side, so each side will need to know the other's addresses, or public keys. Whenever we transfer a coin from the hot side to the cold side we'd like to use a fresh cold address for that purpose. Since the cold side is not online we have to must ﬁnd out about those addresses. Generate a big batch of addresses all at once and those over to the hot side, and the hot side uses them up one by one. A more effective solution is to use a hierarchical wallet. It allows the cold side to use an essentially unbounded number of addresses and the hot side to know about these addresses, but with only a short, one-time communication between the two sides. But it requires a little bit of cryptographic trick. Conclusions: Users can lose bitcoin and other cryptocurrency tokens as a result of theft, computer failure, loss of access keys and more. Cold storage (or offline wallets) is one of the safest methods for holding bitcoin, as these wallets are not accessible via the Internet. Hardware wallets are potentially even safer, although users face the risk of losing access to their tokens if they misplace or forget their keys. There is also the concept of secret sharing: we want to divide our secret key into some number N of pieces. We want to do it in such a way that if we're given any K of those pieces then we'll be able to reconstruct the original secret, but if we're given fewer than K pieces then we won't be able to learn anything about the original secret.


**7. Even when all nodes of Bitcoin are honest, blocks will occasionally get orphaned: if two miners Minnie and Mynie discover blocks nearly simultaneously, neither will have time to hear about the other’s block before broadcasting hers.
    • What determines whose block will end up on the consensus branch?
    • What factors affect the rate of orphan blocks? 
    • if Mynie hears about Minnie’s block just before she’s about to discover hers, does that mean she wasted her effort?**

1. In general, if we have two blocks A and B at the same time, we can have the following situation:  
a. A valid and B invalid = the miner will obviously continue to choose chain A  
b. A valid and B valid = The general rule is that a miner continues on the longest branch. In this situation we have two branches with the same length so a miner can pick one at random. This means that the next block will determine the longest chain. The nodes try to extend the transaction they are aware of: the accepted transaction is the one that will be the longest; the time to extend is random. The accepted transaction is decided within a time window: more time, more certainty.  
2. There are essentially two main factors affecting the orphan block rate:  
a. Network delay = delay in the network, therefore more time to reach consensus;  
b. Time to find a block = Time to find a block.   Easier hash puzzle → Shorter average time to build one block → Greater chance of having different blocks at the same time → More chains → More orphaned blocks.  
3. Mynie wastes no time if Minnie's lock is invalid. In fact, in this case Mynie can discard the received block and continue solving the hash puzzle.
Instead, if Minnie's block is valid, Mynie has no incentive to continue working on her block because with a high probability she will become an orphan block.
No, her block could be the one with the longest valid branch and be approved by consensus before the other. (she or she looks for a new block starting from Minnie's) (??????)

**8. Discuss digital coins that have been proposed after Bitcoin focusing on their differences from Bitcoin.**

There are two methods for adding new blocks and validating transactions (thus enlarging the blockchain):  
1. Proof of Work (PoW) = network participants must solve a "Cryptographic puzzle" in order to add new blocks to the blockchain. This process is called "mining".
The mining calculation gets bigger and bigger with time and therefore the miners will receive a reward in digital coins. BitCoins rely on this PoW consensus mechanism.  
2. Proof of Stake (PoS) = in order to participate in the validation, a network node must demonstrate that it has a certain amount of coins. This validation action is called "forging". Depending on how many coins you have, you will have a better chance to validate the next block (the amount of money is a sign of seniority in the network). A commission is paid to the validator.

Types of blockchain:
1. Permissionless = a node can participate in the network and can leave when it wants because this network is not managed by anyone;  
2. Permissioned = the network is managed by a central entity, an administrator, who allows you to participate in the network or not.  
The permissioned blockchain can be divided into two sub-categories:
a. Open / Public permissioned blockchain = which can be accessed by anyone but only authorized participants can generate transactions and / or update the status of the register;
b. Closed / Enterprise permissioned blockchain = access is limited and only the network administrator can generate transactions and update the status of the register.  

Other types of coins are:  
1. Ethereum (2015) = is a decentralized platform that manages "smart contracts" (they are self-executing app/script, so they work autonomously). In essence, it is a permissionless blockchain and it uses a form of payment to incentivize transactions within the network with Ether coin.
2. RIPPLE = open source decentralized P2P digital payment platform, with a permissioned public blockchain, which allows for fast currency transfers. Use XRP cryptocurrency. Ripple does not rely on PoW or PoS to validate transactions but uses its own specific consensus protocol.

When we have more branches, for example due from a Hard Fork, then we can have different types of coins that are created in the different branches of the blockchain, they are called "Split Coin":  
1. Bitcoin Cash (BCH) = is based on BitCoin PoW. It is known as a hard fork of the bitcoin blockchain. In a nutshell, Bitcoin Cash was born because some developers wanted to put the block size from 1MB to 8MB in order to be able to pay less commission fees.
2. Litecoin = is based on Scrypt Pow which uses BitCoin and uses an algorithm called original SHA-256 PoW. This algorithm offers faster transaction speed than BitCoin and also faster to generate a block.
3. IOTA = it doesn't use commissions. It doesn't even use blocks but transactions are intertwined together, and by flows of individual transactions.


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

People often provide, without worrying too much, a lot of personal information in exchange of some services and/or immediate advantage.  
For example:  
- Some restaurants require personal information in order to use public Wi-Fi. These data are collected by the managers of the company.
- Some television companies require personal information (through registration) in order to let you stream legally from your computer. These data are collected and used to perform analysis (marketing purposes).
- Some websites require personal information in order to notify you promotional offers and to get advanced functionalities (e.g. Groupon, Amazon...)
- Releasing sensitive or personal data just for take prize in competitions with prize.
- An important example is also Google or similar services. These services are based on users' data, this means that in order to use Google services you need to provide them the data they ask for (even if you are not authenticated in the browser they can collect data!)

I remember when I was younger there were a lot of stupid quiz results published on Facebook (e.g. Which type of vegetable you are?) from my friends, these quizzes asked you to provide profile informations in order to take the quiz.


**11. Discuss extension of blockchain technologies beyond digital currency.**

todo

**12. When do we claim that a social network has been deanonymized? Clearly it is not necessary that all data in the network have been deanonymized. Provide the different definitions that are used to claim that a network has been (possibly partially) deanonymized? Be specific and provide at least one example.**

Operators of online social networks are increasingly sharing potentially sensitive information about users and their relationships with advertisers, application developers, and datamining researchers. To alleviate privacy concerns, the networks are anonymized, i.e., names and demographic information associated with individual nodes are suppressed. But despite there is the possibility     about specific user with deanonymization processes.
In general, in order to deanonymize something the goal is: fixing some target record "r" in the original dataset learn as much about "r" as possibile. A network is partially or totally deanonymized when the attacker, starting from a reidentification of a fraction of nodes from an auxiliary network that partially overlaps with the original network,
gains knowledge about the edges of the graph that represents the network. So in a more technical way determine a 1-1 mapping between two graphs.
As example we can consider the partial deanonymization performed on twitter graph passing through Flickr graph. The two companies both exposes: Mandatory username, optional name, optional location. As result researchers obtained: 27,000 mappings. Starting from a seed of 150 pairs of randomly selected mappings with the constraint that the degree of each mapped node in the auxiliary graph is at least 80 the result is: 30.8% of the mappings were re-identified correctly, 12.1% were identified incorrectly, and 57% were not identified.
“An example is for example deanonymization of Netflix users by using IMDB dataset, that is the auxiliary network.”


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

Differential privacy aims to provide means to maximize the accuracy of queries from statistical databases by minimizing the possibilities of defining its records. Therefore, the goal is to release statistical information without compromising the privacy of the individual respondents. Differential privacy ensures that removing or adding an item in the database does not affect the outcome of any analysis; therefore, there is no risk in joining the database.  
DEF: Given a real number, we say that a function K provides differential privacy and, if for all datasets D1, D2 differ at most on one element and for all S belonging to the interval (K): Pr [K (D1) belongs to S] <= exp (epsilon) * Pr [K (D2) belongs to S].  
It means that if a participant added or removed his/her to/from the set, no output would become more or less likely.  
(PRO) The power of differential privacy is that any event (anything an opponent might do to you) has nearly the same chance whether you join or don't join, lie or tell the truth.
So, if an attacker has a lot of information that is not in the dataset about the user, they will never find information that is in the dataset about that user, while for example with k-anonymous database if we know exactly all the information about the user we can discover sensitive information.  
(CONS) The problem with differential privacy is that the parameter is public and the value of this parameter is still uncertain, because given a low value of it implies that the protection of the dataset is very strong but it happens that the response to a query is insignificant, on the other hand, a high value of can allow an attacker to discover the data.

**19. Discuss how differential privacy has been used in the US census. In particular discuss an example that motivates why publishing census data does not preserve privacy and discuss the kind of operation that are performed to achieve differential privacy**

There were made some census on US populations in differents years (2000, 2010, 2018...). The data that has been collected concerned about 6 different fields (race, sex, location, age...). The US agencies had roughly ~1.7 GB of data belonging to about 300 million citizens. They cannot publish the data without any modification, because this could mean (and will) a privacy violation. So they managed to collect all the respondents informations, then there was a noise addition, and then they published the statistical data. The main challenge was to understand how much noise add to the records, in order to achieve both privacy and accuracy of the informations. The epsilon in differential privacy is a measure of amount of data loss; the higher epsilon is, more accuracy you have, but of course this means no privacy at all. The lower epsilon is, higher will be the privacy, but the data of course will be less accurate. In a study was discovered that using the informations coming from the first census, it was possible to deanonymize and reconstruct the data of 17% of US population. There were taken into account two methodologies: block by block perturbation and top-down framework perturbation. The first one means add noise to each block separately (a 'block' is the littlest piece of US surface considered), while the latter means add noise for the histograms related to whole population and then consequently to other histograms with higher accuracy of localization (state, city, tracks, group of blocks, block). According to Prof. Ruggles, "Differential privacy will degrade the quality of data available about the population, and will probably make scientifically useful public use microdata impossible."

**20. What are according to you the main concerns of privacy protection in social networks?**

Third party applications, as social network, doesn’t have term of conditions and they can easily steal personal informations. The main challenge of data priacy is to utilize data while protecting individual’s privacy preferences and their personally identifiable information. Social network is a structure made up of a set of actors (such as individuals or organizations), and interactions between these actors. Privacy concerns with social networking services is a subset of data privacy. Social network privacy issues result from the amounts of informations these sites process each. Features that invite users to participate in messages, invitations, photos, open platform applications and other applications are often the venues for others to gain access to a user’s private information.
As there are so much informations provided by social networks, other things can be deduced, such as the person's social security number (fiscal code), which can then be used as part of identity theft. Many studies shown that it is possible to predict most and sometimes all of an individual’s 9- digit Social Security number (16 for fiscal code) using information gained from social networks and on-line databases.  
Due to the high content of personal informations laced on social networking sites, as well as the ability to hide behind a pseudo-identity, such sites have become increasingly popular for sexual predators. Further, the lack of age verification mechanisms is a cause of conerns in these cosial networking platforms.
It has been noted that the number of sexual predators caught using social networking sites has been increasing, and has now reached an almost weekly basis.
In worst cases children have become victims of pedophiles or lured to meet strangers.  
With the amount of information that users post about themselves on-line, it is easy for users to become a victim of stalking without even being aware of the risk. 63% of Facebook profiles are visible to the public, meaning that if you Google someone’s name and adding "+Facebook" in the search bar, you pretty much will see most of the person profiles.  
Twitter, Facebook, and others, are application which allow users to share their current location information. However, the disclousure of location information within these networks can cause privacy concerns among mobile users. Although there are algorithms using encryption, k-anonymity and noise injection algorithms, its better to understand how the location sharing works in these applications to see if they have good algorithms in place to protect location privacy.

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

**23. Which are the main characteristics of the new European regulations for privacy for individuals?**

- It's easier to access your own data, individuals will have more informations (clear and understandable) on how their data is processed. For example, if an individual has given her or his consent to processing for a specific purpose (e.g. display on a social networking site, and does not want this service anymore, than there is no reason to keep the data in the system).
- Right to data portability: it will be easier to transfer your personal data between service providers.
- Right to be forgotten: when you no longer want your data to be processed, the data will be deleted. This is not completely true, for example if the retention of the data is necessary for the performance of a contract or for compliance with a legal obligation, the data can be kept as long as necessary.
- Companies and orgs must notify the national supervisory authority of serious data breaches as soon as possible.

**24. Which are the main characteristics of the new European regulations for privacy for business?**

- Regulators can impose fines up to 4% of annual turnover (or EUR 20 mln, highest possible), they can perform audits, warnings or ban on processing. 
- Organizations must demonstrate they are compliant by evidencing that they comply with the GDPR conditions, so orgs must document suitable policies, perform privacy assessments and implement technical security measures.
- Companies must provide some additional rights: right to access and rectify personal data, right to be forgotten, right to data portability and some others. 
-It is mandatory to implement Privacy by Design (and so Privacy by Default). 
- In certain cases there must exist a Data Protection Officer (DPO). It is mandatory for 'high' risk personal data processing performing Privacy Impact Assessments.
- Increase of mandatory amount of informations included in privacy notices and also translated in local languages.
- Consent must be freely given, specific, informed and unambiguous.
- It is mandatory to keep records of all security related informations and notify users/authorities of security breaches.
- GDPR applies also to organizations that target EU citizens

**25. Privacy by Design (PbD) is an important technical element in the GDPR. Present main ideas of PbD, its advantages and its limitations.**

Privacy by Design is a concept recently introduced in the GDPR (effectively active 25 May 2018). This term refers to an approach to system engineering which promotes privacy throghout the whole engineering process; it's not about data protection but designing so data doesn't need protection. It's a proactive methodology and not reactive, this means we would like to have a system in which it's already present data protection, so we don't need to try to recover from a data/privacy breach. Data minimization is the most important safeguard in protecting personally identifiable information (PII). The use of cryptography, de-identification techniques, data aggregation are absolutely critical. De-identification techniques are intended to remove identifying information from a dataset while retaining some utility in the remaining data. The de-identified data can be re-identified and this can cause two problems: Disclosure of private facts affecting individuals whose data were re-identified; Damage to reputation affects instead the organization that performed the de-identification. A problem for the de-identification is the meaning that people and experts give to this term: someone states that this means the percentage of de-identified records that can be re-identified, while others consider it as the probability of record re-identification in the future. As we can understand from these two different concepts, there is no wide accepted standard on de-identification, and this is a huge problem. One other criticism against PbD is the fact that is a 'vague' (or opaque) concept, it leaves so many open questions while engineering systems.  


**26. Pseudoanonymization is an important technical element in the GDPR. Present main ideas of Pseudoanonymization, its advantages and its limitations.**

todo

**27. According to the new European rules companies and organizations need a Data Protection Officer; which are the task and the obligations related to this person?**

The key principle is the accountability. Ensure and be able to demonstrate compliance: Adopt policies and implement appropriate measures, documentation.  
The Data Protection Officer will:

- Inform and advise the owner of the treatment about their obligations under the EU regulation
- Check the implementation and application of the regulations, provide opinions on the assessment of the impact on data protection
- Act as a contact point about any issue related to the processing of their data or the exercise of their rights
- Act as a contact point for the Authority for the protection of personal data

**28. The regulations and law that protect sensible data are evolving.  With reference to the Italian regulations  discuss which data are considered sensible and which are the main rules to protect such data. Discuss which are the main problems in processing information  according to the regulations and which kind of  difficulties/problems such regulations poses  to companies and administrations.**

Anyone has the right to protection of personal data concerning him/her. The processing of personal data will be in respect for human rights and fundamental freedoms and dignity, with particular reference to privacy, and the right to identity the protection of personal data. The information systems and programs are configured to minimize the use of personal data and identification data, in order to rule out their processing if the purposes sought in the individual cases can be achieved by using either anonymous data or mechanisms permitting the identification of the individual only in case of need. There are two types of personal data: Sensitive data (personal data revealing racial or ethnic origin, religious beliefs, philosophical or other beliefs, political opinions...) and Judicial data (personal data related to criminal records, the register of offense-related administrative sanctions...). The rights for an individual are: right of access to personal data, the updating, correction or the integration of data, the cancellation, anonymization or blocking of data, the right to oppose.

**29. What are the main challenges and difficulties of making a job as an expert in  privacy protection? Do you think that there will be good opportunities (e.g. well paid?, interesting?) for such a job?  Which are the main issues that you foresee. Explain why yes or not.**

Since we are now in an evolution of technology such that there are lot of effort and development about big data analysis, efficient algorithms for predictions, data mining; and in a scenario where information about people has a great economic value (spreading of personalized advertisement, market investigations etc.) paired with the great spread of social network in our daily lives (which are pure collectors of personal data) makes the privacy protection a big issue to cared about. Also in a corporate environment, such as companies, factories, and sensitive organizations, privacy of data is one of the most important focus in order to preserve safety of the company, and in some cases safety of people as well.  
Due to this growing need of privacy protection, yes, an expert in privacy protection is becoming a relevant figure both in private and corporate environment, indeed, in EU regulations, there is the obligation for companies which deal with personal data to hire a DPO (Data Protection Officer). This person is the one that regulates and controls all aspects concerning data protection and data privacy, therefore due to this kind of activities that it is charged it must be an expert of eithe legislative regulation and cybersecurity aspects related to the IT of the companies for which it has been employed.  
With this growing trend of sensitive data all across the digital world, this kind of figure will become more important, because is an expert from the point of view of the legal aspects and the impact of data protection, and operating with a more technical figure also expert in data protection is a fundamental aspect of his work.
In addition to this situation, citizens are becoming also well informed in data privacy issues (or, let's hope so), and the same concerns of private citizens can be put in pratice, forming a virtuous cycle driven by the customers, making the figure of data protection expert more relevant in the future with a growing need of it.
