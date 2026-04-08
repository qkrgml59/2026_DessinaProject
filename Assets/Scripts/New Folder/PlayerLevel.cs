using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    public int level = 1;
    public int currentXp = 0;
    public int xpToNextLevel = 5;

    public Sh autoShooter;

    public void AddXp(int amount)         //플레이어 경험치 시스템에 경험치 추가
    {
        currentXp += amount;

        Debug.Log("XP: " + currentXp + " / " + xpToNextLevel);

        if (currentXp >= xpToNextLevel)
        {
            LevelUp();
        }
    }

    void LevelUp()
    {
        level++;
        currentXp = 0;
        xpToNextLevel += 3;

        Debug.Log("Level Up! Current Level: " + level);

        if (autoShooter != null)
        {
            autoShooter.attackInterval = Mathf.Max(0.2f, autoShooter.attackInterval - 0.1f);
        }
    }
}