using System;
using System.Collections.Generic;
using System.IO;

class Solution
{
    /*
     * Complete the dynamicArray function below.
     */
    static int[] dynamicArray(int n, int[][] queries)
    {
        int lastAnswer = 0;
        List<int> results = new List<int>();

        List<List<int>> sequences = new List<List<int>>();
        for (var i = 0; i < n; i++)
        {
            sequences.Add(new List<int>());
        }

        for (int i = 0; i < queries.Length; i++)
        {
            int[] currentQuery = queries[i];
            int queryType = currentQuery[0];
            int x = currentQuery[1];
            int y = currentQuery[2];

            int seqNumber = (x ^ lastAnswer) % n;
            var currentSeq = sequences[seqNumber];
            if (queryType == 1)
            {
                currentSeq.Add(y);
            }
            else
            {
                lastAnswer = currentSeq[y % currentSeq.Count];
                results.Add(lastAnswer);
            }
        }

        return results.ToArray();
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] nq = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(nq[0]);

        int q = Convert.ToInt32(nq[1]);

        int[][] queries = new int[q][];

        for (int queriesRowItr = 0; queriesRowItr < q; queriesRowItr++)
        {
            queries[queriesRowItr] = Array.ConvertAll(
                Console.ReadLine().Split(' '),
                queriesTemp => Convert.ToInt32(queriesTemp));
        }

        int[] result = dynamicArray(n, queries);

        textWriter.WriteLine(string.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}