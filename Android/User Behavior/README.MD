This project talks about how User data can be saved into to file and use that same data to recreate the path the user took while playing the game.

UserBehavior Script:

-The UserBehavior script is responsible to writing to the debug.txt file.

-The script uses a reference to a datapoint called "location" which is instantiated every time the player moves 1 unit farther from the previous position.

-Then the position of the location gameObject is stored along with the timestamp in the debug.txt file.

-The color of the individual location gameobject is changed based on the number of gameobjects already created and then assigning this new rgb value.

-Remaining scripts are same as the roll a ball tutuorial.

-Disable the "Movement" script to disable the mouse/touch movement of the player.
-Uncomment the FixedUpdate method in "PlayerScript" to re-enable WASD movement of the player.

<img src="Snippet.PNG" width="600">
