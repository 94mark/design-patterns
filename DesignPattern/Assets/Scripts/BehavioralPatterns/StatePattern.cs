namespace DesignPatterns.StatePattern
{
    using UnityEngine.Assertions;
    using System.Collections.Generic;

    /// <summary>
    /// 상태 패턴
    /// 객체를 캡슐화하여 독립된 동작으로 구분하는 패턴
    /// </summary>
    public class Context //Context
    {
        private Dictionary<string, IState> _dic = new Dictionary<string, IState>();

        public Context()
        {
            _dic.Add("order", new StateOrder());
            _dic.Add("pay", new StatePay());
            _dic.Add("ordered", new StateOrdered());
            _dic.Add("finish", new StateFinish());
        }

        public string Process(string order)
        {
            if (_dic.ContainsKey(order))
                return _dic[order].Process();
            return "등록된 키가 없습니다";
        }
    }

    public interface IState //State
    {
        string Process();
    }

    public class StateOrder : IState //ConcreteState
    {
        public string Process()
        {
            return "주문";
        }
    }

    public class StatePay : IState //ConcreteState
    {
        public string Process()
        {
            return "구입";
        }
    }

    public class StateOrdered : IState //ConcreteState
    {
        public string Process()
        {
            return "주문됨";
        }
    }

    public class StateFinish : IState //ConcreteState
    {
        public string Process()
        {
            return "종료";
        }
    }
}