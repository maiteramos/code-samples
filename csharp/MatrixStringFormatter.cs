using System.Text;

/// <summary>
/// Builds a string from a matrix using a zig-zag row order
/// Even rows are read from left to right
/// Odd rows are read from right to left
/// </summary>

public class MatrixStringFormatter
{
    public string Build(int[,] matrix)
    {
        if (matrix == null || matrix.Length == 0)
        {
            return string.Empty;
        }

        int numRows = matrix.GetLength(0);
        int numColumns = matrix.GetLength(1);

        StringBuilder outputBuilder = new StringBuilder();

        for (int row = 0; row < numRows; row++)
        {
            // Left to right
            if (row % 2 == 0)
            {
                for (int col = 0; col < numColumns; col++)
                {
                    AppendValue(outputBuilder, matrix[row, col]);
                }
            }
            // Right to left
            else
            {
                for (int col = numColumns - 1; col >= 0; col--)
                {
                    AppendValue(outputBuilder, matrix[row, col]);
                }
            }
        }

        // Remove the last ", "
        if (outputBuilder.Length >= 2)
        {
            outputBuilder.Length -= 2;
        }

        return outputBuilder.ToString();
    }

    private void AppendValue(StringBuilder builder, int value)
    {
        builder.Append(value);
        builder.Append(", ");
    }
}