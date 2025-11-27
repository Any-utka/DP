// int a = InputPositiveInt("a");
// int b = InputPositiveInt("b");
// int c = InputPositiveInt("c");

// int product = a * b * c;
// Console.WriteLine(product);

// static int InputPositiveInt(string name)
// {
//     while (true)
//     {
//         Console.Write($"Enter {name}: ");
//         string str = Console.ReadLine();

//         int result;
//         bool parsed = int.TryParse(str, out result);

//         if (!parsed)
//         {
//             Console.WriteLine("Please enter a valid number.");
//             continue;
//         }

//         if (result <= 2)
//         {
//             Console.WriteLine("Number must be greater than 2.");
//             continue;
//         }

//         return result;
//     }
// }

// // A a;
// // F(out a);
// // Console.WriteLine(a.f1);
// // Console.WriteLine(a.f2);

// // static void F(out A b)
// // {
// //     b = 1;
// // }

// // struct A
// // {
// //     public int f1;
// //     public int f2;
// // }

// // bool result = IsGreater(5, 3);
// // Console.WriteLine(result);

// // static bool IsGreater(int a, int b)
// // {
// //     return a > b;
// // }

bool result = A() && B();
 
static bool A()
{
    Console.WriteLine("A");
    return true;
}
 
static bool B()
{
    Console.WriteLine("B");
    return false;
}