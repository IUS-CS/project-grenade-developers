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
		* 2.3.3 Miscellaneous Information
	* 2.4 Interactivity
		* 2.4.1Player/Enemy Interaction
		* 2.4.2 Player/Item Interaction
			* 2.4.2.1 Shops & Currency
		* 2.4.3 Player/Wall Interaction
		* 2.4.4 Miscellaneous Player Interactions
	* 2.5 Replay Value
	* 2.6 Powerups/Items Appendix
* 3 Level Generation
	* 3.1 Procedural Generation Algorithms
	* 3.2 Level Subtypes
		* 3.2.1 “Area 1”
		* 3.2.2 “Area 2”
		* 3.2.3 “Area 3”
		* 3.2.4 “Area 4”
		* 3.2.5 “Area 5”
	* 3.3 Level Population
		* 3.3.1 Enemies
		* 3.3.2 Treasure Items
		* 3.3.3 Shops
		* 3.3.4 Secrets
		* 3.3.5 Mini-Bosses/Level Exits
* 4 Enemy AI(s)
	* 4.1Enemy Template
	* 4.2 Enemy Subtypes
		* 4.2.1 “Red”
		* 4.2.2 “Pink”
		* 4.2.3 “Cyan”
		* 4.2.4 “Orange”
		* 4.2.5 “Other”
	* 4.3 Bosses
	* 4.4 Enemy Appendix 
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

The player character will automatically move forward when the game is not paused. The player can change which direction is forward via the Input Controls. This behavior will be ignored when the player is inside of a “shop” area, and they will be able to simply use the Input Controls to navigate, without needing to worry about autonomous movement.

#### 2.3 User Interface	

This section details the various components of the user interface.

![User Interface Mockup](/docs/images/mockupUI.png?raw=true "mockup UI")

##### 2.3.1 Health

Health will be displayed at the top left-hand corner of the screen. The player will start with 3 hearts which can be lost if the player is hit by an enemy attack, or if the player stands still for too long. Hearts can be regained by completing combos.

##### 2.3.2 Inventory

The players’ inventory will display all powerups and items they have collected in a run. It takes up the left-hand side of the screen, below the Health. Most items simply are upgrades added to the inventory permanently, and only display for visual reference. The player also has one “powerup” slot, which is displayed below the health bar. Pressing the use key will use the item in this slot.

##### 2.3.3 Map

The top right-hand corner of the screen contains a mini-map displaying the parts of the level that the player has explored, and updates live as the player uncovers new portions of a level.

##### 2.3.4 Miscellaneous Information

Below the map on the middle-bottom right-hand side, miscellaneous information is displayed such as time, level, difficulty &c.

#### 2.4 Interactivity

This section details how the player interacts with other objects in the game.

##### 2.4.1 Player/Enemy Interaction

Most enemies cause damage to the player when they collide on the screen. The player can pass through enemies at the cost of taking damage. Enemies can be defeated and “eaten” in order to gain items, currency, or health. In order for an enemy to be defeated, they must be damaged.. Certain enemies can be damaged simply by running directly into them, others cannot be damaged, and most can be damaged by the players current “powerup.” For specific information on how to deal with each enemy, see section 4.

##### 2.4.2 Player/Item Interaction

When the player moves over an item, in most cases they will consume it. Depending on what the item is, the game will have a different reaction.
	* For enemy corpses, the player can eat them to gain points, and when chaining kills together in a short period of time, they can gain items or health.
* For items, the player will simply add them to their inventory upon contact.
* When the player encounters a new powerup, they will pick it up, and drop their previous one in the space where the new one was.

###### 2.4.2.1 Shops & Currency

In a shop, the player does not move forward automatically. Three items spawn in most shops with a price tag above them. Running into one of the items will add it to the players inventory if it is an item, and to the power-up slot if it is a powerup. Both actions will reduce currency from the players total. Items the play cannot afford with function similarly to walls, blocking movement.

##### 2.4.3 Player/Wall Interaction

When the player runs into a wall, they will be prompted with a small icon to push a directional key to keep moving. Failure to do so within a short time period will result in the player taking damage and a direction being chosen for them. This duration is smaller on harder difficulties. Players otherwise cannot pass through normal walls.

#### 2.5 Replay Value

Each time the game is beaten, an additional difficulty level will be unlocked. 

![Difficulty](/docs/images/Difficulty.jpg?raw=true "Difficulty")

#### 2.6 Powerups/Items Appendix

This section will be implemented towards the completion of the game when all the items have been designed and playtested.

### 3 Level Generation

#### 3.1 Procedural Generation Algorithms

Each level will use the same base for a Procedural Generation, making sure that the levels are different each playthrough. We will be using a biased algorithm that tends towards making open rooms (areas with large open-space) connected by hallways (areas with 1-2 width) allowing for a sense of exploration in parts. The Procedural Generation works by populating a grid with tiles designated as either “wall” or “floor.” No other object in the game can occupy the same space as a wall. Floor spaces can be occupied by any object in the game, but only one at a time. 

#### 3.2 Level Subtypes

This section will be implemented at a later date, once we sit down to design the differences in the levels. Each sub-level will have a unique twist on the generation algorithm, including different layout, enemies, rooms, textures, sprites, and mechanics.

##### 3.2.1 “Area 1”
##### 3.2.2 “Area 2”
##### 3.2.3 “Area 3”
##### 3.2.4 “Area 4”
##### 3.2.5 “Area 5”

