namespace Lottery
{
    /// <summary>
    /// Base Exception class for the LottoPicker app
    /// </summary>
    internal class LottoPickerException(string message) : Exception(message)
    {
    }
}
