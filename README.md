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
