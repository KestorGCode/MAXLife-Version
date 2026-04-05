using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace MAXLIFE
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float golod = 100f; float hp = 150f; float stress = 0;
            float money = 2568f; // денюжки
            byte age = 18; // возрост
            string name; string last_name; // имя
            int year = 2020; byte month = 1; int day = 2; byte day_of_month = 2; // дата 
            int month_in_year = 12; int day_in_month = 10; // дней в чём то
            bool home = true;
            float infl = 1.05f; // инфляция
            float price_bread = 50f * infl; // жратва
            bool islive = true; //жизнь
            byte cal_xleb = 0; // хлебушек 
            byte job = 0; //без переработок сегодня
            Console.WriteLine("Приветсвую в игре MAXLIFE это моя простенькая игра про жизнь... задеюсь не сложно вышло да ведь?" +
                "Введите имя подопечного ");
            while (true)
            {
                try
                {
                    name = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(name)) // проверка 
                    {
                        throw new Exception(); // делаем ошибку сами 
                    }
                    break;
                }
                catch
                {
                    Console.WriteLine("Попробуйте ещё раз");
                }




            }
            Console.WriteLine("Ага а теперь фамилию пожалуйста ");
            while (true)
            {
                try
                {
                    last_name = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(last_name)) // проверка 
                    {
                        throw new Exception(); // делаем ошибку сами 
                    }
                    break;
                }
                catch
                {
                    Console.WriteLine("Попробуйте ещё раз");
                }




            }

            while (islive)
            {
                byte vibor;
                Console.Clear();
                Console.WriteLine("День... обычный день. Год {0},  месяц {1}, дней месеца {2} / {3} ", year, month, day_of_month, day_in_month);
                Console.WriteLine("Выберите действие:" +
                    "\n1) Купить хлеб \n" +
                    "2) Пойти на работу \n" +
                    "3) Пойти спать \n" +
                    "4) Cъесть хлебушек\n");
                Console.WriteLine("{0, 20}", "Статистика");
                Console.WriteLine("  | {0, 3} | {1, 2} | {2, 5} | ", "Голод", "Деньги", "Возраст");
                Console.WriteLine("  | {0, 3}   | {1, 2}   | {2, 5}   | ", golod, money, age);
                while (!byte.TryParse(Console.ReadLine(), out vibor))
                {
                    Console.Clear();
                    Console.WriteLine("Попробуйте ещё раз");
                    Console.WriteLine("День... обычный день. Год {0},  месяц {1}, дней месеца {2} / {3} ", year, month, day_of_month, day_in_month);
                    Console.WriteLine("Выберите действие:" +
                        "\n1) Купить хлеб \n" +
                        "2) Пойти на работу \n" +
                        "3) Пойти спать \n" +
                        "4) Cъесть хлебушек\n");

                    Console.WriteLine("{0, 20}", "Статистика");
                    Console.WriteLine("  | {0, 3} | {1, 2} | {2, 5} | ", "Голод", "Деньги", "Возраст");
                    Console.WriteLine("  | {0, 3}   | {1, 2}   | {2, 5}   | ", golod, money, age);
                }
                if (vibor == 1)
                {
                    if (money < price_bread)
                    {
                        Console.WriteLine("У вас недостаточно денег - идите на работу.");
                    }
                    else
                    {

                        Console.WriteLine("Подтвердить покупку?" +
                            "Да = 1" +
                            "Отказано = 0");
                        byte xleb_vibor;
                        while (!byte.TryParse(Console.ReadLine(), out xleb_vibor))
                        {
                            Console.WriteLine("Ошибка! Введите только цифру 1 или 0:");
                        }
                        if (xleb_vibor == 1)
                        {
                            money -= price_bread;
                            cal_xleb++;
                            Console.WriteLine("Вы купили хлеб! Ожидание 2.5 секунд и в меню...");
                            Thread.Sleep(2500);
                            Console.Clear();
                        }
                        else if (xleb_vibor == 0 || cal_xleb > 3)
                        {
                            Console.WriteLine("Отказано или слишком много хлеба, переход в меню через 2.5 секунд...");
                            Thread.Sleep(2500);
                            Console.Clear();
                        }

                    }
                }
                else if (vibor == 2)
                {
                    if (job >= 3)
                        Console.WriteLine("Перерабатывать плохо! Тебе в детсве мама не сказала? Иди спать, завтра можно");
                    else if (job < 3)
                    {
                        Console.WriteLine("Работа... долго.. не интресно.. + 50 денег!");
                        money += 50;
                        job++;
                        stress++;
                        golod -= 5;
                    }
                    Console.WriteLine("Переход в меню через 1.5 секунды...");

                    Thread.Sleep(1500);

                }
                else if (vibor == 3)
                {
                    if (home)
                    {
                        day++;
                        job = 0;
                        golod -= 20;
                        Console.WriteLine("Сладких снов {0}", name);
                        Thread.Sleep(500);
                        if (day_of_month >= day_in_month)
                        {
                            month++;
                            Console.WriteLine("С новым месецем!");
                            day_of_month = 1;
                        }
                        else
                            day_of_month++;
                        if (month >= month_in_year)
                        {
                            year++;
                            Console.WriteLine("С новым годом {0}!", name);
                        }
                        if (stress > 5)
                        {
                            stress -= 5;
                        }
                    } 

                    else
                    {
                        Console.WriteLine("У вас нету дома... {0} ночевал под картонкой под мостом ");
                        hp--;
                        stress++;
                        job -= 1;
                        if (job <= 0)
                        {
                            job = 0;
                        }
                        golod -= 25;
                    }
                    if (hp <= 0)
                    {
                        Console.WriteLine("{0} сдох?? в прямом смысле...", name);
                        Console.WriteLine("Общее время выживания: " + day + " дней.");
                        Console.WriteLine("Нажмите любую клавишу для выхода.");
                        Console.ReadKey();
                        Console.Clear();
                        Console.WriteLine("Прощай, {0}...", name);
                        Thread.Sleep(3000); // 3 секунды тишины и пустоты...
                        Environment.Exit(0);
                    }
                    if (golod <= 10)
                    {
                        Console.WriteLine("{0} очень хочет хлеба", name);
                    }
                    else if (golod <= 5)
                    {
                        Console.WriteLine("{0} ОЧЕНЬ ОЧЕЕЕНЬ  хочет хлеба", name);

                    }
                    else if (golod <= 0)
                    {
                        Console.WriteLine("{0} резко останавливается, он выглядит исхудавшим и усталым.. И вдруг он падает.. У него не было никого кто бы мог вызвать скорую помошь" +
                            "через несколько дней соседи вызвали полицию из за запаха.. \n" +
                            "тебя увезли в морг и дёшего похранили с именем на табличке {0} {1}", name, last_name);
                        Console.Clear();
                        Thread.Sleep(500);
                        Console.WriteLine("Резултаты:" +
                            "прожито {0} дней \n" +
                            "возраст{1} лет \n" +
                            "остаточные деньги, но у тебя нет никого {2} рублей \n", day, age, money);
                    }

                    if (stress >= 100 && stress <= 149)
                    {
                        Console.WriteLine("{0} чуствует себя обеспокоенно");
                    }
                    else if (stress >= 150 && stress <= 199)
                    {
                        Console.WriteLine("{0} постоянно в стресе");
                    }
                    else if (stress >= 200) 
                    {
                        Console.WriteLine("{0} начинает плакать");
                        Thread.Sleep(500);
                        Console.WriteLine("{0} открывает окно и....");
                        Console.WriteLine("3 этажа... 2 этажа... 1 этаж");
                        Thread.Sleep(1000);
                        Console.WriteLine("В следуший раз следи получше, но если я сделал слишком сложно - прости");
                        Console.Clear();
                        Console.WriteLine("Прошай ");
                        Thread.Sleep(1000);
                        Console.Clear();
                        Thread.Sleep(500);
                        Console.WriteLine("Резултаты:" +
                            "прожито {0} дней \n" +
                            "возраст{1} лет \n" +
                            "остаточные деньги, но у тебя нет никого {2} рублей \n", day, age, money);
                    }


                }
                else if (vibor == 4) 
                {
                    if (cal_xleb > 0 )
                    {
                        Console.WriteLine("Вкусный хлеб да {0}?", name);
                        golod += 25;
                        cal_xleb--;
                        if (golod > 100)
                        {
                            golod = 100;
                            Console.WriteLine("{0} немного переел. Жалко", name);
                        } 
                    } else
                    {
                        Console.WriteLine("У вас нету еды...");
                    }
                }
                

            }
        }
    }
}
