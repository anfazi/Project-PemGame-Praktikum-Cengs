using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //energy dipakai format image
using UnityEngine.SceneManagement;

public class HUDManager : MonoBehaviour
{
    //hud gameover
    [SerializeField] GameObject GameOverMenu;
    [SerializeField] GameObject information;
    string info;
    //---------
    [SerializeField] GameObject pauseMenu;
    public static bool GameIsPaused = false;
    public Player playerInstance;
    //clock
    public Text time;
    //-----
    //energy
    public Image currentEnergy;
    private GameObject player;
    private float energy = 200;
    private float maxEnergy = 200;
    private float kecepatan;
    private float kecepatanLari;
    private float input_x;
    private float input_z;
    //-----

    //hud darah
    private float darah;
    private float maxDarah = 100f;
    public Image currentdarah;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        kecepatanLari = player.GetComponent<Gerakan_Player>().speed_lari;

        //restart
        GameIsPaused = false;
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        kecepatan = player.GetComponent<Gerakan_Player>().kecepatan;
        input_x = player.GetComponent<Gerakan_Player>().x;
        input_z = player.GetComponent<Gerakan_Player>().z;
        darah = player.GetComponent<sistem_Darah>().darah_player;

        EnergyDrain();
        UpdateEnergy();
        UpdateTime();
        ShowPauseMenu();
        UpdateDarah();

        gameOver();
        //info
        info = player.GetComponent<sistem_Darah>().info;

        Text pesan = information.GetComponent<Text>();
        pesan.text = info;
        
    }

    private void EnergyDrain(){
        if(kecepatan == kecepatanLari) {
            if(input_x > 0 || input_z > 0){
                if(energy > 0){
                    energy -= 10 * Time.deltaTime;
                }
            }
        }else{
            if(energy < maxEnergy ){
                energy += 15 * Time.deltaTime;
            }
        }
        UpdateEnergy();
    }

    private void UpdateEnergy(){
        float ratio = energy / maxEnergy;

        currentEnergy.rectTransform.localScale = new Vector3(ratio, 1, 1);
    }

    private void UpdateTime(){
        int hours = EnviroSky.instance.GameTime.Hours;
        int minutes = EnviroSky.instance.GameTime.Minutes;

        string gameHours;
        string gameMinutes;

        if(hours >= 0 && hours < 10){
            gameHours = "0" + hours.ToString();
        }
        else{
            gameHours = hours.ToString();
        }
        if(minutes >= 0 && minutes < 10){
            gameMinutes = "0" + minutes.ToString();
        }
        else{
            gameMinutes = minutes.ToString();
        }
        time.text = gameHours + " : " + gameMinutes;
    }

    private void ShowPauseMenu(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(GameIsPaused){
                Resume();
            }
            else{
                Pause();
            }
        }
    }

    public void Resume(){
        pauseMenu.SetActive(false);
        GameIsPaused = false;
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Pause(){
        pauseMenu.SetActive(true);
        GameIsPaused = true;
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void SaveGame(){
        SaveSystem.SavePlayer(playerInstance);
    }

    private void UpdateDarah(){
        float ratio = darah / maxDarah;
        currentdarah.rectTransform.localScale = new Vector3(ratio, 1, 1);
    }

    private void gameOver(){
        if (darah < 1){
            //player mati
            GameOverMenu.SetActive(true);
            GameIsPaused = true;
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
    }

    public void restart(){
        SceneManager.LoadScene("MainMenu");
    }
}
