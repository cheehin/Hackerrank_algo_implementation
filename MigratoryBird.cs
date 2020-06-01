using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution {

    // Complete the migratoryBirds function below.
    static int migratoryBirds(List<int> arr) {
        List<int> darr = arr.Select(i => i).Distinct().ToList();
            List<KeyValuePair<int,int>> ky = new List<KeyValuePair<int,int>>();
            for(int i = 0; i < darr.Count; i++)
            {
                int count = 0;
                for(int j = 0; j < arr.Count; j++)
                {
                    if (darr[i] == arr[j])
                    {
                        count++;
                    }
                }
                ky.Add(new KeyValuePair<int, int>(darr[i], count));
            }
            var pair = ky.OrderByDescending(x => x.Value).First();
            for(int i=0;i<ky.Count;i++){
                if(ky[i].Value==pair.Value && ky[i].Key<pair.Key){
                    pair = new KeyValuePair<int, int>(ky[i].Key,ky[i].Value);
                }
            }
            return pair.Key;

    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int arrCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        int result = migratoryBirds(arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
