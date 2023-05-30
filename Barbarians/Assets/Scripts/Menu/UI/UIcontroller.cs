using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class UIcontroller : MonoBehaviour
{
    [SerializeField] private TMP_InputField warriorInput;
    [SerializeField] private TMP_InputField berserkerInput;
    [SerializeField] private TMP_InputField knightInput;
    [SerializeField] private TMP_InputField vikingInput;
    [SerializeField] private TMP_InputField impInput;
    [SerializeField] private TMP_InputField eyeInput;
    [SerializeField] private TMP_InputField wormInput;
    [SerializeField] private TMP_InputField devilInput;

    [NonSerialized] public static int warriorC = 0;
    [NonSerialized] public static int berserkerC = 0;
    [NonSerialized] public static int knightC = 0;
    [NonSerialized] public static int vikingC = 0;
    [NonSerialized] public static int impC = 0;
    [NonSerialized] public static int eyeC = 0;
    [NonSerialized] public static int wormC = 0;
    [NonSerialized] public static int devilC = 0;

    [SerializeField] private TextMeshProUGUI playText;
    [SerializeField] private TextMeshProUGUI humanCountText;
    [SerializeField] private TextMeshProUGUI demonCountText;
    [SerializeField] private Button simulateButton;

    private void Awake()
    {
        warriorInput.text = "0";
        berserkerInput.text = "0";
        knightInput.text = "0";
        vikingInput.text = "0";
        impInput.text = "0";
        eyeInput.text = "0";
        wormInput.text = "0";
        devilInput.text = "0";

        warriorC = 0;
        berserkerC = 0;
        knightC = 0;
        vikingC = 0;
        impC = 0;
        eyeC = 0;
        wormC = 0;
        devilC = 0;

        humanCountText.text = "0";
        demonCountText.text = "0";

        warriorInput.onValueChanged.AddListener(delegate { WarriorValueChange(); });
        berserkerInput.onValueChanged.AddListener(delegate { BerserkerValueChange(); });
        knightInput.onValueChanged.AddListener(delegate { KnightValueChange(); });
        vikingInput.onValueChanged.AddListener(delegate { VikingValueChange(); });
        impInput.onValueChanged.AddListener(delegate {  ImpValueChange(); });
        eyeInput.onValueChanged.AddListener(delegate {  EyeValueChange(); });
        wormInput.onValueChanged.AddListener(delegate { WormValueChange(); });
        devilInput.onValueChanged.AddListener(delegate { DevilValueChange(); });
        simulateButton.onClick.AddListener(delegate { ButtonClick(); });
    }
    private void Update()
    {
        humanCountText.text = (warriorC + berserkerC + knightC + vikingC).ToString();
        demonCountText.text = (impC + eyeC + wormC + devilC).ToString();
    }
    private void WarriorValueChange()
    {
        warriorC = int.Parse(warriorInput.text);
    }
    private void BerserkerValueChange()
    {
        berserkerC = int.Parse(berserkerInput.text);
    }
    private void KnightValueChange()
    {
        knightC = int.Parse(knightInput.text);
    }
    private void VikingValueChange()
    {
        vikingC = int.Parse(vikingInput.text);
    }
    private void ImpValueChange()
    {
        impC = int.Parse(impInput.text);
    }
    private void EyeValueChange()
    {
        eyeC = int.Parse(eyeInput.text);
    }
    private void WormValueChange()
    {
        wormC = int.Parse(wormInput.text);
    }
    private void DevilValueChange()
    {
        devilC = int.Parse(devilInput.text);
    }
    private void ButtonClick()
    {
        if (int.Parse(humanCountText.text) <= 300 && int.Parse(demonCountText.text) <= 300)
        {
            SceneManager.LoadScene("batalla_Tiles");
        }
    }
}
