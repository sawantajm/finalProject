using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ExamSystem.Models
{
    public partial class OnlineExamContext : DbContext
    {
        public OnlineExamContext()
        {
        }

        public OnlineExamContext(DbContextOptions<OnlineExamContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AddQuestion> AddQuestions { get; set; }
        public virtual DbSet<AdminLogin> AdminLogins { get; set; }
        public virtual DbSet<Exam> Exams { get; set; }
        public virtual DbSet<ExamDetail> ExamDetails { get; set; }
        public virtual DbSet<Filename> Filenames { get; set; }
        public virtual DbSet<Level> Levels { get; set; }
        public virtual DbSet<QuestionDetail> QuestionDetails { get; set; }
        public virtual DbSet<Registration> Registrations { get; set; }
        public virtual DbSet<ReportDetail> ReportDetails { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }

       /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=AJ-PC\\SQLEXPRESS;Database=OnlineExam;Trusted_Connection=True;");
            }
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AddQuestion>(entity =>
            {
                entity.HasKey(e => e.QuestionNumber)
                    .HasName("PK__AddQuest__3A46928632298371");

                entity.ToTable("AddQuestion");

                entity.Property(e => e.QuestionNumber).ValueGeneratedNever();

                entity.Property(e => e.Correctanswer)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Option1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Option2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Option3)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Option4)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Question).HasMaxLength(255);

                entity.Property(e => e.StudentResponse)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Student_response");
            });

            modelBuilder.Entity<AdminLogin>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Admin_Login");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Exam>(entity =>
            {
                entity.ToTable("Exam");

                entity.Property(e => e.ExamId)
                    .ValueGeneratedNever()
                    .HasColumnName("Exam_id");

                entity.Property(e => e.FileId).HasColumnName("File_id");

                entity.Property(e => e.QuestionId).HasColumnName("Question_id");

                entity.Property(e => e.Questions).HasMaxLength(255);

                entity.Property(e => e.SubjectId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Subject_id");
            });

            modelBuilder.Entity<ExamDetail>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.ExamId).HasColumnName("Exam_id");

                entity.Property(e => e.LevelId).HasColumnName("Level_id");

                entity.HasOne(d => d.Exam)
                    .WithMany()
                    .HasForeignKey(d => d.ExamId)
                    .HasConstraintName("FK__ExamDetai__Exam___3F466844");

                entity.HasOne(d => d.Level)
                    .WithMany()
                    .HasForeignKey(d => d.LevelId)
                    .HasConstraintName("FK__ExamDetai__Level__3E52440B");
            });

            modelBuilder.Entity<Filename>(entity =>
            {
                entity.HasKey(e => e.FileId)
                    .HasName("PK__Filename__0FFECDEECF8C21F4");

                entity.ToTable("Filename");

                entity.Property(e => e.FileId)
                    .ValueGeneratedNever()
                    .HasColumnName("File_id");

                entity.Property(e => e.FileName1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("File_Name");
            });

            modelBuilder.Entity<Level>(entity =>
            {
                entity.ToTable("Level");

                entity.Property(e => e.LevelId)
                    .ValueGeneratedNever()
                    .HasColumnName("Level_id");

                entity.Property(e => e.LevelName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Level_Name");
            });

            modelBuilder.Entity<QuestionDetail>(entity =>
            {
                entity.HasKey(e => e.QuestionId)
                    .HasName("PK__Question__B0B3E0BE12B6EFF5");

                entity.Property(e => e.QuestionId).HasColumnName("Question_id");

                entity.Property(e => e.Correctanswers)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FileId).HasColumnName("File_id");

                entity.Property(e => e.LevelId).HasColumnName("Level_id");

                entity.Property(e => e.Option1)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Option2)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Option3)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Option4)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Question).HasMaxLength(255);

                entity.Property(e => e.StudentResponse)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Student_response");

                entity.Property(e => e.SubjectId).HasColumnName("Subject_id");

                entity.HasOne(d => d.File)
                    .WithMany(p => p.QuestionDetails)
                    .HasForeignKey(d => d.FileId)
                    .HasConstraintName("FK__QuestionD__File___03F0984C");

                entity.HasOne(d => d.Level)
                    .WithMany(p => p.QuestionDetails)
                    .HasForeignKey(d => d.LevelId)
                    .HasConstraintName("FK__QuestionD__Level__05D8E0BE");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.QuestionDetails)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK__QuestionD__Subje__04E4BC85");
            });

            modelBuilder.Entity<Registration>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Registra__206A9DF8DD5086C8");

                entity.ToTable("Registration");

                entity.HasIndex(e => e.Email, "UQ__Registra__A9D1053462C6C73A")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("User_id");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fullname)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Mobile_no");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Qualification)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.YearOfCompletion)
                    .HasColumnType("date")
                    .HasColumnName("Year_of_Completion");
            });

            modelBuilder.Entity<ReportDetail>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.LevelId).HasColumnName("Level_id");

                entity.Property(e => e.SubjectId).HasColumnName("Subject_id");

                entity.Property(e => e.UserId).HasColumnName("User_id");

                entity.HasOne(d => d.Level)
                    .WithMany()
                    .HasForeignKey(d => d.LevelId)
                    .HasConstraintName("FK__ReportDet__Level__489AC854");

                entity.HasOne(d => d.Subject)
                    .WithMany()
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK__ReportDet__Subje__498EEC8D");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__ReportDet__User___47A6A41B");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("Subject");

                entity.Property(e => e.SubjectId)
                    .ValueGeneratedNever()
                    .HasColumnName("Subject_id");

                entity.Property(e => e.SubjectName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Subject_name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
