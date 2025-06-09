using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    

    [Header("UI")]
    public Text redBaseResources;
    public Text blueBaseResources;

    public Slider botsCountSlider;
    public Slider botsSpeedSlider;
    public InputField generationFrequency;
    public Toggle checkPaths;

    [Header("Data")]
    public DronsBase redBase;
    public DronsBase blueBase;
    public FlyToPoint flyToPoint;
    public ResourceGenerator resourceGenerator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        checkPaths.isOn = flyToPoint.isVisualizePath;
    }

    // Update is called once per frame
    void Update()
    {
        if(redBaseResources != null)
        {
            redBaseResources.text = redBase.resourcesCount.ToString();
        }
        if(blueBaseResources != null)
        {
            blueBaseResources.text = blueBase.resourcesCount.ToString();
        }
        

    }

    public void OnBotSpeedChanged()
    {
        flyToPoint.speedFlying = botsSpeedSlider.value;
    }

    public void OnBotCountChanged()
    {
        redBase.ChangeDronsCount((int)botsCountSlider.value - redBase.dronCount);
        blueBase.ChangeDronsCount((int)botsCountSlider.value - blueBase.dronCount);
        
    }

    public void OnResourceFrequencyChanged()
    {
        if (float.TryParse(generationFrequency.text, out float parsedNumber))
        {
            resourceGenerator.spawnInterval = parsedNumber;
        }
    }

    public void OnShowPath()
    {
        flyToPoint.isVisualizePath = checkPaths.isOn;
    }
}
