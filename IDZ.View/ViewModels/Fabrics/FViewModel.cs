using IDZ.Domain.Fabric;
using IDZ.Persistense.Repositories;
using IDZ.View.ViewModels.Sewer;

namespace IDZ.View.ViewModels.Fabrics
{
    public sealed class FViewModel : ViewModel<ToDoFabric>
    {
      public const string NameColumnName = "Назва";
      public const string TypeColumnName = "Тип";
      public const string CostColumnName = "ЦінаЗаМетр";

      private static FRepository _repository=new FRepository();
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
              Name = TypeColumnName,
              DataPropertyName=TypeColumnName,
              HeaderText=TypeColumnName
          },
          new DataGridViewTextBoxColumn
          {
              Name = CostColumnName,
              DataPropertyName=CostColumnName,
              HeaderText=CostColumnName
          }
          };
          public string NameFabric { get; set; } = string.Empty;
          public string? Type { get; set; }
          public decimal? Cost { get; set; }
          public override ToDoFabric ToModel()
          {
              return new ToDoFabric
              {
                  Id_Fabric = Id,
                  NameFabric = NameFabric,
                  Type = Type,
                  CostForMeter = Cost,
              };
          }
          public bool Equals(string name, string? type)
          {
              return EqualsByName(name) && EqualsByType(type);
          }
          private bool EqualsByType(string? type)
          {
              return Type == null && type == null ||
                  (Type != null && type != null && Type.Equals(type));
          }
          private bool EqualsByName(string name)
          {
              return NameFabric == null && name == null ||
                  (NameFabric != null && name != null && NameFabric.Equals(name));
          }
          public static bool TryParse(DataGridViewRow row, out FViewModel fabric)
          {
              fabric = new FViewModel();
              var idString = row.Cells[IdColumnName].Value?.ToString();
              var id = int.TryParse(idString, out var parsedId) ? parsedId : -1;

              var name = row.Cells[NameColumnName].Value?.ToString();

              if (string.IsNullOrWhiteSpace(name))
                  return false;

              var type = row.Cells[TypeColumnName].Value?.ToString();
              var cost = row.Cells[CostColumnName].Value?.ToString();

              if (double.TryParse(cost, out var costValue))
              {
                  fabric.Id = id;
                  fabric.NameFabric = name;
                  fabric.Type = type;
                  fabric.Cost = Convert.ToDecimal(costValue);

                  return true;
              }

              return false;
          }
          public static FViewModel Parse(ToDoFabric list)
          {
              return new FViewModel
              {
                  Id = list.Id_Fabric,
                  NameFabric = list.NameFabric,
                  Type = list.Type,
                  Cost = list.CostForMeter
              };
          }
        public void UpdateFromViewModel(FViewModel model, int id)
        {
            if (Id == id)
            {
                NameFabric = model.NameFabric;
                Type = model.Type;
                Cost = model.Cost;
            }
        }
    }
  }
