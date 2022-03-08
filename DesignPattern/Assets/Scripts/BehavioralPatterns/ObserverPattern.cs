namespace DesignPatterns.ObserverPattern
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// 감시자 패턴
    /// 수동으로 상태값을 전달받아 처리하는 패턴
    /// </summary>
    public interface ISubject //Subject
    {
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void Notify();
        string ToString();
    }

    public class RetailStore : ISubject //ConcreteSubject
    {
        private List<IObserver> _list = new List<IObserver>();

        public void Attach(IObserver observer)
        {
            _list.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            _list.Remove(observer);
        }

        public void Notify()
        {
            for (int i = 0; i < _list.Count; i++)
            {
                _list[i].Update();
            }
        }

        public override string ToString()
        {
            var str = "";
            for (int i = 0; i < _list.Count; i++)
            {
                str += _list[i].ToString() + "\n";
            }
            return str;
        }
    }

    public interface IObserver //Observer
    {
        void Update();
        string ToString();
    }

    public class Food : IObserver //ConcreteObserver
    {
        private const float MARGIN_PRICE_RATE = 0.3f;

        private string _name;
        private int _firstCost;
        private int _retailPrice;
        private int _nowPrice;

        public Food(string name, int firstCost)
        {
            _name = name;
            _firstCost = firstCost;
            _retailPrice = firstCost + (int)((float)firstCost * MARGIN_PRICE_RATE);
            _nowPrice = _retailPrice;
        }

        public void Update()
        {
            _nowPrice = MarginClamp((int)((float)_nowPrice * UnityEngine.Random.Range(-100f, 100f)));
        }


        private int MarginClamp(int value)
        {
            return Mathf.Clamp(value, _retailPrice - (int)((float)_firstCost * MARGIN_PRICE_RATE), _retailPrice + (int)((float)_firstCost * MARGIN_PRICE_RATE));
        }

        public override string ToString()
        {
            return $"{_name} {_firstCost} {_retailPrice} {_nowPrice}";
        }
    }
}