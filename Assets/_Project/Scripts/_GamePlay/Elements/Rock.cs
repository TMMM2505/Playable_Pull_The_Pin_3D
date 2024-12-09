using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Rock : ObjectCircle, ILaser
{
    public ObjectCircle TinyRockPrefab;
    public float MinVelocity = 3f;

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bomb"))
        {
            if (Mathf.Abs(Rigidbody2D.velocity.x) > MinVelocity || Mathf.Abs(Rigidbody2D.velocity.y) > MinVelocity)
            {
                Bomb bomb = other.gameObject.GetComponent<Bomb>();
                if (bomb)
                {
                    bomb.Exploding();
                }
            }
        }
    }

    public void BeDestroy()
    {
        for (int i = 0; i < 12; i++)
        {
            ObjectCircle tinyRock = Instantiate(TinyRockPrefab, transform.position + (Vector3) Random.insideUnitCircle*.1f,
                quaternion.identity, LevelController.Instance.CurrentLevel.transform);
            tinyRock.Rigidbody2D.AddForce(300*Random.insideUnitCircle);
        }
        gameObject.SetActive(false);
    }

    public void InteractWithLaser()
    {
     
    }
}
