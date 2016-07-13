﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GuestbookAPI.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Content { get; set; }


        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime PostedAt { get; set; }

    }
}
