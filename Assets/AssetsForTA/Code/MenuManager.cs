using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
 public  GameObject menuPanel;

 private void Start() {
       
 }
    public void SwitchMenu(bool state)
    {
        menuPanel.SetActive(state);
    }

}
