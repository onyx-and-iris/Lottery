namespace Lottery
{
    internal record Numbers(List<int> Normal);

    internal record NumbersWithSpecial(List<int> Normal, List<int> Special) : Numbers(Normal);
}
