using UnityEngine;

public class d : MonoBehaviour
{
    public int maxHp = 3;        //적의최대 체력
    public int currentHp;        //현재 체력

    public GameObject xpPrefab;   //죽을 때 떨어뜨릴 경험치 프리팹

    void Start()
    {
        currentHp = maxHp;
    }

    public void TakeDamage(int damage)        //적이 공격받았을 때 체력을 깎는 함수
    {
        currentHp -= damage;
        Debug.Log("맞았음");

        if (currentHp <= 0)
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
