#include <sstream>
#include <string>

/*
 * Builds a string from a matrix using a zig-zag row order
 * Even rows are read from left to right
 * Odd rows are read from right to left
 */

class MatrixStringFormatter
{

public:
	std::string Build(int* matrix, int numRows, int numColumns)
	{
		if (matrix == nullptr || numRows <= 0 || numColumns <= 0)
		{
			return "";
		}

		std::ostringstream outputBuilder;

		for (int row = 0; row < numRows; row++)
		{
			// Left to right
			if (row % 2 == 0)
			{
				for (int col = 0; col < numColumns; col++)
				{
					AppendValue(outputBuilder, matrix[row * numColumns + col]);
				}
			}
			// Right to left
			else
			{
				for (int col = numColumns - 1; col >= 0; col--)
				{
					AppendValue(outputBuilder, matrix[row * numColumns + col]);
				}
			}
		}

		std::string outputString = outputBuilder.str();

		// Remove the last ", "
		if (outputString.size() >= 2)
		{
			outputString.erase(outputString.size() - 2);
		}

		return outputString;
	}

private:
	void AppendValue(std::ostringstream& builder, int value)
	{
		builder << value << ", ";
	}

};