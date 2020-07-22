namespace MyBasketballScores.Infra.Data.Transactions
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
