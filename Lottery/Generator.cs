namespace Lottery
{
    record Limits(int Count, int Lower, int Upper);

    /// <summary>
    /// Abstract base class for generators
    /// All subclasses must implement the IGenerator interface
    /// Provides some default implementation
    /// </summary>
    class Generator : IGenerator
    { 
        public virtual Numbers Generate() => throw new NotImplementedException();

        protected static void FillNumbers(List<int> NumberList, Limits Limits)
        {
            List<int> Candidates = Enumerable.Range(Limits.Lower, Limits.Upper).ToList();

            for (int i = 0; i < Limits.Count; i++)
            {
                int RandomIndex = Random.Shared.Next(Candidates.Count);
                NumberList.Add(Candidates[RandomIndex]);
                Candidates.RemoveAt(RandomIndex);
            }
            NumberList.Sort();
        }
    }

    /// <summary>
    /// Concrete UKLottoGenerator class.
    /// Generates six balls from 1 to 59
    /// </summary>
    class UKLottoGenerator : Generator
    {
        private readonly Limits Limits = new(6, 1, 59);

        public override Numbers Generate()
        {
            Numbers Numbers = new(KindOfLotto.Uk, []);
            Generator.FillNumbers(Numbers.Normal, Limits);
            return Numbers;
        }
    }

    /// <summary>
    /// Concrete EuroMillionsGenerator class.
    /// Generates five balls from 1 to 50 and two balls from 1 to 12
    /// </summary>
    class EuroMillionsGenerator : Generator
    {
        private readonly Limits NormalLimits = new(5, 1, 50);
        private readonly Limits SpecialLimits = new(2, 1, 12);

        public override Numbers Generate()
        {
            NumbersWithSpecial Numbers = new(KindOfLotto.Euro, [], []);
            Generator.FillNumbers(Numbers.Normal, NormalLimits);
            Generator.FillNumbers(Numbers.Special, SpecialLimits);
            return Numbers;
        }
    }

    /// <summary>
    /// Concrete SetForLifeGenerator class.
    /// Generates five balls from 1 to 47 and one ball from 1 to 10
    /// </summary>
    class SetForLifeGenerator : Generator
    {
        private readonly Limits NormalLimits = new(5, 1, 47);
        private readonly Limits SpecialLimits = new(1, 1, 10);

        public override Numbers Generate()
        {
            NumbersWithSpecial Numbers = new(KindOfLotto.SetForLife, [], []);
            Generator.FillNumbers(Numbers.Normal, NormalLimits);
            Generator.FillNumbers(Numbers.Special, SpecialLimits);
            return Numbers;
        }
    }

    /// <summary>
    /// Concrete ThunderBallGenerator class.
    /// Generates fives balls from 1 to 39 and one ball from 1 to 14
    /// </summary>
    class ThunderBallGenerator : Generator
    {
        private readonly Limits NormalLimits = new(5, 1, 39);
        private readonly Limits SpecialLimits = new(1, 1, 14);

        public override Numbers Generate()
        {
            NumbersWithSpecial Numbers = new(KindOfLotto.Thunderball, [], []);
            Generator.FillNumbers(Numbers.Normal, NormalLimits);
            Generator.FillNumbers(Numbers.Special, SpecialLimits);
            return Numbers;
        }
    }
}
