using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeKey : MonoBehaviour
{
    public GameObject UI;
    private bool click;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Open()
    {
        if (!click)
        {
            Time.timeScale = 0;
            UI.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            UI.SetActive(false);
        }
        click = click ? false:true ;
    }

    public void Default()
    {
        player.isDefault = true;
    }
}
