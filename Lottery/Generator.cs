namespace Lottery
{
    /// <summary>
    /// 
    /// </summary>
    class UKGenerator : IGenerator
    {
        public int Count { get; } = 6;

        public List<int> Generate()
        {
            List<int> numbers = [];
            for (int i = 0; i < Count; i++)
            {
                numbers.Add(Random.Shared.Next(60));
            }
            return numbers;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    class EuroGenerator : IGenerator
    {
        public int Count { get; } = 8;

        public List<int> Generate()
        {
            List<int> numbers = [];
            for (int i = 0; i < Count; i++)
            {
                numbers.Add(Random.Shared.Next(60));
            }
            return numbers;
        }
    }

    class SetForLifeGenerator : IGenerator
    {
        public int Count { get; } = 10;

        public List<int> Generate()
        {
            List<int> numbers = [];
            for (int i = 0; i < Count; i++)
            {
                numbers.Add(Random.Shared.Next(60));
            }
            return numbers;
        }
    }
}
