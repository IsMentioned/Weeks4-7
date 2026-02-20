using UnityEngine;

public class DamageHazard : MonoBehaviour
{
    public Color damageColour;
    private Color playerColour;

    public int damage;
    public DungeonRaiderPlayer player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ApplyDamage()
    {
        player.TakeDamage(damage);
    }

    public void ChangePlayerColour()
    {
        SpriteRenderer playerRenderer = player.GetComponent<SpriteRenderer>();
        playerColour = playerRenderer.color;
        playerRenderer.color = damageColour;
    }

    public void ResetPlayerColour()
    {
        SpriteRenderer playerRenderer = player.GetComponent<SpriteRenderer>();
        playerRenderer.color = playerColour;
    }


}