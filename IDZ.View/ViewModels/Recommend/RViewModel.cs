using IDZ.Domain.Lists;
using IDZ.Domain.Recommend;
using IDZ.View.ViewModels.Clients;

namespace IDZ.View.ViewModels.Recommend
{
    public sealed class RViewModel:ViewModel<ToDoRecommend>
    {
        public const string FabricColumnName = "Тканина";
        public const string ModelColumnName = "Модель";
        public const string ExpenseColumnName = "Вартість тканини";

        public static DataGridViewColumn[] GetColumns(bool isAdmin) => new DataGridViewColumn[]
        {
            new DataGridViewTextBoxColumn
            {
                Name = FabricColumnName,
                DataPropertyName=FabricColumnName,
                HeaderText=FabricColumnName
            },
            new DataGridViewTextBoxColumn
            {
                Name = ModelColumnName,
                DataPropertyName=ModelColumnName,
                HeaderText=ModelColumnName
            },
            new DataGridViewTextBoxColumn
            {
                Name = ExpenseColumnName,
                DataPropertyName=ExpenseColumnName,
                HeaderText=ExpenseColumnName
            }
        };
        public int Id_Fabric { get; set; }
        public int Id_Model { get; set; }
        public decimal? Expense { get; set; }

        public override ToDoRecommend ToModel()
        {
            return new ToDoRecommend
            {
                Id_Fabric=Id_Fabric,
                Id_Model=Id_Model,
                ExpenseForModel=Expense
            };
        }
        public bool Equals(int? model, int fabric)
        {
            return EqualsByModel(model) && EqualsByFabric(fabric);
        }
        private bool EqualsByFabric(int? fabric)
        {
            return Id_Fabric == null && fabric == null || (Id_Fabric != null && fabric != null && Id.Equals(fabric));
        }
        private bool EqualsByModel(int? model)
        {
            return Id_Model == null && model == null ||
                (Id_Model != null && model != null && Id_Model.Equals(model));
        }
        public static bool TryParse(DataGridViewRow row, out RViewModel model)
        {
            model = new RViewModel();
            var idString = row.Cells[FabricColumnName].Value?.ToString();
            var id = int.TryParse(idString, out var parsedId) ? parsedId : -1;

            var Model = row.Cells[ModelColumnName].Value?.ToString();
            var idModel = int.TryParse(Model, out var parsedIdModel) ? parsedIdModel : -1;

            var expense = row.Cells[ExpenseColumnName].Value?.ToString();

            if (string.IsNullOrWhiteSpace(expense))
                return false;

            model.Id_Fabric = id;
            model.Id_Model = idModel;
            model.Expense = Convert.ToDecimal(expense);

            return true;
        }
        public static RViewModel Parse(ToDoRecommend list)
        {
            return new RViewModel
            {
                Id_Fabric = list.Id_Fabric,
                Id_Model = list.Id_Model,
                Expense=list.ExpenseForModel
            };
        }
    }
}
