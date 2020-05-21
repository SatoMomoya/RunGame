using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreText : MonoBehaviour
{
    //プレイヤー
    public GameObject _player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.GetComponent<Text>().text = _player.GetComponent<PlayerMovementControl>().GetScoreInt.ToString();
    }
}
