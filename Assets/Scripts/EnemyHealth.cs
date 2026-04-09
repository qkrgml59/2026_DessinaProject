using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHp = 3;                 //적의 최대 체력
    public int currentHp;                 //현재 체력

    public GameObject xpPrefab;           //죽을 떄 떨어뜨릴 경험치
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHp = maxHp;
    }

    public void TakeDamage(int damage)
    {
        currentHp -= damage;
        Debug.Log("맞았음!");

        if(currentHp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (xpPrefab != null)
        {
            Instantiate(xpPrefab, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}
