using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConnectFourUI : MonoBehaviour
{
    public ConnectFour connectFour;
    public TMP_Text resultText;
    public GameObject slotPrefab;
    public Transform boardContainer;

    private GameObject[,] slots;

    void Start()
    {
        // Ensure ConnectFour script is assigned
        if (connectFour == null)
        {
            Debug.LogError("ConnectFour script not assigned!");
            return;
        }

        // Initialize UI
        InitializeBoard();
        InitializeButtons();
        UpdateResultText();
    }

    void InitializeBoard()
    {
        slots = new GameObject[connectFour.rowCount, connectFour.columnCount];

        for (int row = 0; row < connectFour.rowCount; row++)
        {
            for (int col = 0; col < connectFour.columnCount; col++)
            {
                GameObject slot = Instantiate(slotPrefab, new Vector3(col, -row, 0), Quaternion.identity);
                slot.transform.SetParent(boardContainer);
                slots[row, col] = slot;
            }
        }
    }

    void InitializeButtons()
    {
        for (int col = 0; col < connectFour.columnCount; col++)
        {
            int column = col; // Capture the current column in the closure
            Button button = CreateButton("Column " + (column + 1), transform, () => OnButtonClick(column));
        }
    }

    void OnButtonClick(int column)
    {
        int currentPlayer = 1; // Assuming two players: 1 and 2
        if (connectFour.MakeMove(column, currentPlayer))
        {
            UpdateSlots();
            UpdateResultText();

            // Check for a win
            if (connectFour.CheckForWin(currentPlayer))
            {
                resultText.text = "Player " + currentPlayer + " wins!";
                // You may want to add some additional logic here, like restarting the game.
            }
            else
            {
                // Switch player turn or perform other game-related logic
            }
        }
    }

    void UpdateSlots()
    {
        for (int row = 0; row < connectFour.rowCount; row++)
        {
            for (int col = 0; col < connectFour.columnCount; col++)
            {
                int player = connectFour.GetPlayerAt(row, col);
                Color color = (player == 1) ? Color.red : Color.yellow;
                Image slotImage = slots[row, col].GetComponent<Image>();
                slotImage.color = player == 0 ? Color.white : color;
            }
        }
    }

    void UpdateResultText()
    {
        resultText.text = "Current Player: " + (connectFour.CheckForWin(1) || connectFour.CheckForWin(2) ? "-" : "1");
    }

    Button CreateButton(string buttonText, Transform parent, UnityEngine.Events.UnityAction onClick)
    {
        GameObject buttonObject = new GameObject(buttonText);
        buttonObject.transform.SetParent(parent);
        Button button = buttonObject.AddComponent<Button>();
        Text text = buttonObject.AddComponent<Text>();

        // Set button text
        text.text = buttonText;

        // Set button onClick listener
        button.onClick.AddListener(onClick);

        return button;
    }
}
