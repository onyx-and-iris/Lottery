namespace Lottery
{
    /// <summary>
    /// Base Exception class for the Lottery app
    /// </summary>
    internal class LotteryException(string message) : Exception(message) { }
}
