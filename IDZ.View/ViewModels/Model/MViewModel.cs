using IDZ.Domain.Model;
using IDZ.View.ViewModels.Sewer;
using System.Data.SqlTypes;

namespace IDZ.View.ViewModels.Model
{
    public sealed class MViewModel:ViewModel<ToDoModel>
    {
        public const string ExpenseColumnName = "Витрати тканини, м";
        public const string TimeColumnName = "Потрібний час, дн";
        public const string CostColumnName = "Ціна,грн";
        public const string AdditionalColumnName = "Додаткова ціна, грн";

        public static DataGridViewColumn[] GetColumns(bool isAdmin) => new DataGridViewColumn[]
        {
            new DataGridViewTextBoxColumn
            {
                Name = IdColumnName,
                DataPropertyName=IdColumnName,
                HeaderText=IdColumnName,
                Visible = isAdmin
            },
            new DataGridViewTextBoxColumn
            {
                Name = ExpenseColumnName,
                DataPropertyName=ExpenseColumnName,
                HeaderText=ExpenseColumnName
            },
            new DataGridViewTextBoxColumn
            {
                Name = TimeColumnName,
                DataPropertyName=TimeColumnName,
                HeaderText=TimeColumnName
            },
            new DataGridViewTextBoxColumn
            {
                Name = CostColumnName,
                DataPropertyName=CostColumnName,
                HeaderText=CostColumnName
            },
            new DataGridViewTextBoxColumn
            {
                Name = AdditionalColumnName,
                DataPropertyName=AdditionalColumnName,
                HeaderText=AdditionalColumnName
            }
        };
        public decimal? ExpenseF { get; set; }
        public int? PlanTime { get; set; }
        public decimal? CostModel { get; set; }
        public decimal? AddCost { get; set; }

        public override ToDoModel ToModel()
        {
            return new ToDoModel
            {
                Id_Model = Id,
                ExpenseFabric = ExpenseF,
                PlanTime = PlanTime,
                CostModel = CostModel,
                AdditionalCost = AddCost
            };
        }
        public static bool TryParse(DataGridViewRow row, out MViewModel model)
        {
            model = new MViewModel();
            var idString = row.Cells[IdColumnName].Value?.ToString();
            var id = int.TryParse(idString, out var parsedId) ? parsedId : -1;

            var expense = row.Cells[ExpenseColumnName].Value?.ToString();

            if (string.IsNullOrWhiteSpace(expense))
                return false;

            var time = row.Cells[TimeColumnName].Value?.ToString();
            var cost = row.Cells[CostColumnName].Value?.ToString();
            var add = row.Cells[AdditionalColumnName].Value?.ToString();

            model.Id = id;
            model.ExpenseF = Convert.ToDecimal(expense);
            model.PlanTime = Convert.ToInt32(time);
            model.CostModel = Convert.ToDecimal(cost);
            model.AddCost = Convert.ToDecimal(add);
            
            return true;
        }
        public static MViewModel Parse(ToDoModel list)
        {
            return new MViewModel
            {
                Id = list.Id_Model,
                ExpenseF = list.ExpenseFabric,
                PlanTime = list.PlanTime,
                CostModel = list.CostModel,
                AddCost = list.AdditionalCost
            };
        }
        public void UpdateFromViewModel(MViewModel model, int id)
        {
            if (Id == id)
            {
                ExpenseF=model.ExpenseF; 
                PlanTime=model.PlanTime; 
                CostModel=model.CostModel; 
                AddCost = model.AddCost;
            }
        }
    }
}

