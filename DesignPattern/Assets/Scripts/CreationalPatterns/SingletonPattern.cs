namespace DesignPatterns
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    //객체 생성 개수를 1개로 제한하는 패턴
    public class FoodMarket
    {
        private static FoodMarket _current;

        public static FoodMarket current
        {
            get
            {
                if (_current == null)
                {
                    _current = new FoodMarket();
                }
                return _current;
            }
        }

        private FoodMarket()
        {
            Debug.Log("음식상점 생성");
        }

        public override string ToString()
        {
            return "음식상점";
        }
    }
}