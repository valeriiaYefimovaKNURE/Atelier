using IDZ.Domain.Abstract;
using IDZ.Domain.Fabric;
using IDZ.Domain.Lists;
using IDZ.Domain.Model;
using IDZ.Domain.Order;
using IDZ.Domain.Tasks;
using IDZ.Domain.WareHouse;
using IDZ.View.ViewModels.Clients;
using IDZ.View.ViewModels.Fabrics;
using IDZ.View.ViewModels.Model;
using IDZ.View.ViewModels.Order;
using IDZ.View.ViewModels.Recommend;
using IDZ.View.ViewModels.Sewer;
using IDZ.View.ViewModels.Warehous;
namespace IDZ.View.Controls.MainPanels
{
    public abstract class ModelPanel<TPov> : Panel where TPov : Pov
    {
        private readonly DataGridView _typeDataGridView;
        private readonly Button _saveButton;

        private readonly ClientsViewModels _clientViewModel;
        private readonly SewerViewModel _sewerViewModel;
        private readonly FabricsViewModel _fabricViewModel;
        private readonly ModelsViewModel _modelsViewModel;
        private readonly WarehouseViewModel _wareViewModel;
        private readonly OrderViewModel _orderViewModel;
        private readonly RecommendViewModel _recommendViewModel;
        
        public new Size Size
        {
            get => base.Size;
            set
            {
                base.Size = value;
                _typeDataGridView.Size = new Size(value.Width - CC.Gap * 2, value.Height - CC.Gap * 3 - _saveButton.Height);
                _saveButton.Location = new Point(value.Width - CC.Gap - CC.ButtonWidth3, value.Height - CC.Gap - CC.ButtonHeight3);
            }
        }
        public new bool Visible
        {
            get => base.Visible;
            set
            {
                base.Visible = value;
                if (_clientViewModel != null)
                {
                    _clientViewModel.UpdateGrid();
                }
                if (_sewerViewModel != null)
                {
                    _sewerViewModel.UpdateGrid();
                }
                if (_fabricViewModel != null)
                {
                    _fabricViewModel.UpdateGrid();
                }
                if (_modelsViewModel != null)
                {
                    _modelsViewModel.UpdateGrid();
                }
                if (_wareViewModel != null)
                {
                    _wareViewModel.UpdateGrid();
                }
                if (_orderViewModel != null)
                {
                    _orderViewModel.UpdateGrid();
                }
                if (_recommendViewModel != null)
                {
                    _recommendViewModel.UpdateGrid();
                }
            }
        }
        protected ModelPanel()
        {
            if (typeof(TPov) == typeof(ToDoClient))
            {
                _clientViewModel = new ClientsViewModels();
            }
            else if (typeof(TPov) == typeof(ToDoSewer))
            {
                _sewerViewModel = new SewerViewModel();
            }
            else if (typeof(TPov) == typeof(ToDoFabric))
            {
                _fabricViewModel = new FabricsViewModel();
            }
            else if (typeof(TPov) == typeof(ToDoModel))
            {
                _modelsViewModel = new ModelsViewModel();
            }
            else if (typeof(TPov) == typeof(ToDoWare))
            {
                _wareViewModel = new WarehouseViewModel();
            }
            else if (typeof(TPov) == typeof(ToDoOrder))
            {
                _orderViewModel = new OrderViewModel();
            }
            else if (typeof(TPov) == typeof(ToDoOrder))
            {
                _recommendViewModel = new RecommendViewModel();
            }

            _saveButton = ControlsCreator.CreateButton3("Save", Width - 2*CC.Gap - CC.ButtonWidth3, Height - CC.Gap - CC.ButtonHeight);
            _typeDataGridView = ControlsCreator.CreateDataGridView(CC.Gap, CC.Gap);

            _clientViewModel?.Initialize(_typeDataGridView, _saveButton);
            _sewerViewModel?.Initialize(_typeDataGridView, _saveButton);
            _fabricViewModel?.Initialize(_typeDataGridView, _saveButton);
            _modelsViewModel?.Initialize(_typeDataGridView, _saveButton);
            _wareViewModel?.Initialize(_typeDataGridView, _saveButton);
            _orderViewModel?.Initialize(_typeDataGridView, _saveButton);
            _recommendViewModel?.Initialize(_typeDataGridView, _saveButton);

            InitializeComponent();
        }
        private void InitializeComponent()
        {
            SuspendLayout();

            Controls.Add(_typeDataGridView);
            Controls.Add(_saveButton);

            ResumeLayout(false);
        }
    }
}
