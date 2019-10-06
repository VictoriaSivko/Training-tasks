using System;

namespace BLL.Interface.Entities.Helper
{
    /// <summary>
    /// Account holder information
    /// </summary>
    public class AccountOwner
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }

        public AccountOwner(string name, string surname)
        {
            if (name == null || surname == null)
                throw new ArgumentNullException();

            Name = name;
            Surname = surname;
        }

        public override string ToString()
        {
            return Name + " " + Surname;
        }
    }
}
