using System.Diagnostics;
class Program
{
    static int[] PairwiseSum(int[] A, int[] B)
    {
        int nA = A.Length;
        int nB = B.Length;

        Debug.Assert(nA == nB, "Ошибка: списки разной длины");

        int[] C = new int[nA]; 


        int i = 0;  
        while (i < nA)
        {
            int x = A[i];    
            int y = B[i];    
            int s = x + y;   
            C[i] = s;      
            i = i + 1;      
        }
        Console.WriteLine("Результат (while): " + string.Join(", ", C));


        for (int j = 0; j < nA; j++)  
        {
            int x = A[j];    
            int y = B[j];    
            int s = x + y;   
            C[j] = s;        
        }
        Console.WriteLine("Результат (for): " + string.Join(", ", C));

        return C;
    }

    static void Main()
    {
        int[] A = { 1, 2, 3, 4, 5 };  
        int[] B = { 10, 20, 30, 40, 50 }; 
        var result = PairwiseSum(A, B);
        PrintArray(result);
    }

static PrintFive(int[] arr){
    int count = 0;
    for(int i = 0; i < arr.length; i++){
        if(arr[i] == 5){
            count ++;
        }
        return count;
    }
}

static void PrintArray(int[] arr)
{
    for (int i = 0; i < arr.Length; i++)
    {
        Console.WriteLine(arr[i]);
    }
}

}
//Функция, которая принимает какой-то список и печатает колличество 5
