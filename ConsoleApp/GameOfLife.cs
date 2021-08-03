using System;

namespace ConsoleApp
{
    public class GameOfLife
    {
        private const char ALIVE = '*';
        private const char DEAD =  '.';

        public char[,] NextGeneration(char[,] inputGrid)
        {
            var rowsNumber = inputGrid.GetLength(0);
            var columnsNumber = inputGrid.GetLength(1);
            var outputGrid = new char[rowsNumber, columnsNumber];

            for (int XPosition = 0; XPosition < rowsNumber; XPosition++)
            {
                for (int YPosition = 0; YPosition < columnsNumber; YPosition++)
                {
                    outputGrid[XPosition, YPosition] = DetermineCellState(inputGrid, XPosition, YPosition);
                }
            }

            return outputGrid;
        }

        private char DetermineCellState(char[,] grid, int XPosition, int YPosition)
        {
            var currentCellState = grid[XPosition, YPosition];
            var numberOfNeighbours = GetNumberOfAliveNeighboars(grid, XPosition, YPosition);

            if (IsAlive(currentCellState) && numberOfNeighbours < 2)
            {
                return DEAD;
            }

            if (IsAlive(currentCellState) && numberOfNeighbours > 3)
            {
                return DEAD;
            }

            if (IsDead(currentCellState) && numberOfNeighbours == 3)
            {
                return ALIVE;
            }

            return currentCellState;
        }

        private int GetNumberOfAliveNeighboars(char[,] grid, int XPosition, int YPosition)
        {
            var result = 0;
            int xStart;
            int xEnd;
            int yStart;
            int yEnd;

            xStart = XPosition > 0 ? XPosition - 1 : XPosition;
            xEnd = XPosition < grid.GetUpperBound(0) ? XPosition + 1 : XPosition;
            yStart = YPosition > 0 ? YPosition - 1 : YPosition;
            yEnd = YPosition < grid.GetUpperBound(1) ? YPosition + 1 : YPosition;

            for (int currentX = xStart; currentX <= xEnd; currentX++)
            {
                for (int currentY = yStart; currentY <= yEnd; currentY++)
                {
                    var isSelf = IsSelf(XPosition, YPosition, currentX, currentY);
                    if (!isSelf && IsAlive(grid[currentX, currentY]))
                    {
                        result++;
                    }
                }
            }

            return result;
        }

        private bool IsSelf(int XPosition, int YPosition, int currentX, int currentY) 
        {
            return XPosition == currentX && YPosition == currentY;
        }

        private bool IsAlive(char cell)
        {
            return cell == ALIVE;
        }

        private bool IsDead(char cell)
        {
            return cell == DEAD;
        }
    }
}