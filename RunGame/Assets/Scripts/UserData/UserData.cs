using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public sealed class UserData
{
    private static UserData _userData = new UserData();

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
    /// <summary>
    /// コンストラクタ
    /// </summary>
    private UserData()
    {

    }
    /// <summary>
    /// インスタンス関数
    /// </summary>
    /// <returns>_userData</returns>
    public static UserData GetInstance()
    {
        return _userData;
    }

}