#### 3.3 Level Population

This section details how the procedural generation algorithm handles the placement of enemies, items, shops, secrets, and mini-bosses.

##### 3.3.1 Enemies

Enemies are spawned according to the difficulty selected. Enemies themselves had a difficulty value, and the algorithm attempts to fill a room within a certain margin of error around a target “total” difficulty. This way, the player can choose different modes, and as developers we can have the difficulty across one singular level be varied and more “random.”

##### 3.3.2 Treasure Items

Treasure Items are generated using a similar noise algorithm to the enemies in a level, meaning that items are dependent on difficulty and proximity to other items. Some items will only spawn on higher difficulty levels.

##### 3.3.3 Shops

In each level, one area will be designated as a shop. This area may or may not be locked and require the player to find a key in order to open. The shop sells three randomly selected items, with a bias towards items of an appropriate power level for the given level.

##### 3.3.4 Secrets

Secrets can generate in certain situations, and this section will be expanded upon when more information is known about the level design. For example though, in a level where an explosive enemy can be found, a secret room might generate that can only be accessed by having the exploding enemy explode near it, or perhaps a false wall exists that if the player runs into it a few times it will break allowing them access to the room. Secret rooms can either contain treasure items with a bias towards higher power levels, or deadly traps/enemies, or both.

##### 3.3.5 Mini-Bosses/Level Exits

In each level, one mini-boss will be spawned. Killing this mini-boss opens the level exit which can be found along one of the four sides of the map, usually opposite the mini-boss. See section 4.3 for more information on Mini-Bosses.

### 4 Enemy AI(s)

#### 4.1 Enemy Template

Each enemy will work off of a basic AI template that allows them to move, locate the player, identify dangers and the layout of the level around them, and then specific enemy subtypes will have modifications and extrapolations of this basic AI to allow for more diverse and unique enemies throughout the game.

#### 4.2 Enemy Subtypes

The varied enemy subtypes are based on the varied AI’s in the original PacMan, as well as some additional new ones. This section details information regarding the AI types. See section 4.4 for specific information about individual enemies.

##### 4.2.1 “Red”

Red AIs are the most aggressive type, their primary objective is to take the shortest path to the player, regardless of any other information. Taking advantage of this, the player would be able to lure Red enemies into traps and control their positioning. Most enemies with the “Red” AI type cannot be damaged directly.

##### 4.2.2 “Pink”

Pink AIs are essentially smarter versions of Red AI’s rather than make a direct path to the player, they will attempt to predict where the player is going, and get in the way, usually in an effort to trap them with the help of a Red AI. Pink AI’s are smart enough to avoid putting themselves in unnecessary danger.

##### 4.2.3 “Cyan”

Cyan AI’s are the most complicated of the bunch. They will pick a point on the map, often an item they are guarding, and patrol around it in a somewhat unpredictable pattern. These enemies can be easily avoided by staying away from their patrol points. If the player crosses into their patrol range, they will, without leaving that range, attempt to reach the player or defend their point without putting themselves in harm’s way.

##### 4.2.4 “Orange”

Orange AI’s are shy. They will flee from the player unless there are other enemy types around, in which case they can adopt the behavior of other AI types. If a red enemy is closing in from behind, the Orange AI will attempt to cut off the player like a Pink AI. If a Pink AI is about to cut the player off, an Orange AI will try to rush them from behind. When left to their own devices, Orange AI’s may also mimic the behavior of Cyan AI’s, joining in on the patrol, but fleeing if the player comes too close.

##### 4.2.5 “Green”

Green AI either moves infrequently or not at all. They endanger the player in one of two ways, either by acting as a physical obstacle that can hurt the player or by utilizing ranged attacks that can damage the player from far away. The type and specifics of a given attack are dependent on the specific enemy.

#### 4.3 Bosses

Bosses act as “skill tests” and occur in between each level, and after the final level. There will be at least 5 bosses that are randomly selected for Level’s 1-4 and at least one final boss that will be considered the last part of the game. 

Mini-bosses, which are simply slightly stronger enemies appear within each level and must be defeated in order to exit the level.

This section will be filled out in greater detail as the bosses for each level are designed.

#### 4.4 Enemy Appendix 

This section will be filled out at the end of the project, detailing each enemy in the game and how it works.

### 5 Graphics

#### 5.1 Sprites

Each object including the walls, enemies, floor, and players will have sprites that signify what they are.
* Each level will have unique wall and floor textures
* Each enemy will have a unique texture with a primary color that reflects its primary AI type.
* Mini-bosses will have a glowing outline to signify they are mini-bosses.

#### 5.2 Animation

For enemies and the player, animation of the sprites will be used to give the game some ‘aliveness’. There will also be animations to signify events such as damage, using a power-up or an enemy attacking. Animations will be made using Unity.

### 6 Audio Management

#### 6.1 Background Music

There will be at least 4 different soundtracks for background music that will play as the game is running. 1 soundtrack for when sitting in the first menu of the game, 1 soundtrack for when the base game is running the player moves through the dungeon, 1 soundtrack when the player is in a “boss” room, and the last remaining soundtrack for when the player is in the shop room.

#### 6.2 SFX

Different sound effects will play depending on the different interactions between the player, enemy, level and UI elements. For instance, when the player collides with an enemy, it will play a ‘hit’ sound or when you hover over a certain element in the ui, it will make a ‘pong’ sound. There will also be a sound effect to alert the player when they find a secret.
