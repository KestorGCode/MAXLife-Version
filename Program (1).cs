using System;
using System.Threading;
using System.IO;
using System.Text.Json;

namespace MAXLIFE
{
    public class World
    {
        public float infl { get; set; } = 1.05f; 
        public int year { get; set; } = 2020;  public byte month { get; set; } = 1; public int day { get; set; } = 2;
        public int month_in_year { get; set; } = 12; public int day_in_month { get; set; } = 10; public byte day_of_month { get; set; } = 2;
        public float price_bread { get; set; } = 50;
        public byte job { get; set; } = 0;

    
    }

    public class Player
    {
        public bool islive { get; set; } = true;
        public float golod { get; set; } = 100f;
        public float hp { get; set; } = 150f;
        public float stress { get; set; } = 0;
        public float money { get; set; } = 2568f;
        public byte age { get; set; } = 18;
        public string last_name { get; set; } = "Ошибка поалучения имени"; public string name { get; set; } = "Ошибка получения фамилли";
        public bool home { get; set; } = true;
        public byte cal_xleb { get; set; } = 0;

        public int rent_home { get; set; } = 150;
        public int rent_HACS { get; set; } = 150;
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            World GreatedWorld = new World();
            Player puppet = new Player();
            if (File.Exists("player.json") && File.Exists("world.json"))
            {
                // Если файлы есть - читаем их
                string pJson = File.ReadAllText("player.json");
                string wJson = File.ReadAllText("world.json");

                puppet = JsonSerializer.Deserialize<Player>(pJson);
                GreatedWorld = JsonSerializer.Deserialize<World>(wJson);
                Console.WriteLine("Загружено сохранение для {0}!", puppet.name);
            }


            Console.WriteLine("Загружено сохранение для {0}!", puppet.name);
            Console.WriteLine("Приветсвую в игре MAXLIFE это моя простенькая игра про жизнь... задеюсь не сложно вышло да ведь?" +
                "\nВведите имя подопечного ");
            while (true)
            {
                try
                {
                    puppet.name = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(puppet.name)) // проверка 
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
                    puppet.last_name = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(puppet.last_name)) // проверка 
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

