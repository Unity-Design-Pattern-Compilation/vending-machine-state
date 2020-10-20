public class NoRefri : VendingMachineState
{
    public NoRefri(VendingMachineState state) : this(state.Credit, state.Refri, state.VendingMachine)
    {

    }

    public NoRefri(int credit, int refri, VendingMachineContext vendingMachine)
    {
        this.credit = credit;
        this.refri = refri;
        this.vendingMachine = vendingMachine;
    }

    public override void AddCredit(int amount)
    {
        message = "Can't add credit, no soda in machine";
    }

    public override void AddRefri()
    {
        Refri++;
        if(Credit > 0)
        {
            vendingMachine._state = new WithCreditState(this);
        } else
        {
            vendingMachine._state = new NoCreditState(this);
        }
    }

    public override bool BuyRefri()
    {
        message = "No soda!";
        return false;
    }
}
