namespace Lottery
{
    internal record Numbers(KindOfLotto Kind, List<int> Normal);

    internal record NumbersWithSpecial(KindOfLotto Kind, List<int> Normal, List<int> Special) : Numbers(Kind, Normal);
}
