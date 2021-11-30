# College-Simulator
 GDD Proj3: College Simulator

2021/10/26: by Alan
- Created Basic Turn system
- Created resuable scene transition animation prefab and system

2021/10/27: By Jeffery
- Created transition scene between turns.
	When a player clicks act button, he would see the transition scene for each task he chose. Clicking on the panel transits to the scene of next task.
	See the component TransitionPanel and associated scripts for details.
- Created turn system and UI. After all the transitions for each tasks completes, the turn is incremented.
	See the component Turn and the turn variable in game manager for details.
- TODO:
	1. After each turn, we need to refill the list with empty task cards.
	2. With turn system in place, we can now program the feature where new tasks are added into schedule.

  2021/10/29: By Junkee
- Added the feature where the schedule starts empty with every new turn.
- For new tasks added into the schedule, a baseframe has to be created first, will work on it this weekend.

2021/11/3: by Alan
- Connect transition animation after act button
- Build and smoothen the entire gameplay process skeleton.
   - games now has a complete game play from start to finish
   - just need to furnish individual parts

To-Do:
1. Do the ending based on points. Should be ez. But need to discuss roles vs points.

2021/11/3: By Jeffery
- Fix Following Bugs:
	- In a new turn, the tasks selected are not added into the first row of the schedule
	- In every turn the last scheduled task's attribute points are not added
	- At end of turn X where semester transition happens, the turn number changes to X+1 before the semester changes

- Add dynamically updated pictures for each task in transition panel (note: party task currently has no image, not a bug)

- Remaining Bug:
	At every semester the player's attribute is reset to 0. Reason is GameManager script is reset in a new scene....

2021/11/11: By Jeffery
- Remade UI components for task panel, supporting a scrollable view of tasks in grid layout format.
- Reprogrammed task initialization. Now we could initialize and add task buttons to the list of tasks in the task panel through code!
	- Steps to do this: create task card prefab and assign it a tag, add task card prefab under game manager, change the script TaskOptionsControl
- Add task level up: instantiate new task after player attribubte pass a certain threshold
- Add a pop up text that notifies players in updates in their available tasks
- Remaining issue: this feature only available for the first scene.

2021/11/12: By Alan
- Completed the main skelton for showing end-game results: currently, just randmized the results (does not depend on previous actions).
- Enable developers to easily add different kinds of result stories by simply adding an empty object, attach script, and create stories and images.
- TO-DOs: Data presistency and connect it to this result scene.

2021/11/14: By Jeffery
- Fix some minor bugs, unify all four scenes to have the same prefabs.
- Remaining issue: data persistency. Level loader on scene 1 not loading correctly

2021/11/17: By Jeffery
- Created new branch with one master scene for all 4 semesters that solves data persistency issue
= Added task card pictures to the code base

2021/11/28: By Jeffery
- Added all the base and boosted actions. Boosted actions unlock everytime base actions performed 5 times. After boosted action is unlocked, counter resets.
  Boosted action removed from task panel the next round.
- TODO: Unique Actions. Endings. 1 time per round lock for boosted and unique actions.

2021/11/29: By Jeffery
- Added unique action cards (not code yet). Implented self destroy after click for boost and unique actions (so player can only click it once and it removes itself)
- TODO: Unique Actions Code. Endings.