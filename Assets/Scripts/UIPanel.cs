using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPanel : MonoBehaviour
{
    public CanvasGroup Role1;//Get the canvas group of character position 1_right.
    public CanvasGroup Role2;//Get the canvas group of character position 2_left.
    public CanvasGroup Role3;//Get the canvas group of character position 3_middle.

    public Image DiaLogImg;//Get dialog image.

    public Image BG1;//Get BG 1 and replace the background image.
    public Image BG2;//Get BG 2 and replace BG 1.

    public CanvasGroup BG1Group;//First background canvas.
    public CanvasGroup BG2Group;//Second background canvas.

    public Canvas canvas;//Get this canvas of itself.

    public Text TextList;//Dialogue text.

    public Text RoleText;//Text used to display the character's name.
    public Image RoleImg;//Get the background image of the character's name.

    public GameObject BtnA;//Get the A button.
    public GameObject BtnB;//Get the B button.
    public GameObject BtnC;//Get the C button.

    public float TargerSpeed = 2f;//Gradient speed of character display.
    public float Role1Alpha = 0;//The value of Alpha for character No. 1.
    public float Role2Alpha = 0;//The value of Alpha for character No. 2.
    public float Role3Alpha = 0;//The value of Alpha for character No. 3.

    void Update()
    {
        if (Input.GetKeyDown("a"))
        {
            ShowRole1(1);//Determine whether to show or hide the character at position 1.
            ShowRole2(0);//Determine whether to show or hide the character at position 2.
            ShowRole3(0);//Determine whether to show or hide the character at position 3.
        }

        if (Input.GetKeyDown("s"))
        {
            ShowRole1(0);
            ShowRole2(1);
            ShowRole3(0);
        }

        if (Input.GetKeyDown("d"))
        {
            ShowRole1(0);
            ShowRole2(0);
            ShowRole3(1);
        }

        //if (Input.GetKeyDown("c"))
        //{
        //SetText("testtesttesttesttesttesttesttesttesttest");
        //}

        //if (Input.GetKeyDown("d"))
        //{
        //SetRoleText(true, "BBBBBBB");
        //}

        //if (Input.GetKeyDown("e"))
        //{
        //SetRoleText(false, "C");
        //}

        #region Transparent gradient for character 1
        if (Role1.alpha != Role1Alpha)//If the transparency value of the canvas on character No. 1 is not equal to the transparency value we set manually.
        {
            Role1.alpha = Mathf.Lerp(Role1.alpha, Role1Alpha, TargerSpeed * Time.deltaTime);//The transparency value of character 1 uses lerp gradient to the alpha value we set.
            if(Mathf.Abs(Role1.alpha - Role1Alpha) < 0.1f)//If the absolute value of the character's transparency minus the transparency value we set is less than 0.1.
            {
                Role1.alpha = Role1Alpha;//Set the target's transparency value to character 1's transparency value.
            }
        
        }
        #endregion

        #region Transparent gradient for character 2
        if (Role2.alpha != Role2Alpha)//If the transparency value of the canvas on character No. 2 is not equal to the transparency value we set manually.
        {
            Role2.alpha = Mathf.Lerp(Role2.alpha, Role2Alpha, TargerSpeed * Time.deltaTime);//The transparency value of character 2 uses lerp gradient to the alpha value we set.
            if (Mathf.Abs(Role2.alpha - Role2Alpha) < 0.1f)//If the absolute value of the character's transparency minus the transparency value we set is less than 0.1.
            {
                Role2.alpha = Role2Alpha;//Set the target's transparency value to character 2's transparency value.
            }

        }
        #endregion

        #region Transparent gradient for character 3
        if (Role3.alpha != Role3Alpha)//If the transparency value of the canvas on character No. 3 is not equal to the transparency value we set manually.
        {
            Role3.alpha = Mathf.Lerp(Role3.alpha, Role3Alpha, TargerSpeed * Time.deltaTime);//The transparency value of character 3 uses lerp gradient to the alpha value we set.
            if (Mathf.Abs(Role3.alpha - Role3Alpha) < 0.1f)//If the absolute value of the character's transparency minus the transparency value we set is less than 0.1.
            {
                Role3.alpha = Role3Alpha;//Set the target's transparency value to character 3's transparency value.
            }

        }
        #endregion

    }

    #region Determine whether the RoleImage at position 123 is displayed or hidden
    public void ShowRole1(int value)//value only accepts 0 or 1
    {
        //Determine whether to display the image of character No. 1
        Role1Alpha = value;//Copy the received value to the transparency of image position No. 1
    }
    public void ShowRole2(int value)//value only accepts 0 or 1
    {
        //Determine whether to display the image of character No. 2
        Role2Alpha = value;//Copy the received value to the transparency of image position No. 2
    }
    public void ShowRole3(int value)//value only accepts 0 or 1
    {
        //Determine whether to display the image of character No. 3
        Role3Alpha = value;//Copy the received value to the transparency of image position No. 3
    }
    #endregion 


    public void ShowCanvas(bool value)
    {
        //Determine whether to show or hide the current canvas.
        canvas.enabled = value;//Assign the value passed in to the enable of the current plot canvas.
    }

    public void SetText(string value)
    {
        //Assign a value to the dialogue text.

        TextList.text = value;//Pass the received string to the plot text.
    }

    public void SetRoleText(bool isShow, string value)
    //The first Boolean is the background image to determine whether to display the character's name, and the second string is the character's name to be displayed.
    {
        //Determine whether to display the character's name. If so, set the character's name.
        if(isShow)
        {
            //If need to display the character's name.
            RoleImg.gameObject .SetActive(true);//Display the background image with the character's name.
            RoleText.text = value;//Assign a value to the character name passed in.
        }
        else
        {
            //If the character's name and background image are not displayed.
            RoleImg.gameObject .SetActive(false);//Hide background image of character's name.
        }
    }

    public void ShowBtnList(bool value, bool A, bool B, bool C)
    {
        //Show or hide buttons.
        BtnA.SetActive(value);//Determine whether the current button is hidden or displayed.
        BtnB.SetActive(value);
        BtnC.SetActive(value);

        BtnA.SetActive(A);//Determine whether the current button should be displayed or hidden in the current plot.
        BtnB.SetActive(B);
        BtnC.SetActive(C);
    }

    public void ChangeRole1(Sprite img)
    {
        //更换1号角色位置的图片
        Role1.GetComponent<Image>().sprite = img;//把传递进来的图片添加到1号位置
    }

    public void ChangeRole2(Sprite img)
    {
        //更换2号角色位置的图片
        Role2.GetComponent<Image>().sprite = img;//把传递进来的图片添加到2号位置
    }

    public void ChangeRole3(Sprite img)
    {
        //更换3号角色位置的图片
        Role3.GetComponent<Image>().sprite = img;//把传递进来的图片添加到3号位置
    }
}
