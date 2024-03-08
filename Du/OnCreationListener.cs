using System;

namespace Du
{
    public class OnCreationListener<T>
    {
        public void HeardCreation(T value)
        {
            Console.WriteLine($"Created new [{value.GetType()}]: \n{value.ToString()}");
        }
    }
}
