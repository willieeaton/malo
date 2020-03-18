# Project: Mod, Level, Game, and Executable Organizer/Launcher for Classic Doom

## What It Is
A C# program that enables players of the classic Idtech 1 engine games Doom, 
Doom II, Heretic, etc., to organize their levels packs, gameplay mods, game 
data, and source port executables.  When the user adds files to their database,
the program will parse the .TXT file to gather basic info (mod name, author,
etc.).  Once added, the program will allow the user to add custom tags to their
collection of gameplay mods and level packs - for instance, a user could tag
all levels that have won a Cacoward, or all mods that add weapons.  Then the
program will allow the player to search by one or multiple tags.  Lastly,
the program will serve as a launcher, by combining the user's chosen mods,
and levels into command-line parameters to pass to the source port executable.

## Technologies Used
* C#
* WPF (for GUI)
* EntityFramework
* SQL Lite

## Features
* Organizer
  * All File Types
    * Allow user to specify default directory for files
	* Allow user to add files to database individually
  * IWADs (Game data files)
    * Recognize the most common files (DOOM.WAD, DOOM1.WAD, DOOM2.WAD) by filename and MD5 hash
  * PWADs (Mods and level pack data files)
    * Search ZIP file for TXT file and extract basic mod data such as name, author, release date
	* Allow user to create "tags" for mods and levels, and sort/search by tags
* Launcher
  * Allow user to select game (IWAD), mods and levels (PWADs), and executable (source port)
  * Save configurations of combinations of the above
  * Include checkboxes for easy selection of common command-line parameters (e.g. -complevel for PRBoom+)
  * Search and sort levels & mods for user-generated tags

## Milestone Plan
1. (Week 3) Allow user to add, modify, and remove game data files, folders, source port executables, level packs, and game mods.
2. (Week 4) Allow user to launch game executable from inside app, with command line arguments.
3. (Week 5) Implement tag system, searching, and sorting.
4. (Week 6) Implement recognition of common IWADs and source ports through filename and MD5 hash.
5. (Week 7) Design modern WPF GUI interface for ease of use and improved appearance.
