using IDZ.Domain.Fabric;
using IDZ.Domain.Lists;
using IDZ.Domain.Model;
using IDZ.Domain.Order;
using IDZ.Domain.Tasks;

namespace IDZ.View.ViewModels.Order
{
    public sealed class OViewModel:ViewModel<ToDoOrder>
    {
        public const string ClientColumnName = "Id_Client";
        public const string ModelColumnName = "Id_Model";
        public const string FabricColumnName = "Id_Fabric";
        public const string SewerColumnName = "Id_Sewer";
        public const string DataTakeColumnName = "Дата взяття";
        public const string DataDoPlanColumnName = "Дата план.";
        public const string DataDoRealColumnName = "Дата реальна";
        public const string CostFabricPlanColumnName = "Ціна тканини";
        public const string PriceColumnName = "Повна ціна";
        public const string ExpenseFabricColumnName = "Витрати тканини";
        public const string ReadyColumnName = "Готовність";

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
                Name = ClientColumnName,
                DataPropertyName=ClientColumnName,
                HeaderText=ClientColumnName
            },
            new DataGridViewTextBoxColumn
            {
                Name = ModelColumnName,
                DataPropertyName=ModelColumnName,
                HeaderText=ModelColumnName
            },
            new DataGridViewTextBoxColumn
            {
                Name = FabricColumnName,
                DataPropertyName=FabricColumnName,
                HeaderText=FabricColumnName
            },
            new DataGridViewTextBoxColumn
            {
                Name = SewerColumnName,
                DataPropertyName=SewerColumnName,
                HeaderText=SewerColumnName
            },
            new DataGridViewTextBoxColumn
            {
                Name = DataTakeColumnName,
                DataPropertyName=DataTakeColumnName,
                HeaderText=DataTakeColumnName
            },
            new DataGridViewTextBoxColumn
            {
                Name = DataDoPlanColumnName,
                DataPropertyName=DataDoPlanColumnName,
                HeaderText=DataDoPlanColumnName
            },
            new DataGridViewTextBoxColumn
            {
                Name = DataDoRealColumnName,
                DataPropertyName=DataDoRealColumnName,
                HeaderText=DataDoRealColumnName
            },
            new DataGridViewTextBoxColumn
            {
                Name = CostFabricPlanColumnName,
                DataPropertyName=CostFabricPlanColumnName,
                HeaderText=CostFabricPlanColumnName
            },
            new DataGridViewTextBoxColumn
            {
                Name = PriceColumnName,
                DataPropertyName=PriceColumnName,
                HeaderText=PriceColumnName
            },
            new DataGridViewTextBoxColumn
            {
                Name = ExpenseFabricColumnName,
                DataPropertyName=ExpenseFabricColumnName,
                HeaderText = ExpenseFabricColumnName
            },
            new DataGridViewTextBoxColumn
            {
                Name = ReadyColumnName,
                DataPropertyName=ReadyColumnName,
                HeaderText = ReadyColumnName
            }
        };
        public int Id_Order { get; set; }
        public int Id_Client { get; set; }
        public int Id_Model { get; set; }
        public int Id_Fabric { get; set; }
        public int Id_Sewer { get; set; }
        public DateTime? DataTake { get; set; }
        public DateTime DataDoPlan { get; set; }
        public DateTime? DataDoReal { get; set; }
        public decimal? CostFabric { get; set; }
        public decimal? CostOrder { get; set; }
        public decimal? ExpenseFabricReal { get; set; }
        public bool? Ready { get; set; }

        public override ToDoOrder ToModel()
        {
            return new ToDoOrder
            {
                Id_Client = Id_Client,
                Id_Model = Id_Model,
                Id_Fabric = Id_Fabric,
                Id_Sewer = Id_Sewer,
                DataTake=DataTake,
                DataDoPlan=DataDoPlan,
                DataDoReal=DataDoReal,
                CostFabric=CostFabric,
                CostOrder=CostOrder,
                ExpenseFabricReal=ExpenseFabricReal,
                Ready=Ready,
            };
        }
        public bool Equals(DateTime data, int? id)
        {
            return EqualsByDataTake(data) && EqualsByClient(id);
        }
        private bool EqualsByClient(int? id)
        {
            return Id_Client == null && id == null || (Id_Client != null && id != null && Id_Client.Equals(id));
        }
        private bool EqualsByDataTake(DateTime? data)
        {
            return DataTake == null && data == null ||
                (DataTake != null && data != null && DataTake.Equals(data));
        }
        public static bool TryParse(DataGridViewRow row, out OViewModel model)
        {
            model = new OViewModel();
            var idString = row.Cells[IdColumnName].Value?.ToString();
            var id = int.TryParse(idString, out var parsedId) ? parsedId : -1;

            var idClientString = row.Cells[IdColumnName]?.Value?.ToString();
            var idClient = int.TryParse(idClientString, out var parsedClientId) ? parsedClientId : -1;

            var idModelString = row.Cells[IdColumnName]?.Value?.ToString();
            var idModel = int.TryParse(idModelString, out var parsedModelId) ? parsedModelId : -1;

            var idFabricString = row.Cells[IdColumnName]?.Value?.ToString();
            var idFabric = int.TryParse(idFabricString, out var parsedFabricId) ? parsedFabricId : -1;

            var idSewerString = row.Cells[IdColumnName]?.Value?.ToString();
            var idSewer = int.TryParse(idSewerString, out var parsedSewerId) ? parsedSewerId : -1;

            var dataTake = row.Cells[ClientColumnName].Value?.ToString();

            if (string.IsNullOrWhiteSpace(dataTake))
                return false;

            var dataPlan = row.Cells[ClientColumnName].Value?.ToString();
            var dataReal = row.Cells[ClientColumnName].Value?.ToString();

            var costFabric = row.Cells[ModelColumnName].Value?.ToString();
            var costOrder = row.Cells[FabricColumnName].Value?.ToString();
            var expenseFabric = row.Cells[SewerColumnName].Value?.ToString();
            var ready = row.Cells[SewerColumnName].Value?.ToString();

            model.Id = id;
            model.Id_Client = idClient;
            model.Id_Model = idModel;
            model.Id_Fabric = idFabric;
            model.Id_Sewer = idSewer;
            model.DataTake = Convert.ToDateTime(dataTake);
            model.DataDoPlan= Convert.ToDateTime(dataPlan);
            model.DataDoReal = Convert.ToDateTime(dataReal);
            model.CostFabric=Convert.ToDecimal(costFabric);
            model.CostOrder= Convert.ToDecimal(costOrder);
            model.ExpenseFabricReal= Convert.ToDecimal(expenseFabric);
            model.Ready= Convert.ToBoolean(ready);

            return true;
        }
        public static OViewModel Parse(ToDoOrder list)
        {
            return new OViewModel
            {
                Id = list.Id_Order,
                Id_Client = list.Id_Client,
                Id_Model = list.Id_Model,
                Id_Fabric = list.Id_Fabric,
                Id_Sewer = list.Id_Sewer,
                DataTake =list.DataTake,
                DataDoPlan=list.DataDoPlan,
                DataDoReal=list.DataDoReal,
                CostFabric=list.CostFabric,
                CostOrder=list.CostOrder,
                Ready=list.Ready
            };
        }
    }
}
