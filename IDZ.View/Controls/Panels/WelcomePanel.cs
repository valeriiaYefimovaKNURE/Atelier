
namespace IDZ.View.Controls.Panels
{
    public sealed class WelcomePanel:Panel
    {
        private readonly Label _Welcome;
        private readonly Button _rec;
        private readonly Button _models;

        public event EventHandler? MoveToModelsClick
        {
            add => _models.Click += value;
            remove => _models.Click -= value;
        }
        public event EventHandler? MoveToRecClick
        {
            add => _rec.Click += value;
            remove => _rec.Click -= value;
        }
        public new Size Size
        {
            get => base.Size;
            set
            {
                base.Size = value;
                _rec.Location = new Point(CC.Gap + CC.ButtonWidth, value.Height - CC.Gap - 3*CC.ButtonHeight);
                _models.Location = new Point(value.Width - CC.Gap - 3*CC.ButtonWidth, value.Height - CC.Gap - 3 * CC.ButtonHeight);
            }
        }
        public WelcomePanel()
        {
            BackColor = Color.FromArgb(241, 233, 221);
            _Welcome = ControlsCreator.CreateLabel("Вітаємо в ательє!", CC.midX-2*CC.Gap, CC.Gap+CC.ButtonHeight2);
            _rec = ControlsCreator.CreateButton2("Рекомендоване", Width - CC.Gap - CC.ButtonWidth, Height - CC.Gap-CC.ButtonHeight);
            _models = ControlsCreator.CreateButton2("Моделі", Width - CC.Gap, Height - CC.Gap);


            InitializeComponenet();
        }
        private void InitializeComponenet()
        {
            SuspendLayout();

            Controls.Add( _Welcome );
            Controls.Add( _rec );
            Controls.Add( _models );

            ResumeLayout();
        }
    }
}
