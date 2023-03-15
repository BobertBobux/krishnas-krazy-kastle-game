using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerCharacter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    [SerializeField] private float playerSpeed = 5f;
    private Vector3 targetPosition;
    private float[] headingDirection = {0,0};
    private float direction;
    private float oldDirection = 0;
    public GameObject Projectile;
    
    public Vector3 projectileTarget()
    {
        Vector3 projectileAim = new Vector3();
        projectileAim = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        projectileAim.z = 0f;
        return projectileAim;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            
            projectileTarget();
            Instantiate(Projectile, transform.position, transform.rotation);
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.z = 0f;
        }
        if ((targetPosition != transform.position) && targetPosition!=null)
        {

            Vector3 targetDirection = targetPosition - transform.position;
            headingDirection[0] = targetDirection.x;
            headingDirection[1] = targetDirection.y;
            if (headingDirection[0] > headingDirection[1])
            {
                if (headingDirection[0] > 0)
                {
                    direction = 1f;
                }
                else
                {
                    direction = -1f;
                }
            }
            else
            { 
                if (headingDirection[1] > 0)
                {
                    direction= 3f;
                }
                else
                {
                    direction= -3f;
                }
            }


            /// Right and Up holds positive values; Determine the main direction whether its up down left or right and if the next direction of heading is in the direct opposite direction, slow down the player speed
            if(direction+oldDirection == 0f)
            {
                playerSpeed = 0f;
            }
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * playerSpeed);

            Debug.Log(targetDirection);
            Debug.Log(playerSpeed);

            oldDirection = direction;
            playerSpeed = 5f;
        }

    }
}
    

