using IDZ.Domain.Photo;
using IDZ.View.ViewModels.Sewer;
using System.Text;

namespace IDZ.View.ViewModels.Photo
{
    public sealed class PViewModel : ViewModel<ToDoPhoto>
    {
        public const string ModelColumnName = "Model";
        public const string ImageColumnName = "Image";
        public const string LinkColumnName = "FileName";

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
                Name = ModelColumnName,
                DataPropertyName=ModelColumnName,
                HeaderText=ModelColumnName
            },
            new DataGridViewTextBoxColumn
            {
                Name = LinkColumnName,
                DataPropertyName=LinkColumnName,
                HeaderText=LinkColumnName
            },
            new DataGridViewImageColumn
            {
                Name = ImageColumnName,
                DataPropertyName=ImageColumnName,
                HeaderText=ImageColumnName
            }
        };
        public int? IdModel { get; set; }
        public Image? Image { get; set; }
        public string link { get; set; } = string.Empty;

        public override ToDoPhoto ToModel()
        {
            return new ToDoPhoto
            {
                Id_Photo = Id,
                Id_Model = IdModel,
                link = link,
                Picture = Image
            };
        }
        public bool Equals(string _link, int? model)
        {
            return EqualsBylink(_link) && EqualsById(model);
        }
        private bool EqualsById(int? modelId)
        {
            return modelId == null && IdModel == null ||
                   IdModel != null && modelId != null && IdModel.Equals(modelId);
        }
        private bool EqualsBylink(string _link)
        {
            return link == null && _link == null ||
                link != null && _link != null && link.Equals(_link);
        }
        public static bool TryParse(DataGridViewRow row, out PViewModel model)
        {
            model = new PViewModel();
            var idString = row.Cells[IdColumnName].Value?.ToString();
            var id = int.TryParse(idString, out var parsedId) ? parsedId : -1;

            var idString2 = row.Cells[ModelColumnName].Value?.ToString();

            if (string.IsNullOrWhiteSpace(idString2))
                return false;

            var id_model = int.TryParse(idString2, out var parsedId2) ? parsedId2 : -1;

            var image = row.Cells[ImageColumnName].Value?.ToString();
            var link = row.Cells[LinkColumnName].Value?.ToString();

            model.Id = id;
            model.IdModel = id_model;
            model.link = link;
            model.Image =ConvertBytesToImage(ConvertStringToImage(image));

            return true;
        }
        public static PViewModel Parse(ToDoPhoto list)
        {
            return new PViewModel
            {
                Id = list.Id_Photo,
                IdModel = list.Id_Model,
                link = list.link,
                Image = list.Picture
            };
        }
        public byte[] ConvertImageToString(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }
        public static byte[] ConvertStringToImage(string? data)
        {
            if (data == null)
            {
                return new byte[0]; 
            }

            return Convert.FromBase64String(data);
        }

        public static Image ConvertBytesToImage(byte[] imageBytes)
        {
            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                return Image.FromStream(ms);
            }
        }
        public void UpdateFromViewModel(PViewModel model, int id)
        {
            if (Id == id)
            {
                IdModel = model.IdModel;
                link = model.link;
                Image = model.Image;
            }
        }
    }
}
