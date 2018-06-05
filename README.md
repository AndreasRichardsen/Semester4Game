# Semester4Game
This is my 4th semester game dev project. A simple adventure/RPG game with the basic mechanics i deemed necessary.

## Systems and Mechanics
Along the way we created various systems and mechanics for the game so I'll just list a few here.

### Inventory and Equipment
The big one is an inventory and equipment system. You can create items in the JSON database, assign them as item drops in monster loot tables, create equipment that you can use to attack enemies, easily extend existing weapons to create new weapons, and so on. Equipment and consumables can be interacted with from the UI.

![](https://imgur.com/y6Vx2K1.gif)

### Dialogue
The next system is the simple dialogue system. Nothing fancy here, just a sequential dialogue that you can add to any interactable object.

![](https://imgur.com/NPWljbw.gif)

### Melee Combat
The combat is rather basic. This is simply due to combat not being a priority.

![](https://imgur.com/Q62MJkQ.gif)

### Weighted Loot Tables
You can create weighted loot tables for specific monsters. The tables allow you to roll a die to determine what item will drop, based on rarity ratings.

![](https://imgur.com/3MMwZKp.gif)


### Quests
The questing system allows you to create custom quests and quest givers that can assign various tasks to the player. The player will have to complete the tasks in whatever order they would like. Returning to the quest giver before completion will prompt specific dialogue, while returning after completion will grant you your reward and specific dialogue. The custom quests and tasks are very easy to extend to create whatever you can imagine.

![](https://imgur.com/FHDcPLD.gif)

### Teleportation System
Here's a teleportation network using weird water wells. Which is used by the player to fast travel throughout the world:

![](https://imgur.com/0NHqGhL.gif)
