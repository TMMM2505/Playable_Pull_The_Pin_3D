using DG.Tweening;
using UnityEngine;

public class Wood : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbody1;
    [SerializeField] private Rigidbody rigidbody2;
    [SerializeField] private BoxCollider2D boxCollider;

    public void Broke(float force, Transform bomb)
    {
        boxCollider.enabled = false;
        if (rigidbody1 != null)
        {
            rigidbody1.isKinematic = false;
            rigidbody1.constraints = RigidbodyConstraints.None;
            rigidbody1.AddForce(
                (new Vector3(
                     (rigidbody1.gameObject.transform.position - bomb.position).normalized.x * Random.Range(.2f, .8f),
                     Random.Range(.2f, .5f), Random.Range(-3f, -1f)) * Random.Range(2f, 4f) +
                 (gameObject.transform.position - transform.position).normalized) * force * Random.Range(.1f, .5f));
            rigidbody1.AddTorque(Random.onUnitSphere * Random.Range(100f, 150f));
        }

        if (rigidbody2 != null)
        {
            rigidbody2.isKinematic = false;
            rigidbody2.constraints = RigidbodyConstraints.None;
            rigidbody2.AddForce(
                (new Vector3(
                     -(rigidbody2.gameObject.transform.position - bomb.position).normalized.x * Random.Range(.2f, .8f),
                     Random.Range(.2f, .5f), Random.Range(-3f, -1f)) * Random.Range(2f, 4f) +
                 (gameObject.transform.position - transform.position).normalized) * force * Random.Range(.1f, .5f));
            rigidbody2.AddTorque(Random.onUnitSphere * Random.Range(100f, 150f));
        }

        DOTween.Sequence().AppendInterval(3f).OnComplete(() => gameObject.SetActive(false));
    }
}