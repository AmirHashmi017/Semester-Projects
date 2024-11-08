using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solitair_Game
{
    public class HashMap
    {
        public  (string key,int value)?[] buckets;
        public int tablesize;
        public HashMap(int size)
        {
            buckets = new (string, int)?[size];
            this.tablesize = size;
        }
        public void Hash(string key,int value)
        {
            int index=(CalculateAscii(key))%tablesize;
            if (buckets[index]==null)
            {
                buckets[index]=(key,value);
            }
            else
            {
                DoubleHashing(index, key, value);
            }
        }
        public int GetDoubleHash(string key)
        {
            return 7-((CalculateAscii(key))%7);
        }
        public void DoubleHashing(int index,string key,int value)
        {
            for(int i=1;i<=tablesize;i++)
            {
                int newindex = (index + i * GetDoubleHash(key)) % tablesize;
                if (buckets[newindex] == null)
                {
                    buckets[newindex] = (key, value);
                    break;
                }
            }
        }
        public int GetValue(string key)
        {
            int index=CalculateAscii(key)%tablesize;
            if (buckets[index].HasValue && buckets[index].Value.key ==key)
            {
                return buckets[index].Value.value;
            }
            else
            {
                return GetValueByDoubleHashing(index, key);
            }
        }
        public int GetValueByDoubleHashing(int index, string key)
        {
            for (int i = 1; i <= tablesize; i++)
            {
                int newindex = (index + i*GetDoubleHash(key)) % tablesize;
                if (buckets[newindex].HasValue && buckets[newindex].Value.key == key)
                {
                    return buckets[newindex].Value.value;
                }
            }
            return -1;
        }
        public int CalculateAscii(string key)
        {
            int asciicode = 0;
            foreach (char character in key)
            {
                asciicode += (int)character;
            }
            return asciicode;
        }
    }
}
