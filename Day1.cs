namespace ConsoleApp
{
	class Day1
	{
		public Day1()
		{
			int increaseResult = 0;

			string[] dataStrArr = File.ReadAllLines(@".\\inputs\\1.txt");

			for (int i = 0; i < dataStrArr.Length; i++)
			{
				int num = Int32.Parse(dataStrArr[i]);
				int lastNum = i > 0 ? Int32.Parse(dataStrArr[i - 1]) : num;

				if (num > lastNum) increaseResult++;
			}

			Console.WriteLine(increaseResult);

			// Part two
			Console.WriteLine("Part Two: {0}", this.PartTwo(dataStrArr));
		}

		private int PartTwo(string[] arr)
		{
			int[] numArray = Array.ConvertAll(arr, str => int.Parse(str));

			int increaseResult = 0;

			int currentSum = 0;

			// Get initial window sum.
			for (int i = 0; i < 3; i++)
			{
				currentSum += numArray[i];
			}

			int lastSlidingWindowSum = currentSum;

			// Calculate sliding window
			for (int i = 1; i <= numArray.Length - 3; i++)
			{
				currentSum -= numArray[i - 1];
				currentSum += numArray[i + 2];
				if (currentSum > lastSlidingWindowSum) increaseResult++;

				lastSlidingWindowSum = currentSum;
			}

			return increaseResult;
		}
	}
}
