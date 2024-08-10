using System;

class SudokuSolver
{
	// Size of the Sudoku grid
	static int Matrix = 9;

	// Function to print the Sudoku grid
	static void PrintGrid(int[,] grid)
	{
		for (int row = 0; row < Matrix; row++)
		{
			for (int col = 0; col < Matrix; col++)
				Console.Write(grid[row, col] + " ");
			Console.WriteLine();
		}
	}

	// Function to check if it is safe to place a number in a cell
	static bool IsSafe(int[,] grid, int row, int col, int num)
	{
		// Check the row
		for (int x = 0; x < Matrix; x++)
			if (grid[row, x] == num)
				return false;

		// Check the column
		for (int x = 0; x < Matrix; x++)
			if (grid[x, col] == num)
				return false;

		// Check the 3x3 subgrid
		int startRow = row - row % 3, startCol = col - col % 3;
		for (int i = 0; i < 3; i++)
			for (int j = 0; j < 3; j++)
				if (grid[i + startRow, j + startCol] == num)
					return false;

		return true;
	}

	// Function to solve the Sudoku using backtracking
	static bool SolveSudoku(int[,] grid, int row, int col)
	{
		// If we have reached the 9th row and 10th column, we are done
		if (row == Matrix - 1 && col == Matrix)
			return true;

		// Move to the next row if column end is reached
		if (col == Matrix)
		{
			row++;
			col = 0;
		}

		// Skip cells that are already filled
		if (grid[row, col] != 0)
			return SolveSudoku(grid, row, col + 1);

		for (int num = 1; num <= Matrix; num++)
		{
			// Check if it is safe to place the number
			if (IsSafe(grid, row, col, num))
			{
				// Place the number
				grid[row, col] = num;

				// Recursively solve the rest of the grid
				if (SolveSudoku(grid, row, col + 1))
					return true;
			}

			// Remove the number (backtrack)
			grid[row, col] = 0;
		}

		// Trigger backtracking
		return false;
	}

	static void Main()
	{
		// Example Sudoku puzzle (0 means empty cell)
		int[,] grid = new int[,]
		{
			{ 5, 3, 0, 0, 7, 0, 0, 0, 0 },
			{ 6, 0, 0, 1, 9, 5, 0, 0, 0 },
			{ 0, 9, 8, 0, 0, 0, 0, 6, 0 },
			{ 8, 0, 0, 0, 6, 0, 0, 0, 3 },
			{ 4, 0, 0, 8, 0, 3, 0, 0, 1 },
			{ 7, 0, 0, 0, 2, 0, 0, 0, 6 },
			{ 0, 6, 0, 0, 0, 0, 2, 8, 0 },
			{ 0, 0, 0, 4, 1, 9, 0, 0, 5 },
			{ 0, 0, 0, 0, 8, 0, 0, 7, 9 }
		};

		if (SolveSudoku(grid, 0, 0))
			PrintGrid(grid);
		else
			Console.WriteLine("No solution exists");
	}
}


