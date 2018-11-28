using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace levenshtein_distance
{
    public static class Editdistance
    {
        public static int levenshtein(string original, string modified)
        {
            int len_orig = original.Length;
            int len_diff = modified.Length;

            var matrix = new int[len_orig + 1, len_diff + 1];
            for (int i = 0; i <= len_orig; i++)
                matrix[i, 0] = i;
            for (int j = 0; j <= len_diff; j++)
                matrix[0, j] = j;

            for (int i = 1; i <= len_orig; i++)
            {
                for (int j = 1; j <= len_diff; j++)
                {
                    int cost = modified[j - 1] == original[i - 1] ? 0 : 1; 
                    var vals = new int[] {
					matrix[i - 1, j] + 1, //delete
					matrix[i, j - 1] + 1, //insert
					matrix[i - 1, j - 1] + cost //subs
				};
                    matrix[i, j] = vals.Min();
                    if (i > 1 && j > 1 && original[i - 1] == modified[j - 2] && original[i - 2] == modified[j - 1])
                        matrix[i, j] = Math.Min(matrix[i, j], matrix[i - 2, j - 2] + cost);
                }
            }
            return matrix[len_orig, len_diff];
        }
    }
}
/*
This is Regarding ur answer this: Damerau - Levenshtein Distance, adding a threshold (sorry can't comment as I don't have 50 rep yet)

I think you have made an error here. You initialized:

var minDistance = threshold;
And ur update rule is:

if (d[i, j] < minDistance)
   minDistance = d[i, j];
Also, ur early exit criteria is:

if (minDistance > threshold)
   return int.MaxValue;
Now, observe that the if condition above will never hold true! You should rather initialize minDistance to int.MaxValue
*/