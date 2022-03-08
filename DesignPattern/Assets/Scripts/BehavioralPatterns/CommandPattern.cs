namespace DesignPatterns.CommandPattern
{
    using System.Collections.Generic;

    /// <summary>
    /// 명령 패턴
    /// 행동의 호출을 객체로 캡슐화하여 실행하는 패턴
    /// </summary>
    public class Invoker //Invoker 
    {
        private Dictionary<string, ICommand> _commandDic = new Dictionary<string, ICommand>();

        public void SetCommand(string key, ICommand command)
        {
            if (!HasKey(key))
            {
                _commandDic.Add(key, command);
            }
        }

        public void RemoveCommand(string key)
        {
            if (HasKey(key))
            {
                _commandDic.Remove(key);
            }
        }

        public void Execute(string key, string name)
        {
            if (HasKey(key))
            {
                _commandDic[key].Execute(name);
            }
        }

        public string Execute(string key)
        {
            if (HasKey(key))
            {
                return _commandDic[key].Execute();
            }
            return null;
        }

        private bool HasKey(string key) => _commandDic.ContainsKey(key);

    }

    public interface ICommand //Command
    {
        void Execute(string name);
        string Execute();
    }

    public class GetCommand : ICommand //ConcreteCommand
    {
        private Human _human;

        public GetCommand(Human human)
        {
            _human = human;
        }

        public void Execute(string name)
        {
            _human.GetAction(name);
        }

        public string Execute()
        {
            return "GetCommand";
        }
    }

    public class DropCommand : ICommand
    {
        private Human _human;

        public DropCommand(Human human)
        {
            _human = human;
        }
        public void Execute(string name)
        {
            _human.DropAction(name);
        }

        public string Execute()
        {
            return "DropCommand";
        }
    }

    public class ShowCommand : ICommand
    {
        private Human _human;

        public ShowCommand(Human human)
        {
            _human = human;
        }
        public string Execute()
        {
            return _human.ToString();
        }

        public void Execute(string name)
        {
        }
    }




    public class Human //Receiver
    {

        private List<string> _bucketList = new List<string>();

        public void GetAction(string name)
        {
            _bucketList.Add(name);
        }

        public void DropAction(string name)
        {
            _bucketList.Remove(name);
        }

        public override string ToString()
        {
            var str = "";
            for (int i = 0; i < _bucketList.Count; i++)
            {
                str += _bucketList[i] + "\n";
            }
            return str;
        }
    }
}