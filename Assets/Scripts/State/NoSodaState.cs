public class NoSodaState : VendingMachineState
{
    public NoSodaState(VendingMachineState state) : this(state.Credit, state.Refri, state.VendingMachine)
    {

    }

    public NoSodaState(int credit, int refri, VendingMachineContext vendingMachine)
    {
        this.credit = credit;
        this.refri = refri;
        this.vendingMachine = vendingMachine;
    }

    public override void AddCredit(int amount)
    {
        message = "Can't add credit, no soda in machine";
    }

    public override void AddSoda()
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

    public override bool BuySoda()
    {
        message = "No soda!";
        return false;
    }
}
