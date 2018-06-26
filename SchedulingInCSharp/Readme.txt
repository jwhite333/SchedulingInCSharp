Scheduling in C Sharp

Doing a thing, the right way this time

Flow:
* Assign instructors (1 per class)
* Pair electives
* Distribute amongst semesters based on instructors popularities
* Create blocks (bins)
* Add largest class with fewest conflicts to first open bin (repeat)


Alternate:

      All courses
		 / \
        /   \
	   /     \
	  S1     S2
	 /\      ...
	/  \     
   /    \    
  /\    /\   
 /  \  /  \   
B1  B2 B3  B4
 
* Push any semester requrements to thier semester
* Push any block requrements to thier block
* Score courses for priority
	Based on:
		1. Size
		2. 

Notes:
Add Comparer<T> so that List can sort course elements