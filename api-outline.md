# API Outline

This document defines the general outline of the APIs that are to be implemented.
It is not a replacement for OpenAPI, rather, it is a guideline for how the concrete APIs should be structured.
Therefore, the concrete implementations can differ slightly, but generally should follow this guideline.

APIs in this project are to follow the REST style.

For a more elegant approach to passing some parameters, slugs are preferred over GET parameters.
Slugs are prefixed with the underscore character (`_`) and are to be replaced with the relevant value.

# Endpoint fields

## Milestone

Relevant milestone for the endpoint

## Intent

Description of the endpoint's intended behavior

## Payload

Describes the data that has to be sent through the endpoint. Can be omitted if the intent already makes it clear.

## Response

Describes the data that the server has to send back when the endpoint is called. Can be omitted if the intent already
makes it clear.

# Endpoints

## User session management

### `POST /players`

- Milestone: M0
- Intent: Register a user on the server for tracking plays and statistics
- Response: A unique user ID to save on the user's machine (e.g. browser local storage)

### `GET /players/_id/preferences`

- Milestone: M0
- Intent: Retrieve a user's preferences, such as its language or light/dark theme

### `PATCH /players/_id/preferences`

- Milestone: M3d
- Intent: Updates the user's preferences, such as its language or light/dark theme

### `GET /players/_id/balance`

- Milestone: M2
- Intent: Retrieve a user's balance, i.e. how much credit the player possesses

### `GET /players/_id/stats`

- Milestone: M3c
- Intent: Retrieve a user's statistics, described in milestone M3c

### `GET /players/_id/games`

- Milestone: M0
- Intent: Retrieve the list of **active** games initiated by the player

## Game state

### `POST /games`

- Milestone: M0
- Intent: Creates a new game instance, enabling the server to track a player's specific game
- Payload: User ID
- Response: Game instance data including a unique ID, player ID who initiated the game, its configuration,
  expiration date, and status

### `GET /games/_id`

- Milestone: M0
- Intent: Returns the info about the given game, like its configuration, status and current state (where applicable)

### `PATCH /games/_id`

- Milestone: M3a, M3b
- Intent: Update info about the game such as its configuration
- Payload: Desired game configuration (M3a, M3b)

This is dependent on the game's status, i.e. you can't change the game configuration while it's being played.

### `POST /games/_id/start`

- Milestone: M0
- Intent: Commits to the configuration of the game and starts the game
- Response: Information about the game (configuration) and initial state of the game (cards dealt by the dealer)

### `GET /games/_id/steps`

- Milestone: M0
- Intent: Retrieves the steps (i.e. cards dealt, player decisions) taken by the server and user during the given game

### `POST /games/_id/steps`

- Milestone: M0
- Intent: Commits to the given step transaction and steps through the game
- Result: Step transaction summary (action taken, bets placed, new balance), dealer's actions if game can progress
  or game over summary

The step transactions are handled by the server.

### `PATCH /games/_id/bets`

- Milestone: M2
- Intent: Sets one or multiple bets for the given step transaction
- Payload: Type of bet and amount to bet

### `DELETE /games/_id/bets`

- Milestone: M2
- Intent: Resets all bets for the given step transaction

### `GET /games/_id/actions`

- Milestone: M1
- Intent: Returns all possible actions the player can take at this point in the game

### `PUT /games/_id/actions`

- Milestone: M1
- Intent: Sets the decision the player wants to take for the given step transaction
- Payload: Player decision
- Response: If bets were placed but the player changes their mind (e.g. split to stand), returns the amount of
  "refunded" bets
