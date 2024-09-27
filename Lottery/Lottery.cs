namespace Lottery
{
    /// <summary>
    /// Base Lottery class, it accepts a Generator
    /// SpecialIdentifier may be overriden for Lotteries with Special values.
    /// </summary>
    /// <param name="Generator"></param>
    internal class Lottery(IGenerator Generator)
    {
        public virtual string? SpecialIdentifier { get; }

        public Numbers GenerateNumbers() => Generator.Generate();
    }

    internal class UKLottoLottery(IGenerator Generator) : Lottery(Generator) { };

    internal class EuroMillionsLottery(IGenerator Generator) : Lottery(Generator)
    {
        public override string SpecialIdentifier { get; } = "Lucky Stars";
    }

    internal class SetForLifeLottery(IGenerator Generator) : Lottery(Generator)
    {
        public override string SpecialIdentifier { get; } = "Life Ball";
    }

    internal class ThunderballLottery(IGenerator Generator) : Lottery(Generator)
    {
        public override string SpecialIdentifier { get; } = "Thunderball";
    }
}
