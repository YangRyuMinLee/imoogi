using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Game game;
    public float interval = 1f;
    private float timer;
    [SerializeField] private TextMeshProUGUI dateText;

    private void Start()
    {
        // for test
        // ^ for test??? why are we testing? this isn't aperture!
        game = new Game();
        UpdateDateText();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if(timer >= interval){
            timer -= interval;
            game.Tick();
            UpdateDateText();
        }
    }


    private void UpdateDateText(){
        dateText.text = game.time.ToString();
    }
}
