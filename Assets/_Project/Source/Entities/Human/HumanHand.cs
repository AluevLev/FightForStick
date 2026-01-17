using UnityEngine;
using VContainer;

public class HumanHand : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private HingeJoint2D _hingeJoint2D;

    private InputProvider _inputProvider;
    [Inject]
    public void Construct(InputProvider inputProvider)
    {
        _inputProvider = inputProvider;
    }
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _hingeJoint2D = GetComponent<HingeJoint2D>();
    }
    
}
