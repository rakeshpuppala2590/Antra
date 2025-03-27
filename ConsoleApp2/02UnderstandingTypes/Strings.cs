namespace _02UnderstandingTypes;
using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
public class Strings
{
    public void CopyStringArray()
    {
        string[] originalArray =
        {
            "Apple", "Banana", "Cherry", "Date", "Elderberry",
            "Fig", "Grape", "Honeydew", "Kiwi", "Lemon"
        };

        string[] copiedArray = new string[originalArray.Length];
        for (int i = 0; i < originalArray.Length; i++)
        {
            copiedArray[i] = originalArray[i];
        }
        Console.WriteLine("Original: " + string.Join(", ", originalArray));
        Console.WriteLine("Copied: " + string.Join(", ", copiedArray));
    }

    public void UserManageElements()
    {
        string[] list = new string[10]; 
        int currentSize = 0; 
        while (true)
        {
            Console.WriteLine("\nCurrent List: ");
            if (currentSize == 0)
            {
                Console.WriteLine("Empty");
            }
            else
            {
                for (int i = 0; i < currentSize; i++)
                {
                    Console.WriteLine(list[i]);
                }
            }

            Console.WriteLine("\nEnter command (+ item, - item, or -- to clear):");
            string input = Console.ReadLine();

            if (input.StartsWith("+"))
            {
                string itemToAdd = input.Substring(1).Trim();
                if (!string.IsNullOrEmpty(itemToAdd))
                {
                    if (currentSize < list.Length)
                    {
                        list[currentSize] = itemToAdd;
                        currentSize++;
                        Console.WriteLine($"Added: {itemToAdd}");
                    }
                    else
                    {
                        Console.WriteLine("Array is full, cannot add more items.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please provide an item to add.");
                }
            }
            else if (input.StartsWith("-"))
            {
                string itemToRemove = input.Substring(1).Trim(); 
                bool itemFound = false;
                for (int i = 0; i < currentSize; i++)
                {
                    if (list[i] == itemToRemove)
                    {
                        for (int j = i; j < currentSize - 1; j++)
                        {
                            list[j] = list[j + 1];
                        }

                        list[currentSize - 1] = null;
                        currentSize--;
                        itemFound = true;
                        Console.WriteLine($"Removed: {itemToRemove}");
                        break;
                    }
                }
                if (!itemFound)
                {
                    Console.WriteLine($"Item '{itemToRemove}' not found in the list.");
                }
            }
            else if (input == "--")
            {
                Array.Clear(list, 0, currentSize);
                currentSize = 0;
                Console.WriteLine("The list has been cleared.");
            }
            else
            {
                Console.WriteLine("Invalid command. Please enter a valid command (+ item, - item, or -- to clear).");
            }
        }

    }
    
    public int[] FindPrimesInRange(int startNum, int endNum)
    {
        int maxPrimes = endNum - startNum + 1;
        int[] primesArray = new int[maxPrimes];
        int index = 0;
        for (int num = startNum; num <= endNum; num++)
        { 
            if (num <= 1)
                continue;
            bool isPrime = true;
            for (int i = 2; i <= Math.Sqrt(num); i++)
            {
                if (num % i == 0)
                {
                    isPrime = false;  
                    break;
                }
            }
            if (isPrime)
            {
                primesArray[index++] = num; 
            }
        }
        int[] result = new int[index];
        Array.Copy(primesArray, result, index);
        return result;
    }

    public void Call()
    {
        int start = 10, end = 50;
        int[] primes = FindPrimesInRange(start, end);
        
        Console.WriteLine($"Prime numbers between {start} and {end}:");
        foreach (var prime in primes)
        {
            Console.Write(prime + " ");
        }
    }

    public void ArrayRotation()
    {
        Console.WriteLine("Enter array elements (space separated):");
        string[] input = Console.ReadLine().Split();
        int[] arr = Array.ConvertAll(input, int.Parse);
        Console.WriteLine("Enter the number of rotations:");
        int k = int.Parse(Console.ReadLine());

        int n = arr.Length;
        int[] sum = new int[n];

        for (int r = 1; r <= k; r++)
        {
            int[] rotated = new int[n];
            for (int i = 0; i < n; i++)
            {
                rotated[(i + r) % n] = arr[i];
            }

            Console.WriteLine($"rotated{r}[] = {string.Join(" ", rotated)}");
            for (int i = 0; i < n; i++)
            {
                sum[i] += rotated[i];
            }
        }
        Console.WriteLine($"sum[] = {string.Join(" ", sum)}");
    }
    
    public void LongestSequence()
    {
        Console.WriteLine("Enter array elements (space-separated):");
        int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int maxLength = 1;
        int currentLength = 1;
        int bestElement = arr[0];
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] == arr[i - 1])
            {
                currentLength++;
            }
            else
            {
                currentLength = 1;
            }

