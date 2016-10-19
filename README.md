# CodeChallenges
A general reference for [me](http://www.linkedin.com/in/nortonpengra) for learning.
Some things stolen from codewars with some other algorithms mixed in.

# Kadane's Algoirthm O(n)
[better examplanation](http://www.geeksforgeeks.org/largest-sum-contiguous-subarray/)

If you pass an empty array into the function, it will return `None`.
It will first set `largest_record` and `largest_so_far` to the first item of your array.
Then it will iterate through the rest of the array and set `largest_so_far` to either the sum of the array up to `i` or the sum of the array including `i`. Then set `largest_record` to either itself, or `largest_so_far`.

# Levenshtein's Distance O(log n)
[example in use](https://www.codewars.com/kata/did-you-mean-dot-dot-dot/solutions?show-solutions=1)
An algorithm for calculating how close a word is to another. Starts by chiseling things from the end.

# Deep Copy of Linked List O(n)
[source](https://gist.github.com/qwergram/f6cb9848dd67e528bea1bb7a299fad52)
I actually got this problem at a Microsoft Tech Screening. I was unable to solve it the first time on a whiteboard, but later re-wrote it here so I could sleep at night.

The problem is this: You have a singly linked list with a pointer at the next item, and a random pointer that could point to another node in the list, itself, or null. Make a deep copy of this linked list.
