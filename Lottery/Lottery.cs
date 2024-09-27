namespace Lottery
{
    /// <summary>
    /// Base Lottery class, use it for lotteries that generate a single set of numbers.
    /// SpecialIdentifier may be overridden for Lotteries with Special values.
    /// </summary>
    /// <param name="Generator">A fully formed Generator</param>
    internal class Lottery(IGenerator Generator)
    {
        protected Numbers GenerateNumbers() => Generator.Generate();

        public virtual string Output()
        {
            var numbers = GenerateNumbers();
            return $"Numbers: {string.Join(", ", numbers.Normal)}";
        }
    }

    /// <summary>
    /// Abstract base class, for lotteries with special values.
    /// It subclasses Lottery.
    /// </summary>
    /// <param name="Generator">A fully formed Generator</param>
    internal class LotteryWithSpecial(IGenerator Generator) : Lottery(Generator)
    {
        protected virtual string SpecialIdentifier => throw new NotImplementedException();

        public override string Output()
        {
            var numbers = GenerateNumbers() as NumbersWithSpecial
                ?? throw new LotteryException($"Unable to generate numbers for {this}");

            return string.Join("\t", [
                $"Numbers: {string.Join(", ", numbers.Normal)}",
                $"{SpecialIdentifier}: {string.Join(", ", numbers.Special)}",
            ]);
        }
    }

    internal class EuroMillionsLotteryWithSpecial(IGenerator Generator) : LotteryWithSpecial(Generator)
    {
        protected override string SpecialIdentifier => "Lucky Stars";
    }

    internal class SetForLifeLotteryWithSpecial(IGenerator Generator) : LotteryWithSpecial(Generator)
    {
        protected override string SpecialIdentifier => "Life Ball";
    }

    internal class ThunderballLotteryWithSpecial(IGenerator Generator) : LotteryWithSpecial(Generator)
    {
        protected override string SpecialIdentifier => "Thunderball";
    }
}
