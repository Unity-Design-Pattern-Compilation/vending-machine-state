public class NoCreditState : VendingMachineState
{
    public NoCreditState(VendingMachineState state) : this(state.Credit, state.Refri, state.VendingMachine) { }

    public NoCreditState(int credit, int refri, VendingMachineContext vendingMachine)
    {
        this.credit = credit;
        this.refri = refri;
        this.vendingMachine = vendingMachine;
    }

    public override void AddCredit(int amount)
    {
        Credit += amount;
        if (amount > 0) vendingMachine._state = new WithCreditState(this);
    }

    public override void AddRefri()
    {
        Refri++;
    }

    public override bool BuyRefri()
    {
        message = "No credit!";
        return false;
    }
}
