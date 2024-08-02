using System;
using System.Collections.Generic;
using BookMovieTicket.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace BookMovieTicket.Data;

public partial class MoviesDbContext : DbContext
{
    public MoviesDbContext()
    {
    }

    public MoviesDbContext(DbContextOptions<MoviesDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AuthGroup> AuthGroups { get; set; }

    public virtual DbSet<AuthGroupPermission> AuthGroupPermissions { get; set; }

    public virtual DbSet<AuthPermission> AuthPermissions { get; set; }

    public virtual DbSet<DjangoAdminLog> DjangoAdminLogs { get; set; }

    public virtual DbSet<DjangoContentType> DjangoContentTypes { get; set; }

    public virtual DbSet<DjangoMigration> DjangoMigrations { get; set; }

    public virtual DbSet<DjangoSession> DjangoSessions { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    public virtual DbSet<MovieAdditionalInfo> MovieAdditionalInfos { get; set; }

    public virtual DbSet<MovieDetail> MovieDetails { get; set; }

    public virtual DbSet<MovieRating> MovieRatings { get; set; }

    public virtual DbSet<UserDataGroup> UserDataGroups { get; set; }

    public virtual DbSet<UserDataUserPermission> UserDataUserPermissions { get; set; }

    public virtual DbSet<UserData> UserData { get; set; }
    
    public DbSet<MovieTheater> MovieTheaters => Set<MovieTheater>();

    public DbSet<Reservation> Reservations => Set<Reservation>();

    public DbSet<ScreenShowMapper> ScreenShowMappers => Set<ScreenShowMapper>();
    public DbSet<Seat> Seats => Set<Seat>();
    public DbSet<Show> Shows => Set<Show>();
    public DbSet<TheatreScreen> TheatreScreens => Set<TheatreScreen>();
    public DbSet<TicketPrice> TicketPrices => Set<TicketPrice>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=EFConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AuthGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__auth_gro__3213E83FF1BD8F98");

            entity.ToTable("auth_group", t => t.ExcludeFromMigrations());

            entity.HasIndex(e => e.Name, "auth_group_name_a6ea08ec_uniq").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .HasColumnName("name");
        });

        modelBuilder.Entity<AuthGroupPermission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__auth_gro__3213E83FB09A66FF");

            entity.ToTable("auth_group_permissions", t => t.ExcludeFromMigrations());

            entity.HasIndex(e => e.GroupId, "auth_group_permissions_group_id_b120cbf9");

            entity.HasIndex(e => new { e.GroupId, e.PermissionId }, "auth_group_permissions_group_id_permission_id_0cd325b0_uniq")
                .IsUnique()
                .HasFilter("([group_id] IS NOT NULL AND [permission_id] IS NOT NULL)");

