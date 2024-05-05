using IDZ.Domain.Lists;
using IDZ.Domain.Model;
using IDZ.Domain.Order;
using IDZ.Domain.Recommend;
using IDZ.Persistense.Repositories;
using IDZ.View.Controls.Events;

namespace IDZ.View.Controls.ClientsPanels
{
    public class ClientsOrderPanel:Panel
    {
        private FRepository _fabricRepository;
        private PRepository _photoRepository;
        private ORepository _oRepository;
        private SRepository _sRepository;
        private RRepository _rRepository;
        private ListRepository _cRepository;

        private readonly Label _orderLabel;
        private readonly Label _nameLabel;
        private readonly Label _adressLabel;
        private readonly Label _numLabel;
        private readonly Label _sizeLabel;
        private readonly Label _modelLabel;
        private readonly Label _costLabel;
        private readonly Label _cost;
        private readonly Label _addCostLabel;
        private readonly Label _addCost;
        private readonly Label _expenseLabel;
        private readonly Label _expense;
        private readonly Label _fabricLabel;
        private readonly Label _fabricPriceLabel;
        private readonly Label _fabricPrice;
        private readonly Label _modelPriceLabel;
        private readonly Label _modelPrice;
        private readonly Label _totalPriceLabel;
        private readonly Label _totalPrice;

        private readonly TextBox _nameText;
        private readonly TextBox _adressText;
        private readonly TextBox _numText;
        private readonly TextBox _sizeText;
        private readonly ComboBox _fabricBox;

        private readonly Button _orderButton;
        private readonly Button _backButton;
        private readonly Button _fabricButton;

        private readonly PictureBox _picture;

        private decimal? a, b, c, total;
        private int idFabric;
        private int planTimeModel;

