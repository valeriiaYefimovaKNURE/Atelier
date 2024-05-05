using IDZ.View.Controls.ClientsPanels;
using IDZ.View.Controls.MainPanels;
using IDZ.View.Controls.Panels;

namespace IDZ.View.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new NavigationPanel();
            _defaultPanel = new Panel();
            _authorizationPanel = new AuthorizationPanel();
            _registrationPanel = new RegistrationPanel();
            _welcomePanel = new WelcomePanel();
            pictureBox1 = new PictureBox();
            _photoModelsPanel = new PhotoModelsPanel();
            _clientPanel = new ClientPanel();
            _sewerPanel = new SewerPanel();
            _fabricPanel = new FabricPanel();
            _modelsPanel = new ModelsPanel();
            _warePanel= new WarePanel();
            _clientsModels= new ClientsModels();
            _clientsOrderPanel = new ClientsOrderPanel(_clientsModels);
            _clientsFabricPanel = new ClientsFabricPanel();
            _orderPanel = new OrderPanel();
            _clientsRecommendPanel=new ClientsRecommendPanel();

            _welcomePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(141, 21, 24);
            panel1.Location = new Point(-1, -1);
            panel1.Name = "panel1";
            panel1.Size = new Size(1079, 69);
            panel1.TabIndex = 2;
            panel1.MoveToAuthorization += HidePanels;
            panel1.LogOutClick += HidePanels;
            panel1.MoveToRegistration += HidePanels;
            panel1.MoveToClientsClick += HidePanels;
            panel1.MoveToSewerClick += HidePanels;
            panel1.MoveToFabricClick += HidePanels;
            panel1.MoveToModelsClick += HidePanels;
            panel1.MoveToPhotoClick += HidePanels;
            panel1.MoveToHomeClick += HidePanels;
            panel1.MoveToWareClick += HidePanels;
            panel1.MoveToOrderClick += HidePanels;
            panel1.MoveToAuthorization += MoveToAuthorizationPanel;
            panel1.LogOutClick += MoveToWelcomePanel;
            panel1.MoveToRegistration += MoveToRegistrationPanel;
            panel1.MoveToClientsClick += MoveToClientsPanel;
            panel1.MoveToSewerClick += MoveToSewerPanel;
            panel1.MoveToFabricClick += MoveToFabricPanel;
            panel1.MoveToModelsClick += MoveToModelsAdminPanel;
            panel1.MoveToPhotoClick += MoveToPhotoPanel;
            panel1.MoveToHomeClick += MoveToWelcomePanel;
            panel1.MoveToWareClick += MoveToWarePanel;
            panel1.MoveToOrderClick += MoveToOrderPanel;
            // 
            // _defaultPanel
            // 
            _defaultPanel.Location = new Point(4, 74);
            _defaultPanel.Name = "_defaultPanel";
            _defaultPanel.Size = new Size(968, 584);
            _defaultPanel.TabIndex = 3;
            // 
            // _authorizationPanel
            // 
            _authorizationPanel.BackColor = Color.FromArgb(241, 233, 221);
            _authorizationPanel.Location = new Point(4, 74);
            _authorizationPanel.Name = "_authorizationPanel";
            _authorizationPanel.Size = new Size(1074, 689);
            _authorizationPanel.TabIndex = 3;
            _authorizationPanel.Visible = false;
            _authorizationPanel.LogIn += HidePanels;
            _authorizationPanel.MoveToHomeClick += HidePanels;
            _authorizationPanel.MoveToHomeClick += MoveToWelcomePanel;
            _authorizationPanel.LogIn += MoveToClientsPanel;
            _authorizationPanel.LogIn += panel1.OnLoggedIn;
            // 
            // _registrationPanel
            // 
            _registrationPanel.BackColor = Color.FromArgb(241, 233, 221);
            _registrationPanel.Location = new Point(4, 74);
            _registrationPanel.Name = "_registrationPanel";
            _registrationPanel.Size = new Size(1074, 689);
            _registrationPanel.TabIndex = 3;
            _registrationPanel.Visible = false;
            _registrationPanel.RegIn += HidePanels;
            _registrationPanel.MoveToHomeClick += HidePanels;
            _registrationPanel.RegIn += MoveToClientsPanel;
            _registrationPanel.MoveToHomeClick += MoveToWelcomePanel;
            _registrationPanel.RegIn += panel1.OnLoggedIn;
            // 
            // _welcomePanel
            // 
            _welcomePanel.BackColor = Color.FromArgb(241, 233, 221);
            _welcomePanel.Controls.Add(pictureBox1);
            _welcomePanel.Location = new Point(4, 74);
            _welcomePanel.Name = "_welcomePanel";
            _welcomePanel.Size = new Size(1074, 689);
            _welcomePanel.TabIndex = 3;
            _welcomePanel.MoveToModelsClick += HidePanels;
            _welcomePanel.MoveToRecClick += HidePanels;
            _welcomePanel.MoveToModelsClick += MoveToModels;
            _welcomePanel.MoveToRecClick += MoveToClientsRecommend;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources._3f11ad0969b53dc3ca4be1f7ea53763c;
            pictureBox1.Location = new Point(464, 232);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(142, 112);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // _photoModelsPanel
            // 
            _photoModelsPanel.BackColor = Color.FromArgb(241, 233, 221);
            _photoModelsPanel.Location = new Point(4, 74);
            _photoModelsPanel.Name = "_photoModelsPanel";
            _photoModelsPanel.Size = new Size(1074, 689);
            _photoModelsPanel.TabIndex = 3;
            _photoModelsPanel.Visible = false;
            _photoModelsPanel.UploadClick += _photoModelsPanel.UploadPhoto;
            // 
            // _clientPanel
            // 
            _clientPanel.BackColor = Color.FromArgb(241, 233, 221);
            _clientPanel.Location = new Point(4, 74);
            _clientPanel.Name = "_clientPanel";
            _clientPanel.Size = new Size(1074, 689);
            _clientPanel.TabIndex = 3;
            // 
            // _fabricPanel
            // 
            _fabricPanel.BackColor = Color.FromArgb(241, 233, 221);
            _fabricPanel.Location = new Point(4, 74);
            _fabricPanel.Name = "_fabricPanel";
            _fabricPanel.Size = new Size(1074, 689);
            _fabricPanel.TabIndex = 3;
            // 
            // _sewerPanel
            // 
            _sewerPanel.BackColor = Color.FromArgb(241, 233, 221);
            _sewerPanel.Location = new Point(4, 74);
            _sewerPanel.Name = "_sewerPanel";
            _sewerPanel.Size = new Size(1074, 689);
            _sewerPanel.TabIndex = 3;
            // 
            // _modelsPanel
            // 
            _modelsPanel.BackColor = Color.FromArgb(241, 233, 221);
            _modelsPanel.Location = new Point(4, 74);
            _modelsPanel.Name = "_modelsPanel";
            _modelsPanel.Size = new Size(1074, 689);
            _modelsPanel.TabIndex = 3;
            // 
            // _warePanel
            // 
            _warePanel.BackColor = Color.FromArgb(241, 233, 221);
            _warePanel.Location = new Point(4, 74);
            _warePanel.Name = "_warePanel";
            _warePanel.Size = new Size(1074, 689);
            _warePanel.TabIndex = 3;
            // 
            // _clientsModels
            // 
            _clientsModels.BackColor = Color.FromArgb(241, 233, 221);
            _clientsModels.Location = new Point(4, 74);
            _clientsModels.Name = "_clientsModels";
            _clientsModels.Size = new Size(1074, 689);
            _clientsModels.TabIndex = 3;
            _clientsModels.MoveToOrders += HidePanels;
            _clientsModels.MoveToOrders += MoveToClientsOrderPanel;
            _clientsModels.MoveToHomeClick += HidePanels;
            _clientsModels.MoveToHomeClick += MoveToWelcomePanel;
            // 
            // _clientsOrderPanel
            // 
            _clientsOrderPanel.BackColor = Color.FromArgb(241, 233, 221);
            _clientsOrderPanel.Location = new Point(4, 74);
            _clientsOrderPanel.Name = "_clientsOrderPanel";
            _clientsOrderPanel.Size = new Size(1074, 689);
            _clientsOrderPanel.TabIndex = 3;
            _clientsOrderPanel.MoveToBack += HidePanels;
            _clientsOrderPanel.MoveToBack += MoveToModels;
            _clientsOrderPanel.MoveToFabric += HidePanels;
            _clientsOrderPanel.MoveToFabric += MoveToFabricClientsPanel;
            // 
            // _clientsFabricPanel
            // 
            _clientsFabricPanel.BackColor = Color.FromArgb(241, 233, 221);
            _clientsFabricPanel.Location = new Point(4, 74);
            _clientsFabricPanel.Name = "_clientsFabricPanel";
            _clientsFabricPanel.Size = new Size(1074, 689);
            _clientsFabricPanel.TabIndex = 3;
            _clientsFabricPanel.MoveToModelClientsPanel += HidePanels;
            _clientsFabricPanel.MoveToModelClientsPanel += MoveToModels;
            _clientsFabricPanel.MoveToHomeClick += HidePanels;
            _clientsFabricPanel.MoveToHomeClick += MoveToWelcomePanel;
            // 
            // _orderPanel
            // 
            _orderPanel.BackColor = Color.FromArgb(241, 233, 221);
            _orderPanel.Location = new Point(4, 74);
            _orderPanel.Name = "_orderPanel";
            _orderPanel.Size = new Size(1074, 689);
            _orderPanel.TabIndex = 3;
            // 
            // _clientsRecommendPanel
            // 
            _clientsRecommendPanel.BackColor = Color.FromArgb(241, 233, 221);
            _clientsRecommendPanel.Location = new Point(4, 74);
            _clientsRecommendPanel.Name = "_clientsOrderPanel";
            _clientsRecommendPanel.Size = new Size(1074, 689);
            _clientsRecommendPanel.TabIndex = 3;
            _clientsRecommendPanel.MoveToHomeClick += HidePanels;
            _clientsRecommendPanel.MoveToModel += HidePanels;
            _clientsRecommendPanel.MoveToFabric += HidePanels;
            _clientsRecommendPanel.MoveToHomeClick += MoveToWelcomePanel;
            _clientsRecommendPanel.MoveToModel += MoveToModels;
            _clientsRecommendPanel.MoveToFabric += MoveToFabricClientsPanel;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 233, 221);
            ClientSize = new Size(1083, 769);
            Controls.Add(_welcomePanel);
            Controls.Add(_defaultPanel);
            Controls.Add(panel1);
            Controls.Add(_authorizationPanel);
            Controls.Add(_registrationPanel);
            Controls.Add(_photoModelsPanel);
            Controls.Add(_clientPanel);
            Controls.Add(_sewerPanel);
            Controls.Add(_modelsPanel);
            Controls.Add(_fabricPanel);
            Controls.Add(_photoModelsPanel);
            Controls.Add(_warePanel);
            Controls.Add(_clientsModels);
            Controls.Add(_clientsOrderPanel);
            Controls.Add(_clientsFabricPanel);
            Controls.Add(_clientsRecommendPanel);
            Controls.Add(_orderPanel);

            Name = "MainForm";
            Text = "Atelie";
            _welcomePanel.ResumeLayout(false);
            _welcomePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private NavigationPanel panel1;
        private Panel _defaultPanel;
        private AuthorizationPanel _authorizationPanel;
        private ClientPanel _clientPanel;
        private SewerPanel _sewerPanel;
        private RegistrationPanel _registrationPanel;
        private FabricPanel _fabricPanel;
        private WelcomePanel _welcomePanel;
        private PictureBox pictureBox1;
        private PhotoModelsPanel _photoModelsPanel;
        private ModelsPanel _modelsPanel;
        private WarePanel _warePanel;
        private ClientsModels _clientsModels;
        private ClientsOrderPanel _clientsOrderPanel;
        private ClientsFabricPanel _clientsFabricPanel;
        private OrderPanel _orderPanel;
        private ClientsRecommendPanel _clientsRecommendPanel;
    }
}