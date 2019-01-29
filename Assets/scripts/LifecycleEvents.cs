using UnityEngine;
using UnityEngine.Events;

public class LifecycleEvents : MonoBehaviour {

    public UnityEvent Awaking = new UnityEvent();
    public UnityEvent Starting = new UnityEvent();
    public UnityEvent Enabled = new UnityEvent();
    public UnityEvent Disabled = new UnityEvent();

    private void Awake() => Awaking.Invoke();
    private void Start() => Starting.Invoke();
    private void OnEnable() => Enabled.Invoke();
    private void OnDisable() => Disabled.Invoke();

}
