using HalfLife.UnifiedSdk.Utilities.Entities;
using Sledge.Formats.Bsp.Objects;
using System.Collections.Immutable;

namespace HalfLife.UnifiedSdk.Utilities.Serialization.SledgeBSPFile
{
    internal sealed class BSPEntity : IEntity
    {
        public Sledge.Formats.Bsp.Objects.Entity Entity { get; }

        public ImmutableDictionary<string, string> KeyValues => Entity.KeyValues.ToImmutableDictionary(kv => kv.Key, kv => kv.Value);

        public bool IsWorldspawn { get; }

        public BSPEntity(Sledge.Formats.Bsp.Objects.Entity entity, bool isWorldspawn)
        {
            Entity = entity;
            IsWorldspawn = isWorldspawn;
        }

        public void SetKeyValue(string key, string value)
        {
            Entity.KeyValues[key] = value;
        }

        public void RemoveKeyValue(string key)
        {
            Entity.KeyValues.Remove(key);
        }

        public void RemoveAllKeyValues()
        {
            //Never remove the classname.
            var className = Entity.ClassName;
            Entity.KeyValues.Clear();
            Entity.ClassName = className;
        }
    }
}
