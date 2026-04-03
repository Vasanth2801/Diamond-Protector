using UnityEngine;
using TMPro;

public class Shooting : MonoBehaviour
{
    [Header("Shooting Settings")]
    [SerializeField] private float bulletForce;

    [Header("Weapon Settings")]
    public WeaponData[] weapons;
    WeaponData currentWeapon;
    [SerializeField] private int currentWeaponIndex = 0;
    [SerializeField] private int currentMag;
    [SerializeField] private float nextTimeToFire;
    [SerializeField] private int[] ammoCount;

    [Header("References")]
    [SerializeField] private Transform firePoint;
    [SerializeField] private ObjectPooler pooler;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI weaponText;

    private void Start()
    {
        ammoCount = new int[weapons.Length];
        for(int i =0; i<weapons.Length; i++)
        {
            ammoCount[i] = weapons[i].magazineSize;
        }

        EquipWeapon(0);
    }

    void EquipWeapon(int index)
    {
        if(index < 0 || index >= weapons.Length)
        {
            return;
        }

        currentWeaponIndex = index;
        currentWeapon = weapons[index];
        currentMag = ammoCount[index];

        Debug.Log("Equipped " + currentWeapon.weaponName);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            EquipWeapon(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            EquipWeapon(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            EquipWeapon(2);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }

        UpdateUI();
    }

    void Shoot()
    {
        if(Time.time < nextTimeToFire)
        {
            return;
        }

        if (currentMag > 0)
        {
            GameObject bullet = pooler.SpawnFromPools(currentWeapon.bulletPrefab.name, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
            currentMag--;
            ammoCount[currentWeaponIndex] = currentMag;
            nextTimeToFire = Time.time + 1f / currentWeapon.fireRate;
        }
        else
        {
            Debug.Log("Out of ammo for " + currentWeapon.weaponName);
        }
    }

    void UpdateUI()
    {
        if(weaponText != null)
        {
            weaponText.text = $"Weapon: {currentWeapon.weaponName} \n" +
                              $"Ammo:  {currentMag}/{currentWeapon.magazineSize}";
        }
    }
}