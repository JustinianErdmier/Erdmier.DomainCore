using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demo.Core.Persistence.Configurations;

public sealed class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        ConfigureBookTable(builder);
        ConfigureBookAuthorsTable(builder);
    }

    private static void ConfigureBookTable(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable(name: "Books");

        builder.HasKey(b => b.Id);

        builder.Property(b => b.Id)
               .ValueGeneratedNever()
               .HasConversion(id => id.Value,
                              value => BookId.Create(value));

        builder.Property(b => b.Title)
               .HasMaxLength(maxLength: 250)
               .IsRequired();
    }

    private static void ConfigureBookAuthorsTable(EntityTypeBuilder<Book> builder)
    {
        builder.OwnsMany(b => b.Authors,
                         ab =>
                         {
                             ab.ToTable(name: "BookAuthors");

                             ab.WithOwner()
                               .HasForeignKey("BookId");

                             ab.HasKey("Id", "BookId");

                             ab.Property(ba => ba.Id)
                               .HasColumnName(name: "BookAuthorId")
                               .ValueGeneratedNever()
                               .HasConversion(id => id.Value,
                                              value => AuthorId.Create(value));

                             ab.Property(a => a.Name)
                               .HasMaxLength(maxLength: 50)
                               .IsRequired();
                         });

        builder.Metadata.FindNavigation(nameof(Book.Authors))
            !.SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}
