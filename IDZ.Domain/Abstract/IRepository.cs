namespace IDZ.Domain.Abstract
{
    public interface IRepository<TPov>
        where TPov : Pov
    {
        void Add(TPov list);
        void Delete(int id);
        void Update(TPov list);
        TPov? Get(int id);
        IReadOnlyCollection<TPov> GetAll();
    }
}
