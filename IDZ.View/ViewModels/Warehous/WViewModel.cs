using IDZ.Domain.WareHouse;

namespace IDZ.View.ViewModels.Warehous
{
    public sealed class WViewModel:ViewModel<ToDoWare>
    {
        public const string RemainsColumnName = "Залишок";

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
                Name = RemainsColumnName,
                DataPropertyName=RemainsColumnName,
                HeaderText=RemainsColumnName
            }
        };
        public decimal? Remains { get; set; }

        public override ToDoWare ToModel()
        {
            return new ToDoWare
            {
                ID_Fabric = Id,
                Remains = Remains,
            };
        }
        public bool Equals(int? id, int? remain)
        {
            return EqualsByRemain(id) && EqualsById(remain);
        }
        private bool EqualsById(int? id)
        {
            return Id == null && id == null || (Id != null && id != null && Id.Equals(id));
        }
        private bool EqualsByRemain(int? remain)
        {
            return Remains == null && remain == null ||
                (Remains != null && remain != null && Remains.Equals(remain));
        }
        public static bool TryParse(DataGridViewRow row, out WViewModel model)
        {
            model = new WViewModel();
            var idString = row.Cells[IdColumnName].Value?.ToString();
            var id = int.TryParse(idString, out var parsedId) ? parsedId : -1;

            var remains = row.Cells[RemainsColumnName].Value?.ToString();

            if (string.IsNullOrWhiteSpace(remains))
                return false;

            model.Id = id;
            model.Remains =Convert.ToDecimal(remains);

            return true;
        }
        public static WViewModel Parse(ToDoWare list)
        {
            return new WViewModel
            {
                Id = list.ID_Fabric,
                Remains = list.Remains
            };
        }
        public void UpdateFromViewModel(WViewModel model, int id)
        {
            if(Id==id)
            Remains = model.Remains;
        }
    }
}
