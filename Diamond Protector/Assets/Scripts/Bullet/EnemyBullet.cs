using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PlayerHealth ph = collision.gameObject.GetComponent<PlayerHealth>();
            if(ph != null)
            {
                ph.TakeDamage(10);
            }
        }

        if(collision.gameObject.tag == " Diamond")
        {
            Diamond diamond = collision.gameObject.GetComponent<Diamond>();
            if(diamond != null)
            {
                diamond.TakeDamage(10);
            }
        }

        gameObject.SetActive(false);
    }
}