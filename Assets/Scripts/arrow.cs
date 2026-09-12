using UnityEngine;

public class arrow : MonoBehaviour
{
    public float arrowspeed = 5f;

    private void Start()
    {
        Destroy(this.gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
     
    }
}
