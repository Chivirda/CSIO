using System.Collections.Generic;

static class Sort
{
    public static List<int> bubbleSort(List<int> list)
        {
            int temp;
            for(int i = 0; i < list.Count; i++)
            {
                for(int j = i + 1; j < list.Count; j++)
                {
                    if(list[i] > list[j])
                    {
                        temp = list[i];
                        list[i] = list[j];
                        list[j] = temp;
                    }
                }
            }
            return list;
        }
}