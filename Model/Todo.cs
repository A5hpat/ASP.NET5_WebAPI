using System;
using System.ComponentModel.DataAnnotations;
namespace webapiAPP.Model
{
    public class Todo
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public bool IsDone { get; set; }

    }
}