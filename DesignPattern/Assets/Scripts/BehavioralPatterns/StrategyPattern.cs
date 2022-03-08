namespace DesignPatterns.StrategyPattern
{

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;


    /// <summary>
    /// 전략 패턴
    /// 객체 내부에서 해결해야 하는 목적을 알고리즘 객체로 분리 적용하는 기법
    /// </summary>

    public class Kitchen
    {
        private ICook _cook;
        public void SetStrategy(ICook cook)
        {
            _cook = cook;
        }

        public string Cook(Food food)
        {
            return _cook.Cook(food);
        }

        public Food CreateFood(string name)
        {
            return new Food(name);
        }

    }


    public interface ICook
    {
        string Cook(Food food);
    }

    public class BoilCook : ICook
    {
        public string Cook(Food food)
        {
            return $"{food.Name} : 끓여짐";
        }
    }

    public class FriCook : ICook
    {
        public string Cook(Food food)
        {
            return $"{food.Name} : 구워짐";
        }
    }


    public class Food
    {
        private string _name;

        public string Name => _name;
        public Food(string name)
        {
            _name = name;
        }
    }

}