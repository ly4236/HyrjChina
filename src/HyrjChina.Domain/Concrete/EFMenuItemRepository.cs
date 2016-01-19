using HyrjChina.Domain.Abstarct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HyrjChina.Domain.Entities;

namespace HyrjChina.Domain.Concrete
{
    public class EFMenuItemRepository : IMenuItemRepository
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<MenuItem> MenuItems
        {
            get { return context.MenuItems; }
        }

        public MenuItem DeleteMenuItem(int ID)
        {

            MenuItem dbEntry = context.MenuItems.Find(ID);
            if (dbEntry != null)
            {
                context.MenuItems.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        public void SaveMenuItem(MenuItem menuItem)
        {
            if (menuItem.ID == 0)
            {
                context.MenuItems.Add(menuItem);
            }
            else {
                MenuItem dbEntry = context.MenuItems.Find(menuItem.ID);
                if (dbEntry != null)
                {
                    dbEntry.ActionName = menuItem.ActionName;
                    dbEntry.ControllerName = menuItem.ControllerName;
                    dbEntry.Disable = menuItem.Disable;
                    dbEntry.HasAccess = menuItem.HasAccess;
                    dbEntry.Name = menuItem.Name;
                    dbEntry.Order = menuItem.Order;
                    dbEntry.ParentMenuID = menuItem.ParentMenuID;
                    dbEntry.Url = menuItem.Url;
                    dbEntry.Level = menuItem.Level;
                    dbEntry.Icon = menuItem.Icon;
                }
            }
            context.SaveChanges();
        }
    }
}
