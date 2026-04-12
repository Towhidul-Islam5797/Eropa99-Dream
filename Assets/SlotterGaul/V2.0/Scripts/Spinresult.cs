#region Sprint 1
namespace SlotterGaul.V2
{
    public class SpinResult
    {
        // grid[col][row] = the symbol that landed in that cell
        public SlotSymbol[][] grid;

        public SpinResult(int columns, int rows)
        {
            grid = new SlotSymbol[columns][];
            for (int col = 0; col < columns; col++)
            {
                grid[col] = new SlotSymbol[rows];
            }
        }
    }
}
#endregion
