using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//障害物クラス
public class Obstacle : MonoBehaviour
{
    //ポジション
    private Vector3 _pos;
    //ベクトル
    [SerializeField]
    private Vector3 _vec;
    // Start is called before the first frame update
    void Start()
    {
        //ポジションの初期設定
        _pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //位置の計算
        _pos += _vec;
        transform.position = _pos;
    }
}
