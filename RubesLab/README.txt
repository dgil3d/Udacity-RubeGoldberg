Rube's Lab README
Udacity Project 8 Submission
By: Diego Gile

Released: 9-4-2017
Re-Released: 9-26-2017
Final Release: 10-8-2017

Versions: Unity Version 2017.1.1f1 and Google VR SDK Version 1.7
HMD Tested: HTC VIVE

The teleportation mechanic was challenging for me I think because I was relying too heavily on the course material.   Once I started tweaking the values and understanding each part of the function, I was able to come up with a satisfying solution.  I also took the liberty of adding a visual indicator (RED laser) to show the player when they cannot teleport to a location.  I hope you will find this to be a well implemented solution.  

You should also no longer be able to go through walls or scale the walls as the layermask for the laser has been cleaned up.  Any attempt to teleport to an out of bounds location will not move the player at all and the TeleportAimerObject will appear on the floor.

Thanks for the feedback!

-------------------------------------------------

Rube's Lab is a VR game developed for the HTC VIVE and is designed to allow the player the freedom to solve each of the four puzzles in creative ways.

Create your own Rube Goldberg machine using various spawnable objects.  Try and get the Ball to the red targeted floor marker!


CONTROLS:

Left Controller:
Touchpad Swipe Left / Touchpad Swipe Right - Swipe left and right on the Touchpad to view available spawnable game objects.
Touchpad Button - Press the Touchpad button while viewing a spawnable object, to spawn that object in the world.
Trigger: Grab the Ball and other Objects.  Just hold the trigger to hold an item, or let go of the trigger to let go of the item.

Right Controller:
Touchpad for Teleport - Press and hold the Touchpad and let go at your desired location.
Grip Button for Walking - Press and hold the Grip button to walk in the direction that you are facing.
Trigger: Grab the Ball and other Objects.  Just hold the trigger to hold an item, or let go of the trigger to let go of the item.