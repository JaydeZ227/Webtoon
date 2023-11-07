using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    //public List<string> contents;//用于存储对话
    public int curLine;//对话内容的下标
    public UIPanel ui;
    public PlotRoleData plotRoleData;
    public PlotAssetConfig assetConfig;//切换图片的逻辑


    void Start()
    {
        Init();//调用初始化UI的方法
        LoadCharaSprite(assetConfig.chara1, assetConfig.chara2, assetConfig.chara3);
    }
    void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            ShowUI();//调用UI界面显示的方法
            LoadContent(plotRoleData.contents[curLine].dialogText, plotRoleData.contents[curLine].chara1Display, plotRoleData.contents[curLine].chara2Display, plotRoleData.contents[curLine].chara3Display);//加载剧情内容和三名玩家的透明度
        }

        if (Input.GetMouseButtonDown(0))
        {
            NextLine();//下标自增
            if(curLine >= plotRoleData.contents.Count)//如果下标大于等于数组的长度
            {
                curLine = plotRoleData.contents.Count;//把数组的长度赋值，防止越界
                Init();//初始化UI
            }
            LoadContent(plotRoleData.contents[curLine].dialogText, plotRoleData.contents[curLine].chara1Display, plotRoleData.contents[curLine].chara2Display, plotRoleData.contents[curLine].chara3Display);//加载剧情内容和三名玩家的透明度
        }

        if (Input.GetKeyDown("e"))
        {
            Init();
            plotRoleData = Resources.Load<PlotRoleData>("Story02");//读取故事2
        }
    }

    public void Init()
    {
        //初始化UI
        HideUI();//调用隐藏UI的方法
        curLine = 0;//文本下标清0
        LoadContent("", 0, 0, 0);//清空剧情文本内的内容
    }
        
    public void ShowUI()
    {
        //显示UI
        ui.ShowCanvas(true);//显示UI
    }

    public void HideUI()
    {
        //隐藏掉UI
        ui.ShowCanvas(false);//隐藏UI
    }
        
    public void NextLine()
    {
        //增加读取对话内容数组的下标

        curLine++;//下标自增
    }

    public void LoadContent(string value, int chara1Display, int chara2Display, int chara3Display)
    {
        //加载对话数据
        ui.SetText(value);//传递剧情文本
        ui.ShowRole1(chara1Display);//调用显示1号角色位置的方法
        ui.ShowRole2(chara2Display);//调用显示2号角色位置的方法
        ui.ShowRole3(chara3Display);//调用显示3号角色位置的方法
    }

    public void LoadCharaSprite(Sprite chara1Tex, Sprite chara2Tex, Sprite chara3Tex)
    {
        //更换123三个位置的图片的方法
        //调用UIPanel里切换图片的方法
        ui.ChangeRole1(chara1Tex);//更换1号角色图片
        ui.ChangeRole2(chara1Tex);//更换2号角色图片
        ui.ChangeRole3(chara1Tex);//更换3号角色图片
    }
}
