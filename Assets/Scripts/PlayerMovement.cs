using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;        //플레이어 이동 속도

    
    public float minX = -14f;              
    public float maxX = 14f;
    public float minZ = -14f;
    public float maxZ = 14f;

    private PlayerHealth1 playerHealth;

    private void Start()
    {
        playerHealth = GetComponent<PlayerHealth1>();
    }


    void Update()                    
    {
        if (playerHealth != null && playerHealth.IsDead) return;

        float x = Input.GetAxisRaw("Horizontal");         //좌우 
        float z = Input.GetAxisRaw("Vertical");           //앞뒤 
        

        Vector3 moveDir = new Vector3(x, 0f, z).normalized;
       

        Vector3 nextPosition = transform.position + moveDir * moveSpeed * Time.deltaTime;
        

        nextPosition.x = Mathf.Clamp(nextPosition.x, minX, maxX);
        nextPosition.z = Mathf.Clamp(nextPosition.z, minZ, maxZ);

        transform.position = nextPosition;    
        

        if (moveDir != Vector3.zero)
        {
            transform.forward = moveDir;
           
        }

    }
}


