namespace DesignPatterns.ChainPattern
{

    /// <summary>
    /// 체인 패턴
    /// 객체 메시지의 송신과 수신을 분리해서 처리
    /// </summary>
    public class Sender
    {
        public string Execute(string msg)
        {
            var handler = new Order();
            handler.SetNext(new Cancel());
            return handler.Request(msg);
        }
    }

    public abstract class Handler
    {
        protected Handler _handler;

        public void SetNext(Handler handler)
        {
            _handler = handler;
        }

        public abstract string Request(string msg);
    }

    public class Order : Handler
    {
        public override string Request(string msg)
        {
            if (msg == "Order")
                return "주문 되었음";
            return _handler.Request(msg);
        }

    }


    public class Cancel : Handler
    {
        public override string Request(string msg)
        {
            if (msg == "Cancel")
                return "취소 되었음";
            return _handler.Request(msg);
        }
    }
}