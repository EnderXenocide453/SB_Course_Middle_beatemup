using EffectsSystem;
using UnityEngine;

namespace EffectsSystem
{
    //В будущем можно сделать темплейт эффекта ненаследуемым и просто передавать ему поведение в виде json-файла
    //или собственного языка для описания эффектов
    public abstract class EffectTemplate : ScriptableObject
    {
        [SerializeField] protected string _name;
        [SerializeField] protected Color _color;

        public string Name => _name;
        public Color Color => _color;

        public abstract void Apply(EffectableObject effectableObject);
        public abstract void Remove(EffectableObject effectableObject);
    }
}