// src/Program.cs
using ConsoleApp1;
using System;

namespace ATMProject
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                Console.WriteLine("Початок роботи банкомата...");

                // Створення банкомата з початковою кількістю готівки
                ATM atm = new ATM(10000);

                // Створення рахунків і карток
                Card card1 = new Card("1234-5678-9012-3456");
                Account account1 = new Account("ACC1", 5000, card1);
                atm.AddAccount(account1);

                Card card2 = new Card("6543-2109-8765-4321");
                Account account2 = new Account("ACC2", 3000, card2);
                atm.AddAccount(account2);

                int choice;

                do
                {
                    // Відображення меню для вибору операції
                    Console.WriteLine("\nВиберіть операцію:");
                    Console.WriteLine("1. Депозит");
                    Console.WriteLine("2. Зняття коштів");
                    Console.WriteLine("3. Перевірити баланс");
                    Console.WriteLine("4. Переказ");
                    Console.WriteLine("5. Інформація про рахунок");
                    Console.WriteLine("6. Вихід");

                    // Зчитування вибору користувача
                    Console.Write("\nОпція: ");
                    choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Депозит на картку №1:");
                            Account depositAccount = atm.GetAccount(card1);
                            if (depositAccount != null)
                            {
                                Console.Write("Введіть суму для депозиту: ");
                                decimal depositAmount = decimal.Parse(Console.ReadLine());
                                ICommand deposit = new DepositCommand(atm, depositAccount.Card, depositAmount);
                                deposit.Execute();
                                Console.WriteLine("Депозит виконано.");
                            }
                            else
                            {
                                Console.WriteLine("Рахунок не знайдено.");
                            }
                            break;
                        case 2:
                            Console.WriteLine("Зняття коштів з картки №2:");
                            Account withdrawAccount = atm.GetAccount(card2);
                            if (withdrawAccount != null)
                            {
                                Console.Write("Введіть суму для зняття\n" +
                                    "\t(Сума повинна бути кратною 200): ");
                                decimal withdrawAmount = decimal.Parse(Console.ReadLine());

                                // Сума повинна бути кратною 200
                                if (withdrawAmount % 200 == 0)
                                {
                                    ICommand withdraw = new WithdrawCommand(atm, withdrawAccount.Card, withdrawAmount);
                                    withdraw.Execute();
                                    Console.WriteLine("Зняття коштів виконано.");
                                }
                                else
                                {
                                    Console.WriteLine("Сума повинна бути кратною 200.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Рахунок не знайдено.");
                            }
                            break;
                        case 3:
                            Console.WriteLine("Перевірка балансу картки №1:");
                            Account balanceAccount = atm.GetAccount(card1);
                            if (balanceAccount != null)
                            {
                                ICommand checkBalance = new BalanceCheckCommand(atm, balanceAccount.Card);
                                checkBalance.Execute();
                            }
                            else
                            {
                                Console.WriteLine("Рахунок не знайдено.");
                            }
                            break;
                        case 4:
                            Console.WriteLine("Переказ з картки №1 на картку №2:");
                            Account fromAccount = atm.GetAccount(card1);
                            Account toAccount = atm.GetAccount(card2);
                            if (fromAccount != null && toAccount != null)
                            {
                                Console.Write("Введіть суму для переказу: ");
                                decimal transferAmount = decimal.Parse(Console.ReadLine());
                                ICommand transfer = new TransferCommand(atm, fromAccount.Card, toAccount.Card, transferAmount);
                                transfer.Execute();
                                Console.WriteLine("Переказ виконано.");
                            }
                            else
                            {
                                Console.WriteLine("Рахунок не знайдено.");
                            }
                            break;
                        case 5:
                            Console.WriteLine("Інформація про рахунок №1:");
                            account1.PrintAccountInfo();
                            break;
                        case 6:
                            Console.WriteLine("Вихід з програми.");
                            break;
                        default:
                            Console.WriteLine("Невідома опція.");
                            break;
                    }
                }
                while (choice != 6);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Виникла помилка: {ex.Message}");
            }
        }
    }
}
