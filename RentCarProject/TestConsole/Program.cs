using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
        }
    }
}
