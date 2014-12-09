using UnityEngine;
using System.Collections;

public class PanelControl : MonoBehaviour {

    public SpriteRenderer mainSwitch;
    public SpriteRenderer soundSwitch;


    public Sprite powerOn;
    public Sprite powerOff;
    public Sprite soundOn;
    public Sprite soundOff;
    public Sprite slider;

    private SpriteRenderer spriteSlideR;
    private SpriteRenderer spriteSlideG;
    private SpriteRenderer spriteSlideB;

    // Slider start & stop mark
    public Transform startSlideR;
    public Transform stopSlideR;
    public Transform startSlideG;
    public Transform stopSlideG;
    public Transform startSlideB;
    public Transform stopSlideB;

    // Sliders object
    private GameObject slideR;
    private GameObject slideG;
    private GameObject slideB;

    // Sliders Origin & Target
    private Transform sRTarget;
    private Transform sROrigin;
    private Transform sGTarget;
    private Transform sGOrigin;
    private Transform sBTarget;
    private Transform sBOrigin;
    
    public float sliderSpeed = 10.0F;
    private float startTimeR;
    private float startTimeG;
    private float startTimeB;
    private float journeyLength;
    public float smooth = 5.0F;

    private bool oldStatusR = true;
    private bool oldStatusG = true;
    private bool oldStatusB = true;

	// Use this for initialization
	void Start () {
        // Init slide
        slideR = new GameObject("Slide que je sais pas faire hériter proprement");
        slideG = new GameObject("Slide que je sais pas faire hériter proprement");
        slideB = new GameObject("Slide que je sais pas faire hériter proprement");

        // Init sprite sliders
        spriteSlideR = slideR.AddComponent<SpriteRenderer>();
        spriteSlideG = slideG.AddComponent<SpriteRenderer>();
        spriteSlideB = slideB.AddComponent<SpriteRenderer>();

        // Init Sliders Origin & Target

        mainSwitch.sprite = powerOn;
        soundSwitch.sprite = soundOn;

        spriteSlideR.sprite = slider;
        spriteSlideG.sprite = slider;
        spriteSlideB.sprite = slider;


        // SLIDERS SETUP
        sROrigin = startSlideR;
        sRTarget = stopSlideR;
        sGOrigin = startSlideG;
        sGTarget = stopSlideG;
        sBOrigin = startSlideB;
        sBTarget = stopSlideB;

        startTimeR = Time.time;
        startTimeG = Time.time;
        startTimeB = Time.time;
        journeyLength = Vector3.Distance(startSlideR.position, stopSlideR.position);

	}
	
	// Update is called once per frame
	void Update () {

        // Slide the godamn sliders
        float distCoveredR = (Time.time - startTimeR) * sliderSpeed;
        float fracJourneyR = distCoveredR / journeyLength;
        float distCoveredG = (Time.time - startTimeG) * sliderSpeed;
        float fracJourneyG = distCoveredG / journeyLength;
        float distCoveredB = (Time.time - startTimeB) * sliderSpeed;
        float fracJourneyB = distCoveredB / journeyLength;
        //Debug.Log(slideR.transform);
        slideR.transform.position = Vector3.Lerp(sROrigin.position, sRTarget.position, fracJourneyR);
        slideG.transform.position = Vector3.Lerp(sGOrigin.position, sGTarget.position, fracJourneyG);
        slideB.transform.position = Vector3.Lerp(sBOrigin.position, sBTarget.position, fracJourneyB);
	
	}

    public void setPower(bool status) {
        if (status) mainSwitch.sprite = powerOn;
        else mainSwitch.sprite = powerOff;
    }

    public void setSound(bool status) {
        if (status) soundSwitch.sprite = soundOn;
        else soundSwitch.sprite = soundOff;
    }

    public void setR(bool status) {
        if (status && !oldStatusR) {
            sROrigin = startSlideR;
            sRTarget = stopSlideR;
            oldStatusR = true;
            startTimeR = Time.time;
            journeyLength = Vector3.Distance(startSlideR.position, stopSlideR.position);
        } else if (!status && oldStatusR) {
            sROrigin = stopSlideR;
            sRTarget = startSlideR;
            oldStatusR = false;
            startTimeR = Time.time;
            journeyLength = Vector3.Distance(startSlideR.position, stopSlideR.position);
        }
    }

    public void setG(bool status) {
        if (status && !oldStatusG) {
            sGOrigin = startSlideG;
            sGTarget = stopSlideG;
            oldStatusG = true;
            startTimeG = Time.time;
            journeyLength = Vector3.Distance(startSlideG.position, stopSlideG.position);
        } else if (!status && oldStatusG) {
            sGOrigin = stopSlideG;
            sGTarget = startSlideG;
            oldStatusG = false;
            startTimeG = Time.time;
            journeyLength = Vector3.Distance(startSlideG.position, stopSlideG.position);
        }
    }

    public void setB(bool status) {
        if (status && !oldStatusB) {
            sBOrigin = startSlideB;
            sBTarget = stopSlideB;
            oldStatusB = true;
            startTimeB = Time.time;
            journeyLength = Vector3.Distance(startSlideB.position, stopSlideB.position);
        } else if (!status && oldStatusB) {
            sBOrigin = stopSlideB;
            sBTarget = startSlideB;
            oldStatusB = false;
            startTimeB = Time.time;
            journeyLength = Vector3.Distance(startSlideB.position, stopSlideB.position);
        }
    }
}
