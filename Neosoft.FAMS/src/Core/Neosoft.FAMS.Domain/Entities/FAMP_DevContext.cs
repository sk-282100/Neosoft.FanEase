using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Neosoft.FAMS.Domain.Entities
{
    public partial class FAMP_DevContext : DbContext
    {
        public FAMP_DevContext()
        {
        }

        public FAMP_DevContext(DbContextOptions<FAMP_DevContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdvertisementDetail> AdvertisementDetails { get; set; }
        public virtual DbSet<AdvertisementPlacementDetail> AdvertisementPlacementDetails { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual DbSet<CampaignAdvertiseMapping> CampaignAdvertiseMappings { get; set; }
        public virtual DbSet<CampaignDetail> CampaignDetails { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Configuration> Configurations { get; set; }
        public virtual DbSet<ContentCreatorDetail> ContentCreatorDetails { get; set; }
        public virtual DbSet<ContentTypeDetail> ContentTypeDetails { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Execution> Executions { get; set; }
        public virtual DbSet<Failure> Failures { get; set; }
        public virtual DbSet<HealthCheckExecutionEntry> HealthCheckExecutionEntries { get; set; }
        public virtual DbSet<HealthCheckExecutionHistory> HealthCheckExecutionHistories { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<PasswordResetRequest> PasswordResetRequests { get; set; }
        public virtual DbSet<RefreshToken> RefreshTokens { get; set; }
        public virtual DbSet<RoleType> RoleTypes { get; set; }
        public virtual DbSet<TemplateDetail> TemplateDetails { get; set; }
        public virtual DbSet<TemplateFieldDetail> TemplateFieldDetails { get; set; }
        public virtual DbSet<TemplateVideoMapping> TemplateVideoMappings { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<VideoDetail> VideoDetails { get; set; }
        public virtual DbSet<VideoStatisticsDetail> VideoStatisticsDetails { get; set; }
        public virtual DbSet<ViewerDetail> ViewerDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=180.149.240.247;Initial Catalog=FAMP_Dev;Persist Security Info=True;User ID=famp_dbusers;Password=famp123!@#;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("famp_dbusers")
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AdvertisementDetail>(entity =>
            {
                entity.HasKey(e => e.AdvertisementId);

                entity.ToTable("AdvertisementDetail", "dbo");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.Property(e => e.Url).HasColumnName("URL");
            });

            modelBuilder.Entity<AdvertisementPlacementDetail>(entity =>
            {
                entity.HasKey(e => e.AdvertisementPlacementId);

                entity.ToTable("AdvertisementPlacementDetail", "dbo");

                entity.Property(e => e.AdvertisementPlacement).HasMaxLength(50);
            });

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId, "IX_AspNetUserRoles_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<CampaignAdvertiseMapping>(entity =>
            {
                entity.ToTable("CampaignAdvertiseMapping", "dbo");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<CampaignDetail>(entity =>
            {
                entity.HasKey(e => e.CampaignId);

                entity.ToTable("CampaignDetail", "dbo");

                entity.Property(e => e.CampaignName).HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryId).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("City");

                entity.Property(e => e.CityName).HasMaxLength(50);
            });

            modelBuilder.Entity<Configuration>(entity =>
            {
                entity.Property(e => e.DiscoveryService).HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Uri)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<ContentCreatorDetail>(entity =>
            {
                entity.HasKey(e => e.ContentCreatorId);

                entity.ToTable("ContentCreatorDetail", "dbo");

                entity.Property(e => e.AdditionalRemark).HasMaxLength(500);

                entity.Property(e => e.Address1).HasMaxLength(100);

                entity.Property(e => e.Address2).HasMaxLength(100);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatorName).HasMaxLength(50);

                entity.Property(e => e.EmailId).HasMaxLength(50);

                entity.Property(e => e.MobileNumber)
                    .HasMaxLength(15)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<ContentTypeDetail>(entity =>
            {
                entity.HasKey(e => e.ContentTypeId);

                entity.ToTable("ContentTypeDetail", "dbo");

                entity.Property(e => e.ContentType).HasMaxLength(50);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Country");

                entity.Property(e => e.CountryName).HasMaxLength(50);
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.HasIndex(e => e.CategoryId, "IX_Events_CategoryId");

                entity.Property(e => e.EventId).ValueGeneratedNever();

                entity.Property(e => e.Artist)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedBy).HasMaxLength(450);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.ImageUrl)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.CategoryId);
            });

            modelBuilder.Entity<Execution>(entity =>
            {
                entity.Property(e => e.DiscoveryService).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Uri)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<Failure>(entity =>
            {
                entity.Property(e => e.HealthCheckName)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<HealthCheckExecutionEntry>(entity =>
            {
                entity.HasIndex(e => e.HealthCheckExecutionId, "IX_HealthCheckExecutionEntries_HealthCheckExecutionId");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(d => d.HealthCheckExecution)
                    .WithMany(p => p.HealthCheckExecutionEntries)
                    .HasForeignKey(d => d.HealthCheckExecutionId);
            });

            modelBuilder.Entity<HealthCheckExecutionHistory>(entity =>
            {
                entity.HasIndex(e => e.HealthCheckExecutionId, "IX_HealthCheckExecutionHistories_HealthCheckExecutionId");

                entity.Property(e => e.Name).HasMaxLength(500);

                entity.HasOne(d => d.HealthCheckExecution)
                    .WithMany(p => p.HealthCheckExecutionHistories)
                    .HasForeignKey(d => d.HealthCheckExecutionId);
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.ToTable("Login", "dbo");

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Username).HasMaxLength(50);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);
            });

            modelBuilder.Entity<PasswordResetRequest>(entity =>
            {
                entity.HasKey(e => e.RequestId);

                entity.ToTable("PasswordResetRequest", "dbo");

                entity.Property(e => e.ExpiredOn).HasColumnType("datetime");

                entity.Property(e => e.RequestedOn).HasColumnType("datetime");

                entity.Property(e => e.ValidCode)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<RefreshToken>(entity =>
            {
                entity.HasKey(e => new { e.ApplicationUserId, e.Id });

                entity.ToTable("RefreshToken");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.ApplicationUser)
                    .WithMany(p => p.RefreshTokens)
                    .HasForeignKey(d => d.ApplicationUserId);
            });

            modelBuilder.Entity<RoleType>(entity =>
            {
                entity.HasKey(e => e.RoleId);

                entity.ToTable("RoleType", "dbo");

                entity.Property(e => e.RoleType1)
                    .HasMaxLength(50)
                    .HasColumnName("RoleType");
            });

            modelBuilder.Entity<TemplateDetail>(entity =>
            {
                entity.HasKey(e => e.TemplateId);

                entity.ToTable("TemplateDetail", "dbo");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.TemplateName).HasMaxLength(50);
            });

            modelBuilder.Entity<TemplateFieldDetail>(entity =>
            {
                entity.HasKey(e => e.TemplateFieldId);

                entity.ToTable("TemplateFieldDetail", "dbo");

                entity.Property(e => e.TemplateFieldId).ValueGeneratedNever();
            });

            modelBuilder.Entity<TemplateVideoMapping>(entity =>
            {
                entity.ToTable("TemplateVideoMapping", "dbo");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<VideoDetail>(entity =>
            {
                entity.HasKey(e => e.VideoId);

                entity.ToTable("VideoDetail", "dbo");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.Property(e => e.VideoUrl).HasColumnName("VideoURL");
            });

            modelBuilder.Entity<VideoStatisticsDetail>(entity =>
            {
                entity.HasKey(e => e.VideoStatisticsId);

                entity.ToTable("VideoStatisticsDetail", "dbo");

                entity.Property(e => e.ClickedOn).HasColumnType("datetime");

                entity.Property(e => e.LikeOn).HasColumnType("datetime");

                entity.Property(e => e.SharedOn).HasColumnType("datetime");

                entity.Property(e => e.ViewOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<ViewerDetail>(entity =>
            {
                entity.HasKey(e => e.ViewerId);

                entity.ToTable("ViewerDetail", "dbo");

                entity.Property(e => e.Address1).HasMaxLength(100);

                entity.Property(e => e.Address2).HasMaxLength(100);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.EmailId).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.MiddleName).HasMaxLength(50);

                entity.Property(e => e.MobileNumber)
                    .HasMaxLength(15)
                    .IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
