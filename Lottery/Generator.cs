namespace Lottery
{
    internal class Generator
    {
        /// <summary>
        /// Simple algorithm for generating a list of unique numbers of Limits.Count size
        /// </summary>
        /// <param name="limits">Defines the amount of numbers to generate, the min and max values</param>
        /// <returns>Numbers are returned as a sorted set.</returns>
        public static SortedSet<int> Generate(Limits limits)
        {
            List<int> candidates = Enumerable.Range(limits.Lower, limits.Upper).ToList();
            SortedSet<int> numbers = [];

            for (int i = 0; i < limits.Count; i++)
            {
                int RandomIndex = Random.Shared.Next(candidates.Count);
                numbers.Add(candidates[RandomIndex]);
                candidates.RemoveAt(RandomIndex);
            }
            return numbers;
        }
    }
}
