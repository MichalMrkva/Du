using System;

namespace Du
{
    public class OnCreationListener<T>
    {
        public void Heard(T value)
        {
            Console.WriteLine($"Created new [{value.GetType()}]: \n{value}");
        }
    }
}
