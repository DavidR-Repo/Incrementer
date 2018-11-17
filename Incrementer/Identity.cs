using System;

namespace Incrementer
{
    public class Identity
    {
        public char[] Value { get; set; }
        private bool[] isNumber = { true, true, true };

        public Identity(string newId)
        {
            if (newId.Length > 3) throw new Exception("invalid id length");
            if (!IsValidChar(newId)) throw new Exception("invalid id " + newId);

            Value = new char[] { newId[0], newId[1], newId[2] };

            if (Value[0] >= '9')
            {
                isNumber[0] = false;
            }
            if (Value[0] == 'Z' && Value[1] >= '9')
            {
                isNumber[1] = false;
            }
            if (Value[0] == 'Z' && Value[1] == 'Z' && Value[2] <= '9')
            {
                isNumber[2] = false;
            }
        }


        public void Increment(int pos = 2)
        {
            if (pos > 2 || pos < 0) throw new Exception("invalid position");

            if(isNumber[pos])
            {
                NumericIncrement(pos);
            }
            else
            {
                AlphaIncrement(pos);
            }

            if (Value[0] == 'Z' && Value[1] == 'Z' &&  Value[2] == '9')
            {
                isNumber[2] = false;
            }
            else if (Value[0] == 'Z' && Value[1] == '9')
            {
                isNumber[1] = false;
            }
            else if(Value[0] == '9')
            {
                isNumber[0] = false;
            }
        }

        void AlphaIncrement(int pos)
        {
            if(Value[pos] == '9')
            {
                Value[pos] = 'A';
                return;
            }
            else if(Value[pos] < 'Z')
            {
                Value[pos]++;
                return;
            }

            throw new Exception(@"invalid position: cannot increment a 'Z'");
        }

        void NumericIncrement(int pos)
        {
            if(Value[pos] < '9')
            {
                Value[pos]++;
                return;
            }
            else if(Value[pos] == '9' && !isNumber[pos])
            {
                Value[pos] = 'A';
                return;
            }
            Value[pos] = '0';
            Increment(pos - 1);
        }
        
        public void Set(string newId)
        {
            if (newId.Length > 3) throw new Exception("in Set: invalid id length");
            if (!IsValidChar(newId)) throw new Exception("in Set(): invalid id " + newId);

            Value[0] = newId[0];
            Value[1] = newId[1];
            Value[2] = newId[2];
        }

        private bool IsValidChar(string value)
        {
            for (int i = 0; i < value.Length; i++)
            {
                if (value[i] < '0' || 
                    value[i] > 'Z' ||
                    (value[i] > '9' && value[i] < 'A'))
                    return false;
            }
            return true;
        }

        public override string ToString()
        {
            return $"{Value[0]}{Value[1]}{Value[2]}";
        }
    }
}
