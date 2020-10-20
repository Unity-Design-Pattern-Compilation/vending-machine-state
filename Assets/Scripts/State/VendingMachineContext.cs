
public class VendingMachineContext
{
    public VendingMachineState _state;
    public int Soda {
        get { return _state.Soda; }
        set {
            _state.Soda = value;
        }
    }
    public int Credits { get => _state.Credit; }
    public string Message { get => _state.Message; }

    public VendingMachineContext()
    {
        _state = new NoCreditState(0, 5, this);
        Soda = 5;
    }

    public bool BuyRefri() => _state.BuySoda();

    public void AddCredit() => _state.AddCredit(1);

    public void AddRefri() => _state.AddSoda();
}
