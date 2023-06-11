using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StickingArrowToSurface : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private SphereCollider myCollider;

    [SerializeField]
    private GameObject stickingArrow;

    [SerializeField]
    public GameObject targetA;
    private int scoreValue = 5; // Nilai skor yang diberikan saat panah mengenai target
    public TextMeshProUGUI scoreText; // Reference ke UI TextMeshProUGUI untuk menampilkan skor

    private void OnCollisionEnter(Collision collision)
    {
        rb.isKinematic = true;
        myCollider.isTrigger = true;

        GameObject arrow = Instantiate(stickingArrow);
        arrow.transform.position = transform.position;
        arrow.transform.forward = transform.forward;

        if (collision.collider.attachedRigidbody != targetA)
        {
            arrow.transform.parent = collision.collider.attachedRigidbody.transform;
        }

        collision.collider.GetComponent<IHittable>()?.GetHit();

        Destroy(gameObject);

        // Mengakses komponen ScoreManager dan menambahkan skor
        ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
        if (scoreManager != null)
        {
            scoreManager.AddScore(scoreValue);
        }
    }
}
