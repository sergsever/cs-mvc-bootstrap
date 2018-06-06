namespace testagat
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TaskComments
    {
        [Key]
        public int TaskCommentID { get; set; }

        public int TaskID { get; set; }

        public int UserID { get; set; }

        [StringLength(2000)]
        public string CommentText { get; set; }

        public virtual Tasks Task { get; set; }

        public virtual Users User { get; set; }
    }
}
