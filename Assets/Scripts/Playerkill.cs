using UnityEngine;

public class Playerkill : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
      if(other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
        }
    }
}
