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
		* 2.4.1Player/Enemy Interaction
		* 2.4.2 Player/Item Interaction
		* 2.4.3 Player/Wall Interaction
	* 2.5 Powerups/Items Appendix
* 3 Level Generation
	* 3.1 Procedural Generation Algorithms
	* 3.2 Level Population
		* 3.2.1 Enemies
		* 3.2.2 Treasure Items
* 4 Enemy AI(s)
	* 4.1 Enemy Template
* 5 Graphics
	* 5.1 Sprites
	* 5.2 Animation
* 6 Audio Management
	* 6.1 Backgroud Music
	* 6.2 SFX

### 1 Introduction

Hungry Dungeon is a PacMan inspired rogue-like video game for PC. The player will have to work their way through five randomly generated levels, collecting upgrades, eating enemies, and discovering secrets, all with just one life. Each level will have a unique design that requires different strategies to surpass. 

### 2 Gameplay

#### 2.1 Character Control

To allow for ease of access, the control system will use multiple options, rather than a custom binding system. 
* Basic movement controls will consist of either the set (W/A/S/D) or (UP/DOWN/LEFT/RIGHT) to allow the player to change the direction they want to be moving. 
	* A ‘use/action’ input will be available via either (SPACE) or (RSHIFT). This key will be how the player interacts with objects outside of simply running into them.
	* Both sets of input controls will be accessible at all times, allowing the player to choose the setup that is most comfortable for them, without the need for a key-binding interface.

![KeyboardControl](/docs/images/KeyboardControl.jpg?raw=true "KeyboardControl")

#### 2.2 Autonomous Character Behavior

The player character will automatically move forward when the game is not paused. The player can change which direction is forward via the Input Controls.

#### 2.3 User Interface	

This section details the various components of the user interface.

![User Interface](/docs/images/CharacterImages/GameUI.PNG?raw=true "User Interface")

##### 2.3.1 Health

Health will be displayed at the top left-hand corner of the screen. The player will start with 6 hearts which can be lost if the player is hit by an enemy attack.

![NormalHeart](/docs/images/ItemImages/Heart.gif?raw=true "NormalHeart")
![CorruptedHeart](/docs/images/ItemImages/CorruptedHeart.gif?raw=true "CorruptedHeart")

![HealthBar](/docs/images/ItemImages/HealthBar.PNG?raw=true "HealthBar")

##### 2.3.2 Inventory

The players’ inventory will display all powerups and items they have collected in a run. It takes up the bottom of the screen, below the Health. Most items simply are upgrades added to the inventory permanently, and only display for visual reference.

![Inventory](/docs/images/ItemImages/Inventory.PNG?raw=true "Inventory")

#### 2.4 Interactivity

This section details how the player interacts with other objects in the game.

##### 2.4.1 Player/Enemy Interaction

Most enemies cause damage to the player when they collide on the screen. The player can pass through enemies at the cost of taking damage; once damaged the player has a short cooldown time before they can take damage again.

##### 2.4.2 Player/Item Interaction

When the player moves over an item they can add it to their inventory by pressing the use key.

##### 2.4.3 Player/Wall Interaction

When the player runs into a wall, they will be stopped until they select a new direction to move in. Players otherwise cannot pass through normal walls.

#### 2.5 Powerups/Items Appendix

This section will be implemented towards the completion of the game when all the items have been designed and playtested.

### 3 Level Generation

#### 3.1 Procedural Generation Algorithms

Each level will use the same base for a Procedural Generation, making sure that the levels are different each playthrough. The level generation uses a custom version of Prim's Algorithm, which is an algorithm used for generating mazes. No other object in the game can occupy the same space as a wall. Floor spaces can be occupied by any object in the game, but only one at a time. 

![Prim's Algorithm](/docs/images/CharacterImages/MapGen.PNG?raw=true "Prim's Algorithm")

#### 3.3 Level Population

This section details how the procedural generation algorithm handles the placement of enemies, items.

##### 3.3.1 Enemies

Enemies are spawned randomly through the level.

![Spider](/docs/images/CharacterImages/Spider.PNG?raw=true "Spider")

##### 3.3.2 Items

Item are spawned randomly throught the level.

![SpeedBoost](/docs/images/ItemImages/SpeedBoost2.gif?raw=true "SpeedBoost")
![PickPocket](/docs/images/ItemImages/PickPocket2.gif?raw=true "PickPocket")
![HealthBoost](/docs/images/ItemImages/HealthBoost2.gif?raw=true "HealthBoost")
![Multiplier](/docs/images/ItemImages/Multiplier.gif?raw=true "Multiplier")
![DamageResist](/docs/images/ItemImages/DamageResist.gif?raw=true "DamageResist")
![CamExtend](/docs/images/ItemImages/CameraExtend.gif?raw=true "CamExtend")

##### 3.3.5 Level Exits

Level Exits are represented by a sign with the word exit. Moving onto one causes the game to end.

![Exit Sign](/docs/images/ItemImages/Exit.gif?raw=true "Exit Sign")

### 4 Enemy AI(s)

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

Background music is...

#### 6.2 SFX

Different sound effects will play depending on the different interactions between the player, enemy, level and UI elements. For instance, when the player collides with an enemy, it will play a ‘hit’ sound or when you hover over a certain element in the ui, it will make a ‘pong’ sound. There will also be a sound effect to alert the player when they find a secret.
