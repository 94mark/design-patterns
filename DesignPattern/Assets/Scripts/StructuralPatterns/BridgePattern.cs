namespace DesignPatterns.BridgePattern
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;


    /// <summary>
    /// 브릿지 패턴
    /// 객체의 확장성을 향상하기 위한 패턴
    /// 객체에서 동작을 처리하는 구현부와 확장을 위한 추상부를 분리
    /// </summary>
    public class Kitchen
    {
        public static ICookware GetInstance(string name)
        {
            return new FoodMixer(name);
        }
    }

    public interface ICookware
    {
        void Cook(float value);
        float GetValue();
    }

    public class FoodMixer : ICookware
    {
        private IFoodProcesser _foodProcesser;

        public FoodMixer(string name)
        {
            switch (name)
            {
                case "Mortar":
                    _foodProcesser = new Mortar();
                    break;
                case "FoodProcesser":
                    _foodProcesser = new FoodProcesser();
                    break;
            }
        }

        public void Cook(float value) => _foodProcesser.Mix(value);

        public float GetValue() => _foodProcesser.GetValue();
    }

    public interface IFoodProcesser
    {
        void Mix(float value);
        float GetValue();
    }

    public class Mortar : IFoodProcesser
    {
        private int _value;

        public float GetValue() => (float)_value;

        public void Mix(float value)
        {
            _value += (int)value;
        }
    }

    public class FoodProcesser : IFoodProcesser
    {
        private float _value;

        public float GetValue() => _value;

        public void Mix(float value)
        {
            _value += value;
        }
    }
}