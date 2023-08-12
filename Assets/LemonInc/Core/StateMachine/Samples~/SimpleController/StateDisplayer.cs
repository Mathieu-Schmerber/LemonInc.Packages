using UnityEngine;

namespace LemonInc.Core.StateMachine._Samples.SimpleController
{
    internal class StateDisplayer : MonoBehaviour, IColorable
    {
	    private Renderer _renderer;

	    private void Awake()
	    {
		    _renderer = GetComponent<Renderer>();
	    }

	    public void ChangeColor(Color color)
	    {
			_renderer.material.color = color;
	    }
    }
}
