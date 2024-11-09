using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solitair_Game
{
    //HashMap class for implementing Hashing with Open Addressing scheme Double Hashing.
    public class HashMap
    {
        public  (string key,int value)?[] buckets;
        public int tablesize;
        public HashMap(int size)
        {
            buckets = new (string, int)?[size];
            this.tablesize = size;
        }

        //Function for hashing values to Hashtable.
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

        //Function for getting index of hashtable for double hashing.
        public int GetDoubleHash(string key)
        {
            return 7-((CalculateAscii(key))%7);
        }

        //Function for Double Hashing in case of collision.
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

        //Function for getting value based on key.
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

        //Function for getting value based on key in case of collision.
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

        //Function for calculating ASCII code of key.
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
