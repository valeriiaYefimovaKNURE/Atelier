
namespace IDZ.View.Controls.Helpers
{
    public static class PositionCalculator
    {
        public static int CalculateY(int gap, params Control[] controlBefore)
        {
            return gap + controlBefore.Select(x => x.Height + gap).Sum();
        }
    }
}
