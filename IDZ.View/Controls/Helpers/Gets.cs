
using IDZ.Persistense.Repositories;

namespace IDZ.View.Controls.Helpers
{
    public class Gets
    {
        public static List<int> GetAllModelIds()
        {
            List<int> modelIds = new List<int>();

            using (var repository = new MRepository())
            {
                modelIds = repository.GetAllId();
            }

            return modelIds;
        }
        public static List<string> GetAllFabricNames()
        {
            List<string> fabricNames = new List<string>();

            using (var repository = new FRepository())
            {
                fabricNames = repository.GetAllName();
            }

            return fabricNames;
        }
    }
}
