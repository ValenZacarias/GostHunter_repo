using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //---------- Movement Variables ----------
    public bool canMove = true;
    public float horizontalMove;
    public float verticalMove;
    public float movementSpeed = 2.5f;
    public float rotationSpeed = 15f;
    public bool IsAttacking = false;

    //---------- Components Bindings ---------
    public CharacterController player;
    public Animator animator;
    public GameObject weaponObj;
    private WeaponController weapon;
    public Transform weapondEnd;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        weapon = weaponObj.GetComponent<WeaponController>();
        weapondEnd = transform.GetChild(2).transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove)
            this.Movement();

        this.Attack();
    }

    private void Movement()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        var movementVector = new Vector3(horizontalMove, 0, verticalMove) * movementSpeed * Time.deltaTime;
        player.Move(movementVector);

        animator.SetFloat("Speed", player.velocity.magnitude);

        this.Rotation(movementVector);
    }

    private void Rotation(Vector3 movementVector)
    {
        if(movementVector.magnitude == 0) return;   // Si la magnitud es 0 tiramos un return para que no se restartee la rotacion en Y a 0
        
        var rotation = Quaternion.LookRotation(movementVector);
        player.transform.rotation = Quaternion.RotateTowards(player.transform.rotation, rotation, rotationSpeed);
    }

    private void Attack()
    {
        if(Input.GetMouseButton(0))
        {
            animator.SetBool("IsAttacking", true);
            canMove = false;
            weapon.Damage(weapondEnd);
        }
        else
        {
            animator.SetBool("IsAttacking", false);
            canMove = true;
        }
    }
}
