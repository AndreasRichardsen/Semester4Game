using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefaultUI : MonoBehaviour
{
    public Slider healthSlider, levelSlider;
    public Text healthSliderText, levelSliderText, levelText;
    public PlayerHealth playerHealth;
    public PlayerLevel playerLevel;
    public Player player;

    void Start()
    {
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
        playerLevel = GameObject.Find("Player").GetComponent<PlayerLevel>();
        if(player == null) player = GameObject.Find("Player").GetComponent<Player>();
        if (healthSlider == null) healthSlider = GameObject.Find("CanvasPlayerInterface/DefaultUI/HitPoints/HitPointsBar").GetComponent<Slider>();
        if (healthSliderText == null) healthSliderText = GameObject.Find("CanvasPlayerInterface/DefaultUI/HitPoints/HitPointUI").GetComponent<Text>();
        if (levelSlider == null) levelSlider = GameObject.Find("CanvasPlayerInterface/DefaultUI/Experience/ExperienceBar").GetComponent<Slider>();
        if (levelSliderText == null) levelSliderText = GameObject.Find("CanvasPlayerInterface/DefaultUI/Experience/ExperienceUI").GetComponent<Text>();
        if (levelText == null) levelText = GameObject.Find("CanvasPlayerInterface/DefaultUI/Level/Text").GetComponent<Text>();

        UIEventHandler.OnPlayerHealthChanged += UpdateHealth;
        UIEventHandler.OnPlayerLevelChanged += UpdateLevel;
    }

    void UpdateHealth(int currentHealth, int maxHealth)
    {
        this.healthSliderText.text = currentHealth.ToString() + "/" + maxHealth.ToString(); ;
        this.healthSlider.maxValue = playerHealth.maxHealth;
        this.healthSlider.value = playerHealth.currentHealth;
    }

    void UpdateLevel()
    {
        this.levelSliderText.text = player.PlayerLevel.CurrentExperience.ToString() + "/" + player.PlayerLevel.RequiredExperience.ToString();
        this.levelText.text = "Lvl: " + player.PlayerLevel.Level.ToString();
        this.levelSlider.maxValue = player.PlayerLevel.RequiredExperience;
        this.levelSlider.value = player.PlayerLevel.CurrentExperience;
    }

}
