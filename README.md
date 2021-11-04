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

- Remaining Bug:
	At every semester the player's attribute is reset to 0. Reason is GameManager script is reset in a new scene....