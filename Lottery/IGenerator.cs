namespace Lottery
{
    /// <summary>
    /// 
    /// </summary>
    interface IGenerator
    {
        int Count { get; }

        List<int> Generate();
    }
}
