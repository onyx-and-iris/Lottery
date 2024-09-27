namespace Lottery
{
    internal class Generator
    {
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
