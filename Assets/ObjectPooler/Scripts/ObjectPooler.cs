using System.Collections.Generic;
using UnityEngine;

namespace ObjectPoolerForUnity3d
{
	public class ObjectPooler : MonoBehaviour
	{
		[SerializeField]
		GameObject @object;
		[SerializeField]
		List<GameObject> pool;
		[SerializeField]
		int size;
		[SerializeField]
		bool canGrow;

		public void InitializePool()
		{
			for (int i = 0; i < size; i++)
			{
				var instance = Instantiate(@object);
				instance.SetActive(false);
				pool.Add(instance);
			}
		}

		public GameObject GetObject()
		{
			for (int i = 0; i < size; i++)
			{
				if (!pool[i].activeInHierarchy)
				{
					return pool[i];
				}
			}

			if (canGrow)
			{
				var instance = Instantiate(@object);
				pool.Add(instance);
				return instance;
			}

			return null;
		}

		void Awake()
		{
			InitializePool();
		}


	}

}