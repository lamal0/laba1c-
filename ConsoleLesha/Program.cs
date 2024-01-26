using ConsoleLesha;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
/*using (WSContext db = new WSContext())
{
    User tom = new User("lesha", "lamal", "lamal0@kpi.ua");
    User alice = new User("lesha", "lamal", "lamal0@kpi.ua");


    // добавляем их в бд
    db.Users.Add(tom);
    db.Users.Add(alice);
    db.SaveChanges();
    Console.WriteLine("Объекты успешно сохранены");

    // получаем объекты из бд и выводим на консоль
    var users = db.Users.ToList();
    Console.WriteLine("Список объектов:");
    foreach (User u in users)
    {
        Console.WriteLine($"{u.Id}.{u.FullName}");
    }
}*/


namespace ConsoleLesha
{

    
    internal class Program
    {
        public static async Task Main()
        {
            using (WSContext db = new WSContext())
            {
                //ThreadsFiller(db);
                await TaskFiller(db);
                Task task = ReadUsersAsync(db);
                for (int i = 0; i < db.Users.Count(); i++)
                {
                    await Console.Out.WriteLineAsync($"Remained {db.Users.Count() - i}");
                    Thread.Sleep(1000);
                }
                Task.WaitAll(task);
            }
        }
        static void ThreadsFiller(WSContext db)
        {
            int variable = 0;
            int[] blocker = new int[1];
            List<Thread> threads = new List<Thread>()
            {
                new Thread(() =>
                {
                    for(int i = 0; i < 3; i++)
                    {
                        lock(blocker)
                        {
                            db.Users.Add(new User($"Thread1Name{variable}",$"Username{variable}",$"mail{variable}@email.com"));
                            variable++;
                        }
                    }
                }),
                new Thread(() =>
                {
                    for(int i = 0; i < 3; i++)
                    {
                        lock(blocker)
                        {
                            db.Users.Add(new User($"Thread2Name{variable}",$"Username{variable}",$"mail{variable}@email.com"));
                            variable++;
                        }
                    }
                }),
                new Thread(() =>
                {
                    for(int i = 0; i < 3; i++)
                    {
                        lock(blocker)
                        {
                            db.Users.Add(new User($"Thread3Name{variable}",$"Username{variable}",$"mail{variable}@email.com"));
                            variable++;
                        }
                    }
                })
            };
            foreach (Thread t in threads)
            {
                t.Start();
            }
            foreach (Thread t in threads)
            {
                t.Join();
            }
            db.SaveChanges();
        }
        static async Task TaskFiller(WSContext db)
        {
            //int[] blocker = new int[1];
            object blocker = new object();
            int variable = 0;
            var tasks = new Task[3];

            Func<Task> firstTask = async () =>
            {
                for (int i = 0; i < 3; i++)
                {
                    User user = new User();
                    lock (blocker)
                    {
                        user = new User($"Full1Name{variable}", $"Username{variable}", $"mail{variable}@email.com");
                        variable++;
                    }
                    await db.Users.AddAsync(user);
                    await Console.Out.WriteLineAsync("User added in Task1");
                }
            };
            Func<Task> secondTask = async () =>
            {
                for (int i = 0; i < 3; i++)
                {
                    User user = new User();
                    lock (blocker)
                    {
                        user = new User($"Full2Name{variable}", $"Username{variable}", $"mail{variable}@email.com");
                        variable++;
                    }
                    await db.Users.AddAsync(user);
                    await Console.Out.WriteLineAsync("User added in Task2");
                }
            };
            Func<Task> thirdTask = async () =>
            {
                for (int i = 0; i < 3; i++)
                {
                    User user = new User();
                    lock (blocker)
                    {
                        user = new User($"Full3Name{variable}", $"Username{variable}", $"mail{variable}@email.com");
                        variable++;
                    }
                    await db.Users.AddAsync(user);
                    await Console.Out.WriteLineAsync("User added in Task3");
                }
            };
            tasks[0] = firstTask();
            tasks[1] = secondTask();
            tasks[2] = thirdTask();

            Task.WaitAll(tasks);

            await db.SaveChangesAsync();
        }
        static async Task ReadUsersAsync(WSContext db)
        {
            var users = await db.Users.ToListAsync();
            foreach (var u in users)
            {
                await Console.Out.WriteLineAsync(u.FullName);
                Thread.Sleep(1000);
            }
        }
    }
}
