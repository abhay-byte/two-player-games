using UnityEngine;

public class ConnectFour : MonoBehaviour
{
    public int rowCount = 7;
    public int columnCount = 8;

    private int[,] gameBoard;

    void Awake()
    {
        InitializeBoard();
    }

    void InitializeBoard()
    {
        gameBoard = new int[rowCount, columnCount];
    }

    public int GetPlayerAt(int row, int column)
    {
        if (row < 0 || row >= rowCount || column < 0 || column >= columnCount)
        {
            Debug.LogWarning("Invalid row or column index");
            return -1;
        }

        return gameBoard[row, column];
    }

    // Make a move in a specific column
    public bool MakeMove(int column, int player)
    {
        if (column < 0 || column >= columnCount)
        {
            Debug.LogWarning("Invalid column index");
            return false;
        }

        for (int row = rowCount - 1; row >= 0; row--)
        {
            if (gameBoard[row, column] == 0)
            {
                gameBoard[row, column] = player;
                return true;
            }
        }

        Debug.LogWarning("Column is full");
        return false;
    }

    // Check if the player has won
    public bool CheckForWin(int player)
    {
        // Check horizontally
        for (int row = 0; row < rowCount; row++)
        {
            for (int col = 0; col < columnCount - 3; col++)
            {
                if (gameBoard[row, col] == player && gameBoard[row, col + 1] == player && gameBoard[row, col + 2] == player && gameBoard[row, col + 3] == player)
                {
                    return true;
                }
            }
        }

        // Check vertically
        for (int row = 0; row < rowCount - 3; row++)
        {
            for (int col = 0; col < columnCount; col++)
            {
                if (gameBoard[row, col] == player && gameBoard[row + 1, col] == player && gameBoard[row + 2, col] == player && gameBoard[row + 3, col] == player)
                {
                    return true;
                }
            }
        }

        // Check diagonally (from bottom-left to top-right)
        for (int row = 0; row < rowCount - 3; row++)
        {
            for (int col = 0; col < columnCount - 3; col++)
            {
                if (gameBoard[row, col] == player && gameBoard[row + 1, col + 1] == player && gameBoard[row + 2, col + 2] == player && gameBoard[row + 3, col + 3] == player)
                {
                    return true;
                }
            }
        }

        // Check diagonally (from top-left to bottom-right)
        for (int row = 3; row < rowCount; row++)
        {
            for (int col = 0; col < columnCount - 3; col++)
            {
                if (gameBoard[row, col] == player && gameBoard[row - 1, col + 1] == player && gameBoard[row - 2, col + 2] == player && gameBoard[row - 3, col + 3] == player)
                {
                    return true;
                }
            }
        }

        return false;
    }
}
