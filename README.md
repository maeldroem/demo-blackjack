<div align="center">

<h1>Knowledge demonstration project — Blackjack ♠️</h1>

— The reason emojis are present is to better illustrate and add variety to the reading.
It is not the result of an AI generation —

</div>

Play Blackjack, with fake money of course!

This project is dedicated to demonstrate my knowledge of different technologies through
a visual representation where possible.

# Milestones

Milestones of implementation features, from fundamentals to nice-to-have features.

## Setup (M0)

- User sessions: Assign an ID to a new player, store it in the browser's local storage,
  and keep track of user data through this session ID.
- 0-conf configuration file ⚙️
- Card deck management: Given that the blackjack deck is composed of N 52-card decks,
  a card must not appear more than N times.
- Deck shuffling
- Card distribution

## Fundamentals (M1)

- Card value system (aces = 1 or 11, face cards = 10)
- Choice dialogs: Hit/Stand
- Blackjack\* card dealing system: Deal the cards to the player and virtual dealer,
  track game status.

\*: No hole card, original bets only (OBO), stand on all 17s (S17), 3:2 (150%) blackjack payout

## Full game (M2)

- Balance system 💰: Tracking the user's credits.
- Bets and bet-related operations 💸: Doubling down, Split, Surrender, Insurance

## Extended game (M3)

This is a branch in implementation, as the sub-milestones are independent of one another.

### Settings (M3a)

- Hole card rule
- Hit on 17 rule
- No OBO (Original Bets Only)
- Number of decks used in the blackjack deck
- Relevant configuration menu to adjust those settings

### Game variants (M3b)

See [this section of the Wikipedia article on Blackjack](https://en.wikipedia.org/wiki/Blackjack?useskin=vector#Variants_and_related_games).

- Spanish 21
- 21st-century blackjack
- Double exposure blackjack
- Double attack blackjack
- Blackjack switch
- Super Fun 21

### Game stats (M3c) 📊

- Number of games played
- Balance evolution 📉
- Win/Loss ratio

### Ambiance and customization (M3d)

- Sound effects 🎰
- Casino ambiance 🎶: music, quiet conversation, machine/card noises
- Background customization 🖼️
- Card style 🃏

### Game

# Implementations

For containerization, Docker is used, though files will follow the generic name convention,
(i.e. Containerfile instead of Dockerfile)

## Frontend

The frontend is to be implemented with React (SSR), Tailwind, and TypeScript.

## Backend

| Technology         | Milestone |
| ------------------ | --------- |
| TS (via React SSR) | TODO      |
| Java Springboot    | TODO      |
| C# .NET            | TODO      |
| Rust (axum)        | TODO      |

---

<div align="center">
<a href="https://brainmade.org/">
    <img src="https://brainmade.org/black-logo.png" alt="BrainMade.org logo" width="300" />
</a>
</div>
