namespace Courir.DataAccess.Seed
{
    using System.Threading.Tasks;

    public interface IContextSeed
    {
        CourirContext Context { get; set; }

        Task Execute(bool isProduction);
    }
}