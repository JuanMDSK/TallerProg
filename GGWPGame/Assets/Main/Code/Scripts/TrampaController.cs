using UnityEngine;

public class TrampaController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)

    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.RestarVida(1);
            //SceneManager.LoadScene(0);
        }
    }




    // Update is called once per frame
    void Update()
    {

    }
}
