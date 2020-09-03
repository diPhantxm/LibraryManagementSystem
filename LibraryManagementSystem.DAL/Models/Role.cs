using LibraryManagementSystem.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.DAL.Models
{
    public class Role : IEntity
    {
        public int Id { get; set; }
        public virtual ICollection<Reader> Readers { get; set; }
        public string Name { get; set; }

        public Role(string name)
        {
            Name = name;
        }
        public Role()
        {
            Readers = new List<Reader>();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
