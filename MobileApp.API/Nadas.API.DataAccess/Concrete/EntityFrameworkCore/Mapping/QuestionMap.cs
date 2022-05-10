﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nadas.API.Entities.Concrete;

namespace Nadas.API.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class QuestionMap : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.Property(I => I.Title).HasMaxLength(500).IsRequired();
            builder.Property(I => I.Rate).HasDefaultValue(0);
            builder.Property(I => I.ViewCount).HasDefaultValue(0);

            builder.Property(I => I.CreationDate).HasDefaultValue(DateTime.UtcNow);
            builder.Property(I => I.UpdateDate).HasDefaultValue(DateTime.UtcNow);
            builder.Property(I => I.ViewCount).HasDefaultValue(0);
            builder.Property(I => I.IsDeleted).HasDefaultValue(false);


            builder.HasMany(I => I.Tags).WithMany(I => I.Questions);
        }
    }
}
