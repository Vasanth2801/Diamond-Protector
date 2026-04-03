using UnityEngine;

public class Bullet : MonoBehaviour
{
    WeaponData currentWeapon;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.SetActive(false);

        if(collision.gameObject.tag == "Player")
        {
            EnemyHealth eh = collision.gameObject.GetComponent<EnemyHealth>();
            if(eh != null)
            {
                eh.TakeDamage(currentWeapon.damage);
            }
        }
    }
}