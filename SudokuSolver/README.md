# Sudoku Solver

## Working with static input 

### Explanation:
1.	Grid Definition:
o	int[,] grid: Represents the Sudoku grid. A 0 indicates an empty cell.
2.	PrintGrid Function:
o	Prints the current state of the Sudoku grid.
3.	IsSafe Function:
o	Checks if placing a number in a given cell is valid according to Sudoku rules.
4.	SolveSudoku Function:
o	Implements the backtracking algorithm to solve the Sudoku puzzle.
o	Recursively tries to fill the grid and backtracks if a conflict is found.
5.	Main Function:
o	Initializes a Sudoku puzzle and calls SolveSudoku.
o	Prints the solved grid if a solution is found, otherwise indicates no solution exists.
