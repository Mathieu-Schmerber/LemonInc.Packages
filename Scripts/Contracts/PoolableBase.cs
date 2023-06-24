using UnityEngine;

namespace LemonInc.Core.Pooling.Contracts
{
	/// <summary>
	/// Base implementation of <see cref="IPoolable"/>.
	/// </summary>
	/// <seealso cref="UnityEngine.MonoBehaviour" />
	/// <seealso cref="LemonInc.Core.Pooling.Contracts.IPoolable" />
	public abstract class PoolableBase : MonoBehaviour, IPoolable
	{
		/// <summary>
		/// The owner.
		/// </summary>
		private IPool _owner;

		/// <summary>
		/// The state.
		/// </summary>
		private PoolState _state;

		/// <inheritdoc/>
		public GameObject Instance => gameObject;

		/// <inheritdoc/>
		public PoolState State { get => _state; set => OnStateChanged(value); }
		
		/// <inheritdoc/>
		public void Initialize(IPool owner, object data)
		{
			_owner = owner;
			OnInitialize(data);
		}

		/// <inheritdoc/>
		public void Release()
		{
			OnRelease();
			_owner.Release(this);
		}

		/// <summary>
		/// Called when [Initialize].
		/// </summary>
		/// <param name="data">The data.</param>
		protected abstract void OnInitialize(object data);

		/// <summary>
		/// Called when [Release].
		/// </summary>
		protected abstract void OnRelease();

		/// <summary>
		/// Called when [state changed].
		/// </summary>
		/// <param name="value">The value.</param>
		/// <exception cref="System.NotImplementedException"></exception>
		private void OnStateChanged(PoolState value)
		{
			_state = value;
			switch (_state)
			{
				case PoolState.BUSY:
					Instance.SetActive(true);
					Instance.transform.parent = null;
					break;
				case PoolState.FREE:
					Instance.SetActive(false);
					break;
			}
		}
	}
}