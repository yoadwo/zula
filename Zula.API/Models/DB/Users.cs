using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zula.API.Models
{
    public class Users
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<UserLists> Lists { get; set; }
    }
}
