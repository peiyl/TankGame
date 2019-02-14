using UnityEngine;
public class UIGame : MonoBehaviour
{
    public static UIGame Instance;
    
    public UIJoystick jtLeft;

    public UIJoystick jtRight;

    void Awake()
    {
        Instance = this;
    }
}
