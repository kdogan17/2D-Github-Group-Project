using UnityEngine;

// Allows weapons to be filled in with the inspector
[System.Serializable]
public class WeaponData
{
    public string name;
    public Sprite sprite;
}

public class weaponSkin : MonoBehaviour
{
    // Holds inspector entries
    public WeaponData[] weapons;
    public int currentIndex = 0;

    SpriteRenderer sr;
    CapsuleCollider2D col;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<CapsuleCollider2D>();
        Equip(currentIndex);
    }

    void Update()
    {
        // Keys to change weapons
        if (Input.GetKeyDown(KeyCode.Alpha1)) Equip(0);
        if (Input.GetKeyDown(KeyCode.Alpha2)) Equip(1);
        if (Input.GetKeyDown(KeyCode.Alpha3)) Equip(2);
        if (Input.GetKeyDown(KeyCode.Alpha4)) Equip(3);
    }

    public void Equip(int index)
    {
        if (index < 0 || index >= weapons.Length) return;

        currentIndex = index;
        WeaponData w = weapons[index];

        sr.sprite = w.sprite;
    }
}