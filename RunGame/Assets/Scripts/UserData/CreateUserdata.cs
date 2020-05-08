using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CreateUserdata : MonoBehaviour
{
    UserData _userData = new UserData();

    /// <summary>
    /// 最初にユーザーデータを作成する
    /// </summary>
    private void Awake()
    {
        _userData._userNumber = "NULL";
        _userData._userID = "NULL";
        _userData._userName = "NULL";
        _userData._userPassword = "NULL";
        _userData._userHighscore = 0;
        _userData._userPlaycount = 0;
        _userData._userLastloginDate = "NULL";

        string json = JsonUtility.ToJson(_userData);
        Debug.Log(json);
        StreamWriter writer;

        writer = new StreamWriter(Application.streamingAssetsPath + "/UserData.json", false);
        writer.Write(json);
        writer.Flush();
        writer.Close();

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
