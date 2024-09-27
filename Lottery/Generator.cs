namespace Lottery
{
    internal class Generator
    {
        /// <summary>
        /// Simple algorithm for generating a list of unique numbers of Limits.Count size
        /// </summary>
        /// <param name="Limits">Defines the amount of numbers to generate, the max and min values</param>
        /// <returns>The list of numbers is returned sorted in ascending order.</returns>
        public static List<int> Generate(Limits Limits)
        {
            List<int> Candidates = Enumerable.Range(Limits.Lower, Limits.Upper).ToList();
            List<int> Numbers = [];

            for (int i = 0; i < Limits.Count; i++)
            {
                int RandomIndex = Random.Shared.Next(Candidates.Count);
                Numbers.Add(Candidates[RandomIndex]);
                Candidates.RemoveAt(RandomIndex);
            }
            Numbers.Sort();
            return Numbers;
        }
    }
}
