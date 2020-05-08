using UnityEngine;
using System.Collections;

public class PlayerState
{
    //プレイヤーのステート
   public enum PlayerStates
    {
        PLAYER_IS_RUNNING,
        PLAYER_IS_JUMPING,
        PLAYER_IS_HIT_OBSTACLE,

        NUM
    }
}
