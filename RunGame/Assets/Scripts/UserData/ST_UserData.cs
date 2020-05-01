using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ST_UserData
{
    //ユーザーの番号
    public string _userNumber;
    //ユーザーID
    public string _userID;
    //ユーザーネーム
    public string _userName;
    //ユーザーパスワード
    public string _userPassword;
    //ユーザーのハイスコア
    public float _userHighscore;
    //ユーザーが遊んだ回数
    public int _userPlaycount;
    //ユーザーの最終ログイン日
    public string _userLastloginDate;
}
