
int[] nums = { 0 ,1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
int k = 10;
Console.WriteLine($"Max operations for nums = [{string.Join(", ", nums)}] and k = {k}: {new Solution().MaxOperations(nums, k)}");