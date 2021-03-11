using System;
using System.Collections.Generic;
using System.Text;

namespace Module13
{
    // Класс был изменен. Поле Name мы убрали,
    // так как оно теперь будет ключом
    // для поиска значений в словаре
    public class Contact // модель класса
    {
        public Contact(long phoneNumber, String email) // метод-конструктор
        {
            PhoneNumber = phoneNumber;
            Email = email;
        }
        public long PhoneNumber { get; set; }
        public String Email { get; set; }
    }
}
