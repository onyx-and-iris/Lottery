namespace Lottery
{
    internal record Numbers(KindOfLottery Kind, List<int> Normal);

    internal record NumbersWithSpecial(KindOfLottery Kind, List<int> Normal, List<int> Special) : Numbers(Kind, Normal);
}
