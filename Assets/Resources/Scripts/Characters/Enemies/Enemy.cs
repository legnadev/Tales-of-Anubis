using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class Enemy : MonoBehaviour
{

    public float speed=1f;
    public Rigidbody2D rb;
    private float m_MaxSpeed = 10f; 

	[SerializeField] int m_hp = 5;
	public int hp{
		get {
			if (m_hp <= 0) {
				Death (gameObject);
			}
			return m_hp;
		}
		set{
			if (m_hp <= 0) {
				Death(gameObject);
			}
			m_hp = value;
		}
	}

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //rb.AddForce(transform.forward * speed);
		if (rb != null){
			rb.velocity = new Vector2(speed * m_MaxSpeed, rb.velocity.y);
		}
      
      
    }

	public void Flip()
	{
		// Multiply the x component of localScale by -1.
		Vector3 enemyScale = transform.localScale;
		enemyScale.x *= -1;
		transform.localScale = enemyScale;
	}

	public void applyDmg(int quantity){
		hp -= quantity;
	}

	void Death(GameObject go){
		Destroy(go);
	}
}
