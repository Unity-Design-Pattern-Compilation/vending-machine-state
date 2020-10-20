# Vending Machine - State

This repository has a unity project with State Design Pattern applied. I used a machine vending concept for the states as it shows below.

# Requirements

- Basic of C#
- Good knowledge of object-oriented programming.

# Explanation

We have three states in our vending machine.

![StateScheme](https://user-images.githubusercontent.com/32469468/96651364-0e467a80-130b-11eb-8d7f-04b0544997ce.jpg)

## This is our initial state. We have soda in the machine but no credit.

![buy some soda](https://user-images.githubusercontent.com/32469468/96651778-e277c480-130b-11eb-833c-0a4ba9fae957.jpg)

## If we try to buy some soda, will pop up a message telling us that there is no credit in the vending machine!

![nocredit_soda](https://user-images.githubusercontent.com/32469468/96651776-e1df2e00-130b-11eb-84c3-584ef5ed3942.jpg)

## Then we add some credits and it's possible to buy some soda, yay!

![credit_soda](https://user-images.githubusercontent.com/32469468/96651774-e0ae0100-130b-11eb-865a-0ec52fb767a0.jpg)

## But soda isn't infinite, when it runs out a message appears telling us there is no soda!

![soda](https://user-images.githubusercontent.com/32469468/96651779-e3105b00-130b-11eb-900b-4e96d235ba04.jpg)

You may notice that is missing a state where there is no soda but has credit, and when there is no soda and no credit. In this way will work fine, but if you insert more coins than soda then will lose these coins. You could try to insert one more state in this state machine and see what happens! Perhaps blocking the user to insert coins more than soda count! 

Use your imagination to train with this little example the state design pattern!

# Code

The code is really simple and powerful. It's possible to add any new state really fast with no headache!

Let's jump to it.

First we'll need a Context class, that is the main object in our case the Vending Machine. Thus I create a <b>VendingMachineContext.cs<b>

```cs
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
```

This class contains the current state of himself and some properties: soda and credit amount. There are three functions, these needs special attention if you notice they calls state functions, whatever the state is just call this state function. That means each state has a BuySoda, AddCredit and AddSoda implementation, this class doesn't has to know which state is or what happens, just do what this state do.

To get it less confused let's jump over each state!

This is our state abstract class, so all the states will inherit from this one!

```cs
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
```

Our first state is No Credit State, let's see how is implemented... 

This constructor style may be a little confuse for you, but the idea is that we need to pass over our context instance everytime we change our state. In the first constructor override the *this* means that we are calling the second constructor override passing these arguments, got it? (if not, check my information at the bottom and feel free to ask!)

Alright, in each functions we are implementing the logic when we don't have credit on the machine. We can add soda, why not? We can add credit too, but notice that when the credit is added the state refers to his context and say "Hey, I got credit now! Change you state to With Credit State" passing *this* as parameter so it can just copy all information like context reference and properties.

```cs
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
```

With the credit we can then add more credit or just buy our soda but then we check if it has more soda or more credit and manage it.

```cs
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
```

Same thing here, but now the vending machine is out of soda, oh no! It can't add credit but it's possible to add soda and we check if it already has credit then change state to WithCreditState, otherwise go to the state NoCreditState. Of course we can't buy soda, because there isn't. 

```cs
public class NoSodaState : VendingMachineState
{
    public NoSodaState(VendingMachineState state) : this(state.Credit, state.Soda, state.VendingMachine) { }

    public NoSodaState(int credit, int refri, VendingMachineContext vendingMachine)
    {
        this.credit = credit;
        this.soda = refri;
        this.vendingMachine = vendingMachine;
    }

    public override void AddCredit(int amount)
    {
        message = "Can't add credit, no soda in machine";
    }

    public override void AddSoda()
    {
        Soda++;
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
```

Hope you enjoyed and learnt this wonderful design pattern!

Follow me on Instagram @ricc.dev (send DM for questions)
