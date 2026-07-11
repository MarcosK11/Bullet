using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    [SerializeField]
    private Weapon currentWeapon;

    public Weapon CurrentWeapon => currentWeapon;
}