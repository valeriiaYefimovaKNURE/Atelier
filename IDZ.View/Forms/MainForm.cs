using IDZ.View.Controls.Events;
using IDZ.View.Controls.Panels;

namespace IDZ.View.Forms
{
    public partial class MainForm : Form
    {
        private bool IsUserAuthenticated()
        {
            if (Cache.User == null)
            {
                return false;
            }
            else { return true; }
        }
        public MainForm()
        {
            InitializeComponent();

            _welcomePanel.Visible = true;
        }
        private void MoveToAuthorizationPanel(object sender, EventArgs args)
        {
            _authorizationPanel.Visible = true;
        }
        private void HidePanels(object sender, EventArgs args)
        {
            _welcomePanel.Visible = false;
            _authorizationPanel.Visible = false;
            _defaultPanel.Visible = false;
            _clientPanel.Visible = false;
            _sewerPanel.Visible = false;
            _fabricPanel.Visible = false;
            _registrationPanel.Visible = false;
            _photoModelsPanel.Visible = false;
            _modelsPanel.Visible = false;
            _warePanel.Visible = false;
            _clientsModels.Visible = false;
            _clientsOrderPanel.Visible = false;
            _clientsFabricPanel.Visible = false;
            _orderPanel.Visible = false;
            _clientsRecommendPanel.Visible = false;
        }
        private void MoveToClientsPanel(object sender, EventArgs e)
        {
            if (IsUserAuthenticated())
            {
                if (Cache.User.isAdmin)
                {
                    _clientPanel.Visible = true;
                }
                else
                {
                    _welcomePanel.Visible = true;
                }
            }
        }
        private void MoveToSewerPanel(object sender, EventArgs e)
        {
            _sewerPanel.Visible = true;
        }
        private void MoveToDefaultPanel(object sender, EventArgs e)
        {
            _defaultPanel.Visible = true;
        }
        private void MoveToRegistrationPanel(object sender, EventArgs e)
        {
            _registrationPanel.Visible = true;
        }
        private void MoveToFabricPanel(object sender, EventArgs e)
        {
            _fabricPanel.Visible = true;
        }
        private void MoveToModels(object sender, EventArgs e)
        {
            _clientsModels.Visible = true;
        }
        private void MoveToClientsRecommend(object sender, EventArgs e)
        {
            _clientsRecommendPanel.Visible = true;
        }
        private void MoveToWelcomePanel(object sender, EventArgs e)
        {
            _welcomePanel.Visible = true;
        }
        private void MoveToPhotoPanel(object sender, EventArgs e)
        {
            _photoModelsPanel.Visible = true;
        }
        private void MoveToModelsAdminPanel(object sender, EventArgs e)
        {
            _modelsPanel.Visible = true;
        }
        private void MoveToWarePanel(object sender, EventArgs e)
        {
            _warePanel.Visible = true;
        }
        private void MoveToClientsOrderPanel(object sender, EventArgs e)
        {
            if (IsUserAuthenticated())
            {
                _clientsOrderPanel.Visible = true;
            }
            else
            {
                MessageBox.Show("Для оформлення замовлення вам необхідно авторизуватись або зареєструватися.", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _authorizationPanel.Visible = true;
            }
        }
        private void MoveToFabricClientsPanel(object sender, EventArgs e)
        {
            _clientsFabricPanel.Visible = true;
        }
        private void MoveToOrderPanel(object sender, EventArgs e)
        {
            _orderPanel.Visible = true;
        }
    }
}
