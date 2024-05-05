using System.Diagnostics.CodeAnalysis;

namespace IDZ.View.Controls
{
    public sealed class LabeledTextBox : TextBox
    {
        public string _label = string.Empty;
        public string? Label
        {
            get => _label;
            set
            {
                _label = value ?? string.Empty;
                if (string.IsNullOrEmpty(base.Text))
                {
                    base.Text = value;
                }
            }
        }
        [AllowNull]
        public override string Text
        {
            get => base.Text;
            set
            {
                if (string.IsNullOrEmpty(value))
                    base.Text = Label;
                else
                    base.Text = value;
            }
        }
    }
}
