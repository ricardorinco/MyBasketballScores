using MyBasketballScores.Infra.Data.Persistences.DataContext;

namespace MyBasketballScores.Infra.Data.Transactions
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyBasketballScoresContext context;

        public UnitOfWork(MyBasketballScoresContext context)
        {
            this.context = context;
        }

        public void Commit()
        {
            context.SaveChanges();
        }
    }
}
