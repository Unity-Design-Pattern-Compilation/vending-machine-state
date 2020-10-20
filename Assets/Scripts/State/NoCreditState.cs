public class NoCreditState : VendingMachineState
{
    public NoCreditState(VendingMachineState state) : this(state.Credit, state.Soda, state.VendingMachine) { }

    public NoCreditState(int credit, int refri, VendingMachineContext vendingMachine)
    {
        this.credit = credit;
        this.soda = refri;
        this.vendingMachine = vendingMachine;
    }

    public override void AddCredit(int amount)
    {
        Credit += amount;
        if (amount > 0) vendingMachine._state = new WithCreditState(this);
    }

    public override void AddSoda()
    {
        Soda++;
    }

    public override bool BuySoda()
    {
        message = "No credit!";
        return false;
    }
}
