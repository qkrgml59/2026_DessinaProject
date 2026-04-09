using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    public int level = 1;
    public int curretXp = 0;
    public int xpToNextLevel = 5;

    public AutoShooter autoShooter;
    
    public void Addxp(int amount)
    {
        curretXp += amount;

        Debug.Log("XP: " + curretXp + " / " + xpToNextLevel);

        if (curretXp <= xpToNextLevel)
        {
            LevelUP();
        }
    }

   
    void LevelUP()
    {
        level++;
        curretXp = 0;
        xpToNextLevel += 3;

        Debug.Log("Level Up! Current Level: " + level);

        if (autoShooter != null)
        {
            autoShooter.attackInterval = Mathf.Max(0.2f, autoShooter.attackInterval - 0.1f);
        }
    }
}
