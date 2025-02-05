using UnityEngine;
using UnityEngine.SceneManagement;
using Articy.Unity;


public class PlayerController : MonoBehaviour
{
  

    [SerializeField] private float speed = 4f;
    private bool isNearNPC = false;

    private Rigidbody playerRB;
    private DialogueManager dialogueManager;
    private ArticyObject availableDialogue;
 
    void Start()
    {
        playerRB = gameObject.GetComponent<Rigidbody>();
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    void Update()
    {
        PlayerInteraction();
    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }

    // Simple player movement
    void PlayerMovement()
    {
        // Remove movement control while in dialogue
        if (dialogueManager.DialogueActive)
            return;

        playerRB.velocity = new Vector3(Input.GetAxis("Horizontal") * speed, 0, Input.GetAxis("Vertical") * speed);
    }

    // All interactions and key inputs player can use
    void PlayerInteraction()
    {
        // Key option to start dialogue when near NPC
        if (Input.GetKeyDown(KeyCode.Space) && availableDialogue)
        {
            dialogueManager.StartDialogue(availableDialogue);
        }

        // Key option to abort dialogue
        if (dialogueManager.DialogueActive && Input.GetKeyDown(KeyCode.Escape))
        {
            dialogueManager.CloseDialogueBox();
        }

        // Key option to reset entire scene
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartScene();
        }
    }

    // Simple scene restart for testing purposes
    void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Trigger Enter/Exit used to determine if interaction with NPC is possible
    void OnTriggerEnter(Collider aOther)
    {
       //fetches the articyreference
        availableDialogue = aOther.GetComponent<ArticyReference>().reference.GetObject();

        var articyReferenceComp = aOther.GetComponent<ArticyReference>(); //reference to articy componenet

        //checks to see if there is dialogue attached to the object
        if (articyReferenceComp)
        {
            availableDialogue = articyReferenceComp.reference.GetObject();
        }
       
        
    }

    void OnTriggerExit(Collider aOther)
    {
        //clears the articy reference when you leave the trigger
        if (aOther.GetComponent<ArticyReference>() != null)
        {
            availableDialogue = null;

        }
    }
}
