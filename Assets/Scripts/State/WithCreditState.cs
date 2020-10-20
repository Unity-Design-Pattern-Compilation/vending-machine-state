public class WithCreditState : VendingMachineState
{
    public WithCreditState(VendingMachineState state) : this(state.Credit, state.Refri, state.VendingMachine)
    {

    }

    public WithCreditState(int credit, int refri, VendingMachineContext vendingMachine)
    {
        this.credit = credit;
        this.refri = refri;
        this.vendingMachine = vendingMachine;
    }

    public override void AddCredit(int amount)
    {
        credit += amount;
    }

    public override bool BuyRefri()
    {
        credit--;
        refri--;

        if (refri == 0)
        {
            vendingMachine._state = new NoRefri(this);
        }
        else if(credit == 0)
        {
            vendingMachine._state = new NoCreditState(this);
        }
        return true;
    }

    public override void AddRefri()
    {
        refri++;
    }
}