            if (currentLength > maxLength)
            {
                maxLength = currentLength;
                bestElement = arr[i];
            }
        }

        Console.WriteLine(string.Join(" ", Enumerable.Repeat(bestElement, maxLength)));
    }
    
    public void MostFrequentNumber()
    {
        Console.WriteLine("Enter array elements (space-separated):");
        int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

        Dictionary<int, int> frequency = new Dictionary<int, int>();
        int maxFrequency = 0, mostFrequent = arr[0];

        foreach (int num in arr)
        {
            if (!frequency.ContainsKey(num))
                frequency[num] = 0;
            
            frequency[num]++;

            if (frequency[num] > maxFrequency)
            {
                maxFrequency = frequency[num];
                mostFrequent = num;
            }
        }

        Console.WriteLine($"The number {mostFrequent} is the most frequent (occurs {maxFrequency} times)");
    }
    
    public void ReverseStringMethods(string input)
    {
        string reversed1 = new string(input.ToCharArray().Reverse().ToArray());
        Console.WriteLine("Method 1: " + reversed1);

        StringBuilder reversed2 = new StringBuilder();
        for (int i = input.Length - 1; i >= 0; i--)
            reversed2.Append(input[i]);
        Console.WriteLine("Method 2: " + reversed2.ToString());
    }

    public void ReverseWordsInSentence(string sentence)
    {
        string[] words = Regex.Split(sentence, @"([\s.,:;=\(\)&\[\]\""'\\/!?]+)");
        string[] reversedWords = words.Where(w => !Regex.IsMatch(w, @"^[\s.,:;=\(\)&\[\]\""'\\/!?]+$")).Reverse().ToArray();

        StringBuilder result = new StringBuilder();
        int wordIndex = 0;
        foreach (string part in words)
        {
            if (!Regex.IsMatch(part, @"^[\s.,:;=\(\)&\[\]\""'\\/!?]+$"))
                result.Append(reversedWords[wordIndex++]);
            else
                result.Append(part);
        }
        Console.WriteLine(result.ToString());
    }

    public void ExtractPalindromes(string text)
    {
        HashSet<string> palindromes = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        string[] words = Regex.Split(text, @"[\s.,:;=\(\)&\[\]\""'\\/!?]+");

        foreach (string word in words)
        {
            if (!string.IsNullOrEmpty(word) && word.Length > 1 && word.SequenceEqual(word.Reverse()))
                palindromes.Add(word);
        }
        
        Console.WriteLine(string.Join(", ", palindromes.OrderBy(p => p)));
    }

    public void ParseURL(string url)
    {
        var match = Regex.Match(url, @"^(?:(\w+)://)?([^/]+)(/?.*)$");

        string protocol = match.Groups[1].Success ? match.Groups[1].Value : "";
        string server = match.Groups[2].Value;
        string resource = match.Groups[3].Value.TrimStart('/');
        
        Console.WriteLine($"[protocol] = \"{protocol}\"\n[server] = \"{server}\"\n[resource] = \"{resource}\"");
    }
    
}