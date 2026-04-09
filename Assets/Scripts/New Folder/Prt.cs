using UnityEngine;

public class Prt : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float speed = 10f;
    public int damage = 1;
    public float lifeTime = 3f;      //몇초뒤 사라지게

    private Vector3 moveDirection;        //어느방향으로 갈지 외부에 설정

    void Start()
    {
       
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    public void SetDirection(Vector3 direction)
    {
        moveDirection = direction.normalized;

        if (moveDirection != Vector3.zero)
        {
            transform.forward = moveDirection;
        }
    }

    private void OnTriggerEnter(Collider other)             //적과 닿으면 데미지 주고 탄환 삭제
    {
        if (!other.CompareTag("Enemy")) return;

        d enemyHealth = other.GetComponent<d>();

        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}