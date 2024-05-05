using IDZ.Domain.Lists;

namespace IDZ.View.ViewModels.Clients
{
    public sealed class CViewModel :ViewModel<ToDoClient>
    {
        public const string NameColumnName = "NameClient";
        public const string AddressColumnName = "AddressClient";
        public const string NumColumnName = "NumClient";
        public const string SizeColumnName = "Size";

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
                Name = AddressColumnName,
                DataPropertyName=AddressColumnName,
                HeaderText=AddressColumnName
            },
            new DataGridViewTextBoxColumn
            {
                Name = NumColumnName,
                DataPropertyName=NumColumnName,
                HeaderText=NumColumnName
            },
            new DataGridViewTextBoxColumn
            {
                Name = SizeColumnName,
                DataPropertyName=SizeColumnName,
                HeaderText=SizeColumnName
            }
        };
        public string NameClient { get; set; } = string.Empty;
        public string? AddressClient { get; set; }
        public string? NumClient { get; set; }
        public int Size { get; set; }

        public override ToDoClient ToModel()
        {
            return new ToDoClient
            {
                Id_Client = Id,
                NameClient = NameClient,
                AddressClient = AddressClient,
                NumClient = NumClient,
                Size = Size
            };
        }
        public bool Equals(string name, string? num)
        {
            return EqualsByName(name) && EqualsByNum(num);
        }
        private bool EqualsByNum(string? num)
        {
            return NumClient == null && num == null || (NumClient != null && num != null && NumClient.Equals(num));
        }
        private bool EqualsByName(string name)
        {
            return NameClient == null && name == null ||
                (NameClient != null && name != null && NameClient.Equals(name));
        }
        public static bool TryParse(DataGridViewRow row, out CViewModel model)
        {
            model = new CViewModel();
            var idString = row.Cells[IdColumnName].Value?.ToString();
            var id = int.TryParse(idString, out var parsedId) ? parsedId : -1;

            var name = row.Cells[NameColumnName].Value?.ToString();

            if (string.IsNullOrWhiteSpace(name))
                return false;

            var address = row.Cells[AddressColumnName].Value?.ToString();
            var number = row.Cells[NumColumnName].Value?.ToString();
            var size = row.Cells[SizeColumnName].Value?.ToString();
            
            model.Id=id;
            model.NameClient=name;
            model.AddressClient=address;
            model.NumClient=number;
            model.Size=Convert.ToInt16(size);

            return true;
        }
        public static CViewModel Parse(ToDoClient list)
        {
            return new CViewModel
            {
                Id = list.Id_Client,
                NameClient = list.NameClient,
                AddressClient = list.AddressClient,
                NumClient = list.NumClient,
                Size = list.Size
            };
        }
        public void UpdateFromViewModel(CViewModel model, int id)
        {
            if (Id == id)
            {
                NameClient = model.NameClient;
                AddressClient = model.AddressClient;
                NumClient = model.NumClient;
                Size = model.Size;
            }
        }
    }
}
