# Hungry Dungeon 
## Software Architecture Document

### Table of Contents

* 1 Introduction
	* 1.1 Purpose
* 2 Gameplay
	* 2.1 Character Control
	* 2.2 Autonomous Character Behavior
	* 2.3 User Interface
		* 2.3.1 Health
		* 2.3.2 Inventory
	* 2.4 Interactivity
		* 2.4.1 Player/Enemy Interaction
		* 2.4.2 Player/Item Interaction
		* 2.4.3 Player/Wall Interaction
		* 2.4.4 Miscellaneous Player Interactions
	* 2.5 Powerups/Items Appendix
* 3 Level Generation
	* 3.1 Procedural Generation Algorithms
	* 3.2 Level Population
		* 3.2.1 Enemies
		* 3.2.2 Treasure Items
		* 3.2.3 Level Exits
* 4 Enemy AI
	* 4.1Enemy Template
* 5 Graphics
	* 5.1 Sprites
	* 5.2 Animation
* 6 Audio Management
	* 6.1 Backgroud Music
	* 6.2 SFX

### 1 Introduction

Hungry Dungeon is a PacMan inspired rogue-like video game for PC. The player will have to work their way through randomly generated levels, collecting upgrades, dodging enemies, and discovering secrets, all with just one life. Each level will have a unique design that requires different strategies to surpass. 

### 2 Gameplay

#### 2.1 Character Control

To allow for ease of access, the control system will use multiple options, rather than a custom binding system. 
* Basic movement controls will consist of either the set (W/A/S/D) or (UP/DOWN/LEFT/RIGHT) to allow the player to change the direction they want to be moving. 
	* A ‘use/action’ input will be available via either (SPACE) or (RSHIFT). This key will be how the player interacts with objects outside of simply running into them.
	* Both sets of input controls will be accessible at all times, allowing the player to choose the setup that is most comfortable for them, without the need for a key-binding interface.
	* ESC can be used to pause the game and acess the menu.

![KeyboardControl](/docs/images/KeyboardControl.jpg?raw=true "KeyboardControl")

#### 2.2 Autonomous Character Behavior

The player character will automatically move forward when the game is not paused. The player can change which direction is forward via the Input Controls.

#### 2.3 User Interface	

This section details the various components of the user interface.

![User Interface](/docs/images/inGameUI.png?raw=true "User Interface")

##### 2.3.1 Health

Health will be displayed at the top left-hand corner of the screen. The player will start with 6 hearts which can be lost if the player is hit by an enemy attack.

##### 2.3.2 Inventory

The player's inventory will display all powerups and items they have collected in a run. It takes up the bottom of the screen. Most items simply are upgrades added to the inventory permanently, and only display for visual reference.

#### 2.4 Interactivity

This section details how the player interacts with other objects in the game.

##### 2.4.1 Player/Enemy Interaction

Most enemies cause damage to the player when they collide on the screen. The player can pass through enemies at the cost of taking damage.

##### 2.4.2 Player/Item Interaction

Item can be picked up and added to the player's inventory by pushing the use key while near the item.

##### 2.4.3 Player/Wall Interaction

When the player runs into a wall they will stop moving, until they select a new direction. Players cannot pass through walls.

#### 2.6 Powerups/Items Appendix

This section will be implemented towards the completion of the game when all the items have been designed and playtested.

### 3 Level Generation

#### 3.1 Procedural Generation Algorithms

Each level will use the same base for a Procedural Generation, making sure that the levels are different each playthrough. The Procedural Generation works by populating a grid with tiles designated as either “wall” or “floor.” No other object in the game can occupy the same space as a wall. Floor spaces can be occupied by any object in the game, but only one at a time. Each level will include different layout, enemies, and rooms. The "Dungeon" itself is generated using a custom variation of Prim's Algorithm.

![Prim's Algorithm](/docs/images/primsAlgorithm.png?raw=true "Prim's Algorithm")

#### 3.2 Level Population

This section details how the procedural generation algorithm handles the placement of enemies, items.

##### 3.2.1 Enemies

Enemies are spawned randomly throught the level.

![EnemySprite](/docs/images/enemySprite.png?raw=true "Enemy Sprite")

##### 3.2.2 Treasure Items

Treasure Items are generated randomly through the level. 

##### 3.2.3 Level Exits

Level Exits are represented by a sign with the word exit. Moving onto the exit will end the game.

![Exit Sign](/docs/images/exitSign.png?raw=true "Exit Sign")

### 4 Enemy AI

#### 4.1 Enemy Template

Each enemy will work off of a basic AI template that allows them to move, locate the player, identify dangers and the layout of the level around them, and then specific enemy subtypes will have modifications and extrapolations of this basic AI to allow for more diverse and unique enemies throughout the game. Enemy Subtypes have not been implemented in this version of the game.

![Enemy AI Structure](/docs/images/enemyAIStructure.png?raw=true "Enemy AI Structure")

### 5 Graphics

#### 5.1 Sprites

Each object including the walls, enemies, floor, and players will have sprites that signify what they are.

#### 5.2 Animation

For enemies and the player, animation of the sprites will be used to give the game some ‘aliveness’. There will also be animations to signify events such as damage, using a power-up or an enemy attacking. Animations will be made using Unity.

### 6 Audio Management

#### 6.1 Background Music

There will be at least 4 different soundtracks for background music that will play as the game is running. 1 soundtrack for when sitting in the first menu of the game, 1 soundtrack for when the base game is running the player moves through the dungeon, 1 soundtrack when the player is in a “boss” room, and the last remaining soundtrack for when the player is in the shop room.

#### 6.2 SFX

Different sound effects will play depending on the different interactions between the player, enemy, level and UI elements. For instance, when the player collides with an enemy, it will play a ‘hit’ sound or when you hover over a certain element in the ui, it will make a ‘pong’ sound. There will also be a sound effect to alert the player when they find a secret.
