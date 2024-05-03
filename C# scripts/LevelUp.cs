using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUp : MonoBehaviour
{
    private Player player;

    private void Start()
    {
        player = FindAnyObjectByType<Player>();
    }

    public void LevelUpHp()
    {
        if (player?.levelups > 0)
        {
            player?.LevelUpHp();
        }
    }

    public void LevelUpDmg()
    {
        if (player?.levelups > 0)
        {
            player?.LevelUpDmg();
        }
    }

    public void LevelUpAtkSpd()
    {
        if (player?.levelups > 0)
        {
            player?.LevelUpAtkSpd();
        }
    }

    public void LevelUpMoveSpd()
    {
        if (player?.levelups > 0)
        {
            player?.LevelUpMoveSpd();
        }
    }


}
