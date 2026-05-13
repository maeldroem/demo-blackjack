# Processes

Here is described the different processes using the API should be organized or orchestrated, as well as giving details
on what the implementor should do.

[See API Outline for reference](./api-outline.md)

Processes are described in an ordered list, but some points may have a sub-list, indicating that this
step can be completed asynchronously from the rest of the root list. Some steps may also be labelled a non-blocking.

If a step is action-dependent, it does not have to follow its order within the other adjacent action-dependent steps.

Some steps may be prefixed by a milestone between parentheses, indicating that such a step is only required
for implementing the milestone in question.

# Initialization

## Context

The app was just opened, the client doesn't (yet) know if it's a new user or not.

## Process

1. Client checks local storage for a user ID
2. If no such ID exists, send `POST /players` and store the newly created user ID in local storage
3. (M3d) User preferences
   1. Send `GET /players/_id/preferences` to retrieve user preferences and cache it
   2. Follow user preferences (e.g. translate text to user's language, apply preferred theme)
4. Check for active game(s)
   1. Send `GET /players/_id/games` to retrieve active game(s) initiated by the user
   2. If a game exists, restore it

# Standard game

## Context

The app is initialized and the user wants to play a hand of Blackjack.

## Process

1. Send `POST /games`
2. (M3a, M3b) Bring the user to the game configuration interface
3. (M3a, M3b) If the user makes a change to the game's configuration, send `PATCH /games/_id`
4. When user decides to start the game (or automatically if no configuration is needed), send `POST /games/_id/start`
5. Display the dealer's actions
6. Send `GET /games/_id/actions`
7. Display the player's available actions
8. When the user makes a decision, send `PUT /games/_id/actions` (non-blocking)
9. (M2) When the user places a bet, send `PATCH /games/_id/bets`
10. (M2) When the user resets their bets, send `DELETE /games/_id/bets`
11. When the user decides to commit to their decision and bets, send `POST /games/_id/steps`
12. If response of previous step is not game over, go to step 5
13. Display game over summary
14. If the user wants to play another hand, go to step 1
