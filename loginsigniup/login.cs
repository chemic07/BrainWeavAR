using UnityEngine;

public class RotateAroundOrigin : MonoBehaviour
{
    public float rotationSpeed = 30.0f; 
    
    //rotate speed
        
   
    void Update()
    {
      //axis
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
