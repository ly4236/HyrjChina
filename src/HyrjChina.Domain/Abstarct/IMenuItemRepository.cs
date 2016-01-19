using HyrjChina.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyrjChina.Domain.Abstarct
{
    public interface IMenuItemRepository
    {
        IEnumerable<MenuItem> MenuItems { get; }

        void SaveMenuItem(MenuItem menuItem);

        MenuItem DeleteMenuItem(int ID);
        
    }
}
