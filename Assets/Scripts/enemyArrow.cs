using UnityEngine;

public class enemyArrow : MonoBehaviour
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
