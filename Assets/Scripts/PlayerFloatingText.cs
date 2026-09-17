using UnityEngine;

public class PlayerFloatingText : MonoBehaviour
{
   

    void Start()
    {
        Destroy(this.gameObject, 1.001f);
    }
}

