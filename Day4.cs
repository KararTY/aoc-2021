namespace ConsoleApp
{
	class Day4
	{
		class Entry
		{
			public int num;
			public bool check = false;
		}
		private bool checkIfWon (List<List<Entry>> bingoBoard)
		{
			int yLength = bingoBoard.Count;
			int xLength = bingoBoard[0].Count;

			for (int y = 0; y < yLength; y++)
			{
				int numOfCheckedX = 0;
				int numOfCheckedY = 0;

				for (int x = 0; x < xLength; x++)
				{
					if (bingoBoard[y][x].check) numOfCheckedX++;
				}

				for (int x = 0; x < xLength; x++)
				{
					if (bingoBoard[x][y].check) numOfCheckedY++;
				}

				if (numOfCheckedX == xLength) return true;
				if (numOfCheckedY == yLength) return true;
			}

			return false;
		}
		private void findAndCheckNumber(List<List<Entry>> bingoBoard, int numToCheck)
		{
			for (int y = 0; y < bingoBoard.Count; y++)
			{
				List<Entry> row = bingoBoard[y];
	
				for (int x = 0; x < row.Count; x++)
				{
					Entry entry = row[x];

					if (entry.num == numToCheck)
					{
						entry.check = true;
					}
				}
			}
		}
		public Day4()
		{
			string[] dataStrArr = File.ReadAllLines(@".\\inputs\\4.txt");

			int[] bingoNumbers = Array.ConvertAll(dataStrArr[0].Split(","), str => int.Parse(str));

			string[] bingoBoards = String.Join("\n", dataStrArr.Skip(1)).Split("\n\n");

			List<List<List<Entry>>> matrices = new List<List<List<Entry>>>();

			for (int bingoBoardIndex = 0; bingoBoardIndex < bingoBoards.Length; bingoBoardIndex++)
			{
				string[] bingoBoardLines = bingoBoards[bingoBoardIndex].Trim().Split("\n");
				matrices.Add(new List<List<Entry>>());

				for (int bingoBoardLineIndex = 0; bingoBoardLineIndex < bingoBoardLines.Length; bingoBoardLineIndex++)
				{
					string[] bingoBoardLineNumbers = bingoBoardLines[bingoBoardLineIndex].Trim().Split(" ").Where(str => str.Length > 0).ToArray();
					matrices[bingoBoardIndex].Add(new List<Entry>());

					for (int bingoBoardLineNumberIndex = 0; bingoBoardLineNumberIndex < bingoBoardLineNumbers.Length; bingoBoardLineNumberIndex++)
					{
						int bingoBoardLineNumber = int.Parse(bingoBoardLineNumbers[bingoBoardLineNumberIndex].Trim());

						var entry = new Entry();
						entry.num = bingoBoardLineNumber;

						matrices[bingoBoardIndex][bingoBoardLineIndex].Add(entry);
					}
				}
			}

			int winningMatrixIndex = -1;
			int lastCalledBingoNumber = -1;
			for (int i = 0; i < bingoNumbers.Length; i++)
			{
				int bingoNumber = bingoNumbers[i];
				lastCalledBingoNumber = bingoNumber;

				bool won = false;
				for (int boardIndex = 0; boardIndex < bingoBoards.Length; boardIndex++)
				{
					findAndCheckNumber(matrices[boardIndex], bingoNumber);
					
					bool hasWon = checkIfWon(matrices[boardIndex]);

					if (hasWon) {
						winningMatrixIndex = boardIndex;
						won = true;
						break;
					}
				}
				if (won) break;
			}

			// Calculate sum of winning board
			int sumOfUnmarked = 0;
			for (int y = 0; y < matrices[winningMatrixIndex].Count; y++)
			{
				List<Entry> row = matrices[winningMatrixIndex][y];
				for (int x = 0; x < row.Count; x++)
				{
					Entry entry = row[x];
					if (!entry.check) sumOfUnmarked += entry.num;
				}
			}

			Console.WriteLine(sumOfUnmarked * lastCalledBingoNumber);
		}
	}
}
