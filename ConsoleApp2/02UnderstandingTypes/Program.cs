// See https://aka.ms/new-console-template for more information
/* 
Console.WriteLine("Hacker Name Generator");
Console.WriteLine("Enter Favourite Color:");
string favouriteColor = Console.ReadLine() ?? "Red";;
Console.WriteLine("Enter your astrology Sign");
string astrologySign = Console.ReadLine() ?? "Libra";;
Console.WriteLine("Enter your street address number");
int streetAddress = int.Parse(Console.ReadLine() ?? "3100");
string hackerName = favouriteColor+astrologySign+streetAddress;
Console.WriteLine($"Hacker name: {hackerName}"); 
 */

using System;
using _02UnderstandingTypes;

class Program
{
    static void Main()
    {
        //Uncomment each function to run questions separately
        // UnderstandingTypes();
        // Convert();
        // FizzBuzz();
        // pyramid();
        // check();
        // daysToNextAnniversary();
        // greeting();
        // counting();
        
        Program program = new Program();
        program.stringss();
        
    }
    
    public  void stringss()
    {
        Strings s = new Strings();
        //Strings answers 
        
        //I got an error that i cannot call non static methods from static (which is main). So, i tried to call
        //like this instead of making them static
        
        // 1. Copy an array
        // s.CopyStringArray();
        
        // 2. To do list
        // s.UserManageElements();
        
        // 3. Prime number
        // s.Call();
        
        // 4. Array Rotation
        // s.ArrayRotation();
        
        //5. Longest Sequence
        // s.LongestSequence();
        
        //6. most frequent 
        // s.MostFrequentNumber();
        
        // Practice Strings
        // 1. reverse letters
        // s.ReverseStringMethods("Hello World!");
        
        //2. Reverse list of words
        // s.ReverseWordsInSentence("C# is not C++");
        
        //3. palindromes
        // s.ExtractPalindromes("Hi exe Abba");
        
        //4. URL
        // s.ParseURL("https://www.google.com/");

    }
    
    
    /* 1. Create a console application project named /02UnderstandingTypes/ that outputs the
            number of bytes in memory that each of the following number types uses, and the
            minimum and maximum values they can have: sbyte, byte, short, ushort, int, uint, long,
            ulong, float, double, and decimal.
            Composite Formatting to learn how to align text in a console application */
    
    static void UnderstandingTypes()
    {
        
        Console.WriteLine("{0,-15} {1,-10} {2,-35} {3,-25}", "Type", "Bytes", "Min Value", "Max Value");
        Console.WriteLine(new string('-', 100));
        
        DisplayTypeInfo("sbyte", sizeof(sbyte), sbyte.MinValue, sbyte.MaxValue);
        DisplayTypeInfo("byte", sizeof(byte), byte.MinValue, byte.MaxValue);
        DisplayTypeInfo("short", sizeof(short), short.MinValue, short.MaxValue);
        DisplayTypeInfo("ushort", sizeof(ushort), ushort.MinValue, ushort.MaxValue);
        DisplayTypeInfo("int", sizeof(int), int.MinValue, int.MaxValue);
        DisplayTypeInfo("uint", sizeof(uint), uint.MinValue, uint.MaxValue);
        DisplayTypeInfo("long", sizeof(long), long.MinValue, long.MaxValue);
        DisplayTypeInfo("ulong", sizeof(ulong), ulong.MinValue, ulong.MaxValue);
        DisplayTypeInfo("float", sizeof(float), float.MinValue, float.MaxValue);
        DisplayTypeInfo("double", sizeof(double), double.MinValue, double.MaxValue);
        DisplayTypeInfo("decimal", sizeof(decimal), decimal.MinValue, decimal.MaxValue);
        
    }

        static void DisplayTypeInfo(string typeName, int byteSize, IConvertible minValue, IConvertible maxValue)
        {
            Console.WriteLine("{0,-15} | {1,-9} | {2,-33} | {3,-25}", 
                typeName, byteSize, minValue.ToString(), maxValue.ToString());
        }
        
        /* 2. Write program to enter an integer number of centuries and convert it to years, days, hours,
      minutes, seconds, milliseconds, microseconds, nanoseconds. Use an appropriate data
  type for every data conversion. Beware of overflows! */
        
        static void Convert()
        {
            Console.Write("Enter number of centuries: ");
            long centuries = long.Parse(Console.ReadLine() ?? "1");
            decimal years = centuries * 100m;
            decimal days = centuries * 36524m;
            decimal hours = days * 24m;
            decimal minutes = hours * 60m;
            decimal seconds = minutes * 60m;
            decimal milliseconds = seconds * 1000m;
            decimal microseconds = milliseconds * 1000m;
            decimal nanoseconds = microseconds * 1000m;

            Console.WriteLine($"{centuries} century(s) is equivalent to:");
            Console.WriteLine($"{years} years");
            Console.WriteLine($"{days:N0} days");
            Console.WriteLine($"{hours:N0} hours");
            Console.WriteLine($"{minutes:N0} minutes");
            Console.WriteLine($"{seconds:N0} seconds");
            Console.WriteLine($"{milliseconds:N0} milliseconds");
            Console.WriteLine($"{microseconds:N0} microseconds");
            Console.WriteLine($"{nanoseconds:N0} nanoseconds");
        }

