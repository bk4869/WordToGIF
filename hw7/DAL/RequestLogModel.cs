namespace hw7.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class RequestLogModel : DbContext
    {
        public RequestLogModel()
            : base("name=RequestLogModel1")
        {
        }

        public virtual DbSet<RLModel> RLModel { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
