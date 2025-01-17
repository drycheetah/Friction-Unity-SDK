using System.Collections.Generic;
using UnityEngine;

namespace Friction
{
    [System.Serializable]
    public class SerializableDictionary<TKey, TValue> : ISerializationCallbackReceiver
    {
        [SerializeField] private List<TKey> keys = new List<TKey>();
        [SerializeField] private List<TValue> values = new List<TValue>();

        private Dictionary<TKey, TValue> target = new Dictionary<TKey, TValue>();

        public SerializableDictionary(Dictionary<TKey, TValue> dict)
        {
            target = dict;
        }

        public void OnBeforeSerialize()
        {
            keys.Clear();
            values.Clear();

            foreach (var kvp in target)
            {
                keys.Add(kvp.Key);
                values.Add(kvp.Value);
            }
        }

        public void OnAfterDeserialize()
        {
            for (int i = 0; i < keys.Count; i++)
            {
                target[keys[i]] = values[i];
            }
        }
    }
}
