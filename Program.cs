using System.Numerics;

public class Solution { 
    
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

}

class Program
{
    static void Main()
    {
        Console.WriteLine("Insert an array of numbers, seperated it by commas, e.g '1,2,3'");
        string input = Console.ReadLine();

        Console.WriteLine("Enter the targer sum:");
        string targetInput = Console.ReadLine();


        try {
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


        } catch (Exception ex) 
        
        { Console.WriteLine("Invalid input. Please enter numbers correctly."); }



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






