
//Thread currentThrread=Thread.CurrentThread;

//Console.WriteLine($"Имя потока: {currentThrread.Name}");
//currentThrread.Name = "Метод Main";
//Console.WriteLine($"Имя потока: {currentThrread.Name}");

//Console.WriteLine($"Запущен ли поток: {currentThrread.IsAlive}");
//Console.WriteLine($"Id потока: {currentThrread.ManagedThreadId}");
//Console.WriteLine($"Приоритет потока: {currentThrread.Priority}");
//Console.WriteLine($"Статус потока: {currentThrread.ThreadState}");

//int number = 4;
//Thread myThread2 = new Thread(Print);

//myThread2.Start(number);

//void Print(object? obj) 
//{
//    if(obj is int n)
//        Console.WriteLine($"n * n = {n*n}");
//}
//void Print()
//{
//    for (int i = 0; i < 10; i++)
//    {
//        Console.WriteLine($"Второй поток {i}");
//        Thread.Sleep(400);
//    }
//}
//record class Human(string Name, int Age);
using System.Security.Cryptography;

int x = 0;
//object locker = new();
/*int y = 1;
AutoResetEvent waitHandler= new AutoResetEvent(true);
Mutex mutexObj = new();
bool acquiredLock = false;
for (int i = 0; i <5; i++)
{
    Thread myThread = new(Print3);
    myThread.Name = $"Поток {i}";
    myThread.Start();
}


/*void Print()
{

    lock (locker)
    {
        x = 1;

        for (int i = 1; i < 10; i++)
        {
            Console.WriteLine($"{Thread.CurrentThread.Name}: {x}");
            x++;
            Thread.Sleep(100);
        }
    }
    y++;
    Console.WriteLine($"{Thread.CurrentThread.Name + 10}: {y}");
}*/

/*void Print3()
{
    mutexObj.WaitOne();
    x = 1;
    for (int i = 1; i < 10; i++)
    {
        Console.WriteLine($"{Thread.CurrentThread.Name}: {x}");
        x++;
        Thread.Sleep(100);
    }
    mutexObj.ReleaseMutex();
}
void Print2()
{

    waitHandler.WaitOne();

    x = 1;
    for (int i = 1; i < 10; i++)
    {
        Console.WriteLine($"{Thread.CurrentThread.Name}: {x}");
        x++;
        Thread.Sleep(100);
    }
    waitHandler.Set();

}
/*void Print1()
{
    acquiredLock = false;
    try
    {
        Monitor.Enter(locker, ref acquiredLock);
        x = 1;
        for (int i = 1; i < 10; i++)
        {
            Console.WriteLine($"{Thread.CurrentThread.Name}: {x}");
            x++;
            Thread.Sleep(100);

        }
        Monitor.Exit(locker);

    }

    finally
    {
        if (acquiredLock) Monitor.Exit(locker);
        //Console.WriteLine(acquiredLock);
    }

}*/
for(int i = 0;i<5;i++)
{
    Client client = new Client(i);
}
class Client
{
    static Semaphore sem = new Semaphore(1, 5);
    Thread myThread;
    int count = 5;
    
    public Client(int i)
    {
        myThread = new Thread(Pay);
        myThread.Name = $"Покупатель {i}";
        myThread.Start();
    }
    public void Pay()
    {
        while(count>0)
        {
            sem.WaitOne();//ожидание когда освободиться место
            Console.WriteLine($"{Thread.CurrentThread.Name} входит в салон");
            Console.WriteLine($"{Thread.CurrentThread.Name} знакомится с ценами");
            Thread.Sleep(1000);
            Console.WriteLine($"{Thread.CurrentThread.Name} покидает салон");
            sem.Release();//освобождения места
            count--;
            Thread.Sleep(1000);
        }
    }
}