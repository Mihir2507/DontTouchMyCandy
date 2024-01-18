using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NEwMovements : MonoBehaviour, IDamagable, IShopCustomer {
    [Header("Movements")]
    [SerializeField]float moveSpeed;
    float attackMoveSpeed;
    float originalMoveSpeed;
    private bool isMoving;
    [SerializeField] private FixedJoystick fj;
    
    [SerializeField] float groundDrag;

    [Header("Ground Check")]
    [SerializeField] float playerHeight;
    [SerializeField] LayerMask whatIsGround;

    // [Header("Slope Check")]
    // [SerializeField] float maxSlopeAngle;
    // [SerializeField] RaycastHit slopeHit; 
    [SerializeField] float downVelocity;
    [Header("Enemy Check")]
    [SerializeField] LayerMask whatIsEnemy;
    [SerializeField] float attackRange;
    [SerializeField] float SightRange;
    [SerializeField]public bool enemyInAttackRange;
    [SerializeField]public float attackCoolDown;
    public bool enemyInSightRange;
    public bool isAttacking;
    private bool readyToAttack;
    private bool freezeMotionOnAttacking;
    [SerializeField] GameObject enemyObj;
    public bool grounded; 
    [SerializeField] float jumpForce;
    [SerializeField] float jumpCoolDown;
    [SerializeField] float airMultiplier;
    [SerializeField] float gravityScale;
    private bool readyToJump;
    public bool isJumping;

    [Header("Money")]
    [SerializeField] private CherriesCollision cherriesCollisionScript;
    private int availableMoney;
    [Header("Weapons")]
     Dictionary<string, GameObject> weaponDict = new Dictionary<string, GameObject>();
    [SerializeField] private GameObject currentSword;
    [SerializeField] private GameObject swaySword;
    [SerializeField] private GameObject champSword;
    [SerializeField] private GameObject currentShield;
    [SerializeField] private GameObject crudeShield;
    [SerializeField] private GameObject nailShield;
    [SerializeField] private GameObject champShield;

    [Header("Health")]
    [SerializeField]private HealthBarScript healthScript;
    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;
    private int damage;
    //[SerializeField] KeyCode jumpKeys = KeyCode.Space;
    [SerializeField]Transform orientation;

    
    private float horizontalInput;
    private float verticalInput;
    private Vector3 moveDir;

    Rigidbody rb;

    //[SerializeField] private Animator anim;

    private void Start() {
        rb = GetComponent<Rigidbody>();
        //anim = GetComponent<Animator>();
        rb.freezeRotation = true;
        readyToJump = true;
        isMoving = false;
        readyToAttack = true;
        isAttacking = false;
        freezeMotionOnAttacking = false;
        currentHealth = maxHealth;
        attackMoveSpeed = moveSpeed/2;
        originalMoveSpeed = moveSpeed;
        maxHealth = 100;
        currentHealth = maxHealth;
        healthScript.SetMaxHealth(maxHealth);
        damage = 2;
        AddToDict();
    }

    public void AddToDict(){
        // Dictionary<int, GameObject> weaponDict = new Dictionary<int, GameObject>
        // {
        //     { 1, swaySword },
        //     { 2, champSword },
        //     { 3, crudeShield },
        //     { 4, nailShield },
        //     { 5, champShield }
        // };
        weaponDict.Add("CURRENT SWORD", currentSword);
        weaponDict.Add("SWAY SWORD", swaySword);
        weaponDict.Add("CHAMP SWORD", champSword);
        weaponDict.Add("SHIELD CRUDE", crudeShield);
        weaponDict.Add("SHIELD NAIL", nailShield);
        weaponDict.Add("SHIELD CHAMP", champShield);
        weaponDict.Add("SHIELD CURRENT", currentShield);
    }
    private void Update() {
        // ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f , whatIsGround);
        enemyInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsEnemy);
        enemyInSightRange = Physics.CheckSphere(transform.position, SightRange, whatIsEnemy);

        MyInput();
        SpeedControl();

        // if(!enemyInAttackRange){
        //     isAttacking = false;
        // }

        // handle drag 
        if(grounded){
            rb.drag = groundDrag;
        }
        else
            rb.drag = 0;//0

    }

    private void FixedUpdate() {
        MovePlayer();
    }

    public void MyInput()
    {
        // horizontalInput = Input.GetAxisRaw("Horizontal");
        // verticalInput = Input.GetAxisRaw("Vertical");
        horizontalInput = fj.Horizontal;
        verticalInput = fj.Vertical;
        // readyToJump = false;
        // Jump();
        // Invoke(nameof(ResetJump), jumpCoolDown);

        // if(Input.GetKey(jumpKeys) && readyToJump && grounded)
        // {
        //     readyToJump = false;
        //     Jump();
        //     Invoke(nameof(ResetJump), jumpCoolDown);
        // }   
    }

    private void MovePlayer() //(1, 0, 0)
    {
        moveDir = orientation.forward * verticalInput + orientation.right * horizontalInput;
        // CHECKING IF THE PLAYER IS MOVING OR NOT
        if(moveDir == Vector3.zero)
            isMoving = false;
        else
            isMoving = true;
        
        if(enemyInSightRange){
            moveSpeed = attackMoveSpeed;
        }
        else
            moveSpeed = originalMoveSpeed;


        // on ground
        if(grounded && !freezeMotionOnAttacking)//
        {
            rb.AddForce(moveDir * moveSpeed * 10f, ForceMode.Force);
            
            //anim.SetBool("isWalking", true);
        }
        //in air
        else if(!grounded)
            rb.AddForce(moveDir * moveSpeed * airMultiplier *2.5f, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x , 0f, rb.velocity.z);
        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    public void Jump()
    {
        if(readyToJump && grounded){
            isJumping = true;
            readyToJump = false;
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
            rb.AddForce(-transform.up * gravityScale, ForceMode.Impulse);
            Invoke(nameof(ResetJump), jumpCoolDown);
    
        }
    }

    private void ResetJump()
    {
        isJumping = false;
        readyToJump = true;
    }
    // public void CheckEnemyInRange()
    // {
    //     if(enemyInAttackRange)
    //     {
    //         Debug.Log("Enemy in attack range");
    //         AttackEnemy();
    //     }
    // }

    // private bool OnSlope(){
    //     if(Physics.Raycast(transform.position, Vector3.down, out slopeHit, playerHeight * 0.5f + 0.3f)){
    //         float angle = Vector3.Angle(Vector3.up, slopeHit.normal);
    //         return angle < maxSlopeAngle && angle != 0;
    //     }
    //     return false;
    // }

    // private Vector3 GetSlopeMoveDirection(){
    //     return Vector3.ProjectOnPlane(moveDir, slopeHit.normal).normalized;
    // }
    public void AttackEnemy()
    {
        if(readyToAttack && grounded && !isMoving){//
            freezeMotionOnAttacking = true;
            isAttacking = true;
            readyToAttack = false;
            Invoke(nameof(ResetAttack), attackCoolDown);
            // Destroy(enemyObj);
        }
    }
    
    private void ResetAttack(){
        freezeMotionOnAttacking = false;
        isAttacking = false;
        readyToAttack = true;
        Debug.Log(isAttacking);
    }
    private void OnDrawGizmosSelected() {
        Vector3 gizmosPosition = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(gizmosPosition, attackRange);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(gizmosPosition, SightRange);
    }

    public void Damage()
    {
        currentHealth -= damage;
        healthScript.SetHealth(currentHealth);
        if(currentHealth <=0){
            Debug.Log("Player Died");
        }
    }

    // Buying Items From Shop
    public void BoughtItem(Items.ItemType itemType, string itemName){
        Debug.Log("Bought Item :" + itemType);
        // switch(weaponDict){
        //     default:
        //     case ():
        //         swaySword.SetActive(true);
        //         break;
        // }
        if(weaponDict.ContainsKey(itemName)){//(weaponDict.TryGetValue(itemName, out swaySword)){
            switch(itemName){
                default:
                case "SWAY SWORD":
                    currentSword.SetActive(false);
                    swaySword.SetActive(true);
                    currentSword = swaySword;
                    break;
                case "CHAMP SWORD":
                    currentSword.SetActive(false);
                    champSword.SetActive(true);
                    currentSword = champSword;
                    break;
                case "SHIELD CRUDE":
                    currentShield.SetActive(false);
                    crudeShield.SetActive(true);
                    Debug.Log("shield bought");
                    currentShield = crudeShield;
                    break;
                case "SHIELD NAIL":
                    currentShield.SetActive(false);
                    nailShield.SetActive(true);
                    currentShield = nailShield;
                    break;
                case "SHIELD CHAMP":
                    currentShield.SetActive(false);
                    champShield.SetActive(true);
                    currentShield = champShield;
                    break;
            }
            //swaySword.SetActive(true);
        }
    }

    public bool TryToSpendMoney(int itemMoneyAmount){
        // CherriesCollision cherriesCollisionScript = new CherriesCollision();
        availableMoney = cherriesCollisionScript.cherries;
        if(availableMoney >= itemMoneyAmount){
            Debug.Log("You can buy the item");
            //cherriesCollisionScript.cherries -= itemMoneyAmount;
            cherriesCollisionScript.OnItemBuy(availableMoney - itemMoneyAmount);
            return true;
        }
        else{
            Debug.Log("You dont have enough money");
            return false;
        }
    }
}
