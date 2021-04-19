# Wizard Duel

The game represents a duel between two players over the network or between a player and an AI agent. The aim of the game is to kill your opponent.

## High-level design

- The game is designed as a 2D action/platformer
- The game is designed for two agents:
  - two real players that are connected over a network
  - a player and an AI agent, in which case the game is played on a single machine
- Each player (or a player and an AI agent) controls an avatar that can move
in the given environment and attack
- The aim of the game is to kill the opponent's avatar

## Low-level design

### Scenes

- **Loading scene**: the scene represents a loading screen, where all the necessary assets/scripts are set up
- **Main scene**: the scene represents the main menu, where a player can choose what to do. It consists of the following options:
  - Player name
  - Single player
  - Multiplayer
  - Quit
- **Multiplayer scene**: the scene represents a menu to create/join a multiplayer game
  - Create an arbitrary game
  - Join an arbitrary game
  - Create a dedicated game
  - Join a dedicated game
  - Back to the **main scene**
- **Waiting scene**: the scene represents a state, where one player waits for another to join the game
  - 'Waiting for a player to join' message
  - Back to the **multiplayer scene**
- **Game scene**: the scene represents a playground, where two players have to fight with each other
  - Game start/progress
  - Game finish
    - Replay
    - Back to the **Main scene**

### Objects

- The following game objects are represented in the form of pixel art:
  - active/dynamic agents, _e.g._ avatars, projectiles _etc._
  - passive/decorative objects, _e.g._ background, foreground, moving platforms
  - icons
- Special effects and menu items can be of any form

### Avatar

- An avatar represents a pixel-art image of a wizard/sorcerer
- The avatar should have the following abilities:
  - move
  - jump
  - attack/shoot
- Ability to shoot implies that the corresponding pixel-art image should have a shooting source
- The avatar should have the following animations:
  - idle
  - move
  - active jump
  - passive jump (_e.g._ falling from a platform)
  - attack/shoot
  - death
- The avatar is a living object, _i.e._ it can receive damage and, given enough damage received, die
- The avatar should have a health bar, indicating how much health is left until it dies

### Game scene

- The game scene represents an arena, where two players (or a player and an AI agent) start on the opposite sides
- The game scene consists of a set of platforms/obstacles that are supposed to complicate the chase of the opponent's avatar
- The game scene should be symmetrical to both players

### Projectile

- Projectile is shot by an avatar
- Projectile is destoryed when collides with any active/passive agent
- Projectile deals damage when collides with an avatar
