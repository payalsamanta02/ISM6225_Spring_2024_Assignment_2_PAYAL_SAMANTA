/* 
 
YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINIDTION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK


*/

using System.Text;

namespace ISM6225_Spring_2024_Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            int numberOfUniqueNumbers = RemoveDuplicates(nums1);
            Console.WriteLine(numberOfUniqueNumbers);

            //Question 2:
            Console.WriteLine("Question 2:");
            int[] nums2 = { 0, 1, 0, 3, 12 };
            IList<int> resultAfterMovingZero = MoveZeroes(nums2);
            string combinationsString = ConvertIListToArray(resultAfterMovingZero);
            Console.WriteLine(combinationsString);

            //Question 3:
            Console.WriteLine("Question 3:");
            int[] nums3 = { -1, 0, 1, 2, -1, -4 };
            IList<IList<int>> triplets = ThreeSum(nums3);
            string tripletResult = ConvertIListToNestedList(triplets);
            Console.WriteLine(tripletResult);

            //Question 4:
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 1, 0, 1, 1, 1 };
            int maxOnes = FindMaxConsecutiveOnes(nums4);
            Console.WriteLine(maxOnes);

            //Question 5:
            Console.WriteLine("Question 5:");
            int binaryInput = 101010;
            int decimalResult = BinaryToDecimal(binaryInput);
            Console.WriteLine(decimalResult);

            //Question 6:
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 6, 9, 1 };
            int maxGap = MaximumGap(nums5);
            Console.WriteLine(maxGap);

            //Question 7:
            Console.WriteLine("Question 7:");
            int[] nums6 = { 2, 1, 2 };
            int largestPerimeterResult = LargestPerimeter(nums6);
            Console.WriteLine(largestPerimeterResult);

            //Question 8:
            Console.WriteLine("Question 8:");
            string result = RemoveOccurrences("daabcbaabcbc", "abc");
            Console.WriteLine(result);
        }

        /*
        
        Question 1:
        Given an integer array nums sorted in non-decreasing order, remove the duplicates in-place such that each unique element appears only once. The relative order of the elements should be kept the same. Then return the number of unique elements in nums.

        Consider the number of unique elements of nums to be k, to get accepted, you need to do the following things:

        Change the array nums such that the first k elements of nums contain the unique elements in the order they were present in nums initially. The remaining elements of nums are not important as well as the size of nums.
        Return k.

        Example 1:

        Input: nums = [1,1,2]
        Output: 2, nums = [1,2,_]
        Explanation: Your function should return k = 2, with the first two elements of nums being 1 and 2 respectively.
        It does not matter what you leave beyond the returned k (hence they are underscores).
        Example 2:

        Input: nums = [0,0,1,1,1,2,2,3,3,4]
        Output: 5, nums = [0,1,2,3,4,_,_,_,_,_]
        Explanation: Your function should return k = 5, with the first five elements of nums being 0, 1, 2, 3, and 4 respectively.
        It does not matter what you leave beyond the returned k (hence they are underscores).
 

        Constraints:

        1 <= nums.length <= 3 * 104
        -100 <= nums[i] <= 100
        nums is sorted in non-decreasing order.
        */

        public static int RemoveDuplicates(int[] nums)
        {
            try
            {
                // Confirm if the provided array is empty. If so, return 0 since there are no elements.
                if (nums.Length == 0)
                    return 0;

                // Set k to 1 initially as the first element is always considered unique.
                int k = 1;
                // Begin from the second element and compare it with the preceding one.
                for (int i = 1; i < nums.Length; i++)
                {
                    // If the current element differs from the previous one (indicating a unique element),
                    // assign it to the k-th position and increment k.
                    if (nums[i] != nums[i - 1])
                    {
                        nums[k] = nums[i];
                        k++;
                    }
                }

                // Return the count of unique elements discovered in the array.
                return k;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        
        Question 2:
        Given an integer array nums, move all 0's to the end of it while maintaining the relative order of the non-zero elements.

        Note that you must do this in-place without making a copy of the array.

        Example 1:

        Input: nums = [0,1,0,3,12]
        Output: [1,3,12,0,0]
        Example 2:

        Input: nums = [0]
        Output: [0]
 
        Constraints:

        1 <= nums.length <= 104
        -231 <= nums[i] <= 231 - 1
        */

        public static IList<int> MoveZeroes(int[] nums)
        {
            try
            {
                // Check if the input array is null or empty. If so, return an empty list.
                if (nums == null || nums.Length == 0)
                    return new List<int>();

                int nonZeroPointer = 0; // Initialize a pointer to track the position for the next non-zero element.

                // Loop through each element in the array.
                for (int i = 0; i < nums.Length; i++)
                {
                    // If the current element is not zero, place it at the position indicated by nonZeroPointer.
                    // This effectively moves all non-zero elements to the front of the array in their original order.
                    if (nums[i] != 0)
                    {
                        nums[nonZeroPointer] = nums[i];
                        nonZeroPointer++; // Move the nonZeroPointer forward.
                    }
                }

                // After all non-zero elements have been moved to the front,
                // fill the rest of the array with zeros.
                while (nonZeroPointer < nums.Length)
                {
                    nums[nonZeroPointer] = 0;
                    nonZeroPointer++; // Increment pointer as we insert zeros.
                }

                // Convert the modified array into a list and return it.
                return nums.ToList();

            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question 3:
        Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.

        Notice that the solution set must not contain duplicate triplets.

 

        Example 1:

        Input: nums = [-1,0,1,2,-1,-4]
        Output: [[-1,-1,2],[-1,0,1]]
        Explanation: 
        nums[0] + nums[1] + nums[2] = (-1) + 0 + 1 = 0.
        nums[1] + nums[2] + nums[4] = 0 + 1 + (-1) = 0.
        nums[0] + nums[3] + nums[4] = (-1) + 2 + (-1) = 0.
        The distinct triplets are [-1,0,1] and [-1,-1,2].
        Notice that the order of the output and the order of the triplets does not matter.
        Example 2:

        Input: nums = [0,1,1]
        Output: []
        Explanation: The only possible triplet does not sum up to 0.
        Example 3:

        Input: nums = [0,0,0]
        Output: [[0,0,0]]
        Explanation: The only possible triplet sums up to 0.
 

        Constraints:

        3 <= nums.length <= 3000
        -105 <= nums[i] <= 105

        */



        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            try
            {
                // Create a container to store all distinct triplets discovered.
                List<IList<int>> result = new List<IList<int>>();
                // Arrange the array's elements in ascending order to aid triplet identification.
                Array.Sort(nums);

                // Navigate through the array, treating each element as a potential starting point for a triplet.
                for (int i = 0; i < nums.Length - 2; i++)
                {
                    // Prevent repetition of triplets by skipping over duplicates of the current element.
                    if (i == 0 || (i > 0 && nums[i] != nums[i - 1]))
                    {
                        // Establish two pointers, "low" and "high", to represent the second and third elements of a potential triplet.
                        int low = i + 1, high = nums.Length - 1, sum = 0 - nums[i];

                        // Employ the two pointers to locate elements that, when combined with nums[i], yield a total of zero.
                        while (low < high)
                        {
                            if (nums[low] + nums[high] == sum)
                            {
                                // Upon triplet discovery, incorporate it into the results list.
                                result.Add(new List<int> { nums[i], nums[low], nums[high] });
                                // Advance the "low" pointer past any subsequent identical elements to avoid duplicate triplets.
                                while (low < high && nums[low] == nums[low + 1]) low++;
                                // Similarly, move the "high" pointer past any duplicates for the third element.
                                while (low < high && nums[high] == nums[high - 1]) high--;
                                // Shift both pointers to explore potential distinct triplets.
                                low++;
                                high--;
                            }
                            else if (nums[low] + nums[high] < sum) // If the sum falls short, advance the "low" pointer.
                                low++;
                            else // If the sum surpasses zero, move the "high" pointer downwards.
                                high--;
                        }
                    }
                }
                // Return the collection of identified triplets.
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question 4:
        Given a binary array nums, return the maximum number of consecutive 1's in the array.

        Example 1:

        Input: nums = [1,1,0,1,1,1]
        Output: 3
        Explanation: The first two digits or the last three digits are consecutive 1s. The maximum number of consecutive 1s is 3.
        Example 2:

        Input: nums = [1,0,1,1,0,1]
        Output: 2
 
        Constraints:

        1 <= nums.length <= 105
        nums[i] is either 0 or 1.

        */

        public static int FindMaxConsecutiveOnes(int[] nums)
        {
            try
            {
                // Create a variable named maxCount to store the largest tally of consecutive 1s we've encountered so far.
                int maxCount = 0;
                // Create a variable named count to track the current ongoing count of consecutive 1s.
                int count = 0;

                // Examine each number within the input array.
                foreach (int num in nums)
                {
                    // If the current number is 1,
                    if (num == 1)
                    {
                        // Increase the ongoing count of consecutive 1s.
                        count++;
                        // Compare the ongoing count to the highest count found previously, and update maxCount if the ongoing count is larger.
                        maxCount = Math.Max(maxCount, count);
                    }
                    else
                    {
                        // If the current number is not 1, reset the ongoing count to zero, as the sequence of consecutive 1s has ended.
                        count = 0;
                    }
                }
                // Provide the ultimate result, which is the highest count of consecutive 1s discovered within the array.
                return maxCount;

            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question 5:
        You are tasked with writing a program that converts a binary number to its equivalent decimal representation without using bitwise operators or the `Math.Pow` function. You will implement a function called `BinaryToDecimal` which takes an integer representing a binary number as input and returns its decimal equivalent. 

        Requirements:
        1. Your program should prompt the user to input a binary number as an integer. 
        2. Implement the `BinaryToDecimal` function, which takes the binary number as input and returns its decimal equivalent. 
        3. Avoid using bitwise operators (`<<`, `>>`, `&`, `|`, `^`) and the `Math.Pow` function for any calculations. 
        4. Use only basic arithmetic operations such as addition, subtraction, multiplication, and division. 
        5. Ensure the program displays the input binary number and its corresponding decimal value.

        Example 1:
        Input: num = 101010
        Output: 42


        Constraints:

        1 <= num <= 10^9

        */

        public static int BinaryToDecimal(int binary)
        {
            try
            {
                // Create a variable named decimalNumber to hold the decimal equivalent we'll create. It starts as 0.
                int decimalNumber = 0;
                // Create a variable named baseValue to track the current base value (1, 2, 4, 8, ...) in the binary system. It starts as 1.
                int baseValue = 1;

                // Repeat the following steps as long as the binary number still has digits to process:
                while (binary > 0)
                {
                    // Isolate the rightmost digit (either 0 or 1) from the binary number using the modulo operator (%).
                    int lastDigit = binary % 10;
                    // Shorten the binary number by discarding its rightmost digit using integer division (/).
                    binary = binary / 10;
                    // Calculate the decimal value of the extracted digit by multiplying it with the current baseValue and add it to the cumulative decimalNumber.
                    decimalNumber += lastDigit * baseValue;
                    // Prepare for the next digit by doubling the baseValue to match the next position in the binary number.
                    baseValue *= 2;
                }
                // Once all digits have been processed, provide the final decimal value as the function's output.
                return decimalNumber;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question:6
        Given an integer array nums, return the maximum difference between two successive elements in its sorted form. If the array contains less than two elements, return 0.
        You must write an algorithm that runs in linear time and uses linear extra space.

        Example 1:

        Input: nums = [3,6,9,1]
        Output: 3
        Explanation: The sorted form of the array is [1,3,6,9], either (3,6) or (6,9) has the maximum difference 3.
        Example 2:

        Input: nums = [10]
        Output: 0
        Explanation: The array contains less than 2 elements, therefore return 0.
 

        Constraints:

        1 <= nums.length <= 105
        0 <= nums[i] <= 109

        */

        public static int MaximumGap(int[] nums)
        {
            try
            {
                // If the array has fewer than two numbers, return 0 because gaps cannot exist in such cases.
                if (nums.Length < 2) return 0;

                // Arrange the numbers in ascending order to facilitate finding the largest gap between neighboring elements.
                Array.Sort(nums);

                // Create a variable named maxGap to store the biggest difference found between consecutive elements so far.
                int maxGap = 0;

                // Examine each element in the array, starting with the second one.
                for (int i = 1; i < nums.Length; i++)
                {
                    // If the current element is much larger than the previous element, update maxGap with this wider difference.
                    maxGap = Math.Max(maxGap, nums[i] - nums[i - 1]);
                }

                // Return the final value of maxGap, representing the largest gap identified in the sorted array.
                return maxGap;

            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question:7
        Given an integer array nums, return the largest perimeter of a triangle with a non-zero area, formed from three of these lengths. If it is impossible to form any triangle of a non-zero area, return 0.

        Example 1:

        Input: nums = [2,1,2]
        Output: 5
        Explanation: You can form a triangle with three side lengths: 1, 2, and 2.
        Example 2:

        Input: nums = [1,2,1,10]
        Output: 0
        Explanation: 
        You cannot use the side lengths 1, 1, and 2 to form a triangle.
        You cannot use the side lengths 1, 1, and 10 to form a triangle.
        You cannot use the side lengths 1, 2, and 10 to form a triangle.
        As we cannot use any three side lengths to form a triangle of non-zero area, we return 0.

        Constraints:

        3 <= nums.length <= 104
        1 <= nums[i] <= 106

        */

        public static int LargestPerimeter(int[] nums)
        {
            try
            {
                // Organize the array elements from smallest to largest.
                Array.Sort(nums);

                // Begin examining potential triangles with the largest values for efficiency.
                for (int i = nums.Length - 1; i >= 2; i--)
                {
                    // Determine if the current combination of elements can form a valid triangle.
                    // This involves verifying that the two shorter sides, when added together, exceed the longest side.
                    if (nums[i] < nums[i - 1] + nums[i - 2])
                    {
                        // If a valid triangle exists, calculate and return its perimeter (the sum of its sides).
                        return nums[i] + nums[i - 1] + nums[i - 2];
                    }
                }

                // If no valid triangle can be formed from the given elements, indicate this with a return value of 0.
                return 0;

            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question:8

        Given two strings s and part, perform the following operation on s until all occurrences of the substring part are removed:

        Find the leftmost occurrence of the substring part and remove it from s.
        Return s after removing all occurrences of part.

        A substring is a contiguous sequence of characters in a string.

 

        Example 1:

        Input: s = "daabcbaabcbc", part = "abc"
        Output: "dab"
        Explanation: The following operations are done:
        - s = "daabcbaabcbc", remove "abc" starting at index 2, so s = "dabaabcbc".
        - s = "dabaabcbc", remove "abc" starting at index 4, so s = "dababc".
        - s = "dababc", remove "abc" starting at index 3, so s = "dab".
        Now s has no occurrences of "abc".
        Example 2:

        Input: s = "axxxxyyyyb", part = "xy"
        Output: "ab"
        Explanation: The following operations are done:
        - s = "axxxxyyyyb", remove "xy" starting at index 4 so s = "axxxyyyb".
        - s = "axxxyyyb", remove "xy" starting at index 3 so s = "axxyyb".
        - s = "axxyyb", remove "xy" starting at index 2 so s = "axyb".
        - s = "axyb", remove "xy" starting at index 1 so s = "ab".
        Now s has no occurrences of "xy".

        Constraints:

        1 <= s.length <= 1000
        1 <= part.length <= 1000
        s​​​​​​ and part consists of lowercase English letters.

        */

        public static string RemoveOccurrences(string s, string part)
        {
            try
            {
                // Create a placeholder to store the starting position of the 'part' substring within 's'.
                int index;

                // Iterate as long as 'part' is found within 's'.
                while ((index = s.IndexOf(part)) != -1)
                {
                    // If 'part' is found, proceed to remove it from 's'.
                    // - Use 'index' as the starting point for removal.
                    // - Remove 'part.Length' characters to cover the entire 'part' substring.
                    s = s.Remove(index, part.Length);
                }

                // Return the revised string after all instances of 'part' have been removed.
                return s;

            }
            catch (Exception)
            {
                throw;
            }
        }

        /* Inbuilt Functions - Don't Change the below functions */
        static string ConvertIListToNestedList(IList<IList<int>> input)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("["); // Add the opening square bracket for the outer list

            for (int i = 0; i < input.Count; i++)
            {
                IList<int> innerList = input[i];
                sb.Append("[" + string.Join(",", innerList) + "]");

                // Add a comma unless it's the last inner list
                if (i < input.Count - 1)
                {
                    sb.Append(",");
                }
            }

            sb.Append("]"); // Add the closing square bracket for the outer list

            return sb.ToString();
        }


        static string ConvertIListToArray(IList<int> input)
        {
            // Create an array to hold the strings in input
            string[] strArray = new string[input.Count];

            for (int i = 0; i < input.Count; i++)
            {
                strArray[i] = "" + input[i] + ""; // Enclose each string in double quotes
            }

            // Join the strings in strArray with commas and enclose them in square brackets
            string result = "[" + string.Join(",", strArray) + "]";

            return result;
        }
    }
}