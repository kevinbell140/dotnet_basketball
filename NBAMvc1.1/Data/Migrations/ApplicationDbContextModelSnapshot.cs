﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NBAMvc1._1.Data;

namespace NBAMvc1._1.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("NBAMvc1._1.Areas.Identity.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("NBAMvc1._1.Models.FantasyLeague", b =>
                {
                    b.Property<int>("FantasyLeagueID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CommissionerID");

                    b.Property<int>("CurrentWeek");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsFull");

                    b.Property<bool>("IsSet");

                    b.Property<string>("Name");

                    b.HasKey("FantasyLeagueID");

                    b.HasIndex("CommissionerID");

                    b.ToTable("FantasyLeague");
                });

            modelBuilder.Entity("NBAMvc1._1.Models.FantasyLeagueStandings", b =>
                {
                    b.Property<int>("FantasyLeagueStandingsID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Draws");

                    b.Property<int>("FantasyLeagueID");

                    b.Property<decimal>("FantasyPoints")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("FantasyPointsAgainst")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("GamesBack");

                    b.Property<int>("Losses");

                    b.Property<int?>("MyTeamID");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<int>("Wins");

                    b.HasKey("FantasyLeagueStandingsID");

                    b.HasIndex("FantasyLeagueID");

                    b.HasIndex("MyTeamID")
                        .IsUnique()
                        .HasFilter("[MyTeamID] IS NOT NULL");

                    b.ToTable("FantasyLeagueStandings");
                });

            modelBuilder.Entity("NBAMvc1._1.Models.FantasyMatchup", b =>
                {
                    b.Property<int>("FantasyMatchupID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AwayTeamID");

                    b.Property<decimal?>("AwayTeamScore")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("FantasyLeagueID");

                    b.Property<int?>("FantasyMatchupWeeksID");

                    b.Property<int?>("HomeTeamID");

                    b.Property<decimal?>("HomeTeamScore")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<bool>("Recorded");

                    b.Property<string>("Status");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<int>("Week");

                    b.HasKey("FantasyMatchupID");

                    b.HasIndex("AwayTeamID");

                    b.HasIndex("FantasyLeagueID");

                    b.HasIndex("FantasyMatchupWeeksID");

                    b.HasIndex("HomeTeamID");

                    b.ToTable("FantasyMatchup");
                });

            modelBuilder.Entity("NBAMvc1._1.Models.FantasyMatchupWeeks", b =>
                {
                    b.Property<int>("FantasyMatchupWeeksID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<int>("FantasyLeagueID");

                    b.Property<int>("WeekNum");

                    b.HasKey("FantasyMatchupWeeksID");

                    b.HasIndex("FantasyLeagueID");

                    b.ToTable("FantasyMatchupWeeks");
                });

            modelBuilder.Entity("NBAMvc1._1.Models.Game", b =>
                {
                    b.Property<int>("GameID");

                    b.Property<int?>("AwayTeamID");

                    b.Property<int?>("AwayTeamMoneyLine");

                    b.Property<int?>("AwayTeamScore");

                    b.Property<DateTime>("DateTime");

                    b.Property<int?>("HomeTeamID");

                    b.Property<int?>("HomeTeamMoneyLine");

                    b.Property<int?>("HomeTeamScore");

                    b.Property<decimal?>("OverUnder")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal?>("PointSpread")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("Season");

                    b.Property<int?>("SeasonType");

                    b.Property<string>("Status");

                    b.Property<DateTime?>("Updated");

                    b.HasKey("GameID");

                    b.HasIndex("AwayTeamID");

                    b.HasIndex("HomeTeamID");

                    b.ToTable("Game");
                });

            modelBuilder.Entity("NBAMvc1._1.Models.MyTeam", b =>
                {
                    b.Property<int>("MyTeamID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FantasyLeagueID");

                    b.Property<string>("Name");

                    b.Property<string>("UserID");

                    b.HasKey("MyTeamID");

                    b.HasIndex("FantasyLeagueID");

                    b.HasIndex("UserID");

                    b.ToTable("MyTeam");
                });

            modelBuilder.Entity("NBAMvc1._1.Models.News", b =>
                {
                    b.Property<int>("NewsID");

                    b.Property<string>("Author");

                    b.Property<string>("Content");

                    b.Property<int>("PlayerID");

                    b.Property<string>("Source");

                    b.Property<string>("Title");

                    b.Property<DateTime>("Updated");

                    b.Property<string>("Url");

                    b.HasKey("NewsID");

                    b.HasIndex("PlayerID");

                    b.ToTable("News");
                });

            modelBuilder.Entity("NBAMvc1._1.Models.Player", b =>
                {
                    b.Property<int>("PlayerID");

                    b.Property<DateTime?>("BirthDate");

                    b.Property<string>("FirstName");

                    b.Property<int?>("Height")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<int>("Jersey");

                    b.Property<string>("LastName");

                    b.Property<string>("PhotoUrl");

                    b.Property<string>("Position");

                    b.Property<string>("Status");

                    b.Property<int>("TeamID");

                    b.Property<string>("UsaTodayHeadshotUrl");

                    b.Property<int?>("Weight")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.HasKey("PlayerID");

                    b.HasIndex("TeamID");

                    b.ToTable("Player");
                });

            modelBuilder.Entity("NBAMvc1._1.Models.PlayerGameStats", b =>
                {
                    b.Property<int>("StatID");

                    b.Property<decimal>("Assists")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("BlockedShots")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("DefensiveRebounds")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("FieldGoalsAttempted")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("FieldGoalsMade")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("FieldGoalsPercentage")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("FreeThrowsAttempted")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("FreeThrowsMade")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("FreeThrowsPercentage")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("GameID");

                    b.Property<int>("Minutes");

                    b.Property<decimal>("OffensiveRebounds")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("PersonalFouls")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("PlayerID");

                    b.Property<decimal>("PlusMinus")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("Points")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("Rebounds")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int?>("Started");

                    b.Property<decimal>("Steals")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("ThreePointersAttempted")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("ThreePointersMade")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("ThreePointersPercentage")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("Turnovers")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<DateTime>("Updated");

                    b.HasKey("StatID");

                    b.HasIndex("GameID");

                    b.HasIndex("PlayerID");

                    b.ToTable("PlayerGameStats");
                });

            modelBuilder.Entity("NBAMvc1._1.Models.PlayerMyTeam", b =>
                {
                    b.Property<int>("PlayerID");

                    b.Property<int>("MyTeamID");

                    b.HasKey("PlayerID", "MyTeamID");

                    b.HasIndex("MyTeamID");

                    b.ToTable("PlayerMyTeam");
                });

            modelBuilder.Entity("NBAMvc1._1.Models.PlayerSeasonStats", b =>
                {
                    b.Property<int>("StatID");

                    b.Property<decimal>("Assists")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("BlockedShots")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("FieldGoalsPercentage")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("FreeThrowsPercentage")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("Games");

                    b.Property<int>("PlayerID");

                    b.Property<decimal>("Points")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("Rebounds")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("Steals")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("ThreePointersMade")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("Turnovers")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("StatID");

                    b.HasIndex("PlayerID")
                        .IsUnique();

                    b.ToTable("PlayerSeasonStats");
                });

            modelBuilder.Entity("NBAMvc1._1.Models.Standings", b =>
                {
                    b.Property<int>("TeamID");

                    b.Property<int>("AwayLosses");

                    b.Property<int>("AwayWins");

                    b.Property<int>("ConferenceLosses");

                    b.Property<int>("ConferenceWins");

                    b.Property<int>("DivisionLosses");

                    b.Property<int>("DivisionWins");

                    b.Property<decimal>("GamesBack")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("HomeLosses");

                    b.Property<int>("HomeWins");

                    b.Property<int>("LastTenLosses");

                    b.Property<int>("LastTenWins");

                    b.Property<int>("Losses");

                    b.Property<decimal>("Percentage")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("Streak");

                    b.Property<int>("Wins");

                    b.HasKey("TeamID");

                    b.ToTable("Standings");
                });

            modelBuilder.Entity("NBAMvc1._1.Models.Team", b =>
                {
                    b.Property<int>("TeamID");

                    b.Property<string>("City");

                    b.Property<string>("Conference");

                    b.Property<string>("Division");

                    b.Property<string>("Key");

                    b.Property<string>("LeagueID");

                    b.Property<string>("Name");

                    b.Property<string>("PrimaryColor");

                    b.Property<string>("SecondaryColor");

                    b.Property<string>("TertiaryColor");

                    b.Property<DateTime>("Updated");

                    b.Property<string>("WikipediaLogoUrl");

                    b.HasKey("TeamID");

                    b.ToTable("Team");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("NBAMvc1._1.Areas.Identity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("NBAMvc1._1.Areas.Identity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NBAMvc1._1.Areas.Identity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("NBAMvc1._1.Areas.Identity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NBAMvc1._1.Models.FantasyLeague", b =>
                {
                    b.HasOne("NBAMvc1._1.Areas.Identity.ApplicationUser", "ComissionerNav")
                        .WithMany()
                        .HasForeignKey("CommissionerID");
                });

            modelBuilder.Entity("NBAMvc1._1.Models.FantasyLeagueStandings", b =>
                {
                    b.HasOne("NBAMvc1._1.Models.FantasyLeague", "FantasyLeagueNav")
                        .WithMany("FantasyLeagueStandingsNav")
                        .HasForeignKey("FantasyLeagueID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NBAMvc1._1.Models.MyTeam", "MyTeamNav")
                        .WithOne("FantasyLeagueStandingsNav")
                        .HasForeignKey("NBAMvc1._1.Models.FantasyLeagueStandings", "MyTeamID");
                });

            modelBuilder.Entity("NBAMvc1._1.Models.FantasyMatchup", b =>
                {
                    b.HasOne("NBAMvc1._1.Models.MyTeam", "AwayTeamNav")
                        .WithMany("AwayMatchupNav")
                        .HasForeignKey("AwayTeamID");

                    b.HasOne("NBAMvc1._1.Models.FantasyLeague", "FantasyLeagueNav")
                        .WithMany()
                        .HasForeignKey("FantasyLeagueID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NBAMvc1._1.Models.FantasyMatchupWeeks")
                        .WithMany("FantasyMatchupsNav")
                        .HasForeignKey("FantasyMatchupWeeksID");

                    b.HasOne("NBAMvc1._1.Models.MyTeam", "HomeTeamNav")
                        .WithMany("HomeMatchupNav")
                        .HasForeignKey("HomeTeamID");
                });

            modelBuilder.Entity("NBAMvc1._1.Models.FantasyMatchupWeeks", b =>
                {
                    b.HasOne("NBAMvc1._1.Models.FantasyLeague", "FantasyLeagueNav")
                        .WithMany("FantasyMatchupWeeksNav")
                        .HasForeignKey("FantasyLeagueID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NBAMvc1._1.Models.Game", b =>
                {
                    b.HasOne("NBAMvc1._1.Models.Team", "AwayTeamNav")
                        .WithMany("AwayGamesNav")
                        .HasForeignKey("AwayTeamID");

                    b.HasOne("NBAMvc1._1.Models.Team", "HomeTeamNav")
                        .WithMany("HomeGamesNav")
                        .HasForeignKey("HomeTeamID");
                });

            modelBuilder.Entity("NBAMvc1._1.Models.MyTeam", b =>
                {
                    b.HasOne("NBAMvc1._1.Models.FantasyLeague", "FantasyLeagueNav")
                        .WithMany("TeamsNav")
                        .HasForeignKey("FantasyLeagueID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NBAMvc1._1.Areas.Identity.ApplicationUser", "UserNav")
                        .WithMany("MyTeamNav")
                        .HasForeignKey("UserID");
                });

            modelBuilder.Entity("NBAMvc1._1.Models.News", b =>
                {
                    b.HasOne("NBAMvc1._1.Models.Player", "PlayerNav")
                        .WithMany("NewsNav")
                        .HasForeignKey("PlayerID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NBAMvc1._1.Models.Player", b =>
                {
                    b.HasOne("NBAMvc1._1.Models.Team", "TeamNav")
                        .WithMany("PlayersNav")
                        .HasForeignKey("TeamID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NBAMvc1._1.Models.PlayerGameStats", b =>
                {
                    b.HasOne("NBAMvc1._1.Models.Game", "GameNav")
                        .WithMany("PlayerGameStatsNav")
                        .HasForeignKey("GameID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NBAMvc1._1.Models.Player", "PlayerNav")
                        .WithMany("GameStatsNav")
                        .HasForeignKey("PlayerID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NBAMvc1._1.Models.PlayerMyTeam", b =>
                {
                    b.HasOne("NBAMvc1._1.Models.MyTeam", "MyTeamNav")
                        .WithMany("PlayerMyTeamNav")
                        .HasForeignKey("MyTeamID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NBAMvc1._1.Models.Player", "PlayerNav")
                        .WithMany("PlayerMyTeamNav")
                        .HasForeignKey("PlayerID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NBAMvc1._1.Models.PlayerSeasonStats", b =>
                {
                    b.HasOne("NBAMvc1._1.Models.Player", "PlayNav")
                        .WithOne("StatsNav")
                        .HasForeignKey("NBAMvc1._1.Models.PlayerSeasonStats", "PlayerID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NBAMvc1._1.Models.Standings", b =>
                {
                    b.HasOne("NBAMvc1._1.Models.Team", "TeamNav")
                        .WithOne("RecordNav")
                        .HasForeignKey("NBAMvc1._1.Models.Standings", "TeamID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
