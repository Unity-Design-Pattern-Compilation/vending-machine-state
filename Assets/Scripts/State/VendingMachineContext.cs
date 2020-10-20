
public class VendingMachineContext
{
    public VendingMachineState _state;
    public int Refri {
        get { return _state.Refri; }
        set {
            _state.Refri = value;
        }
    }

    public int Credits {
        get {
            return _state.Credit;
        }
    }

    public string Message {
        get {
            return _state.Message;
        }
    }

    public VendingMachineContext()
    {
        _state = new NoCreditState(0, 5, this);
        Refri = 5;
    }

    public bool BuyRefri()
    {
        return _state.BuySoda();
    }

    public void AddCredit()
    {
        _state.AddCredit(1);
    }

    public void AddRefri()
    {
        _state.AddSoda();
    }
}
