using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GUIController : MonoBehaviour
{
    public CellGrid CellGrid;
    public Text TurnName;
    public Text UnitSelectedText;
    public Text UnitNameText;
	
    void Awake()
    { 
        CellGrid.LevelLoading += onLevelLoading;
        CellGrid.LevelLoadingDone += onLevelLoadingDone;
        TurnName.text = "Human";
    }

    private void onLevelLoading(object sender, EventArgs e)
    {
        Debug.Log("Level is loading");
    }

    private void onLevelLoadingDone(object sender, EventArgs e)
    {
        Debug.Log("Level loading done");
        Debug.Log("Press 'n' to end turn");
    }

    void Update ()
    {
        if(Input.GetKeyDown(KeyCode.N))
        {
            CellGrid.EndTurn();//User ends his turn by pressing "n" on keyboard.
            SwapTurnName();
        }
	}

    private void SwapTurnName()
    {
        if (TurnName.text.Equals("Human"))
            TurnName.text = "Monster";
        else
            TurnName.text = "Human";
        UnitSelectedText.text = "none";
        UnitNameText.text = "none";
        UnitNameText.color = Color.white;

    }

    public void EndTurnByButton()
    {
        CellGrid.EndTurn();
        SwapTurnName();
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Scenes/TeamCompScene");
    }
}
