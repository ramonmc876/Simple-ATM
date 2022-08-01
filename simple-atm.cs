using System;

namespace ATM
{
    public class cardHolder
    {
        string cardNum { get; set; }
        int pin { get; set; }
        string firstName { get; set; }
        string lastName { get; set; }
        double balance { get; set; }

        public cardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
        {
            this.cardNum = cardNum;
            this.pin = pin;
            this.firstName = firstName;
            this.lastName = lastName;
            this.balance = balance;
        }

        public string getFirstName()
        {
            return firstName;
        }

        public string getLastName()
        {
            return lastName;
        }

        public double getBalance()
        {
            return balance;
        }

        public int getPin()
        {
            return pin;
        }

        public void setNum(string newCardNum)
        {
            cardNum = newCardNum;
        }

        public void setPin(int newPin)
        {
            pin = newPin;
        }

        public void setFirstName(string newFirstName)
        {
            firstName = newFirstName;
        }

        public void setLastName(string newLastName)
        {
            lastName = newLastName;
        }

        public void setBalance(double newBalance)
        {
            balance = newBalance;
        }

        public static void Main(string[] args)
        {
            void printOptions()
            {
                Console.Write("Please select an option from the following list: \n 1. Withdraw \n 2. Deposit \n 3. Show Balance \n 4. Exit System \n");
            }

            void deposit(cardHolder currentUser)
            {
                Console.Write("How much money would you like to deposit ?");
                double deposit = Double.Parse(Console.ReadLine());
                currentUser.setBalance(deposit);
                Console.Write("Thank you for the deposit!");

            }

            void withdraw(cardHolder currentUser)
            {
                Console.Write("Please enter the amount of money would like to withdraw...");
                double withdrawal = Double.Parse(Console.ReadLine());
                if(currentUser.getBalance() > withdrawal)
                {
                    Console.Write("Insufficiant balance in account");
                }
                else
                {
                    currentUser.setBalance(currentUser.getBalance() - withdrawal);
                    Console.Write("Please take cash, Thank you come again!");

                }
            }

            void balance(cardHolder currentUser)
            {
                Console.Write("Current Balance is: " + currentUser.getBalance());

            }

            List<cardHolder> cardHolders = new List<cardHolder>();
            cardHolders.Add(new cardHolder("111122223333", 1234, "Ramon", "Mc", 15000.00));
            cardHolders.Add(new cardHolder("444455556666", 5678, "Jason", "Mc", 18000.00));
            cardHolders.Add(new cardHolder("777788889999", 9101, "Gordon", "Mc", 10000.00));

            Console.Write("Welcome user to the simpleATM ! \n Please insert your card into the machine \n");
            String cardNumb = "";
            cardHolder currentUser;

            while (true)
            {
                try
                {
                    cardNumb = Console.ReadLine();
                    currentUser = cardHolders.FirstOrDefault(a => a.cardNum == cardNumb);
                    if (currentUser != null)
                    {
                        break;
                    }
                    else
                    {
                        Console.Write("Card entered not recognized, Please enter a valid card!");
                    }
                }
                catch
                {
                    Console.Write("Card entered not recognized, Please enter a valid card!");
                }
            }

            Console.Write("Please enter pin number: ");
            int userPin = 0;

            while (true)
            {
                try
                {
                    userPin = int.Parse(Console.ReadLine());
                    if (currentUser.getPin() == userPin)
                    {
                        break;
                    }
                    else
                    {
                        Console.Write("Pin entered not recognized, Please enter a valid pin!");
                    }
                }
                catch
                {
                    Console.Write("Pin entered not recognized, Please enter a valid pin!");
                }
            }

            Console.Write("Welcome " + currentUser.getFirstName() + " !");
            int option = 0;
            do
            {
                printOptions();
                try
                {
                    option = int.Parse(Console.ReadLine());

                }
                catch { }
                if (option == 1) { withdraw(currentUser); }
                else if (option == 2) { deposit(currentUser); }
                else if (option == 3) { balance(currentUser); }
                else if (option == 4) { break; }
                else { option = 0; }
            }
            while (option != 0);
            Console.Write("Thank You! Have a great day!");

        }

    }

}
