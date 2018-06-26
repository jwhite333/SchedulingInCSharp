Scheduling in C Sharp

Doing a thing, the right way this time

Flow:
* Assign instructors (1 per class)
* Pair electives
* Distribute amongst semesters based on instructors popularities
* Create blocks (bins)
* Add largest class with fewest conflicts to first open bin (repeat)

Notes:
Add Comparer<T> so that List can sort course elements