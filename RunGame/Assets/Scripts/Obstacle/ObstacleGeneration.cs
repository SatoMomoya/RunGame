using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObstacleGeneration : MonoBehaviour
{
    //ゲーム情報
    GamePlay _gamePlay;
    //障害物
    [SerializeField]
    private GameObject[] _obstacles;
    //計測時間
    float _measurementTime = 0.0f;
    //調節時間
    [SerializeField]
    float _adjustmentTime = 1.0f;
    //時間加算
    float _addTime = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        //ゲームプレイ情報を取得
        _gamePlay = GamePlay.GetInstance();
        if(_adjustmentTime < 0.0f)
        {
            _adjustmentTime = 0.0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        GenerationObstacles();
    }

    /// <summary>
    /// 障害物を生成する関数
    /// </summary>
    public void GenerationObstacles()
    {
        _measurementTime += (_addTime *  Time.deltaTime) * _gamePlay._gameSpeed;

        //計測時間が障害物生成時間を超えた場合登録されている障害物オブジェクトをランダムで1つ生成する
        if (_measurementTime > _gamePlay._generationObstacleTime +  Random.Range(-_adjustmentTime, _adjustmentTime) )
        {
            int randnum = Random.Range(0, _obstacles.Length);
            GameObject go = Instantiate(_obstacles[randnum], this.transform.position, transform.rotation);
            _measurementTime = 0.0f;
        }
    }
}
