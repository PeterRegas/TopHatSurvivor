using UnityEngine;
public class Movement : MonoBehaviour {
    
    public int movementSpeed = 4;
    [SerializeField] private Animator animator = null;
    public float xDirection;
    public float yDirection;
    public Rigidbody2D character;
     Vector2 PInput;
    
    void Update() {
        xDirection = Input.GetAxis("Horizontal");
        yDirection = Input.GetAxis("Vertical");
        PInput.x = Input.GetAxis("Horizontal");
        PInput.y = Input.GetAxis("Vertical");
        PInput.Normalize();
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
        
    }
    void FixedUpdate() {
        character.velocity = new Vector2(PInput.x * movementSpeed, PInput.y * movementSpeed);
    }
}

