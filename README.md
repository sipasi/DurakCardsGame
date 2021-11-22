# DurakCardsGame

A simple implementation of the "Durak" game

## Contents
1. [Glossary](#Glossary)
2. [Rules](#Rules)
3. [References](#References)

## Glossary  
**Suit** - a suit is one of the categories into which the cards of a deck are divided
  - Diamonds (♦)
  - Clubs (♣)
  - Hearts (♥)
  - Spades (♠)

**Rank** - the position of a card relative to others in the same suit. The order of the ranks depends on the game being played. Cards are ranked "6, 7, 8, 9, 10, J (Jeck), Q (Quuen), K (King), A (Ace)"

**Trump card** - a privileged card whose trick-taking power is greater than any plain suit card

**Trump suit** - a privileged suit in which, in the current deal, all its cards rank higher than any plain (=non-trump) card

A trump card of any rank beats all cards in the other three suits. For example, a 6 of trumps beats an ace of any other suit

**Deck** - A pile of cards, face down, which are left over after setting up the rest of the game (i.e. dealing hands, setting up other layout areas) and will be used in the rest of the game

**Discard pile** - The pile of cards already rejected by players. The common pile of discarded cards

## Rules
#### Playing
- Every player receives six cards
- The player who has the lowest trump card will be the first attacker
- Each round of attack play proceeds clockwise
- A card under Deck is laid open, representing the trump
 
#### Attacking
If the attack **succeeds**:
  - The defender loses their turn
  - The defender takes all of the cards on a table
  - The attack passes to the player on the defender's left

#### Defending
If the defend **succeeds**:
- The defender becomes the next attacker
- All of the cards on a table are placed in the discard pile

#### End of Game
- The first player that played all of his or her cards (if there are no cards left on the deck) is the winner of the game
- The remaining players continue until only one player is left. He or she is the loser ("Durak") of the game

## References
- [Wiki](https://en.wikipedia.org/wiki/Durak)
- [Cysharp/UniTask](https://github.com/Cysharp/UniTask)
- [JohannesMP/Unity Scene Reference](https://github.com/JohannesMP/unity-scene-reference)
