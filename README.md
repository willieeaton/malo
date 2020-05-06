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
  
## Usage notes for project reviewers:
The Doom Engine is open source and has been made available on multiple platforms thanks to the efforts of
"source ports" made by the community.  These ports allow you to play the game with some modern features.
In order to test the launcher functionality, I recommend downloading GZDoom, one of the most-compatible
source port executables.  

https://zdoom.org/downloads 

In addition, the actual game's assets are NOT freely available.  The program will require an IWAD to run
(called "Game File" in MALO).  Fortnunately, a project called FreeDoom has emerged to make an open-source
set of assets that are broadly compatible with major Doom mods.  The FreeDoom IWAD files are available at
the URL below.  "FreeDoom2.WAD" will be the one compatible with most mods, as Doom 2 was more popular to modify
and map for than the original game.

https://freedoom.github.io/download.html

While you need a source port and an executable to use the launcher section of MALO, PWADS (mods and user-made
levels) are optional.  They are usually made available for free by their makers at the IdGames archive.  Some
of my favorite freely-available level sets for Doom are:

https://www.doomworld.com/idgames/levels/doom2/megawads/scythe Scythe
https://www.doomworld.com/idgames/levels/doom2/Ports/megawads/aaliens Ancient Aliens

Thanks for reviewing my program!  I intend to continue developing it on my own after the class ends, as I am not
satisfied with the interface or feature set yet and I want to make it excellent for my own use and for the broader
Doom community's!

## Milestone Plan
1. (Week 3) Allow user to add, modify, and remove game data files, folders, source port executables, level packs, and game mods.
2. (Week 4) Allow user to launch game executable from inside app, with command line arguments.
3. (Week 5) Implement tag system, searching, and sorting.
4. (Week 6) Implement recognition of common IWADs and source ports through filename and MD5 hash.
5. (Week 7) Design modern WPF GUI interface for ease of use and improved appearance.
