using DefaultUnDo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace lab4_5.Classes
{
    public class UndoRedoManager
    {
        private UnDoManager unDoManager;
        public ObservableCollection<string> Tickets { get; set; }

        public UndoRedoManager(ObservableCollection<string> strings)
        {
            unDoManager = new UnDoManager();
            Tickets = strings;
        }


        //public ObservableCollection<Ticket> StateManager
        //{
        //    get => Tickets;
        //    set => SetProperty()
        //}

        public void AddItem(string item)
        {
            unDoManager.Do(
                () => Tickets.Add(item),
                () => Tickets.Remove(item));
        }

        public void RemoveItem(string item)
        {
            unDoManager.Do(
                () => Tickets.Remove(item),
                () => Tickets.Add(item));
        }
    }
}
