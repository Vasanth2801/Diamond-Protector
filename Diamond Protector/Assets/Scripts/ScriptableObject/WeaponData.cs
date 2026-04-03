using UnityEngine;

[CreateAssetMenu(fileName = "New WeaponData", menuName = "Add Weapon")]
public class WeaponData : ScriptableObject
{
    public string weaponName;
    public int damage;
    public float fireRate;
    public int magazineSize;
    public GameObject bulletPrefab;
}
