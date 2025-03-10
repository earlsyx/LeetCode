using System.Numerics;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

public class Solution {
    /*
     Current Implementation 
        Array and Hashing
         - Two Sum , Is Anagram, Has Duplicate
        Two Pointers
         - Is Palindrome
     */

    // Array and Hashing
    public int[] TwoSum(int[] nums, int target)
    {
        Dictionary<int, int> prevMap = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++) {
            int diff = target - nums[i];
            if (prevMap.ContainsKey(diff)) {
                return new int[] { prevMap[diff], i };
            }
            else
            {
                prevMap[nums[i]] = i;
            }
        }
        return Array.Empty<int>();
    }
    
    public bool hasDuplicate(int[] nums) {
        HashSet<int> set = new HashSet<int>();

        foreach (int num in nums) {
            if (set.Contains(num))
            {
                return true;
            }
            set.Add(num);
               }
        return false;
    }

    public bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length)
        {
            return false;
        }

        int[] counts = new int[26];

        for (int i = 0; i < s.Length; i++)
        {
            counts[s[i] - 'a']++;
            counts[t[i] - 'a']--;
        }

        foreach (int val in counts)
        {
            if(val != 0)
            {
                return false;
            }
        }

        return true;
    }


    //Two Pointers

    public bool IsPalindrome(string s)
    {

        Checker checker = new Checker();
        // sample. "Was it a car or a cat I Saw?"
        int l = 0;
        int r = s.Length - 1;

        while (l < r)
        {
            while (l < r && !checker.IsAlphaNum(s[l]))
            {
                l++;
            }

            while (r > l && !checker.IsAlphaNum(s[r]))
            {
                r--;
            }

            // compar
            if (char.ToLower(s[l]) != char.ToLower(s[r]))
            {
                return false;
            }
            
            l++; r--;
        }
        return true;
        
    }


    public bool IsValid(string s)
    {
        Stack<char> stack = new Stack<char>();
        Dictionary<char, char> closeToOpen = new Dictionary<char, char>
        {
            {')' , '('},
            {']' , '['},
            {'}' , '{'}
        };

        foreach (char c in s)
        {
            if (closeToOpen.ContainsKey(c))
            {
                if (stack.Count > 0 && stack.Peek() == closeToOpen[c])
                {
                    stack.Pop();
                } else
                {
                    return false;
                }
            }
            else
            {
                stack.Push(c);
            }
        }
        return stack.Count == 0;

    }
 




}


public class Checker
{

    public bool IsAlphaNum(char c)
    {
        return (c >= 'A' && c <= 'Z' ||
                c >= 'a' && c <= 'z' ||
                c >= '0' && c <= '9');
    }
}
class Program
{
    static void Main()
    {
        Solution solutionS = new Solution();

        Type type = typeof(Solution);

        MethodInfo[] methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);



        Console.WriteLine("Which Problem do you want to try? ");

        for (int i = 0; i < methods.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {methods[i].Name}");
        }
        //List all the possible problem base on the Solution class.

        // how acn you like access the methods inside the solution class, 
        // then dynamically like show it ins consle write line e.g
        // Console.WriteLine($"Which Problem do you want to try?{ListOfProblems} "
        // which corresponds to 1. TwoSum, 2. HasDuplicate, etc etc. therefore if I 
        // add another function/problem in the solution, it should correspond to 3. NewProblem
        // and so on.

        Console.Write("\nEnter the number of the problem to run: ");

        var problemSelected = int.TryParse(Console.ReadLine(), out int choice);
        if (problemSelected && choice >= 1 && choice <= methods.Length)
        {
            Console.WriteLine($"You Selected: {methods[choice - 1].Name}");
        }
        else {
             Console.WriteLine("Invalid Selection!");
        }



        if (choice == 1)
        {
            Console.WriteLine("Insert an array of numbers, seperated it by commas, e.g '1,2,3'");
            string input = Console.ReadLine();

            Console.WriteLine("Enter the targer sum:");
            string targetInput = Console.ReadLine();


            try
            {
                int[] nums = Array.ConvertAll(input.Split(","), int.Parse);
                if (!int.TryParse(targetInput, out int target))
                {
                    Console.WriteLine("Invalid number");
                    return;
                }

                Solution solution = new Solution();
                int[] result = solution.TwoSum(nums, target);

                if (result.Length == 0)
                {
                    Console.WriteLine("No Valid Pair found");
                }
                else
                {
                    Console.WriteLine($"Indexes: {result[0]}, {result[1]}");
                }


            }
            catch (Exception ex)

            { Console.WriteLine("Invalid input. Please enter numbers correctly."); }



        }

        else if (choice == 2) {
            Console.WriteLine("Input a list of numbers seperated by commas e.g 1, 2, 3");

            var input = Console.ReadLine();
            // make it so that this input is read and parse as an int, split then a list of object.
            // 
            int[] nums = Array.ConvertAll(input.Split(","), int.Parse);
           if (solutionS.hasDuplicate(nums))
            {
                Console.WriteLine("Has Duplicate");
            }
            else
            {
                Console.WriteLine("No Duplicate");
            }
            
        }

        else if (choice == 3)
        {
            Console.WriteLine("Input the first word s");
            string firstWord = Console.ReadLine();
            Console.WriteLine("Input the second word t");
            string? secondWord = Console.ReadLine();

            Solution solution = new Solution();
            bool isAnagram = solution.IsAnagram(firstWord, secondWord);

            if(isAnagram)
            {
                Console.WriteLine("The two words are Anagram of each other");
            }
            else
            {
                Console.WriteLine("Not Anagram");
            }



        }

        else if(choice == 4)
        {
            Console.WriteLine("Write the text to check if it's a palindrome");
            string sentence = Console.ReadLine();

            Solution solution = new Solution();
            bool isPalindrome = solution.IsPalindrome(sentence);

            if (isPalindrome)
            {
                Console.WriteLine("The text is a Palindrome");
            }
            else
            {
                Console.WriteLine("Not a Palindrome");


            }
        }

        else if(choice == 5)
        {
            Console.WriteLine("Input Valid Parenthesis : i.e Valid is if it close" +
                "and open and the same time. (()) valid, ([]( not valid");

            var input = Console.ReadLine();
            Solution isValid = new Solution();
            var result = isValid.IsValid(input);
            if(result)
            {
                Console.WriteLine("Is Valid Parenthesis");
            }
            else if(!result)
            {
                Console.WriteLine("Not Valid Parenthesis");
            }

        }

        Console.WriteLine("Please Enter 1 if you want to retry, if not enter 0");
        var retry = Console.ReadLine();

        if (retry == "1") {
            Main();
        }
        else
        {

        }


    }
}






