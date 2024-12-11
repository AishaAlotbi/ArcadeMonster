using UnityEngine;

public class GunScript : MonoBehaviour
{
    public Transform crosshair;
    public float shootingCooldown = 0.75f;
    public float shootingRadius = 1f;
    public LayerMask targetLayer;
    public int pointsPerTarget = 10;

    private float cooldownTimer;
    private int score;

    public void Update()
    {
        // Synchronize crosshair with the mouse
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        crosshair.position = mousePosition;

        // Shooting logic
        if (Input.GetMouseButtonDown(0) && cooldownTimer <= 0)
        {
            Shoot(mousePosition);
            cooldownTimer = shootingCooldown;
        }

        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }
    }

    public void Shoot(Vector2 position)
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(position, shootingRadius, targetLayer);

        foreach (Collider2D hit in hits)
        {
            Destroy(hit.gameObject);
            score += pointsPerTarget;
            Debug.Log("Score: " + score);
        }
    }

    public void OnDrawGizmos()
    {
        if (Input.GetMouseButton(0))
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(crosshair.position, shootingRadius);
        }
    }

    public int GetScore()
    {
        return score;
    }
}
