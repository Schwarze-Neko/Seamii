using UnityEngine;

public class Points : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Orange_Trash"))
        {
            GameManager.Instance.AddPoints(1); // Increase points via GameManager

            Destroy(other.gameObject); // Destroy trash
        }



        if (other.CompareTag("Red_Trash"))
        {
            GameManager.Instance.AddPoints(5); // Increase points via GameManager

            Destroy(other.gameObject); // Destroy trash
        }

        if (other.CompareTag("Yellow_Trash"))
        {
            GameManager.Instance.AddPoints(10); // Increase points via GameManager

            Destroy(other.gameObject); // Destroy trash
        }
    }
}



    

