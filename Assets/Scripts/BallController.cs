using UnityEngine;
using Photon.Pun;

public class BallController : MonoBehaviour
{
    private Rigidbody2D rigidbodyBall;
    private bool setSpeed;
    [SerializeField] private float speedUp;
    private float xSpeed;
    private float ySpeed;

    private void Start()
    {
        rigidbodyBall = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            return;
        }
        if (GameController.instance.inPlay == true)
        { 
            if (!setSpeed)
            {
                setSpeed = true;

                xSpeed = Random.Range(1f, 3f) * (Random.Range(0, 2) * 2 - 1);
                ySpeed = Random.Range(1f, 3f) * (Random.Range(0, 2) * 2 - 1);
            }
            MoveBall();
        }
    }

    private void MoveBall()
    {
        rigidbodyBall.velocity = new Vector2(xSpeed, ySpeed);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Wall")
        {
            xSpeed *= -1;
        }

        if (other.transform.tag == "Paddle")
        {
            ySpeed *= -1;

            xSpeed += Mathf.Sign(xSpeed) * speedUp;
            ySpeed += Mathf.Sign(ySpeed) * speedUp;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "End1")
        {
            GameController.instance.score1++;
            GameController.instance.text1.text = "P1 : " + GameController.instance.score1.ToString();
            GameController.instance.inPlay = false;
            setSpeed = false;
            rigidbodyBall.velocity = Vector2.zero;
            this.transform.position = Vector2.zero;
        }
        else if (other.tag == "End2")
        {
            GameController.instance.score2++;
            GameController.instance.text2.text = "P2 : " + GameController.instance.score2.ToString();
            GameController.instance.inPlay = false;
            setSpeed = false;
            rigidbodyBall.velocity = Vector2.zero;
            this.transform.position = Vector2.zero;
        }
    }
}
