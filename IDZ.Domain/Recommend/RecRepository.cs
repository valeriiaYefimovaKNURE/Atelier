using IDZ.Domain.Abstract;

namespace IDZ.Domain.Recommend
{
    public interface RecRepository : IRepository<ToDoRecommend>
    {
        public void DeleteModel(int id);
        public ToDoRecommend? GetByModel(int id);

        public ToDoRecommend? Find(int idFabric, int idModel);
    }
}
