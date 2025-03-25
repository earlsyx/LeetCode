using System.Numerics;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

public class Solution {
    /*
     Current Implementation d
        Array and Hashing
         - Two Sum , Is Anagram, Has Duplicate
        Two Pointers
         - Is Palindrome
        Stack
         - Is Valid Parenthesis
        Binary
        - Binary Search
        Sliding Windows
        - Best Time to Buy and Sell Stock
        Linked List
        - Reverse Linked List
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
            if (val != 0)
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

    //Valid Parenthesis, Stack
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

    //Binary Search 
    public int Search(int[] nums, int target)
    {
        int l = 0, r = nums.Length - 1;

        while (l <= r)
        {
            int midPoint = l + ((r - l) / 2);

            if (nums[midPoint] > target)
            {
                r = midPoint - 1;
            }
            else if (nums[midPoint] < target)
            {
                l = midPoint + 1;
            }
            else
            {
                return midPoint;
            }
        }
        return -1;


    }

    //   Sliding Windows
    // Best Time to Buy and Sell Stock
    public int MaxProfit(int[] prices) {
        int l = 0, r = 1;
        int maxP = 0;

        while (r < prices.Length)
        {
            if (prices[l] < prices[r])
            {
                int profit = prices[r] - prices[l];
                maxP = Math.Max(profit, maxP);
            }
            else 
            {
                l = r;
            }
            r++;
        }

        return maxP;
    }

    //Link List
    public ListNode ReverseList(ListNode head)
    {
        ListNode prev = null;
        ListNode curr = head;

        while (curr != null)
        {
            ListNode temp = curr.next;
            curr.next = prev;
            prev = curr;
            curr = temp;
        }
        return prev;
    }

    public static ListNode CreateLinkedListFromArray(int[] arr)
    {
        if (arr == null || arr.Length == 0)
            return null;

        ListNode head = new ListNode(arr[0]);
        ListNode current = head;
        for (int i = 1; i < arr.Length; i++)
        {
            current.next = new ListNode(arr[i]);
            current = current.next;
        }
        return head;
    }

    public static void PrintList(ListNode head)
    {
        ListNode current = head;
        while (current != null)
        {
            Console.Write(current.val);
            if (current.next != null)
                Console.Write(" -> ");
            current = current.next;
        }
        Console.WriteLine();
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

public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next=null)
    {
        this.val = val;
        this.next = next;
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

            if (isAnagram)
            {
                Console.WriteLine("The two words are Anagram of each other");
            }
            else
            {
                Console.WriteLine("Not Anagram");
            }



        }

        else if (choice == 4)
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

        else if (choice == 5)
        {
            Console.WriteLine("Input Valid Parenthesis : i.e Valid is if it close" +
                "and open and the same time. (()) valid, ([]( not valid");

            var input = Console.ReadLine();
            Solution isValid = new Solution();
            var result = isValid.IsValid(input);
            if (result)
            {
                Console.WriteLine("Is Valid Parenthesis");
            }
            else if (!result)
            {
                Console.WriteLine("Not Valid Parenthesis");
            }

        }

        else if (choice == 6)
        {
            Console.WriteLine("Please Enter the distinct array of numbers you want to search to separated by commas i.e 2,5,6,7,8");
            var inputStrings = Console.ReadLine();

            try
            {
                int[] inputArray = Array.ConvertAll(inputStrings.Split(","), int.Parse);

                Console.WriteLine("Enter your target, you want to search in the arrays");
                var targetNumber = Console.ReadLine();
                var targetParse = int.Parse(targetNumber);

                Solution search = new Solution();
                int result = search.Search(inputArray, targetParse);

                if (result == -1)
                {
                    Console.WriteLine("The target number doesn't exist within the array");
                }
                else
                {
                    Console.WriteLine($"The target exist in index {result}");
                }

            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input! Please enter only numbers separated by commas.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }



         
            
        }

        else if (choice == 7)
        {
            Console.WriteLine("Enter an array of numbers (price of token each day) seperated by commas i.e 200, 400,600,300");
            var stringPrices = Console.ReadLine();
            int[] arrayPrices = Array.ConvertAll(stringPrices.Split(","), int.Parse);

            //Console.WriteLine("Choose the day which you want to buy the coin, I,e the first number in the array corresponds to the day (1) if first day and so on");
            //var day = Console.ReadLine();
            Solution maxP = new Solution();
            var maxProfit = maxP.MaxProfit(arrayPrices);

            Console.WriteLine($"The max Profit you can get given the following days would be  {maxProfit}");
        }

        #region

        if (choice == 8)
        {
            Console.WriteLine("Write a list of numbers separated by commas (e.g., 1,2,3):");
            var inputString = Console.ReadLine();

            int[] numbers = Array.ConvertAll(inputString.Split(','), int.Parse);
            ListNode listHead = Solution.CreateLinkedListFromArray(numbers);

            // Reverse the linked list
            Solution solution = new Solution();
            ListNode reversedHead = solution.ReverseList(listHead);

            Console.WriteLine("Reversed list:");
            Solution.PrintList(reversedHead);
            #endregion
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