        /*
         Practice loops and operators
           1. FizzBuzzis a group word game for children to teach them about division. Players take turns
           to count incrementally, replacing any number divisible by three with the word /fizz/, any
           number divisible by five with the word /buzz/, and any number divisible by both with /
           fizzbuzz/.
           Create a console application in Chapter03 named Exercise03 that outputs a simulated
           FizzBuzz game counting up to 100. The output should look something like the following
           screenshot:
         */
        
        static void FizzBuzz()
        {
            for (int i = 1; i <= 100; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    Console.WriteLine("FizzBuzz");
                }
                else if (i % 3 == 0)
                {
                    Console.WriteLine("Fizz");
                }
                else if (i % 5 == 0)
                {
                    Console.WriteLine("Buzz");
                }
                else
                {
                    Console.WriteLine(i);
                }
            }
        }

    
        
    
        /*2. Print-a-Pyramid.Like the star pattern examples that we saw earlier, create a program that
           will print the following pattern: If you find yourself getting stuck, try recreating the two
           examples that we just talked about in this chapter first. They’re simpler, and you can
           compare your results with the code included above*/

        static void pyramid()
        {
            Console.Write("Enter the number of rows: ");
            int rows = int.Parse(Console.ReadLine() ?? "0");

            for (int i = 1; i <= rows; i++)
            {
                for (int j = 1; j <= rows - i; j++)
                {
                    Console.Write(" ");
                }

                for (int k = 1; k <= (2 * i - 1); k++)
                {
                    Console.Write("*");
                }

                Console.WriteLine(); 
            }
        }
        
        /*3. Write a program that generates a random number between 1 and 3 and asks the user to
           guess what the number is. Tell the user if they guess low, high, or get the correct answer.
           Also, tell the user if their answer is outside of the range of numbers that are valid guesses
           (less than 1 or more than 3). You can convert the user's typed answer from a string to an
           int using this code:  
           
           Repeated question
           
           */ 
        
        static void check()
        {
            int correctNumber = new Random().Next(1, 4);
            while (true)  
            {
                Console.Write("Guess a number between 1 and 3: ");
                int guessedNumber = int.Parse(Console.ReadLine() ?? "-1");

                if (guessedNumber < 1 || guessedNumber > 3)
                {
                    Console.WriteLine("Out of range! Exiting...");
                    break;
                }
                else if (guessedNumber < correctNumber)
                    Console.WriteLine("Too low! Try again.");
                else if (guessedNumber > correctNumber)
                    Console.WriteLine("Too high! Try again.");
                else
                {
                    Console.WriteLine("Correct! You guessed it.");
                    break;
                }
            }
        }

        /*4. Write a simple program that defines a variable representing a birth date and calculates
           how many days old the person with that birth date is currently.
           For extra credit, output the date of their next 10,000 day (about 27 years) anniversary.
           Note: once you figure out their age in days, you can calculate the days until the next
           anniversary using int daysToNextAnniversary = 10000 - (days % 10000);*/

        static void daysToNextAnniversary()
        {
            DateTime birthDate = new DateTime(1995, 5, 15);
            int daysOld = (DateTime.Now - birthDate).Days;
            int daysToNextAnniversary = 10000 - (daysOld % 10000);
            DateTime nextAnniversary = DateTime.Now.AddDays(daysToNextAnniversary);
            Console.WriteLine($"You are {daysOld} days old.");
            Console.WriteLine($"Your next 10,000-day anniversary is on {nextAnniversary:MMMM dd, yyyy}.");
        }
        
        /*5. Write a program that greets the user using the appropriate greeting for the time of day.
           Use only if , not else or switch , statements to do so. Be sure to include the following
           greetings:
           "Good Morning"
           "Good Afternoon"
           "Good Evening"
           "Good Night"
           It's up to you which times should serve as the starting and ending ranges for each of the
           greetings. If you need a refresher on how to get the current time, see DateTime
           Formatting. When testing your program, you'll probably want to use a DateTime variable
           you define, rather than the current time. Once you're confident the program works
           correctly, you can substitute DateTime.Now for your variable (or keep your variable and just
           assign DateTime.Now as its value, which is often a better approach).*/

        static void greeting()
        {
            int hour = DateTime.Now.Hour;
            if (hour >= 5 && hour < 12) Console.WriteLine("Good Morning");
            if (hour >= 12 && hour < 17) Console.WriteLine("Good Afternoon");
            if (hour >= 17 && hour < 21) Console.WriteLine("Good Evening");
            if (hour >= 21 || hour < 5) Console.WriteLine("Good Night");
        }
        
        /*6. Write a program that prints the result of counting up to 24 using four different increments.
           First, count by 1s, then by 2s, by 3s, and finally by 4s.
           Use nested for loops with your outer loop counting from 1 to 4. You inner loop should
           count from 0 to 24, but increase the value of its /loop control variable/ by the value of the /
           loop control variable/ from the outer loop. This means the incrementing in the /
           afterthought/ expression will be based on a variable.*/


        static void counting()
        {
            for (int i = 1; i <= 4; i++)
            {
                for (int j = 0; j <= 24; j += i)
                {
                    Console.Write(j);
                    if (j + i <= 24) Console.Write(",");
                }
                Console.WriteLine();
            }
        }
    }


