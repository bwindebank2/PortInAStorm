using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    [SerializeField] GameObject gun;

    private void Start()
    {
        SwapWeapon(1);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            SwapWeapon(1);
        }

        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            SwapWeapon(2);
        }
    }

    /// <summary>
    /// Changes the current weapon based on the input.
    /// 1 is no weapon.
    /// 2 is gun.
    /// </summary>
    /// <param name="selection"></param>
    void SwapWeapon(int selection)
    {
        var player = FindObjectOfType<Player>();
        switch (selection)
        {
            case 1:
                gun.SetActive(false);
                player.isGunHeld = false;
                break;
            case 2:
                gun.SetActive(true);
                player.isGunHeld = true;
                break;
        }
    }
}
