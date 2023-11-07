using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseSystem : MonoBehaviour
{
    public Text titleText;
    public ChooseButton[] buttons;
    
    private void Awake()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            int j = i;
            buttons[j].clickAction += () =>
            {
                if (chooseItems[j].chooseAction != "")
                {
                    GameController.Instance.SendMessage(chooseItems[j].chooseAction);
                }
                if (chooseItems[j].chooseAction2 != "")
                {
                    GameController.Instance.SendMessage(chooseItems[j].chooseAction2);
                }
                if (chooseItems[j].chooseEndLoadSay != "")
                {

                    PlotController.Instance.SetSay(GameController.Instance.plotSO.GetPlot(chooseItems[j].chooseEndLoadSay).plots);

                }
                gameObject.SetActive(false);
            };
        }
    }
    ChooseItem[] chooseItems;
    public void SetChoose(ChooseGame chooseGame)
    {
        gameObject.SetActive(true);
        titleText.text = chooseGame.titleContent;
        this.chooseItems = chooseGame.chooseItem;
        for (int i = 0; i < buttons.Length; i++)
        {
            if (i < chooseGame.chooseItem.Length)
            {
                buttons[i].gameObject.SetActive(true);
                buttons[i].SetText(chooseGame.chooseItem[i].name);
            }
            else
            {
                buttons[i].gameObject.SetActive(false);
            }
        }
    }
}
[System.Serializable]
public class ChooseGame
{
    [TextArea(4,8)]
    public string titleContent;
    public ChooseItem[] chooseItem;
    public string endAction;
}
[System.Serializable]
public class ChooseItem
{
    public string name;
    public string chooseAction;
    public string chooseAction2;
    
    public string chooseEndLoadSay;
}
