using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class PlotRoleData : ScriptableObject
{
    public List<DialogContent> contents;//用于存储对话内容

 
}

[System.Serializable]//序列化
public class DialogContent
{
    //管理对话内容和三个角色是否显示的布尔
    public string dialogText;//剧情内容
    public int chara1Display;//1号角色
    public int chara2Display;
    public int chara3Display;
}
