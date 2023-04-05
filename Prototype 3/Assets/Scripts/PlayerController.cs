using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    private AudioSource playerAudio;
    private GameManager gameManagerScript;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public float jumpForce = 10;
    public float gravityModifier;
    public bool isOnGround = true;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();

        SetGravity(gravityModifier);

        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameManagerScript.isGameOver)
        {
            // Physics
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            // States
            isOnGround = false;

            // Animations
            playerAnim.SetTrigger("Jump_trig");

            // Particles
            dirtParticle.Stop();

            // Audios
            playerAudio.PlayOneShot(jumpSound);
        }

        if (Input.GetKeyDown(KeyCode.R) && gameManagerScript.isGameOver)
        {
            gameManagerScript.RestartGame();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;

            if (!gameManagerScript.isGameOver)
            {
                dirtParticle.Play();
            }
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameManagerScript.isGameOver = true;
            playerAnim.SetBool("Death_b", true);

            int animationType = Random.Range(1, 3);
            playerAnim.SetInteger("DeathType_int", animationType);

            explosionParticle.Play();
            dirtParticle.Stop();

            playerAudio.PlayOneShot(crashSound);

            Debug.Log("Game Over!");
        }
        else if (collision.gameObject.CompareTag("Scorewall"))
        {
            gameManagerScript.IncrementObstaclesPassed();
            Debug.Log($"Score: {gameManagerScript.Score}");
        }}

    private void SetGravity(float gravityModifier = 1)
    {
        Physics.gravity = Vector3.up * -9.81f * gravityModifier;
    }
}
