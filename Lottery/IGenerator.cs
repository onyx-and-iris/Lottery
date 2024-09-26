namespace Lottery
{
    /// <summary>
    /// All Generators must implement the Generate method
    /// </summary>
    interface IGenerator
    {
        Numbers Generate();
    }
}
