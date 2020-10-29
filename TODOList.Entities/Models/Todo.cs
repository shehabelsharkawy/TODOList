using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODOList.Entities.Models
{
    public class Todo
    {
        public int Id { get; set; }

        public string TodoTitle { get; set; }

        public DateTime DueDate { get; set; }

        public string UserId { get; set; }
    }
}
