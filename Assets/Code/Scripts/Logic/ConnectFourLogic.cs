using UnityEngine;

public class ConnectFourLogic : MonoBehaviour
{
    public Transform columnDummy;
    public Transform table;

    void GenerateTable()
    {
        Transform obj = Instantiate(columnDummy);

    }
}

class ConnectFourBoard 
{
    private int rows = 7; //classic board
    private int columns = 6;

    private int timePerMove;
    private int timeLimit;

}
