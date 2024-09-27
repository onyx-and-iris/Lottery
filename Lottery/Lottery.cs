namespace Lottery
{
    internal class Lottery(Limits limits)
    {
        protected Limits Limits => limits;
        public virtual string Play() => $"Numbers: {string.Join(", ", Generator.Generate(Limits))}";
    }

    internal class LotteryWithSpecial(Limits limits, Limits specialLimits) : Lottery(limits)
    {
        protected Limits SpecialLimits => specialLimits;
        protected virtual string SpecialIdentifier => throw new NotImplementedException();

        public override string Play()
        {
            return string.Join("\t", [
                $"Numbers: {string.Join(", ", Generator.Generate(Limits))}",
                $"{SpecialIdentifier}: {string.Join(", ", Generator.Generate(SpecialLimits))}",
            ]);
        }
    }

    internal class EuroMillionsLottery(Limits limits, Limits specialLimits) : LotteryWithSpecial(limits, specialLimits)
    {
        protected override string SpecialIdentifier => "Lucky Stars";
    }

    internal class SetForLifeLottery(Limits limits, Limits specialLimits) : LotteryWithSpecial(limits, specialLimits)
    {
        protected override string SpecialIdentifier => "Life Ball";
    }

    internal class ThunderballLottery(Limits limits, Limits specialLimits) : LotteryWithSpecial(limits, specialLimits)
    {
        protected override string SpecialIdentifier => "Thunderball";
    }
}
