public abstract class VendingMachineState
{
    protected VendingMachineContext vendingMachine;
    protected int credit;
    protected int soda;
    protected string message;

    public VendingMachineContext VendingMachine {
        get { return vendingMachine; }
        set { vendingMachine = value; }
    }

    public int Credit {
        get { return credit; }
        set { credit = value; }
    }

    public int Soda {
        get { return soda; }
        set { soda = value; }
    }

    public string Message {
        get { return message; }
        set { message = value; }
    }

    public abstract void AddCredit(int amount);
    public abstract bool BuySoda();
    public abstract void AddSoda();
}
