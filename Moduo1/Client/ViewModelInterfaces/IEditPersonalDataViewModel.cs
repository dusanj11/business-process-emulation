using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModelInterfaces
{
    public interface IEditPersonalDataViewModel
    {
        string Name();

        string Surname();

        string Username();

        void Name(string name);

        void Surname(string surname);

        void Username(string username);
    }
}
