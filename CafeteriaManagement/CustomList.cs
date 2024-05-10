using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaManagement
{
    public partial class CustomList<Type>
    {
        private int _count;
        private int _capacity;
        public int Count { get{return _count;} }
        public int Capacity { get{return _capacity;} }
        private Type[] _array;
        
        public Type this[int index]
        {
            get{return _array[index];}
            set{_array[index]= value;}
        }
        public CustomList()
        {
            _count=0;
            _capacity=4;
            _array=new Type[_capacity];
        }
        public CustomList(int size)
        {
            _count=0;
            _capacity=size;
            _array=new Type[_capacity];
        }
        public void Add(Type element)
        {
            if(_count==_capacity)
            {
                GrowSize();
            }
            _array[_count++]=element;
        }
        public void GrowSize()
        {
            _capacity*=2;
            Type[] temp=new Type[_capacity];
            for(int i=0;i<_count;i++)
            {
                temp[i]=_array[i];
            }
            _array=temp;
        }
        public void AddRange(CustomList<Type> elements)
        {
            _capacity=_count+elements.Count;
            Type[] temp=new Type[_capacity];
            for(int i=0;i<_count;i++)
            {
                temp[i]=_array[i];
            }
            int k=0;
            for(int i=_count;i<_capacity;i++)
            {
                temp[i]=elements[k++];
            }
            _array=temp;
            _count=_capacity;
        }

        public bool Contains(Type element)
        {
            bool IsFlag=false;
            foreach(Type data in _array)
            {
                if(data.Equals(element))
                {
                    IsFlag=true;
                }
            }
            return IsFlag;
        }

        public int IndexOf(Type element)
        {
            int position=-1;
            for(int i=0;i<_count;i++)
            {
                if(_array[i].Equals(element))
                {
                    position=i;
                    break;
                }
            }
            return position;
        }

        public void Sort()
        {
            for(int i=0;i<_count-1;i++)
            {
                for(int j=0;j<_capacity-1;i++)
                {
                    if(IsGreater(_array[j],_array[j+1]))
                    {
                        Type temp=_array[j+1];
                        _array[j+1]=_array[j];
                        _array[j]=temp;
                    }
                }
            }
        }

        public bool IsGreater(Type value1, Type value2)
        {
            int result=Comparer<Type>.Default.Compare(value1,value2);
            if(result>0)
            {
                return true;
            }
            return false;
        }
        public void Reverse()
        {
            Type[] temp=new Type[_capacity];
            int j=0;
            for(int i=_count-1;i>=0;i--)
            {
                temp[j++]=_array[i];
            }
            _array=temp;
        }
    }
}