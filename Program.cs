Console.WriteLine("Hello, Jerry");


void PrintABC() {
    Console.WriteLine("A");
    Console.WriteLine("B");
    Console.WriteLine("C");
}

for (int i = 0; i<3; i++)
{
    PrintABC();
    Thread.Sleep(500);
}

void C()
{
    Console.WriteLine("C");
}

void B()
{
    Console.WriteLine("B");
}

void A()
{
    Console.WriteLine("A start");
    B();
    C();
    Console.WriteLine("A end");
}

A();
A();