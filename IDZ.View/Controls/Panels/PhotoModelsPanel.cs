using IDZ.Persistense.Repositories;
using IDZ.View.ViewModels.Photo;
using CC = IDZ.View.Controls.CC;

namespace IDZ.View.Controls.Panels
{
    public sealed class PhotoModelsPanel:Panel
    {
        private readonly DataGridView _typeDataGridView;
        private readonly Button _upload;
        private readonly PictureBox _picture;
        private readonly Label _label;
        private readonly Label _labelClients;
        private readonly TextBox _textBox;
        private readonly Button _saveButton;
        private readonly ComboBox _comboBox;

        private readonly PhotoViewModel _photoViewModel;
        private PViewModel _pVM;
        private PRepository _repository;
        
        public new bool Visible
        {
            get => base.Visible;
            set
            {
                base.Visible = value;
                if (_photoViewModel != null)
                {
                    _photoViewModel.UpdateGrid();
                }
            }
        }
        public event EventHandler? UploadClick
        {
            add => _upload.Click += value;
            remove => _upload.Click -= value;
        }
        public new Size Size
        {
            get => base.Size;
            set
            {
                base.Size = value;
                _typeDataGridView.Size = new Size(value.Width -4* CC.Gap-_saveButton.Width, value.Height - 5* CC.ButtonHeight2);
                _saveButton.Location = new Point(value.Width - CC.Gap - CC.ButtonWidth3, value.Height - CC.Gap - CC.ButtonHeight3);
            }
        }
        public PhotoModelsPanel()
        {
            _photoViewModel= new PhotoViewModel();

            _picture = ControlsCreator.CreatePictureBox(CC.Gap, CC.Gap);
            _labelClients = ControlsCreator.CreateLabel2("Оберіть модель:",4*CC.Gap+CC.PictureBoxWidth, 2*CC.Gap);
            _comboBox=ControlsCreator.CreateComboBox(4 * CC.Gap + CC.PictureBoxWidth, 2*CC.Gap+CC.TextBoxHeight);
            _label = ControlsCreator.CreateLabel("File name:", CC.Gap, 2 * CC.Gap + CC.PictureBoxHeight);
            _textBox = ControlsCreator.CreateTextBox2("", CC.Gap + CC.TextBoxWidth, 2 * CC.Gap + CC.PictureBoxHeight);
            _upload = ControlsCreator.CreateButton3("Upload", 2 * CC.Gap + CC.TextBoxWidth2 + CC.TextBoxWidth, CC.Gap + CC.PictureBoxHeight);
            _typeDataGridView = ControlsCreator.CreateDataGridView(CC.Gap, CC.PictureBoxHeight+CC.TextBoxHeight-CC.Gap);
            _saveButton = ControlsCreator.CreateButton3("Save", Width - CC.Gap - CC.ButtonWidth3, Height - CC.Gap - CC.ButtonHeight);

            _photoViewModel?.Initialize(_typeDataGridView, _saveButton);
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            SuspendLayout();

            Controls.Add(_typeDataGridView);
            Controls.Add(_upload);
            Controls.Add(_picture);
            Controls.Add(_label);
            Controls.Add(_textBox);
            Controls.Add(_saveButton);
            Controls.Add(_comboBox);
            Controls.Add(_labelClients);

            ResumeLayout(false);
        }
        public void UploadPhoto(object sender, EventArgs e)
        {
            _repository = new PRepository();
            _pVM = new PViewModel();
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Image files(*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png", Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _picture.Image = Image.FromFile(ofd.FileName);
                    _textBox.Text = ofd.FileName;
                    _repository.Insert(Convert.ToInt32(_comboBox.Text),_textBox.Text, _pVM.ConvertImageToString(_picture.Image));
                    _typeDataGridView.Update();
                }
            }
        }

    }
}
