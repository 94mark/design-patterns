namespace DesignPatterns.MediatorPattern
{
    using UnityEngine;
    using System.Collections.Generic;

    /// <summary>
    /// 중재자 패턴
    /// 분산된 다수의 객체 역할을 조정할때 주로 사용
    /// </summary>
    //public interface IMediator //Mediator
    //{
    //    void createColleague();
    //}


    public abstract class Mediator //Mediator
    {
        private List<Colleague> _list = new List<Colleague>();

        protected Colleague[] list => _list.ToArray();

        public void AddColleague(Colleague colleague)
        {
            _list.Add(colleague);
        }

        public void RemoveColleague(Colleague colleague)
        {
            _list.Remove(colleague);
        }

        public abstract void CallMediator(string name, string msg);

    }

    public class Server : Mediator //ConcreteMadiator
    {
        public Server()
        {

        }

        public override void CallMediator(string name, string msg)
        {
            for (int i = 0; i < list.Length; i++)
            {
                list[i].Message(name, msg);
            }
        }
    }


    //public interface IColleague
    //{
    //    void SetMediator(Mediator mediator);
    //}

    public abstract class Colleague //Colleague
    {
        private Mediator _mediator;
        protected Mediator mediator => _mediator;

        public void SetMediator(Mediator mediator)
        {
            _mediator = mediator;
        }
        public abstract void Send(string msg);
        public abstract void Message(string name, string msg);
    }

    public class User : Colleague //ConcreteColleague
    {
        private string _name;

        public string name => _name;

        public User(string name)
        {
            _name = name;
        }

        public override void Send(string msg)
        {
            mediator.CallMediator(_name, msg);
        }

        public override void Message(string name, string msg)
        {
            Debug.Log(_name + " : " + name + " " + msg);
        }
    }

}