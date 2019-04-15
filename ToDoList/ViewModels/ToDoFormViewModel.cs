using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ToDoList.ViewModels
{
    public class ToDoFormViewModel
    {
        [Required]
        public string ToDoComment { get; set; }

        [FutureDate]
        public String Date { get; set; }

        public String Time { get; set; }

        public DateTime GetDateTime()
        {
            return DateTime.Parse(string.Format("{0} {1}", Date, Time));
        }
    }
}