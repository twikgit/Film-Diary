using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Domain.Models;

public partial class FilmDiaryContext : DbContext
{
    public FilmDiaryContext()
    {
    }

    public FilmDiaryContext(DbContextOptions<FilmDiaryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Actor> Actors { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Friendship> Friendships { get; set; }

    public virtual DbSet<FriendshipStatus> FriendshipStatuses { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Language> Languages { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    public virtual DbSet<MovieCast> MovieCasts { get; set; }

    public virtual DbSet<MovieRating> MovieRatings { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<StaffRole> StaffRoles { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<UserList> UserLists { get; set; }

    public virtual DbSet<UserListStatus> UserListStatuses { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Actor>(entity =>
        {
            entity.HasKey(e => e.ActorId).HasName("PK__Actor__E5771745101C27C0");

            entity.ToTable("Actor");

            entity.Property(e => e.ActorId).HasColumnName("Actor_id");
            entity.Property(e => e.Bio)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.BirthDate).HasColumnName("Birth_date");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("First_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Last_name");
            entity.Property(e => e.Nationality)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.PhotoUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Photo_url");

            entity.HasOne(d => d.NationalityNavigation).WithMany(p => p.Actors)
                .HasForeignKey(d => d.Nationality)
                .HasConstraintName("FK__Actor__Nationali__59FA5E80");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.CountryCode).HasName("PK__Country__73B286F47544956F");

            entity.ToTable("Country");

            entity.Property(e => e.CountryCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Country_code");
            entity.Property(e => e.CountryName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Country_name");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__8CB382B17C1748B9");

            entity.ToTable("Customer");

            entity.Property(e => e.CustomerId).HasColumnName("Customer_id");
            entity.Property(e => e.Avatar)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Banner)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Bio)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.BirthDate).HasColumnName("Birth_date");
            entity.Property(e => e.CountryCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Country_code");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_by");
            entity.Property(e => e.DeletedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("Deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("Deleted_by");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("First_name");
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Last_name");
            entity.Property(e => e.Pass).IsUnicode(false);
            entity.Property(e => e.RoleId).HasColumnName("Role_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("Updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("Updated_by");
            entity.Property(e => e.Username)
                .HasMaxLength(40)
                .IsUnicode(false);

            entity.HasOne(d => d.CountryCodeNavigation).WithMany(p => p.Customers)
                .HasForeignKey(d => d.CountryCode)
                .HasConstraintName("FK__Customer__Countr__3E52440B");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.InverseCreatedByNavigation)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK__Customer__Create__4316F928");

            entity.HasOne(d => d.DeletedByNavigation).WithMany(p => p.InverseDeletedByNavigation)
                .HasForeignKey(d => d.DeletedBy)
                .HasConstraintName("FK__Customer__Delete__44FF419A");

            entity.HasOne(d => d.Role).WithMany(p => p.Customers)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Customer__Role_i__3F466844");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.InverseUpdatedByNavigation)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("FK__Customer__Update__440B1D61");
        });

        modelBuilder.Entity<Friendship>(entity =>
        {
            entity.HasKey(e => new { e.RequesterId, e.AddresseeId }).HasName("PK__Friendsh__D58EA5D95B7E0C5D");

            entity.ToTable("Friendship");

            entity.Property(e => e.RequesterId).HasColumnName("Requester_id");
            entity.Property(e => e.AddresseeId).HasColumnName("Addressee_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Created_at");

            entity.HasOne(d => d.Addressee).WithMany(p => p.FriendshipAddressees)
                .HasForeignKey(d => d.AddresseeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Friendshi__Addre__48CFD27E");

            entity.HasOne(d => d.Requester).WithMany(p => p.FriendshipRequesters)
                .HasForeignKey(d => d.RequesterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Friendshi__Reque__47DBAE45");
        });

        modelBuilder.Entity<FriendshipStatus>(entity =>
        {
            entity.HasKey(e => new { e.RequesterId, e.AddresseeId, e.SpecifiedDatetime }).HasName("PK__Friendsh__48CE34DB9DA1E626");

            entity.ToTable("Friendship_Status");

            entity.Property(e => e.RequesterId).HasColumnName("Requester_id");
            entity.Property(e => e.AddresseeId).HasColumnName("Addressee_id");
            entity.Property(e => e.SpecifiedDatetime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Specified_datetime");
            entity.Property(e => e.SpecifiedId).HasColumnName("Specified_id");
            entity.Property(e => e.StatusCode)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Status_code");

            entity.HasOne(d => d.Specified).WithMany(p => p.FriendshipStatuses)
                .HasForeignKey(d => d.SpecifiedId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Friendshi__Speci__5070F446");

            entity.HasOne(d => d.StatusCodeNavigation).WithMany(p => p.FriendshipStatuses)
                .HasForeignKey(d => d.StatusCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Friendshi__Statu__778AC167");

            entity.HasOne(d => d.Friendship).WithMany(p => p.FriendshipStatuses)
                .HasForeignKey(d => new { d.RequesterId, d.AddresseeId })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FriendshipStatusToFriendship_FK");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.GenreId).HasName("Genre_PK");

            entity.ToTable("Genre");

            entity.Property(e => e.GenreId).HasColumnName("Genre_Id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Language>(entity =>
        {
            entity.HasKey(e => e.LanguageId).HasName("Language_PK");

            entity.ToTable("Language");

            entity.Property(e => e.LanguageId).HasColumnName("Language_Id");
            entity.Property(e => e.Code)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(e => e.MovieId).HasName("PK__Movie__7A89F80D328DAFCC");

            entity.ToTable("Movie");

            entity.Property(e => e.MovieId).HasColumnName("Movie_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_by");
            entity.Property(e => e.DeletedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("Deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("Deleted_by");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.IsAiring).HasColumnName("Is_Airing");
            entity.Property(e => e.PosterUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Poster_url");
            entity.Property(e => e.ReleaseDate).HasColumnName("Release_date");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("Updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("Updated_by");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.MovieCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK__Movie__Created_b__619B8048");

            entity.HasOne(d => d.DeletedByNavigation).WithMany(p => p.MovieDeletedByNavigations)
                .HasForeignKey(d => d.DeletedBy)
                .HasConstraintName("FK__Movie__Deleted_b__6383C8BA");

            entity.HasOne(d => d.RatingNavigation).WithMany(p => p.Movies)
                .HasForeignKey(d => d.Rating)
                .HasConstraintName("Movie_FK1");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.MovieUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("FK__Movie__Updated_b__628FA481");

            entity.HasMany(d => d.CountryCodes).WithMany(p => p.Movies)
                .UsingEntity<Dictionary<string, object>>(
                    "ProductionCountry",
                    r => r.HasOne<Country>().WithMany()
                        .HasForeignKey("CountryCode")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("Production_Country_FK2"),
                    l => l.HasOne<Movie>().WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("Production_Country_FK1"),
                    j =>
                    {
                        j.HasKey("MovieId", "CountryCode").HasName("Production_Country_PK");
                        j.ToTable("Production_Country");
                        j.IndexerProperty<int>("MovieId").HasColumnName("Movie_Id");
                        j.IndexerProperty<string>("CountryCode")
                            .HasMaxLength(2)
                            .IsUnicode(false)
                            .IsFixedLength()
                            .HasColumnName("Country_code");
                    });

            entity.HasMany(d => d.Genres).WithMany(p => p.Movies)
                .UsingEntity<Dictionary<string, object>>(
                    "MovieGenre",
                    r => r.HasOne<Genre>().WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("Movie_Genres_FK2"),
                    l => l.HasOne<Movie>().WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("Movie_Genres_FK1"),
                    j =>
                    {
                        j.HasKey("MovieId", "GenreId").HasName("Movie_Genres_PK");
                        j.ToTable("Movie_Genres");
                        j.IndexerProperty<int>("MovieId").HasColumnName("Movie_Id");
                        j.IndexerProperty<int>("GenreId").HasColumnName("Genre_Id");
                    });

            entity.HasMany(d => d.Languages).WithMany(p => p.Movies)
                .UsingEntity<Dictionary<string, object>>(
                    "MovieLanguage",
                    r => r.HasOne<Language>().WithMany()
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("Movie_Languages_FK2"),
                    l => l.HasOne<Movie>().WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("Movie_Languages_FK1"),
                    j =>
                    {
                        j.HasKey("MovieId", "LanguageId").HasName("Movie_Languages_PK");
                        j.ToTable("Movie_Languages");
                        j.IndexerProperty<int>("MovieId").HasColumnName("Movie_Id");
                        j.IndexerProperty<int>("LanguageId").HasColumnName("Language_Id");
                    });
        });

        modelBuilder.Entity<MovieCast>(entity =>
        {
            entity.HasKey(e => new { e.ActorId, e.MovieId }).HasName("PK__Movie_Ca__22DF88C5305CD3F4");

            entity.ToTable("Movie_Cast");

            entity.Property(e => e.ActorId).HasColumnName("Actor_id");
            entity.Property(e => e.MovieId).HasColumnName("Movie_id");
            entity.Property(e => e.CharacterName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Character_name");

            entity.HasOne(d => d.Actor).WithMany(p => p.MovieCasts)
                .HasForeignKey(d => d.ActorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Movie_Cas__Actor__6B24EA82");

            entity.HasOne(d => d.Movie).WithMany(p => p.MovieCasts)
                .HasForeignKey(d => d.MovieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Movie_Cas__Movie__6C190EBB");
        });

        modelBuilder.Entity<MovieRating>(entity =>
        {
            entity.HasKey(e => e.MovieRatingId).HasName("Movie_Rating_PK");

            entity.ToTable("Movie_Rating");

            entity.Property(e => e.MovieRatingId).HasColumnName("Movie_Rating_Id");
            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.ReviewId).HasName("Review_PK");

            entity.ToTable("Review");

            entity.Property(e => e.ReviewId).HasColumnName("Review_Id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_by");
            entity.Property(e => e.CustomerId).HasColumnName("Customer_Id");
            entity.Property(e => e.DeletedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("Deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("Deleted_by");
            entity.Property(e => e.MovieId).HasColumnName("Movie_Id");
            entity.Property(e => e.ReviewContent)
                .HasMaxLength(8000)
                .IsUnicode(false)
                .HasColumnName("Review_Content");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("Updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("Updated_by");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ReviewCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Review__Created___71D1E811");

            entity.HasOne(d => d.Customer).WithMany(p => p.ReviewCustomers)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Review_FK1");

            entity.HasOne(d => d.DeletedByNavigation).WithMany(p => p.ReviewDeletedByNavigations)
                .HasForeignKey(d => d.DeletedBy)
                .HasConstraintName("FK__Review__Deleted___73BA3083");

            entity.HasOne(d => d.Movie).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.MovieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Review_FK2");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.ReviewUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("FK__Review__Updated___72C60C4A");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Role__D80BB0938ABB21FC");

            entity.ToTable("Role");

            entity.Property(e => e.RoleId).HasColumnName("Role_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Created_at");
            entity.Property(e => e.DeletedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("Deleted_at");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("Updated_at");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("PK__Staff__32D2E85B7C4AD946");

            entity.Property(e => e.StaffId).HasColumnName("Staff_id");
            entity.Property(e => e.Bio)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.BirthDate).HasColumnName("Birth_date");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("First_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Last_name");
            entity.Property(e => e.Nationality)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.StaffRoleId).HasColumnName("Staff_role_id");

            entity.HasOne(d => d.NationalityNavigation).WithMany(p => p.Staff)
                .HasForeignKey(d => d.Nationality)
                .HasConstraintName("FK__Staff__Nationali__0B91BA14");

            entity.HasOne(d => d.StaffRole).WithMany(p => p.Staff)
                .HasForeignKey(d => d.StaffRoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Staff__Staff_rol__0C85DE4D");

            entity.HasMany(d => d.Movies).WithMany(p => p.Staff)
                .UsingEntity<Dictionary<string, object>>(
                    "MovieStaff",
                    r => r.HasOne<Movie>().WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Movie_Sta__Movie__68487DD7"),
                    l => l.HasOne<Staff>().WithMany()
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Movie_Sta__Staff__03F0984C"),
                    j =>
                    {
                        j.HasKey("StaffId", "MovieId").HasName("PK__Movie_St__F57A77DBD029D42B");
                        j.ToTable("Movie_Staff");
                        j.IndexerProperty<int>("StaffId").HasColumnName("Staff_id");
                        j.IndexerProperty<int>("MovieId").HasColumnName("Movie_id");
                    });
        });

        modelBuilder.Entity<StaffRole>(entity =>
        {
            entity.HasKey(e => e.StaffRoleId).HasName("PK__Staff_Ro__337A625B3241C4E4");

            entity.ToTable("Staff_Role");

            entity.Property(e => e.StaffRoleId).HasColumnName("Staff_role_id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.StatusCode).HasName("PK__Status__A3EABA77740422EB");

            entity.ToTable("Status");

            entity.Property(e => e.StatusCode)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Status_code");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UserList>(entity =>
        {
            entity.HasKey(e => new { e.CustomerId, e.MovieId }).HasName("User_List_PK");

            entity.ToTable("User_List");

            entity.Property(e => e.CustomerId).HasColumnName("Customer_Id");
            entity.Property(e => e.MovieId).HasColumnName("Movie_Id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_by");
            entity.Property(e => e.DeletedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("Deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("Deleted_by");
            entity.Property(e => e.IsFavorite).HasColumnName("Is_Favorite");
            entity.Property(e => e.MovieScore).HasColumnName("Movie_Score");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("Updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("Updated_by");
            entity.Property(e => e.UserListStatusId).HasColumnName("User_List_Status_Id");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.UserListCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("User_List_FK4");

            entity.HasOne(d => d.Customer).WithMany(p => p.UserListCustomers)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("User_List_FK1");

            entity.HasOne(d => d.DeletedByNavigation).WithMany(p => p.UserListDeletedByNavigations)
                .HasForeignKey(d => d.DeletedBy)
                .HasConstraintName("User_List_FK6");

            entity.HasOne(d => d.Movie).WithMany(p => p.UserLists)
                .HasForeignKey(d => d.MovieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("User_List_FK2");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.UserListUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("User_List_FK5");

            entity.HasOne(d => d.UserListStatus).WithMany(p => p.UserLists)
                .HasForeignKey(d => d.UserListStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("User_List_FK3");
        });

        modelBuilder.Entity<UserListStatus>(entity =>
        {
            entity.HasKey(e => e.UserListStatusId).HasName("User_List_Status_PK");

            entity.ToTable("User_List_Status");

            entity.Property(e => e.UserListStatusId).HasColumnName("User_List_Status_Id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
