using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagManagement : MonoBehaviour
{
    public GameObject myBag;
    private bool isOpen = false;

    private void Start()
    {
        myBag.SetActive(false);
    }

    public void ToggleBackpack()
    {
        isOpen = !isOpen;
        myBag.SetActive(isOpen);
    }
}