            while (puppet.islive)
            {
                byte vibor;
                Console.Clear();
                Console.WriteLine("День... обычный день. Год {0},  месяц {1}, дней месеца {2} / {3} ", GreatedWorld.year, GreatedWorld.month, GreatedWorld.day_of_month, GreatedWorld.day_in_month);
                Console.WriteLine("Выберите действие:" +
                    "\n1) Купить хлеб \n" +
                    "2) Пойти на работу \n" +
                    "3) Пойти спать \n" +
                    "4) Cъесть хлебушек\n" +
                    "5) Сохранение \n");
                Console.WriteLine("{0, 20}", "Статистика");
                Console.WriteLine("  | {0, 3} | {1, 2} | {2, 5} | ", "Голод", "Деньги", "Возраст");
                Console.WriteLine("  | {0, 3}   | {1, 2}   | {2, 3}   | ", puppet.golod, puppet.money, puppet.age);
                while (!byte.TryParse(Console.ReadLine(), out vibor))
                {
                    Console.Clear();
                    Console.WriteLine("Попробуйте ещё раз");
                    Console.WriteLine("День... обычный день. Год {0},  месяц {1}, дней месеца {2} / {3} ", GreatedWorld.year, GreatedWorld.month, GreatedWorld.day_of_month, GreatedWorld.day_in_month);
                    Console.WriteLine("Выберите действие:" +
                        "\n1) Купить хлеб \n" +
                        "2) Пойти на работу \n" +
                        "3) Пойти спать \n" +
                        "4) Cъесть хлебушек\n" +
                        "5) Сохранение");

                    Console.WriteLine("{0, 20}", "Статистика");
                    Console.WriteLine("  | {0, 3} | {1, 2} | {2, 5} | ", "Голод", "Деньги", "Возраст");
                    Console.WriteLine("  | {0, 3}   | {1, 2}   | {2, 5}   | ", puppet.golod, puppet.money, puppet.age);
                }
                if (vibor == 1)
                {
                    if (puppet.money < GreatedWorld.price_bread)
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
                            GreatedWorld.price_bread = 50 * GreatedWorld.infl;
                            puppet.money -= GreatedWorld.price_bread;
                            puppet.cal_xleb++;
                            Console.WriteLine("Вы купили хлеб! Ожидание 2.5 секунд и в меню...");
                            Thread.Sleep(2500);
                            Console.Clear();
                        }
                        else if (xleb_vibor == 0 || puppet.cal_xleb > 3)
                        {
                            Console.WriteLine("Отказано или слишком много хлеба, переход в меню через 2.5 секунд...");
                            Thread.Sleep(2500);
                            Console.Clear();
                        }

                    }
                }
                else if (vibor == 2)
                {
                    if (GreatedWorld.job >= 3)
                        Console.WriteLine("Перерабатывать плохо! Тебе в детсве мама не сказала? Иди спать, завтра можно");
                    else if (GreatedWorld.job < 3)
                    {
                        Console.WriteLine("Работа... долго.. не интресно.. + 50 денег!");
                        puppet.money += 50;
                        GreatedWorld.job++;
                        puppet.stress++;
                        puppet.golod -= 5;
                    }
                    Console.WriteLine("Переход в меню через 1.5 секунды...");

                    Thread.Sleep(1500);

                }
                else if (vibor == 3)
                {
                    if (puppet.home)
                    {
                        GreatedWorld.day++;
                        GreatedWorld.job = 0;
                        puppet.golod -= 20;
                        Console.WriteLine("Сладких снов {0}", puppet.name);
                        Thread.Sleep(500);
                        if (GreatedWorld.day_of_month >= GreatedWorld.day_in_month)
                        {
                            GreatedWorld.month++;
                            Console.WriteLine("С новым месецем!");
                            GreatedWorld.day_of_month = 1;
                        }
                        else
                            GreatedWorld.day_of_month++;
                        if (GreatedWorld.month >= GreatedWorld.month_in_year)
                        {
                            GreatedWorld.year++;
                            Console.WriteLine("С новым годом {0}!", puppet.name);
                        }
                        if (puppet.stress > 5)
                        {
                            puppet.stress -= 5;
                        }
                        GreatedWorld.infl += 0.01f;
                    }

                    else
                    {
                        Console.WriteLine("У вас нету дома... {0} ночевал под картонкой под мостом ");
                        puppet.hp--;
                        puppet.stress++;
                        GreatedWorld.job -= 1;
                        if (GreatedWorld.job <= 0)
                        {
                            GreatedWorld.job = 0;
                        }
                        puppet.golod -= 25;
                    }
                    if (puppet.hp <= 0)
                    {
                        Console.WriteLine("{0} сдох?? в прямом смысле...", puppet.name);
                        Console.WriteLine("Общее время выживания: " + GreatedWorld.day + " дней.");
                        Console.WriteLine("Нажмите любую клавишу для выхода.");
                        Console.ReadKey();
                        Console.Clear();
                        Console.WriteLine("Прощай, {0}...", puppet.name);
                        Thread.Sleep(3000); // 3 секунды тишины и пустоты...
                        Environment.Exit(0);
                    }
                    if (puppet.golod <= 10)
                    {
                        Console.WriteLine("{0} очень хочет хлеба", puppet.name);
                    }
                    else if (puppet.golod <= 5)
                    {
                        Console.WriteLine("{0} ОЧЕНЬ ОЧЕЕЕНЬ  хочет хлеба", puppet.name);

                    }
                    else if (puppet.golod <= 0)
                    {
                        Console.WriteLine("{0} резко останавливается, он выглядит исхудавшим и усталым.. И вдруг он падает.. У него не было никого кто бы мог вызвать скорую помошь" +
                            "через несколько дней соседи вызвали полицию из за запаха.. \n" +
                            "тебя увезли в морг и дёшего похранили с именем на табличке {0} {1}", puppet.name, puppet.last_name);
                        Console.Clear();
                        Thread.Sleep(500);
                        Console.WriteLine("Резултаты:" +
                            "прожито {0} дней \n" +
                            "возраст{1} лет \n" +
                            "остаточные деньги, но у тебя нет никого {2} рублей \n", GreatedWorld.day, puppet.age, puppet.money);
                    }

                    if (puppet.stress >= 100 && puppet.stress <= 149)
                    {
                        Console.WriteLine("{0} чуствует себя обеспокоенно", puppet.name);
                    }
                    else if (puppet.stress >= 150 && puppet.stress <= 199)
                    {
                        Console.WriteLine("{0} постоянно в стресе", puppet.name);
                    }
                    else if (puppet.stress >= 200)
                    {
                        Console.WriteLine("{0} начинает плакать", puppet.name);
                        Thread.Sleep(500);
                        Console.WriteLine("{0} открывает окно и....", puppet.name);
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
                            "возраст {1} лет \n" +
                            "остаточные деньги, но у тебя нет никого. {2} рублей \n", GreatedWorld.day, puppet.age, puppet.money);
                    }


                }
                else if (vibor == 4)
                {
                    if (puppet.cal_xleb > 0)
                    {
                        Console.WriteLine("Вкусный хлеб да {0}?", puppet.name);
                        puppet.golod += 25;
                        puppet.cal_xleb--;
                        if (puppet.golod > 100)
                        {
                            puppet.golod = 100;
                            Console.WriteLine("{0} немного переел. Жалко", puppet.name);
                        }
                    }
                    else
                    {
                        Console.WriteLine("У вас нету еды...");
                    }
                }
                else if (vibor == 5)
                {
                    SaveGame(puppet, GreatedWorld);
                    Console.WriteLine("Сохранение...");
                    Thread.Sleep(1500);
                    Console.WriteLine("Сохранено!");
                    Console.WriteLine("Выйти в..." +
                        "1) рабочий стол" +
                        "2) меню");
                    byte SaveVibor;
                    while (!byte.TryParse(Console.ReadLine(), out SaveVibor))
                    {
                        Console.WriteLine("Ошибка! Введите только цифру 1 или 2:");
                    }


                } 
                

            }


        }
        static void SaveGame(Player p, World w)
        {
            try
            {
                // Настройки, чтобы JSON был красивым и читаемым (не в одну строку)
                var options = new JsonSerializerOptions { WriteIndented = true };

                string playerJson = JsonSerializer.Serialize(p, options);
                string worldJson = JsonSerializer.Serialize(w, options);

                // Используем WriteAllText — он сам открывает и ЗАКРЫВАЕТ файл
                File.WriteAllText("player.json", playerJson);
                File.WriteAllText("world.json", worldJson);

                Console.WriteLine("\n[УСПЕХ] Данные персонажа {0} сохранены!", p.name);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при сохранении: " + ex.Message);
            }
        }
    }
}