        public event EventHandler? MoveToBack
        {
            add => _backButton.Click += value;
            remove => _backButton.Click -= value;
        }
        public event EventHandler? MoveToFabric
        {
            add => _fabricButton.Click += value;
            remove => _fabricButton.Click -= value;
        }
        public event EventHandler? MoveToOrder
        {
            add => _orderButton.Click += value;
            remove => _orderButton.Click -= value;
        }
        public ClientsOrderPanel(ClientsModels clientsModels)
        {
            _fabricRepository = new FRepository();
            _photoRepository = new PRepository();

            _orderLabel = ControlsCreator.CreateLabel("Замовлення", CC.midX, CC.Gap);
            _nameLabel= ControlsCreator.CreateLabel2("ФІ0", 5*CC.Gap, 3*CC.Gap+CC.TextBoxHeight2);
            _adressLabel= ControlsCreator.CreateLabel2("Адреса", 5 * CC.Gap, 3 * CC.Gap + 2*CC.TextBoxHeight2);
            _numLabel= ControlsCreator.CreateLabel2("Номер телефона", 5 * CC.Gap, 3 * CC.Gap + 3 * CC.TextBoxHeight2);
            _sizeLabel= ControlsCreator.CreateLabel2("Розмір одягу", 15*CC.Gap+CC.TextBoxWidth2, 3 * CC.Gap + 3 * CC.TextBoxHeight2);

            _nameText = ControlsCreator.CreateTextBox2("фіо", 5 * CC.Gap+CC.ButtonWidth2, 3 * CC.Gap + CC.TextBoxHeight2);
            _adressText = ControlsCreator.CreateTextBox2("Адреса", 5 * CC.Gap + CC.ButtonWidth2, 3 * CC.Gap + 2 * CC.TextBoxHeight2);
            _numText = ControlsCreator.CreateTextBox("Номер телефона", 12 * CC.Gap + CC.ButtonWidth2, 3 * CC.Gap + 3 * CC.TextBoxHeight2);
            _sizeText = ControlsCreator.CreateTextBox("Розмір одягу", 17 * CC.Gap + CC.TextBoxWidth2 + CC.ButtonWidth2, 3 * CC.Gap + 3 * CC.TextBoxHeight2);

            _modelLabel = ControlsCreator.CreateLabel2("", 5 * CC.Gap, 3 * CC.Gap + 4 * CC.TextBoxHeight2);
            _costLabel= ControlsCreator.CreateLabel2("Ціна моделі:", 16 * CC.Gap + CC.ButtonWidth2, 3 * CC.Gap + 4 * CC.TextBoxHeight2);
            _cost = ControlsCreator.CreateLabel2("", 16 * CC.Gap + 2*CC.ButtonWidth2, 3 * CC.Gap + 4 * CC.TextBoxHeight2);

            _expenseLabel= ControlsCreator.CreateLabel2("Витрати тканини:", 15 * CC.Gap + 3 * CC.ButtonWidth2, 3 * CC.Gap + 4 * CC.TextBoxHeight2);
            _expense = ControlsCreator.CreateLabel2("", 22 * CC.Gap + 4 * CC.ButtonWidth2, 3 * CC.Gap + 4 * CC.TextBoxHeight2);

            _picture = ControlsCreator.CreatePictureBox(5 * CC.Gap, 3 * CC.Gap + 5 * CC.TextBoxHeight2);

            _fabricLabel= ControlsCreator.CreateLabel2("Оберіть тканину:", 8 * CC.Gap+CC.PictureBoxWidth, 3 * CC.Gap + 5 * CC.TextBoxHeight2);
            _fabricBox = ControlsCreator.CreateComboBoxFabric(8 * CC.Gap + CC.PictureBoxWidth, 3 * CC.Gap + 6 * CC.TextBoxHeight2);
            _fabricPriceLabel = ControlsCreator.CreateLabel2("Ціна тканини за метр: ", 8 * CC.Gap + CC.PictureBoxWidth, 3 * CC.Gap + 7 * CC.TextBoxHeight2);
            _fabricPrice= ControlsCreator.CreateLabel2("", 19 * CC.Gap + CC.PictureBoxWidth+CC.ButtonWidth2, 3 * CC.Gap + 7 * CC.TextBoxHeight2);
            _modelPriceLabel = ControlsCreator.CreateLabel2("Ціна моделі з тканиною: ", 8 * CC.Gap + CC.PictureBoxWidth, 3 * CC.Gap + 8 * CC.TextBoxHeight2);
            _modelPrice = ControlsCreator.CreateLabel2("", 22* CC.Gap + CC.PictureBoxWidth+ CC.ButtonWidth2, 3 * CC.Gap + 8 * CC.TextBoxHeight2);

            _addCostLabel = ControlsCreator.CreateLabel2("Додаткові витрати:", 8 * CC.Gap + CC.PictureBoxWidth, 3 * CC.Gap + 9 * CC.TextBoxHeight2);
            _addCost = ControlsCreator.CreateLabel2("", 34 * CC.Gap + CC.PictureBoxWidth, 3 * CC.Gap + 9 * CC.TextBoxHeight2);

            _totalPriceLabel = ControlsCreator.CreateLabel2("Повна ціна: ", 19 * CC.Gap + CC.PictureBoxWidth+CC.ButtonWidth3, 4 * CC.Gap + 10 * CC.TextBoxHeight2);
            _totalPrice= ControlsCreator.CreateLabel2("", 34 * CC.Gap + CC.PictureBoxWidth + CC.ButtonWidth3, 4 * CC.Gap + 10 * CC.TextBoxHeight2);

            _orderButton = ControlsCreator.CreateButton3("Замовити", 28 * CC.Gap + CC.PictureBoxWidth + CC.ButtonWidth3, 6 * CC.Gap + 11 * CC.TextBoxHeight2);
            _backButton= ControlsCreator.CreateButton3("Назад", 5 * CC.Gap, 6 * CC.Gap + 11 * CC.TextBoxHeight2);
            _fabricButton= ControlsCreator.CreateButton3("Тканини", 8 * CC.Gap+CC.ButtonWidth3, 6 * CC.Gap + 11 * CC.TextBoxHeight2);

            clientsModels.OrderButtonClick += OnOrderButtonClick;

            _fabricBox.SelectionChangeCommitted += ComboBoxSelectionChangeCommitted;

            _orderButton.Click += OrderCommitted;

            InitializeComponent();
        }
        private void InitializeComponent()
        {
            SuspendLayout();

            Controls.Add(_fabricBox);
            Controls.Add(_modelPrice);
            Controls.Add( _orderLabel );
            Controls.Add( _nameLabel );
            Controls.Add( _adressLabel );
            Controls.Add( _numLabel );
            Controls.Add( _sizeLabel );
            Controls.Add( _nameText );
            Controls.Add( _adressText );
            Controls.Add( _numText );
            Controls.Add( _sizeText );
            Controls.Add( _picture );
            Controls.Add(_modelLabel );
            Controls.Add(_cost);
            Controls.Add(_costLabel );
            Controls.Add(_expenseLabel);
            Controls.Add(_expense);
            Controls.Add(_addCostLabel);
            Controls.Add(_addCost);
            Controls.Add(_fabricLabel);
            Controls.Add( _modelPriceLabel );
            
            Controls.Add(_fabricPriceLabel );
            Controls.Add(_fabricPrice);

            Controls.Add(_totalPriceLabel);
            Controls.Add( _totalPrice);

            Controls.Add(_orderButton);
            Controls.Add(_backButton );
            Controls.Add( _fabricButton );

            ResumeLayout(false);
        }
        public void OnOrderButtonClick(object? sender, ModelEventArgs e)
        {
            var currentModel = e.CurrentModel;
            var photo = _photoRepository.GetPhoto(currentModel.Id_Model);

            if (photo != null)
            {
                _picture.Image = photo;
                _picture.Invalidate();
            }
            else
            {
                _picture.Image = null;
                MessageBox.Show("Фото не знайдено");
            }
            var id=e.CurrentModel.Id_Model;
            var cost = e.CurrentModel.CostModel;
            var addcost = e.CurrentModel.AdditionalCost;
            var expense = e.CurrentModel.ExpenseFabric;
            var time = e.CurrentModel.PlanTime;

            _modelLabel.Text = "Вибрана модель: N." + id;
            _cost.Text = cost.ToString();
            _addCost.Text = addcost.ToString();
            _expense.Text = expense.ToString();

            planTimeModel = Convert.ToInt32(time);
            a = cost;
            b = addcost;

            UpdateTotalPrice();
        }
        private void ComboBoxSelectionChangeCommitted(object sender, EventArgs e)
        {
            var selectedValue = _fabricBox.SelectedItem?.ToString();
            var fabric = _fabricRepository.GetByName(selectedValue);

            idFabric = fabric.Id_Fabric;

            if (fabric != null)
            {
                var costformeter = fabric.CostForMeter;
                _fabricPrice.Text = costformeter.ToString();
                _modelPrice.Text = (costformeter * Convert.ToDecimal(_expense.Text)).ToString();
                c = costformeter * Convert.ToDecimal(_expense.Text);
            }
            else
            {
                _fabricPrice.Text = "";
                c = null; 
            }

            UpdateTotalPrice();
        }
        private void UpdateTotalPrice()
        {
            total = (a ?? 0) + (b ?? 0) + (c ?? 0);
            _totalPrice.Text = Convert.ToString((a ?? 0) + (b ?? 0) + (c ?? 0))+" грн.";
        }
        private void OrderCommitted(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_nameText.Text) || string.IsNullOrWhiteSpace(_adressText.Text) || string.IsNullOrWhiteSpace(_numText.Text) || string.IsNullOrWhiteSpace(_sizeText.Text))
            {
                MessageBox.Show("Заповніть усі необхідні поля", "Увага", MessageBoxButtons.OK);
            }
            else
            {
                _sRepository = new SRepository();
                var sewer = _sRepository.GetAll();
                var leastLoadedSewer = sewer.OrderBy(s => s.Workload).FirstOrDefault();

                bool exist=false;
                int idModel = int.Parse(_modelLabel.Text.Split('.')[1]);

                if (leastLoadedSewer != null && leastLoadedSewer.Workload<10)
                {
                    _oRepository=new ORepository();
                    _rRepository=new RRepository();
                    _cRepository=new ListRepository();

                    if(_rRepository.Find(idFabric, idModel) != null)
                    {
                        exist= true;
                    }
                    if (exist == false)
                    {
                        var rec = new ToDoRecommend
                        {
                            Id_Fabric = idFabric,
                            Id_Model = idModel,
                            ExpenseForModel = c
                        };

                        _rRepository.Add(rec);
                    }
                    var client = _cRepository.Find(_nameText.Text, _numText.Text);

                    if (client == null)
                    {
                        client = new ToDoClient
                        {
                            NameClient = _nameText.Text,
                            AddressClient = _adressText.Text,
                            NumClient = _numText.Text,
                            Size = Convert.ToInt16(_sizeText.Text)
                        };
                        _cRepository.Add(client);
                    }
                    var order = new ToDoOrder
                    {
                        Id_Client = client.Id_Client,
                        Id_Model = idModel,
                        Id_Fabric = idFabric,
                        Id_Sewer = leastLoadedSewer.Id_Sewer,
                        DataTake = DateTime.Today,
                        DataDoPlan = DateTime.Today.AddDays(planTimeModel),
                        DataDoReal = null,
                        CostFabric = c,
                        CostOrder = total,
                        ExpenseFabricReal = null,
                        Ready = false
                    };

                    _oRepository.Add(order);

                    leastLoadedSewer.Workload++;
                    _sRepository.UpdateWork(leastLoadedSewer);

                    MessageBox.Show("Дякую за замовлення!");   
                }
                else
                {
                    MessageBox.Show("На жаль, зараз немає вільних кравчинь. Зробіть замовлення пізніше");
                }
            }
        }
    }
}
