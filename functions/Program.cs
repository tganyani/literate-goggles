// 9. Методы. Процедуры и функции. Как определяются. Передача параметров в метод. Вывод результата.

// <modifiers> <return-type> <method-name> <parameter-list> , this is how a fuction is defined in c#
// <modifiers> async, unsafe, static (A static local function can't capture local variables or instance state) ,extern (An external local function must be static)
// <return-type> void (function returns nothing), int , string, double , float ,string[](array of strings) , int[](array of integers) , ... float [](array of floats) , object, list of objects
// <method-name> In C# the method name must start with uppercase letter and should be made of a verb or a couple,he name is formatted by following the Upper Camel Case convention (PascalCase) , example FindStudent, The function should not be the same as predifined key words
// <parameter-list> , paramets could be (int, string,float, double) , array, objects, list of objects
// function call , <function name>(arguments), example Sum(x, y)

// the difference between function and method is that a method is called on the object while the function can be called without the object
// a methode can have access modifiers like public, private,protected
using System;




namespace CsharpFunctions
{
    class Program
    {


        static int Func1 (int x, int y){
                Console.WriteLine("You called the first function");
                return x+y;

            }
            static double Func1 (double x, double y){
                Console.WriteLine("You called the second function");
                return x+y;

            }

            static float Func1 (float x, float y){
                Console.WriteLine("You called the third function");
                return x+y;

            }
        static void Main(string[] args)
        {
            // ***********************************************************
            // lambda function or arrow function, if function consists of one statement logic it can be written as an arrow function
            //  int Polynom(int x)
            // {
            //     return x*x + 2 * x + 1;
            //  }
            // int Polynom (int x)=>x*x + 2 * x + 1;
            // Console.WriteLine(Polynom(2));
            // **********************************************************
            // Overloading methods
            
            double x = 3; double y = 6; 
            Console.WriteLine(Func1(x,y));// 9 You called the second function
            int x1 = 3; int y1 = 6;
            Console.WriteLine(Func1(x1,y1));// 9 You called the first function
            float x2 = 3; float y2 = 6;
            Console.WriteLine(Func1(x2,y2));// 9 You called the third function
            // *************************************************

            void Function_With_Default_Arguments(int x, int y = 3, int z = 6){
                Console.WriteLine($"x = {x}, y = {y}, z = {z}");
            }
            // if a function with all its difault arguments the defaults are replaced with the ones in the function call
            Function_With_Default_Arguments(1,3,4); // x = 1, y = 3, z = 4

            Function_With_Default_Arguments(1,4); // x = 1, y = 4, z = 6 y is replaced but parameter z maintains its value
            Function_With_Default_Arguments(1); //x = 1, y = 3, z = 6  y and z maintained their default values

            // we can also name the parameters as we call the function , then we dont need to  remember the order in which we pass them in the function
            Function_With_Default_Arguments(y : 10, x : 6, z  : 15); //x = 6, y = 10, z = 15
        }
    }
}
