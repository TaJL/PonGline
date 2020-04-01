using UnityEngine;
using Photon.Pun;

public class PaddleController : MonoBehaviour
{
    private PhotonView photonView;
    [SerializeField] private float limitHorizontal = 2;
    public string leftKey, rightKey;
    public float speed;

    private void Start()
    {
        photonView = GetComponent<PhotonView>();
        if (photonView.IsMine)
        {
            Camera.main.transform.rotation = transform.rotation;
        }
    }

    void Update()
    {
        if (!photonView.IsMine)
        {
            return;
        }
        PaddleMovement();
    }

    void PaddleMovement()
    {
        if (Input.GetKey(leftKey) && transform.position.x > -limitHorizontal)
        {
            transform.Translate(Vector2.left * Time.deltaTime * speed, Space.Self);
        }
        else if (Input.GetKey(rightKey) && transform.position.x < limitHorizontal)
        {
            transform.Translate(Vector2.right * Time.deltaTime * speed, Space.Self);
        }
    }
}
