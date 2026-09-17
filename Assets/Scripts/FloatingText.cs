using UnityEngine;

public class FloatingText : MonoBehaviour
{
    public TextMesh textMesh;

    void Start()
    {
                      
        float randomNumber = Random.Range(0, 101);
        textMesh.text = randomNumber.ToString();
        Destroy(this.gameObject, 1.001f);
    }
}
