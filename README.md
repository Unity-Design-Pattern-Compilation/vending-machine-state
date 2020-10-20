# Vending Machine - State

This repository has a unity project with State Design Pattern applied. I used a machine vending concept for the states as it shows below.

![StateScheme](https://user-images.githubusercontent.com/32469468/96651364-0e467a80-130b-11eb-8d7f-04b0544997ce.jpg)

## This is our initial state. We have soda in the machine but no credit.

![buy some soda](https://user-images.githubusercontent.com/32469468/96651778-e277c480-130b-11eb-833c-0a4ba9fae957.jpg)

## If we try to buy some soda, will pop up a message telling us that there is no credit in the vending machine!

![nocredit_soda](https://user-images.githubusercontent.com/32469468/96651776-e1df2e00-130b-11eb-84c3-584ef5ed3942.jpg)

## Then we add some credits and it's possible to buy some soda, yay!

![credit_soda](https://user-images.githubusercontent.com/32469468/96651774-e0ae0100-130b-11eb-865a-0ec52fb767a0.jpg)

## But soda isn't infinite, when it runs out a message appears telling us there is no soda!

![soda](https://user-images.githubusercontent.com/32469468/96651779-e3105b00-130b-11eb-900b-4e96d235ba04.jpg)
![nosoda_credit](https://user-images.githubusercontent.com/32469468/96652008-67fb7480-130c-11eb-8c9a-333792f93b8a.jpg)


You may notice that is missing a state where there is no soda but has credit, and when there is no soda and no credit. In this way will work fine, but if you insert more coins than soda then will lose these coins. You could try to insert one more state in this state machine and see what happens! Perhaps blocking the user to insert coins more than soda count! 

Use your imagination to train with this little example the state design pattern!

Follow me on Instagram @ricc.dev
