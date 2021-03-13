using UnityEngine;
public class PlayerControl : MonoBehaviour
{
    public Transform explode;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0)) {     // Mouse clicked
            Vector2 mouseLoc = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mouseLoc, Vector2.zero);
            if (hit.collider != null) {
                Debug.Log("Hit something!" + hit.transform.gameObject.name);
                if (hit.transform.CompareTag("spaceship"))
                {
                    Transform exp = Instantiate(explode, mouseLoc, Quaternion.identity);
                    Destroy(hit.transform.gameObject);
                    Destroy(exp.gameObject, 3);
                }
            }
        }
    }
}
