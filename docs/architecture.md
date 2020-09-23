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

To allow for ease of access, the control system will use a multiple options, rather than a custom binding system. 
* Basic movement controls will consist of either the set (W/A/S/D) or (UP/DOWN/LEFT/RIGHT) to allow the player to change the direction they want to be moving. 
	* A ‘use/action’ input will be available via either (SPACE) or (RSHIFT). This key will be how the player interacts with objects outside of simply running into them.
	* Both sets of input controls will be accessible at all times, allowing the player to choose the setup that is most comfortable for them, without the need for a key-binding interface.

INSERT IMAGE HERE

#### 2.2 Autonomous Character Behavior

The player character will automatically move forward when the game is not paused. The player can change which direction is forward via the Input Controls.

#### 2.3 User Interface

This section details the various components of the user interface.

##### 2.3.1 Health
##### 2.3.2 Inventory
##### 2.3.3 Miscellaneous Information
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
#### 4.2 Enemy Subtypes
##### 4.2.1 “Red”
##### 4.2.2 “Pink”
##### 4.2.3 “Cyan”
##### 4.2.4 “Orange”
##### 4.2.5 “Other”
#### 4.3 Bosses
#### 4.4 Enemy Appendix 
### 5 Graphics
#### 5.1 Sprites
#### 5.2 Animation
### 6 Audio Management






