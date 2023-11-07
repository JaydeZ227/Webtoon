using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagPage : MonoBehaviour
{
    bool isOpen = false;
    public void CloseOrOpenThis()
    {
        Debug.Log("����");
        if (isOpen)
        {
         
            Close();
        }
        else
        {
           
            Open();
        }
    }
    public Transform propParent;
    void Open()
    {
        isOpen = true;
        gameObject.SetActive(true);
        for (int i = 0; i < propParent.childCount; i++)
        {
            if (GameController.Instance.bagItemNameList.Contains(propParent.GetChild(i).GetComponent<PropIcon>().propName))
            {
                propParent.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                propParent.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
    void Close()
    {
        isOpen = false;
        gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
