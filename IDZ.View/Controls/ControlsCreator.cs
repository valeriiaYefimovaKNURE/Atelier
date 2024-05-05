using IDZ.Persistense.Repositories;
using IDZ.View.Controls.Helpers;
using System.Windows.Forms;
using CC = IDZ.View.Controls.CC;
namespace IDZ.View.Controls
{
    public static class ControlsCreator
    {
        public static Button CreateButton(string text, int x,int y,bool visible=true)
        {
            return new Button()
            {
                Size = new Size(CC.ButtonWidth, CC.ButtonHeight),
                Location = new Point(x, y),
                Text = text,
                Visible = visible,
                BackColor = Color.FromArgb(241, 233, 221),
                ForeColor=Color.Black
            };
        }
        public static Button CreateButton2(string text, int x, int y, bool visible = true)
        {
            return new Button()
            {
                Size = new Size(CC.ButtonWidth2, CC.ButtonHeight2),
                Location = new Point(x, y),
                Text = text,
                Font = new Font("Segoe UI", 10),
                Visible = visible,
                BackColor = Color.FromArgb(172, 69, 70),
                ForeColor = Color.White
            };
        }
        public static Button CreateButton3(string text, int x, int y, bool visible = true)
        {
            return new Button()
            {
                Size = new Size(CC.ButtonWidth3, CC.ButtonHeight3),
                Location = new Point(x, y),
                Text = text,
                Visible = visible,
                BackColor = Color.FromArgb(141, 21, 24),
                ForeColor = Color.White
            };
        }
        public static Button CreateButton4(string text, int x, int y, bool visible = true)
        {
            return new Button()
            {
                Size = new Size(CC.ButtonWidth+CC.Gap, CC.ButtonHeight),
                Location = new Point(x, y),
                Text = text,
                Visible = visible,
                BackColor = Color.FromArgb(241, 233, 221),
                ForeColor = Color.Black
            };
        }
        public static TextBox CreateTextBox(string placeholder, int x, int y)
        {
            return new TextBox
            {
                Size=new Size(CC.TextBoxWidth,CC.TextBoxHeight),
                Location = new Point(x, y),
                PlaceholderText = placeholder
            };
        }
        public static TextBox CreateTextBox2(string placeholder, int x, int y)
        {
            return new TextBox
            {
                Size = new Size(CC.TextBoxWidth2, CC.TextBoxHeight2),
                Location = new Point(x, y),
                PlaceholderText = placeholder
            };
        }
        public static Label CreateLabel(string text, int x, int y, bool visible = true)
        {
            return new Label
            {
                Location = new Point(x, y),
                Text = text,
                Font = new Font("Calibri", 16),
                AutoSize=true,
                Visible=visible
            };
        }
        public static Label CreateLabel2(string text, int x, int y,bool visible = true)
        {
            return new Label
            {
                Location = new Point(x, y),
                Text = text,
                Font = new Font("Calibri", 14),
                AutoSize = true,
                Visible=visible
            };
        }
        public static DataGridView CreateDataGridView(int x, int y)
        {
            return new DataGridView
            {
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeRows = false,
                AllowUserToResizeColumns = false,
                ColumnHeadersHeightSizeMode=DataGridViewColumnHeadersHeightSizeMode.AutoSize,
                Location=new Point(x,y),
                Name="clientDataGridView",
                RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders,
                RowTemplate = {Height=CC.TextBoxHeight-CC.Gap},
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
        }
        public static PictureBox CreatePictureBox(int x, int y)
        {
            return new PictureBox
            {
                Location = new Point(x, y),
                Name = "PhotoPictureBox",
                Size = new Size(CC.PictureBoxWidth, CC.PictureBoxHeight),
                TabIndex = 3,
                TabStop = false,
                BackColor = Color.Gray,
                SizeMode = PictureBoxSizeMode.CenterImage
            };
        }
        public static PictureBox CreatePictureBox2(int x, int y)
        {
            return new PictureBox
            {
                Location = new Point(x, y),
                Name = "PhotoPictureBox",
                Size = new Size(CC.PictureBoxWidth2, CC.PictureBoxHeight2),
                TabIndex = 3,
                TabStop = false,
                SizeMode = PictureBoxSizeMode.Zoom
            };
        }
        public static PictureBox CreatePictureBox3(int x, int y)
        {
            return new PictureBox
            {
                Location = new Point(x, y),
                Name = "PhotoPictureBox",
                Size = new Size(CC.PictureBoxWidth3, CC.PictureBoxHeight3),
                TabIndex = 3,
                TabStop = false,
                SizeMode = PictureBoxSizeMode.CenterImage
            };
        }
        public static PictureBox CreatePictureBoxSmall(int x, int y)
        {
            return new PictureBox
            {
                Location = new Point(x, y),
                Name = "PhotoPictureBox",
                Size = new Size(CC.PictureBoxWidth4, CC.PictureBoxHeight4),
                TabIndex = 3,
                TabStop = false,
                SizeMode = PictureBoxSizeMode.Zoom
            };
        }
        public static ComboBox CreateComboBox(int x, int y)
        {
            ComboBox comboBox = new ComboBox
            {
                Location = new Point(x, y),
                Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 204),
                FormattingEnabled = true,
                Name = "ClientComboBox",
                Size = new Size(CC.TextBoxWidth, CC.TextBoxHeight),
                TabIndex = 0,
            };

            List<int> modelIds = Gets.GetAllModelIds();
            comboBox.Items.AddRange(modelIds.Select(id => id.ToString()).ToArray());

            return comboBox;
        }
        public static ComboBox CreateComboBoxFabric(int x, int y)
        {
            ComboBox comboBox = new ComboBox
            {
                Location = new Point(x, y),
                Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 204),
                FormattingEnabled = true,
                Name = "ClientComboBox",
                Size = new Size(CC.TextBoxWidth, CC.TextBoxHeight),
                TabIndex = 0,
            };

            List<string> fabricNames = Gets.GetAllFabricNames();
            comboBox.Items.AddRange(fabricNames.Select(id => id.ToString()).ToArray());

            return comboBox;
        }
    }
}
