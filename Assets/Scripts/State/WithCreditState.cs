public class WithCreditState : VendingMachineState
{
    public WithCreditState(VendingMachineState state) : this(state.Credit, state.Soda, state.VendingMachine) { }

    public WithCreditState(int credit, int refri, VendingMachineContext vendingMachine)
    {
        this.credit = credit;
        this.soda = refri;
        this.vendingMachine = vendingMachine;
    }

    public override void AddCredit(int amount)
    {
        credit += amount;
    }

    public override bool BuySoda()
    {
        credit--;
        soda--;

        if (soda == 0)
        {
            vendingMachine._state = new NoSodaState(this);
        }
        else if(credit == 0)
        {
            vendingMachine._state = new NoCreditState(this);
        }
        return true;
    }

    public override void AddSoda()
    {
        soda++;
    }
}