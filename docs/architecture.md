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

Health will be displayed at the top left-hand corner of the screen. The player with start with 3 hearts which can be lost if the player it hit by an enemy attack, or if the player stands still for too long. Hearts can be regained by completing combos.

##### 2.3.2 Inventory

The players’ inventory will display all powerups and items they have collected in a run. It takes up the left-hand side of the screen, below the Health. Most items simply are upgrades added to the inventory permanently, and only display for visual reference. The player also has one “powerup” slot, which is displayed below the health bar. Pressing the use key will use the item in this slot.

##### 2.3.3 Map

The top right-hand corner of the screen contains a mini-map displaying the parts of the level that the player has explored, and updates live as the player uncovers new portions of a level.

##### 2.3.4 Miscellaneous Information

Below the map on the middle-bottom right-hand side, miscellaneous information is displayed such as time, level, difficulty &c.

#### 2.4 Interactivity
##### 2.4.1Player/Enemy Interaction
##### 2.4.2 Player/Item Interaction
###### 2.4.2.1 Shops & Currency
##### 2.4.3 Player/Wall Interaction
##### 2.4.4 Miscellaneous Player Interactions
#### 2.5 Replay Value
#### 2.6 Powerups/Items Appendix
### 3 Level Generation
#### 3.1 Procedural Generation Algorithms
#### 3.2 Level Subtypes
##### 3.2.1 “Area 1”
##### 3.2.2 “Area 2”
##### 3.2.3 “Area 3”
##### 3.2.4 “Area 4”
##### 3.2.5 “Area 5”
#### 3.3 Level Population
##### 3.3.1 Enemies
##### 3.3.2 Treasure Items
##### 3.3.3 Shops
##### 3.3.4 Secrets
##### 3.3.5 Mini-Bosses/Level Exits
### 4 Enemy AI(s)

#### 4.1Enemy Template

Each enemy will work off of a basic AI template that allows them to move, locate the player, identify dangers and the layout of the level around them, and then specific enemie subtypes will have modifications and extrapolations of this basic AI to allow for more diverse and unique enemies throughout the game.

#### 4.2 Enemy Subtypes

The varied enemy subtypes are based on the varied AI’s in the original PacMan. This section details information regarding the AI types. See section 4.4 for specific information about individual enemies.

##### 4.2.1 “Red”

Red AIs are the most aggressive type, their primary objective is to take the shortest path to the player, regardless of any other information. Taking advantage of this, the player would be able to lure Red enemies into traps and control their positioning.

##### 4.2.2 “Pink”

Pink AIs are essentially smarter versions of Red AI’s rather than make a direct path to the player, they will attempt to predict where the player is going, and get in the way, usually in an effort to trap them with the help of a Red AI. Pink AI’s are smart enough to avoid putting themselves in unnecessary danger.

##### 4.2.3 “Cyan”

Cyan AI’s are the most complicated of the bunch. They will pick a point on the map, often an item they are guarding, and patrol around it in a somewhat unpredictable pattern. These enemies can be easily avoided by staying away from their patrol point. If the player crosses into their patrol range, they will, without leaving that range, attempt to reach the player or defend their point without putting themselves in harms way.

##### 4.2.4 “Orange”

Orange AI’s are shy. They will flee from the player unless there are other enemy types around, in which case they can adopt the behavior of other AI types. If a red enemy is closing in from behind, the Orange AI will attempt to cut off the player like a Pink AI. If a Pink Ai is about to cut the player off, an Orange AI will try to rush them from behind. When left to their own devices, Orange AI’s may also mimic the behavior of Cyan AI’s, joining in on the patrol, but fleeing if the player comes too close.

##### 4.2.5 “Other”

#### 4.3 Bosses

Bosses act as “skill tests” and occur in between each level, and after the final level. There will be at least 5 bosses that are randomly selected for Level’s 1-4 and at least one final boss that will be considered the last part of the game. 

Mini-bosses, which are simply slightly stronger enemies appear within each level and must be defeated in order to exit the level.

This section will be filled out in greater detail as the bosses for each level are designed.

#### 4.4 Enemy Appendix 

This section will be filled out at the end of the project, detailing each enemy in the game and how it works.

### 5 Graphics
#### 5.1 Sprites
#### 5.2 Animation
### 6 Audio Management
#### 6.1 Backgroud Music
#### 6.2 SFX





