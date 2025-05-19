using UnityEngine;

public class KillOnTouch : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        GameObject root = other.gameObject.transform.root.gameObject;
        Debug.Log($"Is trigger ativado em {root.name} com tag {root.tag}");
        if (root.CompareTag("Enemy"))
        {
            Debug.Log("Inimigo encontrado");
            Destroy(other.transform.root.gameObject);
        }
    }
}
