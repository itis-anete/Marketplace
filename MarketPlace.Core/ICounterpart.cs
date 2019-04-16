namespace MarketPlace.Core
{
    public interface ICounterpart<in TEntity>
    {
        double GetSimilarityCoefficient(TEntity other);
    }
}