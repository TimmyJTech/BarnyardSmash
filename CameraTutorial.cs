using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Tutorial : MonoBehaviour {

    [SerializeField]
    private bool tutorialComplete = false;

    private CinemachineVirtualCamera cam;
    public GameObject vCam;
    public GameObject tutorialOne;
    public GameObject tutorialTwo;
    public GameObject tutorialThree;
    void Start() {
        cam = GameObject.FindWithTag("cam").GetComponent<CinemachineVirtualCamera>();
        tutorialComplete = PlayerPrefs.GetInt("tutorialComplete")== 1;
    }

    void Update() {
        if (tutorialComplete == false) {
            ShowTutorial();
            tutorialComplete = true;
            PlayerPrefs.SetInt("tutorialComplete", tutorialComplete ? 1 : 0);
        }
    }

    public void ShowTutorial() {
        StartCoroutine(EnableTutorial());
    }

    IEnumerator EnableTutorial() {
        cam.Follow = tutorialOne.transform;
        yield return new WaitForSeconds(5);
        cam.Follow = tutorialTwo.transform;
        yield return new WaitForSeconds(5);
        StopCam();
    }

    public void StopCam() {
        StartCoroutine(DisableCam());
    }

    IEnumerator DisableCam() {
        cam.Follow = tutorialThree.transform;
        yield return new WaitForSeconds(5);
        vCam.SetActive(false);
    }
}
