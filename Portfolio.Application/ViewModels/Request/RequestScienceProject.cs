using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.ViewModels.Request
{
    public class RequestScienceProject
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public DateOnly BeginTimeWork { get; set; } = DateOnly.FromDateTime(DateTimeOffset.Now.DateTime);
		public DateOnly? EndTimeWork { get; set; }
        public bool Director { get; set; }
    }
}
