using UnityEngine;
public class Movement : MonoBehaviour {
    
    [SerializeField] float movementSpeed = 10f;
    [SerializeField] private Animator animator = null;

    void Update() {
        float xDirection = Input.GetAxis("Horizontal");
        float yDirection = Input.GetAxis("Vertical");
        if(xDirection>0){
            animator.SetBool("walk right", true);
        }
        else{
            animator.SetBool("walk right", false);
        }
        if(xDirection<0){
            animator.SetBool("walk left", true);
        }
        else{
            animator.SetBool("walk left", false);
        }
        if(yDirection<0){
            animator.SetBool("walk down", true);
        }
        else{
            animator.SetBool("walk down", false);
        }
        if(yDirection>0){
            animator.SetBool("walk up", true);
        }
        else{
            animator.SetBool("walk up", false);
        }

        transform.Translate(Vector3.right * (xDirection * movementSpeed * Time.deltaTime));
        transform.Translate(Vector3.up * (yDirection * movementSpeed * Time.deltaTime));
    }
}

