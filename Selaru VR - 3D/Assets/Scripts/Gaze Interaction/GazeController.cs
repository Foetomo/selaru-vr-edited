using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class GazeController : MonoBehaviour
{

    [Header("Gaze Setting")]
    [SerializeField] private float _maxDistanceInteraction = 10f; // max distance to interact
    [SerializeField] private float _totalGazeTime = 3f; // Total time to gaze to interact
    [SerializeField] private string _interactableTag = "Interactable"; // Total time to gaze to interact
    private float _gazingTime; // Gaze time passed 

    [SerializeField] private GameObject loadingImage;
    [SerializeField] private GameObject recticleImage;

    [Header("Pointer Setting")]
    [SerializeField] private Image _gazeTimerImage; // Loading image gaze

    private GameObject _gazedAtObject = null; // Object that camera gazed at

    // Update is called once per frame
    void Update()
    {
        //loadingImage.transform.position = new Vector2(XRSettings.eyeTextureWidth / 2, XRSettings.eyeTextureHeight/ 2);
        //recticleImage.transform.position = new Vector2(XRSettings.eyeTextureWidth / 2, XRSettings.eyeTextureHeight/ 2);

        // casts ray towards camera's forward direction, to detect if a GameObject is being gazed at.
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, _maxDistanceInteraction))
        {
            // Make sure GameObject Tag name is correct.
            if (hit.transform.gameObject.tag == _interactableTag || (LayerMask.Equals(hit.transform.gameObject.layer, "UI") && hit.transform.gameObject.tag == _interactableTag))
            {
                // GameObject detected in front of the camera.
                if (_gazedAtObject != hit.transform.gameObject)
                {
                    _gazedAtObject = hit.transform.gameObject;// store new GameObject
                }
                // check if there's no object stored in gazedAtObject
                else if (_gazedAtObject != null)
                {
                    _gazingTime += Time.deltaTime; // Time each frame gazing
                    _gazeTimerImage.fillAmount = _gazingTime / _totalGazeTime; // Filling image gaze timer
                }
            }
            else
            {
                initGaze();
            }
        }
        // no object detected
        else
        {
            initGaze();
        }

        // Check if gazing time is more or equal total gaze time to interaction
        if (_gazingTime >= _totalGazeTime)
        {
            _gazedAtObject?.GetComponent<Button>().onClick.Invoke(); // send message to object gazed at
            initGaze();
        }

    }

    // Initilize gaze so the value remain the same after interact
    private void initGaze()
    {
        _gazingTime = 0; // Set back gazingTime to 0
        _gazeTimerImage.fillAmount = 0; // Set back fillAmount value of image gaze timer to 0
        _gazedAtObject = null; // Set back to null gazedAtObject
    }
}
