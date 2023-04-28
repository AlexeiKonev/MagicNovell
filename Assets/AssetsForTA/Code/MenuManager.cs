using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject menuPanel;

    private void Start()
    {

    }
    public void SwitchMenu(bool state)
    {
        menuPanel.SetActive(state);
    }
    public void ExitGame()
    {
        Application.Quit();
    }

}
