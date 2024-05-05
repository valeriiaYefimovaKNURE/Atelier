using IDZ.Domain.Lists;
using IDZ.Domain.Tasks;
using IDZ.View.ViewModels.Clients;
using IDZ.View.ViewModels.Warehous;

namespace IDZ.View.ViewModels.Sewer
{
    public sealed class SViewModel:ViewModel<ToDoSewer>
    {
        public const string NameColumnName = "ФІО";
        public const string PayColumnName = "Зарплата";
        public const string QualColumnName = "Кваліфікація";
        public const string WorkColumnName = "Навантаження";

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
                Name = NameColumnName,
                DataPropertyName=NameColumnName,
                HeaderText=NameColumnName
            },
            new DataGridViewTextBoxColumn
            {
                Name = PayColumnName,
                DataPropertyName=PayColumnName,
                HeaderText=PayColumnName
            },
            new DataGridViewTextBoxColumn
            {
                Name = QualColumnName,
                DataPropertyName=QualColumnName,
                HeaderText=QualColumnName
            },
            new DataGridViewTextBoxColumn
            {
                Name = WorkColumnName,
                DataPropertyName=WorkColumnName,
                HeaderText=WorkColumnName
            }
        };
        public string NameSewer { get; set; } = string.Empty;
        public double Payment { get; set; }
        public string? Qualification { get; set; }
        public int Workload { get; set; }

        public override ToDoSewer ToModel()
        {
            return new ToDoSewer
            {
                Id_Sewer = Id,
                NameSewer = NameSewer,
                Payment = Payment,
                Qualification = Qualification,
                Workload = Workload
            };
        }
        public bool Equals(string name, string? qual)
        {
            return EqualsByName(name) && EqualsByQual(qual);
        }
        private bool EqualsByQual(string? qual)
        {
            return Qualification == null && qual == null || (Qualification != null && qual != null && Qualification.Equals(qual));
        }
        private bool EqualsByName(string name)
        {
            return NameSewer == null && name == null ||
                (NameSewer != null && name != null && NameSewer.Equals(name));
        }
        public static bool TryParse(DataGridViewRow row, out SViewModel sewer)
        {
            sewer = new SViewModel();
            var idString = row.Cells[IdColumnName].Value?.ToString();
            var id = int.TryParse(idString, out var parsedId) ? parsedId : -1;

            var name = row.Cells[NameColumnName].Value?.ToString();

            if (string.IsNullOrWhiteSpace(name))
                return false;

            var pay = row.Cells[PayColumnName].Value?.ToString();
            var qual = row.Cells[QualColumnName].Value?.ToString();
            var work = row.Cells[WorkColumnName].Value?.ToString();

            sewer.Id = id;
            sewer.NameSewer = name;
            sewer.Payment = Convert.ToDouble(pay);
            sewer.Qualification = qual;
            sewer.Workload = Convert.ToInt16(work);

            return true;
        }
        public static SViewModel Parse(ToDoSewer list)
        {
            return new SViewModel
            {
                Id = list.Id_Sewer,
                NameSewer = list.NameSewer,
                Payment = list.Payment,
                Qualification = list.Qualification,
                Workload = list.Workload
            };
        }
        public void UpdateFromViewModel(SViewModel model, int id)
        {
            if (Id == id)
            {
                NameSewer = model.NameSewer;
                Payment = model.Payment;
                Qualification = model.Qualification;
                Workload = model.Workload;
            }
        }
    }
}
