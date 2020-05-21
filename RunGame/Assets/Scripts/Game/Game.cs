using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//ゲーム関連の変数を管理しているシングルトンクラス
public sealed class GamePlay
{
    private static GamePlay _game = new GamePlay();
    //ゲーム速度
    public float _gameSpeed = 1.0f;
    //生成スパン
    [SerializeField]
    public float _generationObstacleTime = 5.0f;
    //
    /// <summary>
    /// コンストラクタ
    /// </summary>
    private GamePlay()
    {

    }
    /// <summary>
    /// インスタンス関数
    /// </summary>
    /// <returns>_game</returns>
    public static GamePlay GetInstance()
    {
        return _game;
    }

}
