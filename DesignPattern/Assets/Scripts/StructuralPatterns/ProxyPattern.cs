namespace DesignPatterns.ProxyPattern
{
    using System;

    /// <summary>
    /// 프록시 패턴
    /// 객체 접근을 제어하기 위해 중간 단계에 대리자를 위치시키는 패턴
    /// </summary>

    public interface IFood
    {
        string ToString();
    }

    public class Food : IFood
    {
        private string _name;
        private DateTime _shelfLife;

        public DateTime shelfLife => _shelfLife;

        public Food(string name, DateTime shelfLife)
        {
            _name = name;
            _shelfLife = shelfLife;
        }

        public override string ToString()
        {
            return $"{_name} {_shelfLife.Year}-{_shelfLife.Month}-{_shelfLife.Day}";
        }
    }

    public class FoodWrapper : IFood
    {
        private Food _food;

        public FoodWrapper(Food food)
        {
            _food = food;
        }

        public override string ToString()
        {
            var compare = DateTime.Compare(_food.shelfLife, DateTime.Now);
            if (compare < 0)
            {
                return $"{_food.ToString()} / {DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day} 상했습니다.";
            }
            else
            {
                return $"{_food.ToString()} / {DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day} 상하지 않았습니다.";
            }
        }
    }


}