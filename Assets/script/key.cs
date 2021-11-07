using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class key : MonoBehaviour,IPointerClickHandler 
{
    public bool isChange;
    public KeyCode Key=KeyCode.None;
    public void OnPointerClick(PointerEventData eventData)
    {
            isChange = isChange?false: true;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.GetComponent<Text>().text = Key.ToString();
        if (player.isDefault)
        {
            Key = KeyCode.None;
        }
    }
    void OnGUI()
    {
        if (isChange)
        {
            if (Input.anyKeyDown)
            {
                player.isDefault = false;
                isChange = false;
                Key = Event.current.keyCode;
            }
        }
    }
}

