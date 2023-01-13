using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Models
{
    public class Department{
        public int Id{get;set;}

        [DisplayName("Department Name")]
        public string? Name{get;set;}
        
        [DisplayName("Department Location")]
        public string? Location{get;set;}

    }
}