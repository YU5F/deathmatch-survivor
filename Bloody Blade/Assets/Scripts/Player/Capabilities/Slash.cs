using UnityEngine;

public class Slash : MonoBehaviour
{
    [SerializeField] private inputController input = null;
    private bool isSlashing = false;
    private Animator slashAnim;
    [SerializeField] private GameObject sword;

    void Awake(){
        slashAnim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        isSlashing = input.retrieveSlashInput();
        
        if(isSlashing){
            sword.SetActive(true);
        }
    }
}