            entity.HasIndex(e => e.PermissionId, "auth_group_permissions_permission_id_84c5c92e");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.GroupId).HasColumnName("group_id");
            entity.Property(e => e.PermissionId).HasColumnName("permission_id");

            entity.HasOne(d => d.Group).WithMany(p => p.AuthGroupPermissions)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("auth_group_permissions_group_id_b120cbf9_fk_auth_group_id");

            entity.HasOne(d => d.Permission).WithMany(p => p.AuthGroupPermissions)
                .HasForeignKey(d => d.PermissionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("auth_group_permissions_permission_id_84c5c92e_fk_auth_permission_id");
        });

        modelBuilder.Entity<AuthPermission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__auth_per__3213E83F031067FE");

            entity.ToTable("auth_permission", t => t.ExcludeFromMigrations());

            entity.HasIndex(e => e.ContentTypeId, "auth_permission_content_type_id_2f476e4b");

            entity.HasIndex(e => new { e.ContentTypeId, e.Codename }, "auth_permission_content_type_id_codename_01ab375a_uniq")
                .IsUnique()
                .HasFilter("([content_type_id] IS NOT NULL AND [codename] IS NOT NULL)");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Codename)
                .HasMaxLength(100)
                .HasColumnName("codename");
            entity.Property(e => e.ContentTypeId).HasColumnName("content_type_id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");

            entity.HasOne(d => d.ContentType).WithMany(p => p.AuthPermissions)
                .HasForeignKey(d => d.ContentTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("auth_permission_content_type_id_2f476e4b_fk_django_content_type_id");
        });

        modelBuilder.Entity<DjangoAdminLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__django_a__3213E83FDAD6135B");

            entity.ToTable("django_admin_log", t => t.ExcludeFromMigrations());

            entity.HasIndex(e => e.ContentTypeId, "django_admin_log_content_type_id_c4bce8eb");

            entity.HasIndex(e => e.UserId, "django_admin_log_user_id_c564eba6");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActionFlag).HasColumnName("action_flag");
            entity.Property(e => e.ActionTime).HasColumnName("action_time");
            entity.Property(e => e.ChangeMessage).HasColumnName("change_message");
            entity.Property(e => e.ContentTypeId).HasColumnName("content_type_id");
            entity.Property(e => e.ObjectId).HasColumnName("object_id");
            entity.Property(e => e.ObjectRepr)
                .HasMaxLength(200)
                .HasColumnName("object_repr");
            entity.Property(e => e.UserId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("user_id");

            entity.HasOne(d => d.ContentType).WithMany(p => p.DjangoAdminLogs)
                .HasForeignKey(d => d.ContentTypeId)
                .HasConstraintName("django_admin_log_content_type_id_c4bce8eb_fk_django_content_type_id");

            entity.HasOne(d => d.User).WithMany(p => p.DjangoAdminLogs)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("django_admin_log_user_id_c564eba6_fk_user_data_id");
        });

        modelBuilder.Entity<DjangoContentType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__django_c__3213E83F94A41AC2");

            entity.ToTable("django_content_type", t => t.ExcludeFromMigrations());

            entity.HasIndex(e => new { e.AppLabel, e.Model }, "django_content_type_app_label_model_76bd3d3b_uniq")
                .IsUnique()
                .HasFilter("([app_label] IS NOT NULL AND [model] IS NOT NULL)");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AppLabel)
                .HasMaxLength(100)
                .HasColumnName("app_label");
            entity.Property(e => e.Model)
                .HasMaxLength(100)
                .HasColumnName("model");
        });

        modelBuilder.Entity<DjangoMigration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__django_m__3213E83F714BCCAD");

            entity.ToTable("django_migrations", t => t.ExcludeFromMigrations());

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.App)
                .HasMaxLength(255)
                .HasColumnName("app");
            entity.Property(e => e.Applied).HasColumnName("applied");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<DjangoSession>(entity =>
        {
            entity.HasKey(e => e.SessionKey).HasName("PK__django_s__B3BA0F1F4ABC7EB4");

            entity.ToTable("django_session", t => t.ExcludeFromMigrations());

            entity.HasIndex(e => e.ExpireDate, "django_session_expire_date_a5c62663");

            entity.Property(e => e.SessionKey)
                .HasMaxLength(40)
                .HasColumnName("session_key");
            entity.Property(e => e.ExpireDate).HasColumnName("expire_date");
            entity.Property(e => e.SessionData).HasColumnName("session_data");
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(e => e.ImdbId).HasName("PK__Movies__F12E201A063D0A05");
            entity.ToTable("Movies", t => t.ExcludeFromMigrations());

            entity.Property(e => e.ImdbId)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("imdb_id");
            entity.Property(e => e.PosterPath)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("poster_path");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("title");
            entity.Property(e => e.WikiLink)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("wiki_link");
        });

        modelBuilder.Entity<MovieAdditionalInfo>(entity =>
        {
            entity.HasKey(e => e.ImdbId).HasName("PK__MovieAdd__F12E201AC120E64F");

            entity.ToTable("MovieAdditionalInfo", t => t.ExcludeFromMigrations());

            entity.Property(e => e.ImdbId)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("imdb_id");
            entity.Property(e => e.Actors)
                .IsUnicode(false)
                .HasColumnName("actors");
            entity.Property(e => e.ReleaseDate).HasColumnName("release_date");
            entity.Property(e => e.Story)
                .IsUnicode(false)
                .HasColumnName("story");
            entity.Property(e => e.Summary)
                .IsUnicode(false)
                .HasColumnName("summary");
            entity.Property(e => e.Tagline)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("tagline");
            entity.Property(e => e.WinsNominations)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("wins_nominations");

            entity.HasOne(d => d.Imdb).WithOne(p => p.AdditionalInfo)
                .HasForeignKey<MovieAdditionalInfo>(d => d.ImdbId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MovieAddi__imdb___787EE5A0");
        });

        modelBuilder.Entity<MovieDetail>(entity =>
        {
            entity.HasKey(e => e.ImdbId).HasName("PK__MovieDet__F12E201AE5A48D7E");
            entity.ToTable("MovieDetails", t => t.ExcludeFromMigrations());

            entity.Property(e => e.ImdbId)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("imdb_id");
            entity.Property(e => e.Genres)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("genres");
            entity.Property(e => e.IsAdult).HasColumnName("is_adult");
            entity.Property(e => e.OriginalTitle)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("original_title");
            entity.Property(e => e.Runtime).HasColumnName("runtime");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("title");
            entity.Property(e => e.YearOfRelease).HasColumnName("year_of_release");

            entity.HasOne(d => d.Imdb).WithOne(p => p.MovieDetail)
                .HasForeignKey<MovieDetail>(d => d.ImdbId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MovieDeta__imdb___6FE99F9F");
        });

        modelBuilder.Entity<MovieRating>(entity =>
        {
            entity.HasKey(e => e.ImdbId).HasName("PK__MovieRat__F12E201A146B6CED");
            entity.ToTable("MovieRatings", t => t.ExcludeFromMigrations());

            entity.Property(e => e.ImdbId)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("imdb_id");
            entity.Property(e => e.ImdbRating)
                .HasColumnType("decimal(3, 1)")
                .HasColumnName("imdb_rating");
            entity.Property(e => e.ImdbVotes).HasColumnName("imdb_votes");

            entity.HasOne(d => d.Imdb).WithOne(p => p.MovieRating)
                .HasForeignKey<MovieRating>(d => d.ImdbId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MovieRati__imdb___72C60C4A");
        });

        modelBuilder.Entity<UserDataGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__user_dat__3213E83FD9E5EB9C");

            entity.ToTable("user_data_groups", t => t.ExcludeFromMigrations());

            entity.HasIndex(e => e.GroupId, "user_data_groups_group_id_87f478f6");

            entity.HasIndex(e => e.UserdataId, "user_data_groups_userdata_id_ac66f47c");

            entity.HasIndex(e => new { e.UserdataId, e.GroupId }, "user_data_groups_userdata_id_group_id_44f6387f_uniq")
                .IsUnique()
                .HasFilter("([userdata_id] IS NOT NULL AND [group_id] IS NOT NULL)");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.GroupId).HasColumnName("group_id");
            entity.Property(e => e.UserdataId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("userdata_id");

            entity.HasOne(d => d.Group).WithMany(p => p.UserDataGroups)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_data_groups_group_id_87f478f6_fk_auth_group_id");

            entity.HasOne(d => d.Userdata).WithMany(p => p.UserDataGroups)
                .HasForeignKey(d => d.UserdataId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_data_groups_userdata_id_ac66f47c_fk_user_data_id");
        });

        modelBuilder.Entity<UserDataUserPermission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__user_dat__3213E83FAAF65E57");

            entity.ToTable("user_data_user_permissions", t => t.ExcludeFromMigrations());

            entity.HasIndex(e => e.PermissionId, "user_data_user_permissions_permission_id_160b9c16");

            entity.HasIndex(e => e.UserdataId, "user_data_user_permissions_userdata_id_d173d91b");

            entity.HasIndex(e => new { e.UserdataId, e.PermissionId }, "user_data_user_permissions_userdata_id_permission_id_c133d91d_uniq")
                .IsUnique()
                .HasFilter("([userdata_id] IS NOT NULL AND [permission_id] IS NOT NULL)");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PermissionId).HasColumnName("permission_id");
            entity.Property(e => e.UserdataId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("userdata_id");

            entity.HasOne(d => d.Permission).WithMany(p => p.UserDataUserPermissions)
                .HasForeignKey(d => d.PermissionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_data_user_permissions_permission_id_160b9c16_fk_auth_permission_id");

            entity.HasOne(d => d.Userdata).WithMany(p => p.UserDataUserPermissions)
                .HasForeignKey(d => d.UserdataId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_data_user_permissions_userdata_id_d173d91b_fk_user_data_id");
        });

        modelBuilder.Entity<UserData>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__user_dat__3213E83F9CCDDDD9");

            entity.ToTable("user_data", t => t.ExcludeFromMigrations());

            entity.HasIndex(e => e.PhoneNumber, "UQ__user_dat__A1936A6B4A46B413").IsUnique();

            entity.HasIndex(e => e.Username, "UQ__user_dat__F3DBC5722EBFB4C4").IsUnique();

            entity.Property(e => e.Id)
                .HasMaxLength(32)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("id");
            entity.Property(e => e.DateJoined).HasColumnName("date_joined");
            entity.Property(e => e.Email)
                .HasMaxLength(254)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(150)
                .HasColumnName("first_name");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.IsStaff).HasColumnName("is_staff");
            entity.Property(e => e.IsSuperuser).HasColumnName("is_superuser");
            entity.Property(e => e.LastLogin).HasColumnName("last_login");
            entity.Property(e => e.LastName)
                .HasMaxLength(150)
                .HasColumnName("last_name");
            entity.Property(e => e.Password)
                .HasMaxLength(128)
                .HasColumnName("password");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .HasColumnName("phone_number");
            entity.Property(e => e.Username)
                .HasMaxLength(150)
                .HasColumnName("username");
        });

        modelBuilder.Entity<TheatreScreen>(entity =>
        {
            entity.HasOne(e => e.Theatre)
                .WithMany(t => t.Screens)
                .HasForeignKey(e => e.TheatreId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.MovieShow)
                .WithOne(t => t.Screen)
                .HasForeignKey<TheatreScreen>(e => e.ShowId);
        });

        modelBuilder.Entity<Show>(entity =>
        {
            entity.HasOne(e => e.Movie)
                .WithMany(s => s.Shows)
                .IsRequired()
                .HasForeignKey(e => e.MovieId)
                .OnDelete(DeleteBehavior.NoAction);

            entity.HasOne(e => e.Screen)
                .WithOne(s => s.MovieShow)
                .HasForeignKey<Show>(e => e.ScreenId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Theatre)
                .WithMany(s => s.Shows)
                .HasForeignKey(e => e.TheatreId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
