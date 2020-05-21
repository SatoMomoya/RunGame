using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementControl : MonoBehaviour
{
    //ゲームプレイ情報  
    GamePlay _gamePlay;
    //プレイヤーの状態
    [SerializeField]
    private PlayerState.PlayerStates _playerState = PlayerState.PlayerStates.PLAYER_IS_RUNNING;

    //キャラクターコントローラー
    private CharacterController _controller;
    //ジャンプ方向
    private Vector3 _jumpDirection;
    //ジャンプパワー
    [SerializeField]
    private float _jumpPower = 10.0f;
    //重力
    [SerializeField]
    private float _gravity = 10.0f;
    //プレイヤーが障害物に当たったか確認するフラグ
    [SerializeField]
    private bool _isHitObstacle = false;
    //ノックバックスピード
    [SerializeField]
    private float _knockBackSpeed = -1.0f;
    //スコア(int)
    [SerializeField]
    private int _scoreInt = 0;
    //スコア(float)
    [SerializeField]
    private float _scoreFloat = 0.0f;
    //一秒間に得られるスコア
    [SerializeField]
    private float _scorePerSecond = 100.0f;

    void Start()
    {
        //ゲームプレイ情報を取得
        _gamePlay =  GamePlay.GetInstance();
        //キャラクターコントローラーを取得
        _controller = GetComponent<CharacterController>();
        
    }

    void Update()
    {   
        //衝突フラグがtrueならプレイヤー衝突状態に変更
        if(_isHitObstacle == true)
        {
            _playerState = PlayerState.PlayerStates.PLAYER_IS_HIT_OBSTACLE;
        }

        //プレイヤーが障害物に当たっていなければスコアを加算する
        if(_playerState != PlayerState.PlayerStates.PLAYER_IS_HIT_OBSTACLE)
        {
            _scoreFloat += Time.deltaTime * _scorePerSecond;
            _scoreInt = (int)_scoreFloat;
        }

        //プレイヤーの状態によって処理を変更する
        switch(_playerState)
        {
            case PlayerState.PlayerStates.PLAYER_IS_RUNNING : PlayerIsRunning(); break;
            case PlayerState.PlayerStates.PLAYER_IS_JUMPING : PlayerIsJumPing(); break;
            case PlayerState.PlayerStates.PLAYER_IS_HIT_OBSTACLE: PlayerIsHitObstacle(); break;
        }
        //重力計算
        _jumpDirection.y -= _gravity * Time.deltaTime;
        //プレイヤーを動かす処理
        _controller.Move(_jumpDirection * Time.deltaTime);

    }
    /// <summary>
    /// プレイヤーが走っている状態の関数
    /// </summary>
    public void PlayerIsRunning()
    {
        //地面についていたら走り状態に切り替える
        if (_controller.isGrounded)
        {
            //もし左クリックを押されたらジャンプ状態に切り替える
            if (Input.GetMouseButtonDown(0))
            {
                _playerState = PlayerState.PlayerStates.PLAYER_IS_JUMPING;
            }
        }
    }
    /// <summary>
    /// プレイヤーがジャンプしているの関数
    /// </summary>
    public void PlayerIsJumPing()
    {
        //ジャンプするベクトルの代入
        _jumpDirection.y = _jumpPower;
        //地面についていたら走り状態に切り替える
        if (_controller.isGrounded)
        {
            _playerState = PlayerState.PlayerStates.PLAYER_IS_RUNNING;
        }
    }
    /// <summary>
    /// プレイヤーが障害物に当たった時の関数
    /// </summary>
    public void PlayerIsHitObstacle()
    {
        if(_knockBackSpeed < 0.0f)
        {
            _knockBackSpeed += Time.deltaTime;
        }
        else
        {
            _knockBackSpeed = 0.0f;
        }

        _gamePlay._gameSpeed = _knockBackSpeed;
    }
    /// <summary>
    /// プレイヤーとの当たり判定
    /// </summary>
    /// <param name="other">オブジェクト</param>
    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Obstacle":
                _isHitObstacle = true;        //プレイヤーのステートを衝突状態に変更
                break;
            case "Coin":

                break;
          
        }

    }

    /// <summary>
    /// スコア(int)を取得するプロパティ
    /// </summary>
    public int GetScoreInt
    { 
        get { return _scoreInt; }
    }
    public float GetScoreFloat
    {
        get { return _scoreFloat; }
    }

}
