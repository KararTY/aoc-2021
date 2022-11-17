namespace ConsoleApp
{
	class Day2
	{
		public Day2()
		{
			int horizontalPosition = 0;
			int depth = 0;

			string[] dataStrArr = File.ReadAllLines(@".\\input_day2.txt");

			for (int i = 0; i < dataStrArr.Length; i++)
			{
				string[] instructionAndValue = dataStrArr[i].Split(" ");
				string instruction = instructionAndValue[0];
				int value = int.Parse(instructionAndValue[1]);

				switch (instruction)
				{
					case "forward":
						horizontalPosition += value;
						break;
					case "up":
						depth -= value;
						break;
					case "down":
						depth += value;
						break;
					default:
						break;
				}
			}

			Console.WriteLine(horizontalPosition * depth);
			Console.WriteLine("Part Two: {0}", this.PartTwo(dataStrArr));
		}

		private int PartTwo(string[] strArr)
		{
			int horizontalPosition = 0;
			int depth = 0;

			int aim = 0;

			for (int i = 0; i < strArr.Length; i++)
			{
				string[] instructionAndValue = strArr[i].Split(" ");
				string instruction = instructionAndValue[0];
				int value = int.Parse(instructionAndValue[1]);

				switch (instruction)
				{
					case "forward":
						/*
						forward X does two things:
							It increases your horizontal position by X units.
							It increases your depth by your aim multiplied by X.
						*/
						horizontalPosition += value;
						depth += value * aim;
						break;
					case "down":
						// down X increases your aim by X units.
						aim += value;
						break;
					case "up":
						// up X decreases your aim by X units.
						aim -= value;
						break;
					default:
						break;
				}
			}

			return horizontalPosition * depth;
		}
	}
}