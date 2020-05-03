# Project diary

### Week 2

### March 17, 2020 (Tues.)
* After watching mentor Ernesto's demonstration of a CVS program using EntityFramework to model database, conversed with him; will be using EntityFramework and SQL Lite to model database.
* With Ernesto's guidance, finally landed on WPF for application type.
* Submitted final project plan (README.md in github repo).
* **Need to learn at this point in order to proceed with project: WPF basics, SQL Lite basics, EntityFramework basics.**
	* Will be using the Treehouse courses on SQL Basics and EntityFramework Basics to get an understanding of that; will need to find WPF tutorials online.

### March 18, 2020 (Wed.)
* Created this project journal to track the time I spend on this application.
* Began the SQL Basics course on Treehouse.
	* Began and finished "Data, Databases, and SQL" (chapter 1/3)
	* Began and finished "Getting Data from a Database" (chapter 2/3) 
	* Began "Finding the Data You Want" (chapter 3/3)
  
### March 19, 2020 (Thurs.)
* Created TODO section at bottom of journal.md.
* Resumed and completed SQL Basics course on Treehouse.
	* Resumed and completed "Finding the Data You Want" (chapter 3/3)
* Began the Entity Framework Basics course on Treehouse.
	* Began "Introducing Entity Framework" (chapter 1/5)
	
### March 20, 2020 (Fri.)
* Resumed Entity Framework Basics course on Treehouse.
	* Resumed and completed "Introducing Entity Framework" (chapter 1/5)
	* Began "Entity Framework and Databases" (chapter 2/5)
		
### March 22, 2020 (Sun.)
* Resumed Entity Framework Basics course on Treehouse.
	* Resumed and completed "Entity Framework and Databases" (chapter 2/5)
	* Began and completed "Extending Our Entity Data Model" (chapter 3/5)
	* Began and completed "LINQ Queries" (chapter 4/5)
	* Began "CRUD Operations" (chapter 5/5)
	
### Week 3

### March 23, 2020 (Mon.)
* Resumed and completed Entity Framework Basics course on Treehouse.
	* Resumed and completed "CRUD Operations" (chapter 5/5)
* Began Microsoft tutorial "Walkthrough: My First WPF Desktop Application"

### March 24, 2020 (Tues.)
* Began to implement the entity classes.

### March 25, 2020 (Wed.)
* Continued to implement entity classes.
* Attempted to connect entities to Sqlite server.
* Bashed head against "Sqlite error 1: No such table" error

### March 26, 2020 (Thurs.)
* Resumed bashing of head
* Actually got the database working!  Turns out I needed "Database.EnsureCreated()" in there.

###Week 5
	
### April 7, 2020 (Tues.)
* Continued to expand defintion of entity classes over last week
* Program now launches the chosen executable with chosen game and levels!

###Week 7

### April 24, 2020
* Returned from health-related break
* Began to implement a basic version of the launch page
* Wired up the WPF form to the database!!

###Week 8

### April 28, 2020
* Added extensive comments explaining Doom engine/community jargon used in the game and various functions.

### April 29, 2020
* Added comments to functions in Data namespace
* Created "Add File" window (not yet functional)
* "Launch Game" button now works from inside GUI, allowing user selection of game, executable, and mods!

### May 1, 2020
* Moved "Add File" window functionality to a navigation frame with multiple sub-pages
* Implemented OpenFileDialog!  It doesn't yet add data yet, that's next.  Need to implement "options" pages for each file type.

###Week 9

### May 3, 2020
* Created "Options" page for adding each type of file.

# TODO

### Week 2
- [x] (:heavy_check_mark: Mar. 19) *Complete SQL Basics on Treehouse (179-minute Beginner-level Databases course)*
- [x] (:heavy_check_mark: Mar. 23) *Complete Entity Framework Basics on Treehouse (299-minute Intermediate-level C# course)*
- [x] (:heavy_check_mark: Mar. 23) *Find and complete basic WPF UI tutorial*

### Week 3
- [x] (:heavy_check_mar: Apr. 24) Create (placeholder/skeleton) interface

##### From Project Plan milestones: 
- [ ] Allow user to add, modify, and remove game data files, folders, source port executables, level packs, and game mods.
	* - [x] (:heavy_check_mark: During Week 3) Create basic parent class for game data files
	* - [x] (:heavy_check_mark: May 1) Implement "Open file" dialog
	* - [x] (:heavy_check_mark: During Week 3) Implement very basic elements of database (filename, location, identity)

### Week 4
##### From Project Plan milestones: 
- [x] (:heavy_check_mark: Apr. 7) Allow user to launch game executable from inside app, with command line arguments.
	
### Week 5
##### From Project Plan milestones: 
- [ ] Implement tag system, searching, and sorting.
	
### Week 6
##### From Project Plan milestones: 
- [ ] Implement recognition of common IWADs and source ports through filename and MD5 hash.

### Week 7
##### From Project Plan milestones: 
- [ ] Design modern WPF GUI interface for ease of use and improved appearance.

# UPDATED TODO:

### Week 9:
### Sunday:
- [ ] Implement user file addition to database.
- [ ] Implement user file deletion from database.
- [ ] Implement other user file modification

### Monday:
- [ ] Implement tagging system
- [ ] Implement searching system
- [ ] Implement IWAD/Source Port recognition.
	* - [ ] Build databases for common IWADs and Source Ports
	* - [ ] Build functions to check user input against these and automatically recognize them.

### Tuesday:
- [ ] Implement "Initial Install" mode (blank DB populated with above table)
- [ ] GUI beautification

