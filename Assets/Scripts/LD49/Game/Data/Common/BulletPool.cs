using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utils.Extensions;

namespace LD49.Game.Common {
	public static class BulletPool {
		private static Dictionary<string, List<Bullet>> pool          { get; } = new Dictionary<string, List<Bullet>>();
		private static HashSet<Bullet>                  activeBullets { get; } = new HashSet<Bullet>();

		public static void Clear() {
			pool.Clear();
		}

		public static Bullet Instantiate(Bullet bullet, Vector3 position, Vector3 force) {
			var instance = GetFromPoolOrCreate(bullet);
			activeBullets.Add(instance);
			instance.transform.position = position;
			instance.Init(force);
			return instance;
		}

		private static Bullet GetFromPoolOrCreate(Bullet bullet) {
			if (!pool.ContainsKey(bullet.name) || pool[bullet.name].Count <= 0) return Object.Instantiate(bullet).Named(bullet.name);
			var fromPool = pool[bullet.name][0];
			pool[bullet.name].RemoveAt(0);
			fromPool.gameObject.SetActive(true);
			return fromPool;
		}

		public static void Pool(Bullet bullet) {
			if (!pool.ContainsKey(bullet.name)) pool.Add(bullet.name, new List<Bullet>());
			pool[bullet.name].Add(bullet);
			bullet.gameObject.SetActive(false);
			activeBullets.Remove(bullet);
		}

		public static void PoolAll() => activeBullets.ToArray().ForEach(Pool);
	}
}