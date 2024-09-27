namespace Lottery
{
    internal record Limits(int Count, int Lower, int Upper);

    /// <summary>
    /// Abstract base class for lotteries.
    /// Limits property must be overridden.
    /// </summary>
    internal class Lottery
    {
        protected virtual Limits Limits => throw new NotImplementedException();
        public virtual string Play() => $"Numbers: {string.Join(", ", Generator.Generate(Limits))}";
    }

    /// <summary>
    /// Concrete UKLotto Lottery class.
    /// Generates six balls from 1 to 59.
    /// </summary>
    internal class UKLottoLottery : Lottery
    {
        protected override Limits Limits { get; } = new(Count: 6, Lower: 1, Upper: 59);
    }

    /// <summary>
    /// Abstract base class for Lotteries with Special values.
    /// It subclasses Lottery.
    /// SpecialLimits and SpecialIdentifier properties must be overridden.
    /// </summary>
    internal class LotteryWithSpecial : Lottery
    {
        protected virtual Limits SpecialLimits => throw new NotImplementedException();
        protected virtual string SpecialIdentifier => throw new NotImplementedException();

        public override string Play()
        {
            return string.Join("\t", [
                $"Numbers: {string.Join(", ", Generator.Generate(Limits))}",
                $"{SpecialIdentifier}: {string.Join(", ", Generator.Generate(SpecialLimits))}",
            ]);
        }
    }

    /// <summary>
    /// Concrete class for EuroMillions lottery.
    /// Generates five balls from 1 to 50 and two lucky stars from 1 to 12.
    /// </summary>
    internal class EuroMillionsLottery : LotteryWithSpecial
    {
        protected override Limits Limits { get; } = new(Count: 5, Lower: 1, Upper: 50);
        protected override Limits SpecialLimits { get; } = new(Count: 2, Lower: 1, Upper: 12);
        protected override string SpecialIdentifier => "Lucky Stars";
    }

    /// <summary>
    /// Concrete class for SetForLifeLottery lottery.
    /// Generates five balls from 1 to 47 and one life ball from 1 to 10.
    /// </summary>
    internal class SetForLifeLottery : LotteryWithSpecial
    {
        protected override Limits Limits { get; } = new(Count: 5, Lower: 1, Upper: 47);
        protected override Limits SpecialLimits { get; } = new(Count: 1, Lower: 1, Upper: 10);
        protected override string SpecialIdentifier => "Life Ball";
    }

    /// <summary>
    /// Concrete class for ThunderballLottery lottery.
    /// Generates fives balls from 1 to 39 and one thunderball from 1 to 14.
    /// </summary>
    internal class ThunderballLottery : LotteryWithSpecial
    {
        protected override Limits Limits { get; } = new(Count: 5, Lower: 1, Upper: 39);
        protected override Limits SpecialLimits { get; } = new(Count: 1, Lower: 1, Upper: 14);
        protected override string SpecialIdentifier => "Thunderball";
    }
}
