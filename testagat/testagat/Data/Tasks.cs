namespace testagat
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tasks
    {
        public Tasks()
        {
//            TaskComments = new HashSet<TaskComments>();
//            UserTask = new HashSet<UserTask>();

//            CreateDate = DateTime.Now;
        }

        [Key]
        public virtual int TaskID { get; set; }
        [Required]
        public virtual DateTime CreateDate { get; set; }
          public virtual Users Creator {get;set;}
        public virtual Users Executor { get; set;}

        [Required]
        [StringLength(128)]
        public virtual string Title { get; set; }

        [Required]
        [StringLength(256)]
        public virtual string Description { get; set; }

    }
}
