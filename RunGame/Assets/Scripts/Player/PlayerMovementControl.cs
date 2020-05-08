using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementControl : MonoBehaviour
{
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

    void Start()
    {
        _controller = GetComponent<CharacterController>();
        
    }

    void Update()
    {   
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
    /// プレイヤーが
    /// </summary>
    public void PlayerIsHitObstacle()
    {

    }
}
